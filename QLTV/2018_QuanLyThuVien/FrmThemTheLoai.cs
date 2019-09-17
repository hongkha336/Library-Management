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
    public partial class FrmThemTheLoai : Form
    {
        string conStr = @"Data Source = UX305FA;" + "Initial Catalog = QLTV_16110112_Thu3;" + "User ID = sa; Password = hongkha123";
        SqlConnection conn = null;
        private void openConnect()
        {
            conn = new SqlConnection(conStr);
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
        }
        public FrmThemTheLoai()
        {
            InitializeComponent();
        }
        //------------------------------------------------------------------------CAC THE LOAI KIEM TRA
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
                Int32.Parse(takeString(txtHSDM.Text));

            }
            catch
            {
                MessageBox.Show("Hệ số phải là số");
                txtHSDM.Focus();
                return false;
            }
            try
            {
                Int32.Parse(txtSL.Text);
            }
            catch
            {
                MessageBox.Show("Số lượng phải là số");
                txtSL.Focus();
                return false;
            }
            return true;
        }
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
                    MessageBox.Show("Dữ liệu bị trùng", "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    txtMaTL.ResetText();
                    txtMaTL.Focus();
                }
                else
                {
                    txtTenTL.Focus();
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
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //-------------------------------------------------------------------------KEY DOWN
        private void txtMaTL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                kiemTra("THE_LOAI", "MaTheLoai", txtMaTL.Text);
        }

        private void txtTenTL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtSL.Focus();
        }

        private void txtSL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtHSDM.Focus();
        }

        private void txtHSDM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLuu_Click(null, null);
        }
//----------------------------------------------------------------------------FRMload
        private void FrmThemTheLoai_Load(object sender, EventArgs e)
        {
            txtMaTL.Focus();
        }
//-----------------------------------------------------------------------------btnLUU ----------------very Important
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kiemTraSo())
            {
                if (!txtMaTL.Text.Equals("") && !txtTenTL.Text.Equals("") &&
                    !txtHSDM.Text.Equals("") && !txtSL.Text.Equals(""))
                {
                    openConnect();
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Insert into THE_LOAI values ('" + txtMaTL.Text + "',N'" + txtTenTL.Text + "',"
                            + Int32.Parse(txtSL.Text) + "," + Int32.Parse(txtHSDM.Text) + ");";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đã thêm thể loại thành công");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Lỗi");
                    }
                    conn.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Dữ liệu còn trống");
                }
            }
        }
    }
}
