using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QuanLyYTe
{
    /// <summary>
    /// Hỗ trợ chuyển đổi dữ liệu giữa SQL, XML và MySQL (thông qua file script).
    /// </summary>
    public static class DataConversionHelper
    {
        public static void HandleConversion(ComboBox cbFrom, ComboBox cbTo, SqlConnection sqlConnection, string tableName, Action reloadAction = null)
        {
            string from = cbFrom.SelectedItem as string;
            string to = cbTo.SelectedItem as string;

            if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ định dạng nguồn và đích!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (from == to)
            {
                MessageBox.Show("Định dạng nguồn và đích đang trùng nhau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                switch (from + "->" + to)
                {
                    case "SQL->XML":
                        ExportSqlToXml(sqlConnection, tableName);
                        break;
                    case "XML->SQL":
                        ImportXmlToSql(sqlConnection, tableName);
                        reloadAction?.Invoke();
                        break;
                    case "XML->MySQL":
                        ExportXmlToMySqlScript(tableName);
                        break;
                    case "MySQL->XML":
                        ImportMySqlScriptToXml(tableName);
                        reloadAction?.Invoke();
                        break;
                    default:
                        MessageBox.Show("Kết hợp chuyển đổi này chưa được hỗ trợ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi chuyển đổi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void ExportSqlToXml(SqlConnection conn, string tableName)
        {
            using (SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "XML Files (*.xml)|*.xml",
                FileName = $"{tableName}_{DateTime.Now:yyyyMMddHHmmss}.xml"
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                DataTable table = new DataTable(tableName);
                using (SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM {tableName}", conn))
                {
                    adapter.Fill(table);
                }

                table.WriteXml(sfd.FileName, XmlWriteMode.WriteSchema);
                MessageBox.Show("Xuất dữ liệu SQL sang XML thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static void ImportXmlToSql(SqlConnection conn, string tableName)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "XML Files (*.xml)|*.xml" })
            {
                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                DataSet ds = new DataSet();
                ds.ReadXml(ofd.FileName);
                if (ds.Tables.Count == 0)
                    throw new InvalidOperationException("Không tìm thấy dữ liệu trong file XML.");

                DataTable incoming = ds.Tables[0];

                DialogResult confirm = MessageBox.Show("Toàn bộ dữ liệu bảng sẽ được thay thế. Bạn chắc chắn muốn tiếp tục?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes)
                    return;

                bool wasOpen = conn.State == ConnectionState.Open;
                if (!wasOpen)
                    conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand deleteCmd = new SqlCommand($"DELETE FROM {tableName}", conn, transaction))
                        {
                            deleteCmd.ExecuteNonQuery();
                        }

                        using (SqlBulkCopy bulk = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction)
                        {
                            DestinationTableName = tableName
                        })
                        {
                            foreach (DataColumn column in incoming.Columns)
                            {
                                bulk.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                            }
                            bulk.WriteToServer(incoming);
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                    finally
                    {
                        if (!wasOpen)
                            conn.Close();
                    }
                }

                MessageBox.Show("Nhập dữ liệu XML vào SQL thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static void ExportXmlToMySqlScript(string tableName)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "XML Files (*.xml)|*.xml" })
            {
                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                DataSet ds = new DataSet();
                ds.ReadXml(ofd.FileName);
                if (ds.Tables.Count == 0)
                    throw new InvalidOperationException("Không tìm thấy dữ liệu trong file XML.");

                DataTable table = ds.Tables[0];

                using (SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "SQL Script (*.sql)|*.sql",
                    FileName = $"{tableName}_{DateTime.Now:yyyyMMddHHmmss}.sql"
                })
                {
                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    string script = BuildMySqlInsertScript(tableName, table);
                    File.WriteAllText(sfd.FileName, script, Encoding.UTF8);
                    MessageBox.Show("Đã chuyển XML sang script MySQL!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private static void ImportMySqlScriptToXml(string tableName)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "SQL Script (*.sql)|*.sql" })
            {
                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                string content = File.ReadAllText(ofd.FileName, Encoding.UTF8);
                DataTable table = ParseMySqlInsertScript(tableName, content);

                using (SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "XML Files (*.xml)|*.xml",
                    FileName = $"{tableName}_{DateTime.Now:yyyyMMddHHmmss}_from_mysql.xml"
                })
                {
                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    table.WriteXml(sfd.FileName, XmlWriteMode.WriteSchema);
                    MessageBox.Show("Đã chuyển script MySQL sang XML!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private static string BuildMySqlInsertScript(string tableName, DataTable table)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"-- Script được tạo từ ứng dụng lúc {DateTime.Now:G}");
            sb.AppendLine($"-- Bảng: {tableName}");

            string columnList = BuildColumnList(table.Columns);

            foreach (DataRow row in table.Rows)
            {
                List<string> formattedValues = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    formattedValues.Add(FormatMySqlValue(row[column]));
                }

                sb.AppendLine($"INSERT INTO `{tableName}` ({columnList}) VALUES ({string.Join(", ", formattedValues)});");
            }

            return sb.ToString();
        }

        private static string BuildColumnList(DataColumnCollection columns)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < columns.Count; i++)
            {
                if (i > 0)
                    sb.Append(", ");
                sb.Append('`').Append(columns[i].ColumnName).Append('`');
            }
            return sb.ToString();
        }

        private static string FormatMySqlValue(object value)
        {
            if (value == null || value == DBNull.Value)
                return "NULL";

            Type type = value.GetType();
            if (type == typeof(int) || type == typeof(long) || type == typeof(short) ||
                type == typeof(byte) || type == typeof(decimal) || type == typeof(double) || type == typeof(float))
            {
                return Convert.ToString(value, CultureInfo.InvariantCulture);
            }

            if (type == typeof(bool))
                return (bool)value ? "1" : "0";

            if (type == typeof(DateTime))
                return $"'{((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}'";

            string escaped = value.ToString().Replace("'", "''");
            return $"'{escaped}'";
        }

        private static DataTable ParseMySqlInsertScript(string tableName, string scriptContent)
        {
            DataTable table = null;
            using (StringReader reader = new StringReader(scriptContent))
            {
                var statementBuilder = new StringBuilder();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string trimmed = line.Trim();
                    if (string.IsNullOrWhiteSpace(trimmed) || trimmed.StartsWith("--"))
                        continue;

                    statementBuilder.AppendLine(trimmed);

                    if (trimmed.EndsWith(";", StringComparison.Ordinal))
                    {
                        string statement = statementBuilder.ToString();
                        statementBuilder.Clear();

                        if (!IsInsertStatementForTable(statement, tableName))
                            continue;

                        ProcessInsertStatement(statement, tableName, ref table);
                    }
                }
            }

            if (table == null || table.Rows.Count == 0)
                throw new InvalidOperationException($"Không tìm thấy câu INSERT hợp lệ dành cho bảng {tableName} trong script MySQL.");

            return table;
        }

        private static bool IsInsertStatementForTable(string statement, string tableName)
        {
            if (string.IsNullOrEmpty(statement))
                return false;

            string needle = $"INSERT INTO `{tableName}`";
            if (statement.IndexOf(needle, StringComparison.OrdinalIgnoreCase) >= 0)
                return true;

            needle = $"INSERT INTO {tableName}";
            return statement.IndexOf(needle, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static void ProcessInsertStatement(string statement, string tableName, ref DataTable table)
        {
            int insertIndex = statement.IndexOf("INSERT", StringComparison.OrdinalIgnoreCase);
            if (insertIndex < 0)
                return;

            int columnsStart = statement.IndexOf('(', insertIndex);
            if (columnsStart < 0)
                throw new InvalidOperationException("Không xác định được danh sách cột trong câu INSERT.");

            int columnsEnd = statement.IndexOf(')', columnsStart + 1);
            if (columnsEnd < 0)
                throw new InvalidOperationException("Câu INSERT thiếu dấu ) kết thúc phần cột.");

            string columnPart = statement.Substring(columnsStart + 1, columnsEnd - columnsStart - 1);
            string[] columns = columnPart.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < columns.Length; i++)
            {
                columns[i] = columns[i].Trim().Trim('`');
            }

            if (table == null)
            {
                table = new DataTable(tableName);
                foreach (string col in columns)
                {
                    if (!table.Columns.Contains(col))
                    {
                        table.Columns.Add(col);
                    }
                }
            }

            int valuesIndex = statement.IndexOf("VALUES", columnsEnd, StringComparison.OrdinalIgnoreCase);
            if (valuesIndex < 0)
                throw new InvalidOperationException("Không tìm thấy từ khóa VALUES trong câu INSERT.");

            string valuesSegment = statement.Substring(valuesIndex + "VALUES".Length).Trim();
            if (valuesSegment.EndsWith(";", StringComparison.Ordinal))
                valuesSegment = valuesSegment.Substring(0, valuesSegment.Length - 1);
            valuesSegment = valuesSegment.Trim();

            List<string> rowBlocks = ExtractRowValueBlocks(valuesSegment);
            foreach (string block in rowBlocks)
            {
                List<string> values = SplitValues(block.Trim());
                DataRow row = table.NewRow();
                for (int i = 0; i < columns.Length && i < values.Count; i++)
                {
                    row[i] = NormalizeValue(values[i]);
                }
                table.Rows.Add(row);
            }
        }

        private static List<string> ExtractRowValueBlocks(string valuesSegment)
        {
            var rows = new List<string>();
            var current = new StringBuilder();
            bool inQuotes = false;
            int depth = 0;

            for (int i = 0; i < valuesSegment.Length; i++)
            {
                char c = valuesSegment[i];
                bool isQuote = c == '\'' && (i == 0 || valuesSegment[i - 1] != '\\');
                if (isQuote)
                {
                    if (inQuotes && i + 1 < valuesSegment.Length && valuesSegment[i + 1] == '\'')
                    {
                        if (depth > 0)
                            current.Append("''");
                        i++;
                        continue;
                    }

                    inQuotes = !inQuotes;
                    if (depth > 0)
                        current.Append(c);
                    continue;
                }

                if (!inQuotes)
                {
                    if (c == '(')
                    {
                        if (depth > 0)
                            current.Append(c);
                        depth++;
                        continue;
                    }
                    if (c == ')')
                    {
                        depth--;
                        if (depth == 0)
                        {
                            rows.Add(current.ToString().Trim());
                            current.Clear();
                            continue;
                        }
                        else
                        {
                            current.Append(c);
                            continue;
                        }
                    }
                }

                if (depth > 0)
                {
                    current.Append(c);
                }
            }

            return rows;
        }

        private static List<string> SplitValues(string valuesPart)
        {
            var values = new List<string>();
            var current = new StringBuilder();
            bool inQuotes = false;

            for (int i = 0; i < valuesPart.Length; i++)
            {
                char c = valuesPart[i];
                bool isQuote = c == '\'' && (i == 0 || valuesPart[i - 1] != '\\');

                if (isQuote)
                {
                    if (inQuotes && i + 1 < valuesPart.Length && valuesPart[i + 1] == '\'')
                    {
                        current.Append("''");
                        i++;
                        continue;
                    }

                    inQuotes = !inQuotes;
                    current.Append(c);
                    continue;
                }

                if (c == ',' && !inQuotes)
                {
                    values.Add(current.ToString().Trim());
                    current.Clear();
                    continue;
                }

                current.Append(c);
            }

            if (current.Length > 0)
            {
                values.Add(current.ToString().Trim());
            }

            return values;
        }

        private static object NormalizeValue(string valueToken)
        {
            if (string.IsNullOrWhiteSpace(valueToken))
                return DBNull.Value;

            valueToken = valueToken.Trim();

            if (string.Equals(valueToken, "NULL", StringComparison.OrdinalIgnoreCase))
                return DBNull.Value;

            if (valueToken.StartsWith("'") && valueToken.EndsWith("'") && valueToken.Length >= 2)
            {
                string unescaped = valueToken.Substring(1, valueToken.Length - 2).Replace("''", "'");

                if (DateTime.TryParse(unescaped, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime quotedDate))
                    return quotedDate;

                return unescaped;
            }

            if (int.TryParse(valueToken, NumberStyles.Integer, CultureInfo.InvariantCulture, out int intResult))
                return intResult;

            if (long.TryParse(valueToken, NumberStyles.Integer, CultureInfo.InvariantCulture, out long longResult))
                return longResult;

            if (decimal.TryParse(valueToken, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal decimalResult))
                return decimalResult;

            if (DateTime.TryParse(valueToken, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateResult))
                return dateResult;

            return valueToken;
        }
    }
}
