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
    public partial class frmQuanLySach : Form
    {
        string conStr = @"Data Source = UX305FA;" + "Initial Catalog = QLTV_16110112_Thu3;" + "User ID = sa; Password = hongkha123";
        SqlConnection conn = null;
        SqlDataAdapter daSACH = null;
        DataTable dtSACH = null;
        string taiKhoanDangNhap;
        //DataTable dtMaSach = null;
        //SqlDataAdapter daMaSach = null;
        public frmQuanLySach()
        {
            InitializeComponent();
        }
        public frmQuanLySach(string a)
        {
            taiKhoanDangNhap = a;
            InitializeComponent();
        }
        private void xuLyPhanQuyen(string a)
        {
            if (!a.Equals("admin"))
            {
                btnXoa.Enabled = false;
                //lableKH.Enabled = false;
            }
        }
        void ToolTip()
        {
            //btnClose
            ToolTip btnClo = new ToolTip();
            btnClo.SetToolTip(btnClose, "Đóng chương trình");
            //btnRestart
            ToolTip btnRes = new ToolTip();
            btnRes.SetToolTip(btnRestart, "Tải lại dữ liệu");
            //btnBack
            ToolTip btnBac = new ToolTip();
            btnBac.SetToolTip(btnBack, "Trở về trang trước");

        }
        void loadIcon()
        {
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
            //btnBack
            btnBack.Image = Image.FromFile("D:/2018_TU HOC WINFORM/2018_QuanLyThuVien/2018_QuanLyThuVien/icon/btnBack.PNG");
            btnBack.ImageAlign = ContentAlignment.MiddleCenter;
            btnBack.TextAlign = ContentAlignment.MiddleLeft;
            btnBack.Text = "";

        }
        //------------------------------------------------------------lấy thông tin
        private void openConnect()
        {
            conn = new SqlConnection(conStr);
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
        }
        private void loadData()
        {
            try
            {
                openConnect();
                daSACH = new SqlDataAdapter("Select * from SACH", conn);
                dtSACH = new DataTable();
   
                daSACH.Fill(dtSACH);
                dgvSACH.DataSource = dtSACH;

                //daMaSach = new SqlDataAdapter("Select * from THE_LOAI", conn);
                //dtMaSach = new DataTable();
                //daMaSach.Fill(dtMaSach);

                //TenTheLoai.DataSource = dtMaSach;
                //TenTheLoai.DisplayMember = "TenTheLoai";
                //TenTheLoai.ValueMember = "MaTheLoai";
                conn.Close();
                
               
               
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thể kết nối đến CSDL", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //-----------------------------------------------------------
        private void frmQuanLySach_Load(object sender, EventArgs e)
        {
            loadIcon();
            ToolTip();
            loadData();
            xuLyPhanQuyen(taiKhoanDangNhap);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Thoát chương trình", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
                Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            loadData();
        }
        //-------------------------------------------------------------------- THÊM
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemSach f = new frmThemSach();
            f.ShowDialog();
            loadData();
        }
        //-------------------------------------------------------------------- SỬA
        private void btnSửa_Click(object sender, EventArgs e)
        {
          
            int r = dgvSACH.CurrentCell.RowIndex;
            string a = dgvSACH.Rows[r].Cells[0].Value.ToString();
            string b = dgvSACH.Rows[r].Cells[1].Value.ToString();
            string c = dgvSACH.Rows[r].Cells[2].Value.ToString();
            string d = dgvSACH.Rows[r].Cells[3].Value.ToString();
            string e1 = dgvSACH.Rows[r].Cells[4].Value.ToString();
            string f = dgvSACH.Rows[r].Cells[5].Value.ToString();
           frmSua fr = new frmSua(a, b, c, d, e1, f);
            fr.ShowDialog();
            loadData();
        }
//-------------------------------------------------------------------- XÓA
        void xoaPT(string Bang, string khoachinh, string str)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText =
                "Delete From " + Bang + " Where " + khoachinh + " = '"
                + str + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {

            DialogResult tl = MessageBox.Show("Xóa dữ liệu?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tl == DialogResult.OK)
            {
                openConnect();
                try
                {
                    int r = dgvSACH.CurrentCell.RowIndex;
                    string strThanhPho = dgvSACH.Rows[r].Cells[0].Value.ToString();

                    xoaPT("CT_DONNHAP", "MaSach", strThanhPho);
                    xoaPT("CT_PHIEUMUON", "MaSach", strThanhPho);
                    xoaPT("CT_DONHANG", "MaSach", strThanhPho);
                    xoaPT("SACH", "MaSach", strThanhPho);
                    loadData();

                    MessageBox.Show("Đã xóa xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Có lỗi xảy ra trong quá trình xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();

            }
        }

        private void dgvSACH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
