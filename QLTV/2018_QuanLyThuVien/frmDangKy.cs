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
    public partial class frmDangKy : Form
    {
        string conStr = @"Data Source = UX305FA;" + "Initial Catalog = QLTV_16110112_Thu3;" + "User ID = sa; Password = hongkha123";
        SqlConnection conn = null; private void openConnect()
        {
            conn = new SqlConnection(conStr);
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
        }
        string takeString(string txtBoxDonGia)
        {
            string kq = "";
            int t = 0;
            while (t < txtBoxDonGia.Length && txtBoxDonGia[t] != '.')
            {
                kq = kq + txtBoxDonGia[t];
                t++;
            }
            return kq;
        }
        private bool kiemTraSo()
        {
            try
            {
                Int32.Parse(takeString(txtCMND.Text));

            }
            catch
            {
                MessageBox.Show("CMND phải là số");
               txtCMND.Focus();
                return false;
            }
            try
            {
                Int32.Parse(txtNamSinh.Text);
            }
            catch
            {
                MessageBox.Show("Năm sinh phải là số");
                txtNamSinh.Focus();
                return false;
            }
            return true;
        }
        /// <summary>
        /// /-------------- kiem tra co san
        private void kiemTra(string table, string primarykey, string str)
        {
            openConnect();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select count(*) from " + table + " where " + primarykey + " ='" + str + "'";
                int soluong = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (soluong > 0)
                {
                    MessageBox.Show("Tài khoản đã có người sử dụng");
                     txtTenTK.ResetText();
                    txtTenTK.Focus();
                }
                else
                {
                    txtMK.Focus();
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
        public frmDangKy()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void frmDangKy_Load(object sender, EventArgs e)
        {

            checkBox1.CheckState = CheckState.Checked;
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            if (checkNull())
            {
                if (kiemTraSo())
                {
                    conn = new SqlConnection(conStr);
                    openConnect();
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        string GT = "Nam";
                        if (checkBox2.CheckState == CheckState.Checked)
                            GT = "Nu";
                        cmd.CommandText = "insert into MATKHAU values ('" + txtMK.Text + "','" + txtTenTK.Text + "','0',"
                            + Convert.ToInt16(txtPIN.Text) +
                            ",N'" + txtHoTen.Text + "'," + Int16.Parse(txtNamSinh.Text) + ",'" + GT + "'," + Int64.Parse(txtCMND.Text) + ",'" + txtEmail.Text + "')";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đăng ký thành công");
                        this.Close();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Tài khoản đã có người sử dụng");
                        txtTenTK.Focus();
                        txtTenTK.ResetText();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
                checkBox2.CheckState = CheckState.Unchecked;
            else
            {
                checkBox1.CheckState = CheckState.Unchecked;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.CheckState == CheckState.Checked)
                checkBox1.CheckState = CheckState.Unchecked;
            else
            {
                checkBox2.CheckState = CheckState.Unchecked;
            }
        }

        private void txtTenTK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                kiemTra("MATKHAU", "TK", txtTenTK.Text);
        }

        private void txtMK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPIN.Focus();
        }

        private void txtPIN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtHoTen.Focus();
        }



        private void txtHoTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtNamSinh.Focus();
        }

        private void txtNamSinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCMND.Focus();
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnDK_Click(null, null);
        }
        private bool checkNull()
        {
            if(txtHoTen.Text.Equals(""))
            {
                MessageBox.Show("Không để trống Họ Tên");
                txtHoTen.Focus();
                return false;
            }
            if (txtMK.Text.Equals(""))
            {
                MessageBox.Show("Không để trống Mật khẩu");
                txtMK.Focus();
                return false;
            }
            if (txtNamSinh.Text.Equals(""))
            {
                MessageBox.Show("Không để trống Năm sinh");
                txtNamSinh.Focus();
                return false;
            }
            if (txtPIN.Text.Equals(""))
            {
                MessageBox.Show("Không để trống PIN");
                txtPIN.Focus();
                return false;
            }
            if (txtTenTK.Text.Equals(""))
            {
                MessageBox.Show("Không để trống Tài Khoản");
                txtTenTK.Focus();
                return false;
            }
            if (txtCMND.Text.Equals(""))
            {
                MessageBox.Show("Không để trống Năm sinh");
                txtCMND.Focus();
                return false;
            }
            if(checkBox1.CheckState == checkBox2.CheckState)
            {
                MessageBox.Show("Chọn giới tính");
                return false;
            }
            return true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
