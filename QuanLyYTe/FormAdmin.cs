using System;
using System.Windows.Forms;

namespace QuanLyYTe
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
            // Mặc định khi vào trang admin, xóa nội dung panel chính
            PanelMain.Controls.Clear();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            // Hiển thị form nhân viên bên trong PanelMain (giữ nguyên Form hiện tại)
            PanelMain.Controls.Clear();
            lblTitle.Text = "Quản lý Nhân viên";

            FormNhanVien formNhanVien = new FormNhanVien();
            formNhanVien.TopLevel = false;
            formNhanVien.FormBorderStyle = FormBorderStyle.None;
            formNhanVien.Dock = DockStyle.Fill;

            PanelMain.Controls.Add(formNhanVien);
            formNhanVien.Show();
        }



        private void btnPatient_Click(object sender, EventArgs e)
        {
            PanelMain.Controls.Clear();
            lblTitle.Text = "Quản lý Bệnh nhân";

            FormQuanLyBenhNhan formQuanLyBenhNhan = new FormQuanLyBenhNhan();
            formQuanLyBenhNhan.TopLevel = false;
            formQuanLyBenhNhan.FormBorderStyle = FormBorderStyle.None;
            formQuanLyBenhNhan.Dock = DockStyle.Fill;

            PanelMain.Controls.Add(formQuanLyBenhNhan);
            formQuanLyBenhNhan.Show();
        }

        private void btnClinic_Click(object sender, EventArgs e)
        {
            PanelMain.Controls.Clear();
            lblTitle.Text = "Quản lý Phòng khám";

            FormPhongKham formPhongKham = new FormPhongKham();
            formPhongKham.TopLevel = false;
            formPhongKham.FormBorderStyle = FormBorderStyle.None;
            formPhongKham.Dock = DockStyle.Fill;

            PanelMain.Controls.Add(formPhongKham);
            formPhongKham.Show();
        }

        private void btnEquipment_Click(object sender, EventArgs e)
        {
            PanelMain.Controls.Clear();
            lblTitle.Text = "Quản lý Vật tư Y tế";

            FormQuanLyVatTuYTe formQuanLyVatTuYTe = new FormQuanLyVatTuYTe();
            formQuanLyVatTuYTe.TopLevel = false;
            formQuanLyVatTuYTe.FormBorderStyle = FormBorderStyle.None;
            formQuanLyVatTuYTe.Dock = DockStyle.Fill;

            PanelMain.Controls.Add(formQuanLyVatTuYTe);
            formQuanLyVatTuYTe.Show();
        }

        private void btnExamination_Click(object sender, EventArgs e)
        {
            PanelMain.Controls.Clear();
            lblTitle.Text = "Quản lý Khám bệnh";

            FormQuanLyKhamBenh formQuanLyKhamBenh = new FormQuanLyKhamBenh();
            formQuanLyKhamBenh.TopLevel = false;
            formQuanLyKhamBenh.FormBorderStyle = FormBorderStyle.None;
            formQuanLyKhamBenh.Dock = DockStyle.Fill;

            PanelMain.Controls.Add(formQuanLyKhamBenh);
            formQuanLyKhamBenh.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Đăng xuất: quay về màn hình đăng nhập
            this.Hide();
            var loginForm = new frmLogin();
            // Khi form đăng nhập đóng thì đóng luôn form admin (thoát ứng dụng)
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }
    }
}
