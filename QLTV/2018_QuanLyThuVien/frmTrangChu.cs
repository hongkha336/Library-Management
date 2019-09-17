using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace _2018_QuanLyThuVien
{
    public partial class frmHomePage : Form
    {
        string taiKhoanDangNhap="";
        string conStr = @"Data Source = UX305FA;" 
                            + "Initial Catalog = QLTV_16110112_Thu3;" 
                            + "User ID = sa; Password = hongkha123";
        SqlConnection conn = null;
        private void openConnect()
        {
            conn = new SqlConnection(conStr);
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
        }
        public frmHomePage()
        {
            InitializeComponent();
        }

        public void nhanTK(string a)
        {
            taiKhoanDangNhap = a;
        }
        void loadIcon()
        {
            //btn Sach
            btnSach.Image = Image.FromFile("D:/2018_TU HOC WINFORM/2018_QuanLyThuVien/2018_QuanLyThuVien/icon/btnSach.PNG");
            btnSach.ImageAlign = ContentAlignment.MiddleCenter;
            btnSach.TextAlign = ContentAlignment.MiddleLeft;
            btnSach.Text = "Sách";
            //btnClose
            btnClose.Image = Image.FromFile("D:/2018_TU HOC WINFORM/2018_QuanLyThuVien/2018_QuanLyThuVien/icon/btnClose.PNG");
            btnClose.ImageAlign = ContentAlignment.MiddleCenter;
            btnClose.TextAlign = ContentAlignment.MiddleLeft;
            btnClose.Text = "";
            //btnRestart
            btnRestart.Image = Image.FromFile("D:/2018_TU HOC WINFORM/2018_QuanLyThuVien/2018_QuanLyThuVien/icon/btnRestart.PNG");
            btnRestart.ImageAlign = ContentAlignment.MiddleCenter;
            btnRestart.TextAlign = ContentAlignment.MiddleLeft;
            btnRestart.Text = "";
            //btnXuatNhap
            btnXuatNhap.Image = Image.FromFile("D:/2018_TU HOC WINFORM/2018_QuanLyThuVien/2018_QuanLyThuVien/icon/btnXuatNhap.PNG");
            btnXuatNhap.ImageAlign = ContentAlignment.MiddleCenter;
            btnXuatNhap.TextAlign = ContentAlignment.MiddleLeft;
            btnXuatNhap.Text = "";
            //btnKhachHang
            btnKhachHang.Image = Image.FromFile("D:/2018_TU HOC WINFORM/2018_QuanLyThuVien/2018_QuanLyThuVien/icon/btnKhachHang.PNG");
            btnKhachHang.ImageAlign = ContentAlignment.MiddleCenter;
            btnKhachHang.TextAlign = ContentAlignment.MiddleLeft;
            btnKhachHang.Text = "";
            //btnBack
            btnBack.Image = Image.FromFile("D:/2018_TU HOC WINFORM/2018_QuanLyThuVien/2018_QuanLyThuVien/icon/btnUSER.PNG");
            btnBack.ImageAlign = ContentAlignment.MiddleCenter;
            btnBack.TextAlign = ContentAlignment.MiddleLeft;
            btnBack.Text = "";
            //btnTTK
            btnTTK.Image = Image.FromFile("D:/2018_TU HOC WINFORM/2018_QuanLyThuVien/2018_QuanLyThuVien/icon/btnTTK.PNG");
            btnTTK.ImageAlign = ContentAlignment.MiddleCenter;
            btnTTK.TextAlign = ContentAlignment.MiddleLeft;
            btnTTK.Text = "";
            //btnQLUSER
            btnQLUSER.Image = Image.FromFile("D:/2018_TU HOC WINFORM/2018_QuanLyThuVien/2018_QuanLyThuVien/icon/btnQLUSER.PNG");
            btnQLUSER.ImageAlign = ContentAlignment.MiddleCenter;
            btnQLUSER.TextAlign = ContentAlignment.MiddleLeft;
            btnQLUSER.Text = "";
        }
        void ToolTip()
        {
            //btnClose
            ToolTip btnClo = new ToolTip();
            btnClo.SetToolTip(btnClose, "Đóng chương trình");
            //btnRestart
            ToolTip btnRes = new ToolTip();
            btnRes.SetToolTip(btnRestart, "Tải lại dữ liệu");
            //btnSach
            ToolTip btnSac = new ToolTip();
            btnSac.SetToolTip(btnSach, "Thông tin của sách ở Database");
            //btnKhachHang
            ToolTip btnKha = new ToolTip();
            btnKha.SetToolTip(btnKhachHang, "Phiếu mượn và Thông tin của Khách hàng");
            //btnXuatNhap
            ToolTip btnXua = new ToolTip();
            btnXua.SetToolTip(btnXuatNhap, "Đơn nhập và chi tiết đơn nhập");
            //btnBack
            ToolTip btnBac = new ToolTip();
            btnBac.SetToolTip(btnBack, "Thông tin người dùng");
            //btnTTK
            ToolTip btnttk = new ToolTip();
            btnttk.SetToolTip(btnTTK, "Các thông tin bổ xung");
            //btnQLUSER
            ToolTip btnQLU = new ToolTip();
            btnQLU.SetToolTip(btnQLUSER, "Các thông tin bổ xung");
        }
        // xử lý phân quyền
        private void xuLyPhanQuyen(string a)
        {
            if (a.Equals(""))
                Application.Exit();
            if (!a.Equals("admin"))
            {
               // btnBack.Visible = false;
                btnKhachHang.Visible = false;
                lableKH.Visible = false;
                lblU.Visible = false;
                btnQLUSER.Visible = false;
            }
            else
            {
                btnBack.Visible = false;
            }
        }

        // ------------- lấy thông tin người dùng đưa vào lable

        //-----------------------------------------------------------------
        private void frmHomePage_Load(object sender, EventArgs e)
        {
            //bảo mật
        frmSecurity frmS = new frmSecurity();
            // lay tai khoan dang nhap
            frmS.tdlTK = new frmSecurity.TruyenDulieu(nhanTK);
            frmS.ShowDialog();
            // gọi gợi ý
            
            xuLyPhanQuyen(taiKhoanDangNhap);
            ToolTip();
            loadIcon();
           
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Thoát chương trình", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
                Application.Exit();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {

        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            frmQuanLySach f2 = new frmQuanLySach(taiKhoanDangNhap);
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang f2 = new frmKhachHang();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmUSER f = new frmUSER(taiKhoanDangNhap);
            f.ShowDialog();
        }

        private void btnQLUSER_Click(object sender, EventArgs e)
        {
            frmQLUSER f2 = new frmQLUSER();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }
    }
}
