namespace _2018_QuanLyThuVien
{
    partial class frmThemKhachHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label7 = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaLoaiKH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTienNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiemTichLuy = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.llbGoiy = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Crimson;
            this.label7.Location = new System.Drawing.Point(64, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(382, 45);
            this.label7.TabIndex = 65;
            this.label7.Text = "THÊM KHÁCH HÀNG";
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(348, 459);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(99, 48);
            this.btnHuy.TabIndex = 67;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(43, 459);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(99, 48);
            this.btnLuu.TabIndex = 66;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 68;
            this.label1.Text = "Mã Khách Hàng:";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(169, 100);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(195, 26);
            this.txtMaKH.TabIndex = 69;
            this.txtMaKH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaKH_KeyDown);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(169, 151);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(305, 26);
            this.txtHoTen.TabIndex = 71;
            this.txtHoTen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHoTen_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 70;
            this.label2.Text = "Họ Tên:";
            // 
            // txtMaLoaiKH
            // 
            this.txtMaLoaiKH.Location = new System.Drawing.Point(169, 207);
            this.txtMaLoaiKH.Name = "txtMaLoaiKH";
            this.txtMaLoaiKH.Size = new System.Drawing.Size(148, 26);
            this.txtMaLoaiKH.TabIndex = 73;
            this.txtMaLoaiKH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaLoaiKH_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 72;
            this.label3.Text = "Mã loại KH:";
            // 
            // txtTienNo
            // 
            this.txtTienNo.Location = new System.Drawing.Point(169, 311);
            this.txtTienNo.Name = "txtTienNo";
            this.txtTienNo.Size = new System.Drawing.Size(195, 26);
            this.txtTienNo.TabIndex = 75;
            this.txtTienNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTienNo_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 74;
            this.label4.Text = "Tiền Nợ:";
            // 
            // txtDiemTichLuy
            // 
            this.txtDiemTichLuy.Location = new System.Drawing.Point(169, 376);
            this.txtDiemTichLuy.Name = "txtDiemTichLuy";
            this.txtDiemTichLuy.Size = new System.Drawing.Size(195, 26);
            this.txtDiemTichLuy.TabIndex = 77;
            this.txtDiemTichLuy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiemTichLuy_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 382);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 76;
            this.label5.Text = "Điểm tích lũy:";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(338, 213);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(136, 24);
            this.checkBox2.TabIndex = 79;
            this.checkBox2.Text = "Mã loại có sẵn";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // llbGoiy
            // 
            this.llbGoiy.AutoSize = true;
            this.llbGoiy.ForeColor = System.Drawing.Color.Black;
            this.llbGoiy.LinkColor = System.Drawing.Color.Black;
            this.llbGoiy.Location = new System.Drawing.Point(334, 266);
            this.llbGoiy.Name = "llbGoiy";
            this.llbGoiy.Size = new System.Drawing.Size(100, 20);
            this.llbGoiy.TabIndex = 81;
            this.llbGoiy.TabStop = true;
            this.llbGoiy.Text = "Gợi ý thể loại";
            this.llbGoiy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbGoiy_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.ForeColor = System.Drawing.Color.Black;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(165, 266);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(106, 20);
            this.linkLabel1.TabIndex = 80;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Thêm loại mới";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmThemKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(496, 538);
            this.Controls.Add(this.llbGoiy);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.txtDiemTichLuy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTienNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMaLoaiKH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaKH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThemKhachHang";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmThemKhachHang_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaLoaiKH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTienNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiemTichLuy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.LinkLabel llbGoiy;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}