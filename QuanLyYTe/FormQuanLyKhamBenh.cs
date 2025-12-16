using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyYTe
{
    public partial class FormQuanLyKhamBenh : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=VIETHOANG\\MSSQLSERVER01;Initial Catalog=QuanLyYTe;Integrated Security=True");
        SqlDataAdapter da;
        DataTable dt;
        private string currentMaKhamBenh = ""; // Lưu mã khám bệnh hiện tại
        private string currentMaNhanVien = ""; // Lưu mã nhân viên hiện tại

        public FormQuanLyKhamBenh()
        {
            InitializeComponent();
        }

        private void FormPhongKham_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadHinhThucKham();

        }

        private void LoadHinhThucKham()
        {
            SqlDataAdapter daHTK = new SqlDataAdapter("SELECT MaLoaiKhamBenh, TenLoaiKhamBenh FROM TypeOfExamination", conn);
            DataTable dtHTK = new DataTable();
            daHTK.Fill(dtHTK);

            cboHinhThucKham.DataSource = dtHTK;
            cboHinhThucKham.DisplayMember = "TenLoaiKhamBenh";
            cboHinhThucKham.ValueMember = "MaLoaiKhamBenh";
        }

        private void LoadData()
        {
            string query = @"
        SELECT 
            me.MaKhamBenh AS [Mã khám],
            mc.MaPhongKham AS [Mã phòng khám],
            mc.TenPhongKham AS [Tên phòng khám],
            s.MaNhanVien AS [Mã nhân viên],
            s.TenNhanVien AS [Tên nhân viên],
            te.TenLoaiKhamBenh AS [Hình thức khám],
            me.MaBenhNhan AS [Mã bệnh nhân],
            me.NgayKham AS [Ngày khám]
        FROM MedicalExamination me
        LEFT JOIN Staff s ON me.MaNhanVien = s.MaNhanVien
        LEFT JOIN TypeOfExamination te ON me.MaLoaiKhamBenh = te.MaLoaiKhamBenh
        LEFT JOIN MedicalClinic mc ON me.MaPhongKham = mc.MaPhongKham";

            da = new SqlDataAdapter(query, conn);
            dt = new DataTable();
            da.Fill(dt);
            dgvPhongKham.DataSource = dt;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaPK.Text) || string.IsNullOrWhiteSpace(txtMaBenhNhan.Text) || cboHinhThucKham.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin: Mã phòng khám, Mã bệnh nhân và Hình thức khám!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO MedicalExamination (MaKhamBenh, MaPhongKham, MaNhanVien, MaLoaiKhamBenh, MaBenhNhan, NgayKham) " +
                    "VALUES (@MaKB, @MaPK, @MaNV, @MaLoaiKB, @MaBN, @NgayKham)", conn);
                
                // Tạo mã khám bệnh tự động
                string maKhamBenh = $"KB{DateTime.Now:yyyyMMddHHmmss}";
                
                cmd.Parameters.AddWithValue("@MaKB", maKhamBenh);
                cmd.Parameters.AddWithValue("@MaPK", txtMaPK.Text);
                cmd.Parameters.AddWithValue("@MaNV", string.IsNullOrWhiteSpace(currentMaNhanVien) ? DBNull.Value : (object)currentMaNhanVien);
                cmd.Parameters.AddWithValue("@MaLoaiKB", cboHinhThucKham.SelectedValue);
                cmd.Parameters.AddWithValue("@MaBN", txtMaBenhNhan.Text);
                cmd.Parameters.AddWithValue("@NgayKham", dtpNgayKham.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                LoadData();
                MessageBox.Show("Thêm khám bệnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                MessageBox.Show("Lỗi khi thêm khám bệnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentMaKhamBenh))
                {
                    MessageBox.Show("Vui lòng chọn khám bệnh cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlCommand cmd = new SqlCommand("UPDATE MedicalExamination SET MaPhongKham=@MaPK, MaNhanVien=@MaNV, MaLoaiKhamBenh=@MaLoaiKB, MaBenhNhan=@MaBN, NgayKham=@NgayKham " +
                    "WHERE MaKhamBenh=@MaKB", conn);
                
                cmd.Parameters.AddWithValue("@MaKB", currentMaKhamBenh);
                cmd.Parameters.AddWithValue("@MaPK", txtMaPK.Text);
                cmd.Parameters.AddWithValue("@MaNV", string.IsNullOrWhiteSpace(currentMaNhanVien) ? DBNull.Value : (object)currentMaNhanVien);
                cmd.Parameters.AddWithValue("@MaLoaiKB", cboHinhThucKham.SelectedValue);
                cmd.Parameters.AddWithValue("@MaBN", txtMaBenhNhan.Text);
                cmd.Parameters.AddWithValue("@NgayKham", dtpNgayKham.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                LoadData();
                MessageBox.Show("Cập nhật khám bệnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                MessageBox.Show("Lỗi khi cập nhật khám bệnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentMaKhamBenh))
                {
                    MessageBox.Show("Vui lòng chọn khám bệnh cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khám bệnh này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                    return;

                SqlCommand cmd = new SqlCommand("DELETE FROM MedicalExamination WHERE MaKhamBenh=@MaKB", conn);
                cmd.Parameters.AddWithValue("@MaKB", currentMaKhamBenh);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                LoadData();
                MessageBox.Show("Xóa khám bệnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                MessageBox.Show("Lỗi khi xóa khám bệnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaPK.Clear();
            txtTenPK.Clear();
            txtTenNV.Clear();
            txtMaBenhNhan.Clear();
            cboHinhThucKham.SelectedIndex = -1;
            dtpNgayKham.Value = DateTime.Now;
            currentMaKhamBenh = "";
            currentMaNhanVien = "";
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

            string keyword = ShowInputDialog("Nhập thông tin tìm kiếm (Mã khám, Mã phòng, Tên phòng, Mã NV, Tên NV, Mã BN):", "Tìm kiếm");
            
            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvPhongKham.DataSource = dt;
                return;
            }

            try
            {
                string tempPath = System.IO.Path.GetTempPath();
                string fileName = "MedicalExamination_Search_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                XSLTSearchHelper.TimKiemXSLTFromDataTable(dt, keyword, tempPath + fileName, "MedicalExamination", "MedicalExamination");
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

                // Lưu mã khám bệnh để sử dụng khi sửa/xóa
                if (row.Cells["Mã khám"].Value != null)
                {
                    currentMaKhamBenh = row.Cells["Mã khám"].Value.ToString();
                }

                txtMaPK.Text = row.Cells["Mã phòng khám"].Value?.ToString() ?? "";
                txtTenPK.Text = row.Cells["Tên phòng khám"].Value?.ToString() ?? "";
                
                // Lưu mã nhân viên
                if (row.Cells["Mã nhân viên"].Value != null)
                {
                    currentMaNhanVien = row.Cells["Mã nhân viên"].Value.ToString();
                }
                else
                {
                    currentMaNhanVien = "";
                }
                
                txtTenNV.Text = row.Cells["Tên nhân viên"].Value?.ToString() ?? "";
                
                if (row.Cells["Hình thức khám"].Value != null)
                {
                    cboHinhThucKham.Text = row.Cells["Hình thức khám"].Value.ToString();
                }
                
                txtMaBenhNhan.Text = row.Cells["Mã bệnh nhân"].Value?.ToString() ?? "";
                
                if (row.Cells["Ngày khám"].Value != null)
                {
                    dtpNgayKham.Value = Convert.ToDateTime(row.Cells["Ngày khám"].Value);
                }
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            DataConversionHelper.HandleConversion(cbFrom, cbTo, conn, "MedicalExamination", LoadData);
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
                string fileName = "MedicalExamination_Export_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                XSLTSearchHelper.XuatXSLTFromDataTable(dt, tempPath + fileName, "MedicalExamination", "MedicalExamination");
                MessageBox.Show("Xuất dữ liệu XSLT thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất dữ liệu XSLT: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}

