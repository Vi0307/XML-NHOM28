using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyYTe
{
    partial class FormPhongKham
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtMaPK = new System.Windows.Forms.TextBox();
            this.txtTenPK = new System.Windows.Forms.TextBox();
            this.dgvPhongKham = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnXuatXSLT = new System.Windows.Forms.Button();
            this.lblMaPK = new System.Windows.Forms.Label();
            this.lblTenPK = new System.Windows.Forms.Label();
            this.groupBoxConvert = new System.Windows.Forms.GroupBox();
            this.lblConvert = new System.Windows.Forms.Label();
            this.cbFrom = new System.Windows.Forms.ComboBox();
            this.lblArrow = new System.Windows.Forms.Label();
            this.cbTo = new System.Windows.Forms.ComboBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongKham)).BeginInit();
            this.groupBoxConvert.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMaPK
            // 
            this.txtMaPK.Location = new System.Drawing.Point(61, 100);
            this.txtMaPK.Name = "txtMaPK";
            this.txtMaPK.Size = new System.Drawing.Size(200, 22);
            this.txtMaPK.TabIndex = 2;
            // 
            // txtTenPK
            // 
            this.txtTenPK.Location = new System.Drawing.Point(61, 160);
            this.txtTenPK.Name = "txtTenPK";
            this.txtTenPK.Size = new System.Drawing.Size(200, 22);
            this.txtTenPK.TabIndex = 4;
            // 
            // dgvPhongKham
            // 
            this.dgvPhongKham.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPhongKham.ColumnHeadersHeight = 29;
            this.dgvPhongKham.GridColor = System.Drawing.Color.LightBlue;
            this.dgvPhongKham.Location = new System.Drawing.Point(303, 80);
            this.dgvPhongKham.Name = "dgvPhongKham";
            this.dgvPhongKham.RowHeadersWidth = 51;
            this.dgvPhongKham.Size = new System.Drawing.Size(759, 220);
            this.dgvPhongKham.TabIndex = 5;
            this.dgvPhongKham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhongKham_CellClick);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(61, 200);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 35);
            this.btnThem.TabIndex = 6;
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
            this.btnSua.Location = new System.Drawing.Point(171, 200);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 35);
            this.btnSua.TabIndex = 7;
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
            this.btnXoa.Location = new System.Drawing.Point(61, 245);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 35);
            this.btnXoa.TabIndex = 8;
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
            this.btnLamMoi.Location = new System.Drawing.Point(171, 245);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(90, 35);
            this.btnLamMoi.TabIndex = 9;
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
            this.btnTimKiem.Location = new System.Drawing.Point(61, 290);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(200, 35);
            this.btnTimKiem.TabIndex = 10;
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
            this.btnXuatXSLT.Location = new System.Drawing.Point(61, 335);
            this.btnXuatXSLT.Name = "btnXuatXSLT";
            this.btnXuatXSLT.Size = new System.Drawing.Size(200, 35);
            this.btnXuatXSLT.TabIndex = 11;
            this.btnXuatXSLT.Text = "Xuất XSLT";
            this.btnXuatXSLT.UseVisualStyleBackColor = false;
            this.btnXuatXSLT.Click += new System.EventHandler(this.btnXuatXSLT_Click);
            // 
            // lblMaPK
            // 
            this.lblMaPK.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblMaPK.Location = new System.Drawing.Point(61, 80);
            this.lblMaPK.Name = "lblMaPK";
            this.lblMaPK.Size = new System.Drawing.Size(200, 20);
            this.lblMaPK.TabIndex = 1;
            this.lblMaPK.Text = "Mã phòng khám:";
            // 
            // lblTenPK
            // 
            this.lblTenPK.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTenPK.Location = new System.Drawing.Point(61, 140);
            this.lblTenPK.Name = "lblTenPK";
            this.lblTenPK.Size = new System.Drawing.Size(200, 20);
            this.lblTenPK.TabIndex = 3;
            this.lblTenPK.Text = "Tên phòng khám:";
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
            this.groupBoxConvert.Location = new System.Drawing.Point(396, 335);
            this.groupBoxConvert.Name = "groupBoxConvert";
            this.groupBoxConvert.Size = new System.Drawing.Size(364, 150);
            this.groupBoxConvert.TabIndex = 11;
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
            this.btnConvert.FlatAppearance.BorderSize = 0;
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvert.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnConvert.ForeColor = System.Drawing.Color.White;
            this.btnConvert.Location = new System.Drawing.Point(123, 105);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(120, 35);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "Chuyển";
            this.btnConvert.UseVisualStyleBackColor = false;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(257, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(544, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ PHÒNG KHÁM";
            // 
            // FormPhongKham
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1074, 593);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMaPK);
            this.Controls.Add(this.txtMaPK);
            this.Controls.Add(this.lblTenPK);
            this.Controls.Add(this.txtTenPK);
            this.Controls.Add(this.dgvPhongKham);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnXuatXSLT);
            this.Controls.Add(this.groupBoxConvert);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "FormPhongKham";
            this.Text = "Quản lý Phòng khám";
            this.Load += new System.EventHandler(this.FormPhongKham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongKham)).EndInit();
            this.groupBoxConvert.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtMaPK;
        private TextBox txtTenPK;
        private DataGridView dgvPhongKham;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnTimKiem;
        private Button btnXuatXSLT;
        private Label lblMaPK;
        private Label lblTenPK;

        private GroupBox groupBoxConvert;
        private Label lblConvert;
        private ComboBox cbFrom;
        private ComboBox cbTo;
        private Label lblArrow;
        private Button btnConvert;
        private Label label1;
    }
}
