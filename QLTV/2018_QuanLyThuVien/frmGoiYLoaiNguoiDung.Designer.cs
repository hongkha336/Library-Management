namespace _2018_QuanLyThuVien
{
    partial class frmGoiYLoaiNguoiDung
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnThoat = new System.Windows.Forms.Button();
            this.MaLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TienNoToiDa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeSoDiemThuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemTichLuyCanThiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongSachMuonToiDa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLoai,
            this.TenLoai,
            this.TienNoToiDa,
            this.HeSoDiemThuong,
            this.DiemTichLuyCanThiet,
            this.SoLuongSachMuonToiDa});
            this.dataGridView1.Location = new System.Drawing.Point(0, -1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(684, 286);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(0, 280);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(686, 39);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // MaLoai
            // 
            this.MaLoai.DataPropertyName = "MaLoai";
            this.MaLoai.Frozen = true;
            this.MaLoai.HeaderText = "Mã Loại";
            this.MaLoai.Name = "MaLoai";
            this.MaLoai.Width = 50;
            // 
            // TenLoai
            // 
            this.TenLoai.DataPropertyName = "TenLoai";
            this.TenLoai.HeaderText = "Tên Loại";
            this.TenLoai.Name = "TenLoai";
            // 
            // TienNoToiDa
            // 
            this.TienNoToiDa.DataPropertyName = "TienNoToiDa";
            this.TienNoToiDa.HeaderText = "Tiền Nợ Tối Đa";
            this.TienNoToiDa.Name = "TienNoToiDa";
            // 
            // HeSoDiemThuong
            // 
            this.HeSoDiemThuong.DataPropertyName = "HeSoDiemThuong";
            this.HeSoDiemThuong.HeaderText = "Hệ số điểm thưởng";
            this.HeSoDiemThuong.Name = "HeSoDiemThuong";
            this.HeSoDiemThuong.Width = 50;
            // 
            // DiemTichLuyCanThiet
            // 
            this.DiemTichLuyCanThiet.DataPropertyName = "DiemTichLuyCanThiet";
            this.DiemTichLuyCanThiet.HeaderText = "Điểm tích lũy cần thiết";
            this.DiemTichLuyCanThiet.Name = "DiemTichLuyCanThiet";
            this.DiemTichLuyCanThiet.Width = 50;
            // 
            // SoLuongSachMuonToiDa
            // 
            this.SoLuongSachMuonToiDa.DataPropertyName = "SoLuongSachMuonToiDa";
            this.SoLuongSachMuonToiDa.HeaderText = "Số lượng sách mượn tối đa";
            this.SoLuongSachMuonToiDa.Name = "SoLuongSachMuonToiDa";
            this.SoLuongSachMuonToiDa.Width = 50;
            // 
            // frmGoiYLoaiNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 311);
            this.ControlBox = false;
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGoiYLoaiNguoiDung";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmGoiYLoaiNguoiDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TienNoToiDa;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeSoDiemThuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemTichLuyCanThiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongSachMuonToiDa;
    }
}