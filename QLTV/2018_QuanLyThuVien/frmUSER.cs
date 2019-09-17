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
    public partial class frmUSER : Form
    {

        string conStr = @"Data Source = UX305FA;"
                            + "Initial Catalog = QLTV_16110112_Thu3;"
                            + "User ID = sa; Password = hongkha123";
        SqlConnection conn = null;
        SqlDataAdapter daTT = null;
        DataTable dtTT = null;
        string taiKhoanDangNhap;
        public frmUSER()
        {
            InitializeComponent();
        }
        public frmUSER(string a)
        {
            taiKhoanDangNhap = a;
            InitializeComponent();
        }
        private void openConnect()
        {
            conn = new SqlConnection(conStr);
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
        }
        private void loadData()
        {
            panel1.Enabled = false;
                try
            {
                openConnect();
                daTT = new SqlDataAdapter("select HoTen,GioiTinh,Namsinh,CMND,EMAIL from MATKHAU where TK = '"+taiKhoanDangNhap+"'", conn);
                dtTT = new DataTable();
                daTT.Fill(dtTT);
                conn.Close();
                dataGridView1.DataSource = dtTT;
                string gt = dataGridView1.Rows[0].Cells[1].Value.ToString();
                if (String.Compare(gt, "Nam       ") ==0)
                    checkBox1.CheckState = CheckState.Checked;
                else
                    checkBox2.CheckState = CheckState.Checked;
                textBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                textBox4.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
                textBox6.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
                textBox2.ResetText();
                textBox3.ResetText();
            }
            catch(SqlException)
            {
                MessageBox.Show("Lỗi");
                this.Close();
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

            ToolTip btnBac = new ToolTip();
            btnBac.SetToolTip(btnBack, "Quay về trang trước");


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
        private void frmUSER_Load(object sender, EventArgs e)
        {
            ToolTip();
            loadIcon();
            loadData();
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            panel1.Enabled = false;
            btnSua.Enabled = true;
            loadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled =true;
            panel1.Enabled = true;

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                openConnect();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update MATKHAU set HoTen = N'" + textBox1.Text + "' where TK = '" + taiKhoanDangNhap + "'";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "update MATKHAU set NamSinh = " + textBox4.Text + " where TK = '" + taiKhoanDangNhap + "'";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "update MATKHAU set CMND = " + textBox5.Text + " where TK = '" + taiKhoanDangNhap + "'";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "update MATKHAU set Email = '" + textBox6.Text + "' where TK = '" + taiKhoanDangNhap + "'";
                cmd.ExecuteNonQuery();
                string gt = "Nam";
                if (checkBox2.CheckState == CheckState.Checked)
                    gt = "Nu";
                cmd.CommandText = "update MATKHAU set GioiTinh = '" + gt + "' where TK = '" + taiKhoanDangNhap + "'";
                cmd.ExecuteNonQuery();

                if(!textBox2.Text.Equals(""))
                    cmd.CommandText = "update MATKHAU set MK = '" + textBox2.Text + "' where TK = '" + taiKhoanDangNhap + "'";
                cmd.ExecuteNonQuery();
                if (!textBox3.Text.Equals(""))
                    cmd.CommandText = "update MATKHAU set PIN = '" + textBox3.Text + "' where TK = '" + taiKhoanDangNhap + "'";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Cập nhật thành công");
                loadData();
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnSua.Enabled = true;
                panel1.Enabled = false;
            }
            catch(SqlException)
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
                checkBox2.CheckState = CheckState.Unchecked;
            else
            {
                checkBox2.CheckState = CheckState.Checked;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.CheckState == CheckState.Checked)
                checkBox1.CheckState = CheckState.Unchecked;
            else
            {
                checkBox1.CheckState = CheckState.Checked;
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
