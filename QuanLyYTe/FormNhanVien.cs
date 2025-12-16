using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace QuanLyYTe
{
    public partial class FormNhanVien : Form
    {
        SqlConnection conn = ConnectionDB.GetConnection();
        SqlDataAdapter da;
        DataTable dt;

        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            LoadChucVu();
            LoadCaLamViec();
            LoadData();
        }

        private void LoadChucVu()
        {
            SqlDataAdapter daCV = new SqlDataAdapter("SELECT * FROM Position", conn);
            DataTable dtChucVu = new DataTable();
            daCV.Fill(dtChucVu);
            cboChucVu.DataSource = dtChucVu;
            cboChucVu.DisplayMember = "TenChucVu";
            cboChucVu.ValueMember = "MaChucVu";
        }

        private void LoadCaLamViec()
        {
            SqlDataAdapter daShift = new SqlDataAdapter("SELECT * FROM Shift", conn);
            DataTable dtShift = new DataTable();
            daShift.Fill(dtShift);
            cboCaLamViec.DataSource = dtShift;
            cboCaLamViec.DisplayMember = "ThoiGianLamViec";
            cboCaLamViec.ValueMember = "MaCaLamViec";
        }

        private void LoadData()
        {
            da = new SqlDataAdapter("SELECT * FROM Staff", conn);
            dt = new DataTable();
            da.Fill(dt);
            dgvNhanVien.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) || string.IsNullOrWhiteSpace(txtTenNV.Text)
                || cboChucVu.SelectedValue == null || cboCaLamViec.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên, đặc biệt là chức vụ và ca làm việc!");
                return;
            }
            try
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Staff (MaNhanVien, TenNhanVien, NgaySinh, DiaChi, MaLoaiChucVu, TaiKhoan, MatKhau, MaCaLamViec) " +
                    "VALUES (@MaNV, @TenNV, @NgaySinh, @DiaChi, @MaLoaiChucVu, @TaiKhoan, @MatKhau, @MaCa)", conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                    cmd.Parameters.AddWithValue("@TenNV", txtTenNV.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@MaLoaiChucVu", cboChucVu.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@TaiKhoan", txtTaiKhoan.Text);
                    cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);
                    cmd.Parameters.AddWithValue("@MaCa", cboCaLamViec.SelectedValue.ToString());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    LoadData();
                    MessageBox.Show("Thêm thành công!");
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Staff SET TenNhanVien=@TenNV, NgaySinh=@NgaySinh, DiaChi=@DiaChi, " +
                    "MaLoaiChucVu=@MaLoaiChucVu, TaiKhoan=@TaiKhoan, MatKhau=@MatKhau, MaCaLamViec=@MaCa WHERE MaNhanVien=@MaNV", conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                    cmd.Parameters.AddWithValue("@TenNV", txtTenNV.Text);
                    cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@MaLoaiChucVu", cboChucVu.SelectedValue);
                    cmd.Parameters.AddWithValue("@TaiKhoan", txtTaiKhoan.Text);
                    cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);
                    cmd.Parameters.AddWithValue("@MaCa", cboCaLamViec.SelectedValue);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    LoadData();
                    MessageBox.Show("Cập nhật thành công!");
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi khi sửa nhân viên: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Staff WHERE MaNhanVien=@MaNV", conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    LoadData();
                    MessageBox.Show("Xóa thành công!");
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            txtDiaChi.Clear();
            cboChucVu.SelectedIndex = 0;
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            cboCaLamViec.SelectedIndex = 0;
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

            string keyword = ShowInputDialog("Nhập thông tin tìm kiếm (Mã NV, Tên NV, Địa chỉ, Tài khoản):", "Tìm kiếm");
            
            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvNhanVien.DataSource = dt;
                return;
            }

            try
            {
                string tempPath = System.IO.Path.GetTempPath();
                string fileName = "Staff_Search_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                XSLTSearchHelper.TimKiemXSLTFromDataTable(dt, keyword, tempPath + fileName, "Staff", "Staff");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNhanVien"].Value.ToString();
                txtTenNV.Text = row.Cells["TenNhanVien"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                cboChucVu.SelectedValue = row.Cells["MaLoaiChucVu"].Value;
                txtTaiKhoan.Text = row.Cells["TaiKhoan"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
                cboCaLamViec.SelectedValue = row.Cells["MaCaLamViec"].Value;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            DataConversionHelper.HandleConversion(cbFrom, cbTo, conn, "Staff", LoadData);
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
                string fileName = "Staff_Export_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                XSLTSearchHelper.XuatXSLTFromDataTable(dt, tempPath + fileName, "Staff", "Staff");
                MessageBox.Show("Xuất dữ liệu XSLT thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất dữ liệu XSLT: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
