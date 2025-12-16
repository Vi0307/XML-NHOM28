using System.Drawing;
using System.Windows.Forms;

namespace QuanLyYTe
{
    partial class FormAdmin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.PanelLeft = new System.Windows.Forms.Panel();
            this.btnExamination = new System.Windows.Forms.Button();
            this.btnEquipment = new System.Windows.Forms.Button();
            this.btnClinic = new System.Windows.Forms.Button();
            this.btnPatient = new System.Windows.Forms.Button();
            this.btnStaff = new System.Windows.Forms.Button();
            this.sidebarLogo = new System.Windows.Forms.Label();
            this.PanelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.PanelMain = new System.Windows.Forms.Panel();
            this.PanelLeft.SuspendLayout();
            this.PanelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelLeft
            // 
            this.PanelLeft.BackColor = System.Drawing.Color.SteelBlue;
            this.PanelLeft.Controls.Add(this.btnExamination);
            this.PanelLeft.Controls.Add(this.btnEquipment);
            this.PanelLeft.Controls.Add(this.btnClinic);
            this.PanelLeft.Controls.Add(this.btnPatient);
            this.PanelLeft.Controls.Add(this.btnStaff);
            this.PanelLeft.Controls.Add(this.sidebarLogo);
            this.PanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelLeft.Location = new System.Drawing.Point(0, 0);
            this.PanelLeft.Name = "PanelLeft";
            this.PanelLeft.Padding = new System.Windows.Forms.Padding(0, 0, 0, 17);
            this.PanelLeft.Size = new System.Drawing.Size(253, 624);
            this.PanelLeft.TabIndex = 0;
            // 
            // btnExamination
            // 
            this.btnExamination.FlatAppearance.BorderSize = 0;
            this.btnExamination.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExamination.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnExamination.ForeColor = System.Drawing.Color.White;
            this.btnExamination.Location = new System.Drawing.Point(0, 329);
            this.btnExamination.Name = "btnExamination";
            this.btnExamination.Padding = new System.Windows.Forms.Padding(47, 0, 0, 0);
            this.btnExamination.Size = new System.Drawing.Size(253, 52);
            this.btnExamination.TabIndex = 5;
            this.btnExamination.Text = "    Quản lý Khám bệnh";
            this.btnExamination.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExamination.UseVisualStyleBackColor = false;
            this.btnExamination.Click += new System.EventHandler(this.btnExamination_Click);
            // 
            // btnEquipment
            // 
            this.btnEquipment.FlatAppearance.BorderSize = 0;
            this.btnEquipment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEquipment.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEquipment.ForeColor = System.Drawing.Color.White;
            this.btnEquipment.Location = new System.Drawing.Point(0, 277);
            this.btnEquipment.Name = "btnEquipment";
            this.btnEquipment.Padding = new System.Windows.Forms.Padding(47, 0, 0, 0);
            this.btnEquipment.Size = new System.Drawing.Size(253, 52);
            this.btnEquipment.TabIndex = 4;
            this.btnEquipment.Text = "    Quản lý Vật tư Y tế";
            this.btnEquipment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEquipment.UseVisualStyleBackColor = false;
            this.btnEquipment.Click += new System.EventHandler(this.btnEquipment_Click);
            // 
            // btnClinic
            // 
            this.btnClinic.FlatAppearance.BorderSize = 0;
            this.btnClinic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClinic.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnClinic.ForeColor = System.Drawing.Color.White;
            this.btnClinic.Location = new System.Drawing.Point(0, 225);
            this.btnClinic.Name = "btnClinic";
            this.btnClinic.Padding = new System.Windows.Forms.Padding(47, 0, 0, 0);
            this.btnClinic.Size = new System.Drawing.Size(253, 52);
            this.btnClinic.TabIndex = 3;
            this.btnClinic.Text = "    Quản lý Phòng khám";
            this.btnClinic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClinic.UseVisualStyleBackColor = false;
            this.btnClinic.Click += new System.EventHandler(this.btnClinic_Click);
            // 
            // btnPatient
            // 
            this.btnPatient.FlatAppearance.BorderSize = 0;
            this.btnPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatient.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPatient.ForeColor = System.Drawing.Color.White;
            this.btnPatient.Location = new System.Drawing.Point(0, 173);
            this.btnPatient.Name = "btnPatient";
            this.btnPatient.Padding = new System.Windows.Forms.Padding(47, 0, 0, 0);
            this.btnPatient.Size = new System.Drawing.Size(253, 52);
            this.btnPatient.TabIndex = 2;
            this.btnPatient.Text = "    Quản lý Bệnh nhân";
            this.btnPatient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPatient.UseVisualStyleBackColor = false;
            this.btnPatient.Click += new System.EventHandler(this.btnPatient_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.FlatAppearance.BorderSize = 0;
            this.btnStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStaff.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnStaff.ForeColor = System.Drawing.Color.White;
            this.btnStaff.Location = new System.Drawing.Point(0, 121);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Padding = new System.Windows.Forms.Padding(47, 0, 0, 0);
            this.btnStaff.Size = new System.Drawing.Size(253, 52);
            this.btnStaff.TabIndex = 1;
            this.btnStaff.Text = "    Quản lý Nhân viên";
            this.btnStaff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStaff.UseVisualStyleBackColor = false;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // sidebarLogo
            // 
            this.sidebarLogo.BackColor = System.Drawing.Color.SteelBlue;
            this.sidebarLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.sidebarLogo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.sidebarLogo.ForeColor = System.Drawing.Color.White;
            this.sidebarLogo.Location = new System.Drawing.Point(0, 0);
            this.sidebarLogo.Name = "sidebarLogo";
            this.sidebarLogo.Size = new System.Drawing.Size(253, 113);
            this.sidebarLogo.TabIndex = 0;
            this.sidebarLogo.Text = "QUẢN LÝ Y TẾ";
            this.sidebarLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelHeader
            // 
            this.PanelHeader.BackColor = System.Drawing.Color.SteelBlue;
            this.PanelHeader.Controls.Add(this.lblTitle);
            this.PanelHeader.Controls.Add(this.btnLogout);
            this.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelHeader.Location = new System.Drawing.Point(253, 0);
            this.PanelHeader.Name = "PanelHeader";
            this.PanelHeader.Size = new System.Drawing.Size(861, 61);
            this.PanelHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(26, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(90, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Admin";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(754, 13);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(103, 35);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // PanelMain
            // 
            this.PanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.PanelMain.BackgroundImage = global::QuanLyYTe.Properties.Resources.bao_hiem_3;
            this.PanelMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(253, 61);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(861, 563);
            this.PanelMain.TabIndex = 2;
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 624);
            this.Controls.Add(this.PanelMain);
            this.Controls.Add(this.PanelHeader);
            this.Controls.Add(this.PanelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(1099, 629);
            this.Name = "FormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Y tế - Administrator";
            this.PanelLeft.ResumeLayout(false);
            this.PanelHeader.ResumeLayout(false);
            this.PanelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelLeft;
        private System.Windows.Forms.Button btnExamination;
        private System.Windows.Forms.Button btnEquipment;
        private System.Windows.Forms.Button btnClinic;
        private System.Windows.Forms.Button btnPatient;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Label sidebarLogo;
        private System.Windows.Forms.Panel PanelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel PanelMain;

        // Các biến bạn đã có trong file .cs chính
        private PictureBox picLogo;
        private Label lblUser;
        private Button activeButton;
        private int currentActiveButton;
    }
}
