using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyYTe
{
    public partial class FormPhongKham : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=VIETHOANG\\MSSQLSERVER01;Initial Catalog=QuanLyYTe;Integrated Security=True");
        SqlDataAdapter da;
        DataTable dt;

        public FormPhongKham()
        {
            InitializeComponent();
        }

        private void FormPhongKham_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            da = new SqlDataAdapter("SELECT * FROM MedicalClinic", conn);
            dt = new DataTable();
            da.Fill(dt);
            dgvPhongKham.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO MedicalClinic (MaPhongKham, TenPhongKham) VALUES (@MaPK, @TenPK)", conn);
            cmd.Parameters.AddWithValue("@MaPK", txtMaPK.Text);
            cmd.Parameters.AddWithValue("@TenPK", txtTenPK.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadData();
            MessageBox.Show("Thêm phòng khám thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE MedicalClinic SET TenPhongKham=@TenPK WHERE MaPhongKham=@MaPK", conn);
            cmd.Parameters.AddWithValue("@MaPK", txtMaPK.Text);
            cmd.Parameters.AddWithValue("@TenPK", txtTenPK.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadData();
            MessageBox.Show("Cập nhật phòng khám thành công!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM MedicalClinic WHERE MaPhongKham=@MaPK", conn);
            cmd.Parameters.AddWithValue("@MaPK", txtMaPK.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadData();
            MessageBox.Show("Xóa phòng khám thành công!");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaPK.Clear();
            txtTenPK.Clear();
        }

        public static string ShowInputDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 150,
                Text = caption,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label lblText = new Label() { Left = 10, Top = 20, Text = text, Width = 360 };
            TextBox input = new TextBox() { Left = 10, Top = 50, Width = 360 };
            Button ok = new Button() { Text = "OK", Left = 210, Width = 75, Top = 80, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Cancel", Left = 295, Width = 75, Top = 80, DialogResult = DialogResult.Cancel };

            prompt.Controls.Add(lblText);
            prompt.Controls.Add(input);
            prompt.Controls.Add(ok);
            prompt.Controls.Add(cancel);

            prompt.AcceptButton = ok;
            prompt.CancelButton = cancel;

            return prompt.ShowDialog() == DialogResult.OK ? input.Text : "";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (dt == null)
            {
                MessageBox.Show("Dữ liệu chưa được tải!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string keyword = ShowInputDialog("Nhập thông tin tìm kiếm (Mã phòng khám hoặc Tên phòng khám):", "Tìm kiếm");
            
            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvPhongKham.DataSource = dt;
                return;
            }

            try
            {
                string tempPath = System.IO.Path.GetTempPath();
                string fileName = "MedicalClinic_Search_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                XSLTSearchHelper.TimKiemXSLTFromDataTable(dt, keyword, tempPath + fileName, "MedicalClinic", "MedicalClinic");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPhongKham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhongKham.Rows[e.RowIndex];
                txtMaPK.Text = row.Cells["MaPhongKham"].Value.ToString();
                txtTenPK.Text = row.Cells["TenPhongKham"].Value.ToString();
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            DataConversionHelper.HandleConversion(cbFrom, cbTo, conn, "MedicalClinic", LoadData);
        }

        private void btnXuatXSLT_Click(object sender, EventArgs e)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string tempPath = System.IO.Path.GetTempPath();
                string fileName = "MedicalClinic_Export_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                XSLTSearchHelper.XuatXSLTFromDataTable(dt, tempPath + fileName, "MedicalClinic", "MedicalClinic");
                MessageBox.Show("Xuất dữ liệu XSLT thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất dữ liệu XSLT: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
