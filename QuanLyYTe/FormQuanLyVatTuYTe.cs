using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyYTe
{
    public partial class FormQuanLyVatTuYTe : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=VIETHOANG\\MSSQLSERVER01;Initial Catalog=QuanLyYTe;Integrated Security=True");
        SqlDataAdapter da;
        DataTable dt;

        public FormQuanLyVatTuYTe()
        {
            InitializeComponent();
        }

        private void FormQuanLyVatTuYTe_Load(object sender, EventArgs e)
        {
            LoadLoaiVatTu();
            LoadData();
        }

        private void LoadLoaiVatTu()
        {
            SqlDataAdapter daLoai = new SqlDataAdapter("SELECT MaLoaiVatTuYTE, TenLoaiVatTuYTE FROM TypeOfEquipment", conn);
            DataTable dtLoai = new DataTable();
            daLoai.Fill(dtLoai);

            cboLoaiVatTu.DataSource = dtLoai;
            cboLoaiVatTu.DisplayMember = "TenLoaiVatTuYTE";
            cboLoaiVatTu.ValueMember = "MaLoaiVatTuYTE";
        }

        private void LoadData()
        {
            string query = @"
                SELECT me.MaVatTuYTE AS [Mã vật tư], 
                       me.TenVatTuYTE AS [Tên vật tư],
                       me.NgayNhap AS [Ngày nhập],
                       te.TenLoaiVatTuYTE AS [Loại vật tư],
                       me.SoLuong AS [Số lượng],
                       me.Gia AS [Giá]
                FROM MedicalEquipment me
                LEFT JOIN TypeOfEquipment te ON me.MaLoaiThietBi = te.MaLoaiVatTuYTE";

            da = new SqlDataAdapter(query, conn);
            dt = new DataTable();
            da.Fill(dt);
            dgvVatTu.DataSource = dt;
        }

        private void dgvVatTu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvVatTu.Rows[e.RowIndex];
                txtMaVatTu.Text = row.Cells["Mã vật tư"].Value.ToString();
                txtTenVatTu.Text = row.Cells["Tên vật tư"].Value.ToString();
                dtpNgayNhap.Value = Convert.ToDateTime(row.Cells["Ngày nhập"].Value);
                cboLoaiVatTu.Text = row.Cells["Loại vật tư"].Value.ToString();
                txtSoLuong.Text = row.Cells["Số lượng"].Value.ToString();
                txtGia.Text = row.Cells["Giá"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO MedicalEquipment (MaVatTuYTE, TenVatTuYTE, NgayNhap, MaLoaiThietBi, SoLuong, Gia) " +
                               "VALUES (@Ma, @Ten, @Ngay, @Loai, @SL, @Gia)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Ma", txtMaVatTu.Text);
                cmd.Parameters.AddWithValue("@Ten", txtTenVatTu.Text);
                cmd.Parameters.AddWithValue("@Ngay", dtpNgayNhap.Value);
                cmd.Parameters.AddWithValue("@Loai", cboLoaiVatTu.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@SL", int.Parse(txtSoLuong.Text));
                cmd.Parameters.AddWithValue("@Gia", decimal.Parse(txtGia.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                LoadData();
                MessageBox.Show("Thêm vật tư thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE MedicalEquipment SET TenVatTuYTE=@Ten, NgayNhap=@Ngay, MaLoaiThietBi=@Loai, SoLuong=@SL, Gia=@Gia " +
                               "WHERE MaVatTuYTE=@Ma";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Ma", txtMaVatTu.Text);
                cmd.Parameters.AddWithValue("@Ten", txtTenVatTu.Text);
                cmd.Parameters.AddWithValue("@Ngay", dtpNgayNhap.Value);
                cmd.Parameters.AddWithValue("@Loai", cboLoaiVatTu.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@SL", int.Parse(txtSoLuong.Text));
                cmd.Parameters.AddWithValue("@Gia", decimal.Parse(txtGia.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                LoadData();
                MessageBox.Show("Sửa vật tư thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM MedicalEquipment WHERE MaVatTuYTE=@Ma";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Ma", txtMaVatTu.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                LoadData();
                MessageBox.Show("Xóa vật tư thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaVatTu.Clear();
            txtTenVatTu.Clear();
            dtpNgayNhap.Value = DateTime.Today;
            cboLoaiVatTu.SelectedIndex = -1;
            txtSoLuong.Clear();
            txtGia.Clear();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (dt == null)
            {
                MessageBox.Show("Dữ liệu chưa được tải!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string search = txtTimKiem.Text.Trim();
            
            if (string.IsNullOrWhiteSpace(search))
            {
                dgvVatTu.DataSource = dt;
                return;
            }

            try
            {
                string tempPath = System.IO.Path.GetTempPath();
                string fileName = "MedicalEquipment_Search_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                XSLTSearchHelper.TimKiemXSLTFromDataTable(dt, search, tempPath + fileName, "MedicalEquipment", "MedicalEquipment");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            DataConversionHelper.HandleConversion(cbFrom, cbTo, conn, "MedicalEquipment", LoadData);
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
                string fileName = "MedicalEquipment_Export_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                XSLTSearchHelper.XuatXSLTFromDataTable(dt, tempPath + fileName, "MedicalEquipment", "MedicalEquipment");
                MessageBox.Show("Xuất dữ liệu XSLT thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất dữ liệu XSLT: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
