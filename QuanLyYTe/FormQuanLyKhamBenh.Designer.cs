using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyYTe
{
    partial class FormQuanLyKhamBenh
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
            this.txtMaPK = new System.Windows.Forms.TextBox();
            this.txtTenPK = new System.Windows.Forms.TextBox();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.cboHinhThucKham = new System.Windows.Forms.ComboBox();
            this.txtMaBenhNhan = new System.Windows.Forms.TextBox();
            this.dtpNgayKham = new System.Windows.Forms.DateTimePicker();
            this.lblMaPK = new System.Windows.Forms.Label();
            this.lblTenPK = new System.Windows.Forms.Label();
            this.lblTenNV = new System.Windows.Forms.Label();
            this.lblHinhThuc = new System.Windows.Forms.Label();
            this.lblMaBN = new System.Windows.Forms.Label();
            this.lblNgayKham = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvPhongKham = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnXuatXSLT = new System.Windows.Forms.Button();
            this.groupBoxConvert = new System.Windows.Forms.GroupBox();
            this.lblConvert = new System.Windows.Forms.Label();
            this.cbFrom = new System.Windows.Forms.ComboBox();
            this.lblArrow = new System.Windows.Forms.Label();
            this.cbTo = new System.Windows.Forms.ComboBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongKham)).BeginInit();
            this.groupBoxConvert.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMaPK
            // 
            this.txtMaPK.Location = new System.Drawing.Point(39, 51);
            this.txtMaPK.Name = "txtMaPK";
            this.txtMaPK.Size = new System.Drawing.Size(200, 29);
            this.txtMaPK.TabIndex = 2;
            // 
            // txtTenPK
            // 
            this.txtTenPK.Location = new System.Drawing.Point(39, 99);
            this.txtTenPK.Name = "txtTenPK";
            this.txtTenPK.Size = new System.Drawing.Size(200, 29);
            this.txtTenPK.TabIndex = 4;
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(39, 156);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(200, 29);
            this.txtTenNV.TabIndex = 6;
            // 
            // cboHinhThucKham
            // 
            this.cboHinhThucKham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHinhThucKham.Items.AddRange(new object[] {
            "Khám thường",
            "Khám chuyên khoa",
            "Khám cấp cứu"});
            this.cboHinhThucKham.Location = new System.Drawing.Point(39, 207);
            this.cboHinhThucKham.Name = "cboHinhThucKham";
            this.cboHinhThucKham.Size = new System.Drawing.Size(200, 32);
            this.cboHinhThucKham.TabIndex = 8;
            // 
            // txtMaBenhNhan
            // 
            this.txtMaBenhNhan.Location = new System.Drawing.Point(39, 257);
            this.txtMaBenhNhan.Name = "txtMaBenhNhan";
            this.txtMaBenhNhan.Size = new System.Drawing.Size(200, 29);
            this.txtMaBenhNhan.TabIndex = 10;
            // 
            // dtpNgayKham
            // 
            this.dtpNgayKham.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKham.Location = new System.Drawing.Point(39, 310);
            this.dtpNgayKham.Name = "dtpNgayKham";
            this.dtpNgayKham.Size = new System.Drawing.Size(200, 29);
            this.dtpNgayKham.TabIndex = 12;
            // 
            // lblMaPK
            // 
            this.lblMaPK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPK.ForeColor = System.Drawing.Color.Black;
            this.lblMaPK.Location = new System.Drawing.Point(39, 31);
            this.lblMaPK.Name = "lblMaPK";
            this.lblMaPK.Size = new System.Drawing.Size(200, 20);
            this.lblMaPK.TabIndex = 1;
            this.lblMaPK.Text = "Mã phòng khám:";
            // 
            // lblTenPK
            // 
            this.lblTenPK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenPK.ForeColor = System.Drawing.Color.Black;
            this.lblTenPK.Location = new System.Drawing.Point(39, 79);
            this.lblTenPK.Name = "lblTenPK";
            this.lblTenPK.Size = new System.Drawing.Size(200, 20);
            this.lblTenPK.TabIndex = 3;
            this.lblTenPK.Text = "Tên phòng khám:";
            // 
            // lblTenNV
            // 
            this.lblTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNV.ForeColor = System.Drawing.Color.Black;
            this.lblTenNV.Location = new System.Drawing.Point(39, 136);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(200, 20);
            this.lblTenNV.TabIndex = 5;
            this.lblTenNV.Text = "Tên nhân viên:";
            // 
            // lblHinhThuc
            // 
            this.lblHinhThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHinhThuc.ForeColor = System.Drawing.Color.Black;
            this.lblHinhThuc.Location = new System.Drawing.Point(39, 187);
            this.lblHinhThuc.Name = "lblHinhThuc";
            this.lblHinhThuc.Size = new System.Drawing.Size(200, 20);
            this.lblHinhThuc.TabIndex = 7;
            this.lblHinhThuc.Text = "Hình thức khám:";
            // 
            // lblMaBN
            // 
            this.lblMaBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaBN.ForeColor = System.Drawing.Color.Black;
            this.lblMaBN.Location = new System.Drawing.Point(39, 237);
            this.lblMaBN.Name = "lblMaBN";
            this.lblMaBN.Size = new System.Drawing.Size(200, 20);
            this.lblMaBN.TabIndex = 9;
            this.lblMaBN.Text = "Mã bệnh nhân:";
            // 
            // lblNgayKham
            // 
            this.lblNgayKham.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayKham.ForeColor = System.Drawing.Color.Black;
            this.lblNgayKham.Location = new System.Drawing.Point(39, 290);
            this.lblNgayKham.Name = "lblNgayKham";
            this.lblNgayKham.Size = new System.Drawing.Size(200, 20);
            this.lblNgayKham.TabIndex = 11;
            this.lblNgayKham.Text = "Ngày khám:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.AliceBlue;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitle.Location = new System.Drawing.Point(400, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(504, 52);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ KHÁM BỆNH";
            // 
            // dgvPhongKham
            // 
            this.dgvPhongKham.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPhongKham.ColumnHeadersHeight = 29;
            this.dgvPhongKham.Location = new System.Drawing.Point(9, 21);
            this.dgvPhongKham.Name = "dgvPhongKham";
            this.dgvPhongKham.RowHeadersWidth = 51;
            this.dgvPhongKham.Size = new System.Drawing.Size(954, 295);
            this.dgvPhongKham.TabIndex = 13;
            this.dgvPhongKham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhongKham_CellClick);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(25, 25);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 35);
            this.btnThem.TabIndex = 14;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(136, 25);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 35);
            this.btnSua.TabIndex = 15;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(252, 25);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 35);
            this.btnXoa.TabIndex = 16;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(375, 25);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(90, 35);
            this.btnLamMoi.TabIndex = 17;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(491, 25);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(200, 35);
            this.btnTimKiem.TabIndex = 18;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnXuatXSLT
            // 
            this.btnXuatXSLT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnXuatXSLT.FlatAppearance.BorderSize = 0;
            this.btnXuatXSLT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatXSLT.ForeColor = System.Drawing.Color.White;
            this.btnXuatXSLT.Location = new System.Drawing.Point(715, 27);
            this.btnXuatXSLT.Name = "btnXuatXSLT";
            this.btnXuatXSLT.Size = new System.Drawing.Size(157, 35);
            this.btnXuatXSLT.TabIndex = 19;
            this.btnXuatXSLT.Text = "Xuất XSLT";
            this.btnXuatXSLT.UseVisualStyleBackColor = false;
            this.btnXuatXSLT.Click += new System.EventHandler(this.btnXuatXSLT_Click);
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
            this.groupBoxConvert.Location = new System.Drawing.Point(934, 410);
            this.groupBoxConvert.Name = "groupBoxConvert";
            this.groupBoxConvert.Size = new System.Drawing.Size(362, 140);
            this.groupBoxConvert.TabIndex = 19;
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
            this.cbFrom.Location = new System.Drawing.Point(30, 55);
            this.cbFrom.Name = "cbFrom";
            this.cbFrom.Size = new System.Drawing.Size(120, 31);
            this.cbFrom.TabIndex = 1;
            // 
            // lblArrow
            // 
            this.lblArrow.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblArrow.Location = new System.Drawing.Point(160, 55);
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
            this.cbTo.Location = new System.Drawing.Point(200, 55);
            this.cbTo.Name = "cbTo";
            this.cbTo.Size = new System.Drawing.Size(120, 31);
            this.cbTo.TabIndex = 3;
            // 
            // btnConvert
            // 
            this.btnConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnConvert.FlatAppearance.BorderSize = 0;
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvert.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnConvert.ForeColor = System.Drawing.Color.White;
            this.btnConvert.Location = new System.Drawing.Point(114, 91);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(120, 35);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "Chuyển";
            this.btnConvert.UseVisualStyleBackColor = false;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.lblMaPK);
            this.groupBox1.Controls.Add(this.txtMaPK);
            this.groupBox1.Controls.Add(this.lblTenPK);
            this.groupBox1.Controls.Add(this.txtTenPK);
            this.groupBox1.Controls.Add(this.lblTenNV);
            this.groupBox1.Controls.Add(this.txtTenNV);
            this.groupBox1.Controls.Add(this.lblHinhThuc);
            this.groupBox1.Controls.Add(this.cboHinhThucKham);
            this.groupBox1.Controls.Add(this.lblMaBN);
            this.groupBox1.Controls.Add(this.txtMaBenhNhan);
            this.groupBox1.Controls.Add(this.lblNgayKham);
            this.groupBox1.Controls.Add(this.dtpNgayKham);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(32, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 350);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox2.Controls.Add(this.btnThem);
            this.groupBox2.Controls.Add(this.btnSua);
            this.groupBox2.Controls.Add(this.btnXoa);
            this.groupBox2.Controls.Add(this.btnLamMoi);
            this.groupBox2.Controls.Add(this.btnTimKiem);
            this.groupBox2.Controls.Add(this.btnXuatXSLT);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Location = new System.Drawing.Point(32, 445);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(882, 79);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thao tác";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox3.Controls.Add(this.dgvPhongKham);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox3.Location = new System.Drawing.Point(319, 76);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(977, 328);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bảng danh sách khám bệnh";
            // 
            // FormQuanLyKhamBenh
            // 
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BackgroundImage = global::QuanLyYTe.Properties.Resources.anh_mo_ta;
            this.ClientSize = new System.Drawing.Size(1333, 559);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.groupBoxConvert);
            this.Name = "FormQuanLyKhamBenh";
            this.Text = "Quản lý Phòng khám";
            this.Load += new System.EventHandler(this.FormPhongKham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongKham)).EndInit();
            this.groupBoxConvert.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Controls
        private TextBox txtMaPK, txtTenPK, txtTenNV, txtMaBenhNhan;
        private DateTimePicker dtpNgayKham;
        private ComboBox cboHinhThucKham;

        private Label lblMaPK, lblTenPK, lblTenNV, lblHinhThuc, lblMaBN, lblNgayKham, lblTitle;

        private DataGridView dgvPhongKham;

        private Button btnThem, btnSua, btnXoa, btnLamMoi, btnTimKiem, btnXuatXSLT;

        private GroupBox groupBoxConvert;
        private Label lblConvert, lblArrow;
        private ComboBox cbFrom, cbTo;
        private Button btnConvert;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
    }
}
