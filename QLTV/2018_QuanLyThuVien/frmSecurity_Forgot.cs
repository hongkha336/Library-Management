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
    public partial class frmSecurity_Forgot : Form
    {
        string conStr = @"Data Source = UX305FA;" + "Initial Catalog = QLTV_16110112_Thu3;" + "User ID = sa; Password = hongkha123";
        SqlConnection conn = null;
        SqlDataAdapter daPIN = null;
        DataTable dtPIN = null;
        private void openConnect()
        {
            conn = new SqlConnection(conStr);
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
        }
        string TaiKhoan;
        public frmSecurity_Forgot(string a)
        {
            TaiKhoan = a;
            InitializeComponent();
        }

        private void frmSecurity_Forgot_Load(object sender, EventArgs e)
        {
            textBox1.Text = TaiKhoan;
            lbMK.Visible = false;
            label3.Visible = false;
        }
        private void kiemTraTrung(string table, string strTK, string strMK)
        {
            openConnect();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select count(*) from " + table + " where TK ='" + strTK + "' and PIN ='" + strMK + "'";
                int soluong = Int32.Parse(cmd.ExecuteScalar().ToString());

                if (soluong == 0)
                {
                    MessageBox.Show("Mã PIN không đúng", "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                    conn.Close();
                    textBox2.Focus();
                  //  this.Close();
                    
                }
                else
                {
                    conn.Close();
                    lbMK.Visible = true;
                    label3.Visible = true;
                    // show Mật khẩu
                    layMK(strTK);
                   // this.Close();
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
       private void layMK(string TK)
        {
            try
            {
                openConnect();
                daPIN = new SqlDataAdapter("Select * From MATKHAU where TK ='"+TK +"'", conn);
                dtPIN = new DataTable();
                daPIN.Fill(dtPIN);
                conn.Close();
                lbMK.DataSource = dtPIN;
                lbMK.DisplayMember = "MK";

            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi");
            }
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            kiemTraTrung("MATKHAU", textBox1.Text, textBox2.Text);
          
                

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox2.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnTim_Click(null, null);
        }
    }
}
