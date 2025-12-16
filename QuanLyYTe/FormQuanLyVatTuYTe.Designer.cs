using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyYTe
{
    partial class FormQuanLyVatTuYTe
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtMaVatTu = new System.Windows.Forms.TextBox();
            this.txtTenVatTu = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.cboLoaiVatTu = new System.Windows.Forms.ComboBox();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.lblMaVatTu = new System.Windows.Forms.Label();
            this.lblTenVatTu = new System.Windows.Forms.Label();
            this.lblLoai = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvVatTu = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnXuatXSLT = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.groupBoxConvert = new System.Windows.Forms.GroupBox();
            this.lblConvert = new System.Windows.Forms.Label();
            this.cbFrom = new System.Windows.Forms.ComboBox();
            this.lblArrow = new System.Windows.Forms.Label();
            this.cbTo = new System.Windows.Forms.ComboBox();
            this.btnConvert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVatTu)).BeginInit();
            this.groupBoxConvert.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMaVatTu
            // 
            this.txtMaVatTu.Location = new System.Drawing.Point(46, 92);
            this.txtMaVatTu.Name = "txtMaVatTu";
            this.txtMaVatTu.Size = new System.Drawing.Size(200, 22);
            this.txtMaVatTu.TabIndex = 2;
            // 
            // txtTenVatTu
            // 
            this.txtTenVatTu.Location = new System.Drawing.Point(46, 132);
            this.txtTenVatTu.Name = "txtTenVatTu";
            this.txtTenVatTu.Size = new System.Drawing.Size(200, 22);
            this.txtTenVatTu.TabIndex = 4;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(46, 212);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(200, 22);
            this.txtSoLuong.TabIndex = 8;
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(46, 252);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(200, 22);
            this.txtGia.TabIndex = 10;
            // 
            // cboLoaiVatTu
            // 
            this.cboLoaiVatTu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiVatTu.Items.AddRange(new object[] {
            "Dụng cụ",
            "Thuốc",
            "Vật tư tiêu hao"});
            this.cboLoaiVatTu.Location = new System.Drawing.Point(46, 172);
            this.cboLoaiVatTu.Name = "cboLoaiVatTu";
            this.cboLoaiVatTu.Size = new System.Drawing.Size(200, 24);
            this.cboLoaiVatTu.TabIndex = 6;
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayNhap.Location = new System.Drawing.Point(46, 292);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayNhap.TabIndex = 12;
            // 
            // lblMaVatTu
            // 
            this.lblMaVatTu.Location = new System.Drawing.Point(46, 72);
            this.lblMaVatTu.Name = "lblMaVatTu";
            this.lblMaVatTu.Size = new System.Drawing.Size(100, 23);
            this.lblMaVatTu.TabIndex = 1;
            this.lblMaVatTu.Text = "Mã vật tư:";
            // 
            // lblTenVatTu
            // 
            this.lblTenVatTu.Location = new System.Drawing.Point(46, 112);
            this.lblTenVatTu.Name = "lblTenVatTu";
            this.lblTenVatTu.Size = new System.Drawing.Size(100, 23);
            this.lblTenVatTu.TabIndex = 3;
            this.lblTenVatTu.Text = "Tên vật tư:";
            // 
            // lblLoai
            // 
            this.lblLoai.Location = new System.Drawing.Point(46, 152);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(100, 23);
            this.lblLoai.TabIndex = 5;
            this.lblLoai.Text = "Loại vật tư:";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Location = new System.Drawing.Point(46, 192);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(100, 23);
            this.lblSoLuong.TabIndex = 7;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // lblGia
            // 
            this.lblGia.Location = new System.Drawing.Point(46, 232);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(100, 23);
            this.lblGia.TabIndex = 9;
            this.lblGia.Text = "Giá:";
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.Location = new System.Drawing.Point(46, 272);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(100, 23);
            this.lblNgayNhap.TabIndex = 11;
            this.lblNgayNhap.Text = "Ngày nhập:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitle.Location = new System.Drawing.Point(300, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(510, 52);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ VẬT TƯ Y TẾ";
            // 
            // dgvVatTu
            // 
            this.dgvVatTu.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvVatTu.ColumnHeadersHeight = 29;
            this.dgvVatTu.Location = new System.Drawing.Point(309, 72);
            this.dgvVatTu.Name = "dgvVatTu";
            this.dgvVatTu.RowHeadersWidth = 51;
            this.dgvVatTu.Size = new System.Drawing.Size(751, 300);
            this.dgvVatTu.TabIndex = 15;
            this.dgvVatTu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVatTu_CellClick);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(46, 372);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 35);
            this.btnThem.TabIndex = 16;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(156, 372);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 35);
            this.btnSua.TabIndex = 17;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(46, 417);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 35);
            this.btnXoa.TabIndex = 18;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(156, 417);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(90, 35);
            this.btnLamMoi.TabIndex = 19;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(190, 330);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(56, 25);
            this.btnTimKiem.TabIndex = 14;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnXuatXSLT
            // 
            this.btnXuatXSLT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnXuatXSLT.FlatAppearance.BorderSize = 0;
            this.btnXuatXSLT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatXSLT.ForeColor = System.Drawing.Color.White;
            this.btnXuatXSLT.Location = new System.Drawing.Point(46, 472);
            this.btnXuatXSLT.Name = "btnXuatXSLT";
            this.btnXuatXSLT.Size = new System.Drawing.Size(200, 25);
            this.btnXuatXSLT.TabIndex = 15;
            this.btnXuatXSLT.Text = "Xuất XSLT";
            this.btnXuatXSLT.UseVisualStyleBackColor = false;
            this.btnXuatXSLT.Click += new System.EventHandler(this.btnXuatXSLT_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(46, 332);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(140, 22);
            this.txtTimKiem.TabIndex = 13;
            // 
            // groupBoxConvert
            // 
            this.groupBoxConvert.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBoxConvert.Controls.Add(this.lblConvert);
            this.groupBoxConvert.Controls.Add(this.cbFrom);
            this.groupBoxConvert.Controls.Add(this.lblArrow);
            this.groupBoxConvert.Controls.Add(this.cbTo);
            this.groupBoxConvert.Controls.Add(this.btnConvert);
            this.groupBoxConvert.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.groupBoxConvert.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBoxConvert.Location = new System.Drawing.Point(369, 388);
            this.groupBoxConvert.Name = "groupBoxConvert";
            this.groupBoxConvert.Size = new System.Drawing.Size(362, 140);
            this.groupBoxConvert.TabIndex = 20;
            this.groupBoxConvert.TabStop = false;
            this.groupBoxConvert.Text = "Chuyển đổi dữ liệu";
            // 
            // lblConvert
            // 
            this.lblConvert.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblConvert.Location = new System.Drawing.Point(20, 25);
            this.lblConvert.Name = "lblConvert";
            this.lblConvert.Size = new System.Drawing.Size(200, 25);
            this.lblConvert.TabIndex = 0;
            this.lblConvert.Text = "Chọn kiểu chuyển đổi:";
            // 
            // cbFrom
            // 
            this.cbFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFrom.Items.AddRange(new object[] {
            "XML",
            "SQL",
            "MySQL"});
            this.cbFrom.Location = new System.Drawing.Point(30, 60);
            this.cbFrom.Name = "cbFrom";
            this.cbFrom.Size = new System.Drawing.Size(120, 31);
            this.cbFrom.TabIndex = 1;
            // 
            // lblArrow
            // 
            this.lblArrow.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblArrow.Location = new System.Drawing.Point(160, 60);
            this.lblArrow.Name = "lblArrow";
            this.lblArrow.Size = new System.Drawing.Size(25, 25);
            this.lblArrow.TabIndex = 2;
            this.lblArrow.Text = "→";
            this.lblArrow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbTo
            // 
            this.cbTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbTo.Items.AddRange(new object[] {
            "XML",
            "SQL",
            "MySQL"});
            this.cbTo.Location = new System.Drawing.Point(200, 60);
            this.cbTo.Name = "cbTo";
            this.cbTo.Size = new System.Drawing.Size(120, 31);
            this.cbTo.TabIndex = 3;
            // 
            // btnConvert
            // 
            this.btnConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvert.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnConvert.ForeColor = System.Drawing.Color.White;
            this.btnConvert.Location = new System.Drawing.Point(140, 95);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(120, 35);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "Chuyển";
            this.btnConvert.UseVisualStyleBackColor = false;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // FormQuanLyVatTuYTe
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1072, 550);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblMaVatTu);
            this.Controls.Add(this.txtMaVatTu);
            this.Controls.Add(this.lblTenVatTu);
            this.Controls.Add(this.txtTenVatTu);
            this.Controls.Add(this.lblLoai);
            this.Controls.Add(this.cboLoaiVatTu);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.lblGia);
            this.Controls.Add(this.txtGia);
            this.Controls.Add(this.lblNgayNhap);
            this.Controls.Add(this.dtpNgayNhap);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnXuatXSLT);
            this.Controls.Add(this.dgvVatTu);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.groupBoxConvert);
            this.Name = "FormQuanLyVatTuYTe";
            this.Text = "Quản lý Vật tư Y tế";
            this.Load += new System.EventHandler(this.FormQuanLyVatTuYTe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVatTu)).EndInit();
            this.groupBoxConvert.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Controls
        private TextBox txtMaVatTu, txtTenVatTu, txtSoLuong, txtGia, txtTimKiem;
        private ComboBox cboLoaiVatTu;
        private DateTimePicker dtpNgayNhap;
        private Label lblMaVatTu, lblTenVatTu, lblLoai, lblSoLuong, lblGia, lblNgayNhap, lblTitle;
        private DataGridView dgvVatTu;
        private Button btnThem, btnSua, btnXoa, btnLamMoi, btnTimKiem, btnXuatXSLT;
        private GroupBox groupBoxConvert;
        private Label lblConvert, lblArrow;
        private ComboBox cbFrom, cbTo;
        private Button btnConvert;
    }
}
