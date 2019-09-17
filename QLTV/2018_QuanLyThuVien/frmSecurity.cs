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

    public partial class frmSecurity : Form
    {
        //------------------ Truyển dữ liệu qua form
        public delegate void TruyenDulieu(string strTK);
        public TruyenDulieu tdlTK;
        
        public void truyenTKRa()
        {
            if (tdlTK != null)
            {
                string thongtinTK = txtTK.Text;
                tdlTK(thongtinTK);
            }
        }
        //
        //
        string conStr = @"Data Source = UX305FA;" + "Initial Catalog = QLTV_16110112_Thu3;" + "User ID = sa; Password = hongkha123";
        SqlConnection conn = null;

        private void openConnect()
        {
            conn = new SqlConnection(conStr);
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
        }
        //
        public frmSecurity()
        {
            InitializeComponent();
        }
        private void kiemTraTrung(string table, string strTK, string strMK)
        {
            openConnect();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select count(*) from " + table + " where TK ='" +strTK+ "' and MK ='" + strMK + "'";
                int soluong = Int32.Parse(cmd.ExecuteScalar().ToString());

                if (soluong ==0)
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng", "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                 //   txtTK.ResetText();
                    txtMK.ResetText();
                    txtTK.Focus();
                }
                else
                {
                    truyenTKRa();
                    conn.Close();
                    this.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi");
            }
            finally
            {
                conn.Close();
            }
        }

        private void frmSecurity_Load(object sender, EventArgs e)
        {
            txtTK.Focus();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            kiemTraTrung("MATKHAU", txtTK.Text, txtMK.Text);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Thoát chương trình","", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
                Application.Exit();
        }

        private void txtTK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMK.Focus();
        }

        private void txtMK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnDN_Click(null, null);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSecurity_Forgot f = new frmSecurity_Forgot(txtTK.Text);
            this.Visible = false;
            f.ShowDialog();
            this.Visible = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDangKy f2 = new frmDangKy();
            this.Visible = false;
            f2.ShowDialog();
            this.Visible = true;
        }
    }
}
