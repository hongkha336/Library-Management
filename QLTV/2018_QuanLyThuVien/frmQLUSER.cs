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
    public partial class frmQLUSER : Form
    {
        string conStr = @"Data Source = UX305FA;" + "Initial Catalog = QLTV_16110112_Thu3;" + "User ID = sa; Password = hongkha123";
        SqlConnection conn = null;
        SqlDataAdapter daUS = null;
        DataTable dtUS = null;
        private void openConnect()
        {
            conn = new SqlConnection(conStr);
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
        }
        public frmQLUSER()
        {
            InitializeComponent();
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
        private void loadData()
        {
            try
            {
                openConnect();
                daUS = new SqlDataAdapter("Select * from MATKHAU where TK != 'admin'", conn);
                dtUS = new DataTable();
                daUS.Fill(dtUS);
                dataGridView1.DataSource = dtUS;
                conn.Close();
            }
            catch(SqlException)
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void frmQLUSER_Load(object sender, EventArgs e)
        {
            ToolTip();
            loadIcon();
            loadData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Thoát chương trình", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
                Application.Exit();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                openConnect();
                int r = dataGridView1.CurrentCell.RowIndex;
                string TK = dataGridView1.Rows[r].Cells[1].Value.ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText ="delete from MATKHAU where TK ='"+TK+"'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã xóa người dùng " + TK);
                loadData();
                conn.Close();    
            }
            catch(SqlException)
            {
                MessageBox.Show("Lỗi");
            }

        }
    }
}
