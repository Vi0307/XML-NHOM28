using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyYTe
{
    public partial class FormQuanLyBenhNhan : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=VIETHOANG\\MSSQLSERVER01;Initial Catalog=QuanLyYTe;Integrated Security=True");
        SqlDataAdapter da;
        DataTable dt;

        public FormQuanLyBenhNhan()
        {
            InitializeComponent();
        }

        private void FormQuanLyBenhNhan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            da = new SqlDataAdapter("SELECT * FROM Patient", conn);
            dt = new DataTable();
            da.Fill(dt);
            dgvBenhNhan.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Patient (MaBenhNhan, TenBenhNhan, NgaySinh, DiaChi, SoDienThoai, Email, CanCuocCongDan) " +
                                            "VALUES (@MaBN, @TenBN, @NgaySinh, @DiaChi, @SDT, @Email, @CCCD)", conn);
            cmd.Parameters.AddWithValue("@MaBN", txtMaBN.Text);
            cmd.Parameters.AddWithValue("@TenBN", txtTenBN.Text);
            cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
            cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
            cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadData();
            MessageBox.Show("Thêm bệnh nhân thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Patient SET TenBenhNhan=@TenBN, NgaySinh=@NgaySinh, DiaChi=@DiaChi, " +
                                            "SoDienThoai=@SDT, Email=@Email, CanCuocCongDan=@CCCD " +
                                            "WHERE MaBenhNhan=@MaBN", conn);
            cmd.Parameters.AddWithValue("@MaBN", txtMaBN.Text);
            cmd.Parameters.AddWithValue("@TenBN", txtTenBN.Text);
            cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
            cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
            cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadData();
            MessageBox.Show("Cập nhật bệnh nhân thành công!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Patient WHERE MaBenhNhan=@MaBN", conn);
            cmd.Parameters.AddWithValue("@MaBN", txtMaBN.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadData();
            MessageBox.Show("Xóa bệnh nhân thành công!");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaBN.Clear();
            txtTenBN.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtCCCD.Clear();
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

            string keyword = ShowInputDialog("Nhập thông tin tìm kiếm (Mã, Tên, Địa chỉ, SĐT, Email, CCCD):", "Tìm kiếm");
            
            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvBenhNhan.DataSource = dt;
                return;
            }

            try
            {
                string tempPath = System.IO.Path.GetTempPath();
                string fileName = "Patient_Search_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                XSLTSearchHelper.TimKiemXSLTFromDataTable(dt, keyword, tempPath + fileName, "Patient", "Patient");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBenhNhan.Rows[e.RowIndex];
                txtMaBN.Text = row.Cells["MaBenhNhan"].Value.ToString();
                txtTenBN.Text = row.Cells["TenBenhNhan"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtSDT.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtCCCD.Text = row.Cells["CanCuocCongDan"].Value.ToString();
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            DataConversionHelper.HandleConversion(cbFrom, cbTo, conn, "Patient", LoadData);
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
                string fileName = "Patient_Export_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                XSLTSearchHelper.XuatXSLTFromDataTable(dt, tempPath + fileName, "Patient", "Patient");
                MessageBox.Show("Xuất dữ liệu XSLT thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất dữ liệu XSLT: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
