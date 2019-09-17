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
    public partial class frmThemSach : Form
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
        public frmThemSach()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThemSach_Load(object sender, EventArgs e)
        {
            txtMaTheLoai.Enabled = false;
            txtMaSach.Focus();
        }
        //-------------------------------------------------------Cac ham xu ly chuoi error khi don gia convert to int bi loi
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
                Int32.Parse(takeString(txtDonGia.Text));

            }
            catch
            {
                MessageBox.Show("Đơn giá phải là số");
                txtDonGia.Focus();
                return false;
            }
            try
            {
                Int32.Parse(txtSoLuong.Text);
            }
            catch
            {
                MessageBox.Show("Số lượng phải là số");
                txtSoLuong.Focus();
                return false;
            }
            return true;
        }
        //-------------------------------------------------------Cac ham kiem tra
        //----------------------- kiem tra co san
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
                    MessageBox.Show("Dữ liệu bị trùng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaSach.ResetText();
                    txtMaSach.Focus();
                }
                else
                {
                    txtTenSach.Focus();
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
        //------------------------kiem tra khong co san
        private void kiemTra_2(string table, string primarykey, string str)
        {
            openConnect();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select count(*) from " + table + " where " + primarykey + " ='" + str + "'";
                int soluong = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (soluong < 1)
                {
                    MessageBox.Show("Mã thể loại không có sẵn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaTheLoai.ResetText();
                    txtMaTheLoai.Focus();
                }
                else
                {
                    if (txtSoLuong.Text.Equals(""))
                        txtSoLuong.Focus();
                    else
                    {
                        if (txtDonGia.Text.Equals(""))
                            txtDonGia.Focus();
                        else
                        {
                            conn.Close();
                        }
                    }
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
        //------------------------------------------------------- Xu ly LUU -----------------very important
        private void btnLuu_Click(object sender, EventArgs e)
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
                    cmd.CommandText = "insert into SACH (MaSach,TenSach,TacGia,SoLuong,DonGia) values('"
                        + txtMaSach.Text + "',N'" + txtTenSach.Text + "',N'" + txtTacGia.Text + "'," + Int32.Parse(txtSoLuong.Text) + "," + Int32.Parse(txtDonGia.Text) + ");";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    if (!txtMaTheLoai.Text.Equals("") && checkBox1.CheckState == CheckState.Checked)
                    {
                        conn.Open();
                        SqlCommand cmd2 = new SqlCommand();
                        cmd2.Connection = conn;
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "update SACH set MaTheLoai = '" + txtMaTheLoai.Text + "' where MaSach = '" + txtMaSach.Text + "';";
                        cmd2.ExecuteNonQuery();
                        conn.Close();
                    }
                    MessageBox.Show("Đã thêm dữ liệu");
                    this.Close();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Mã Thể Loại không có sẵn");
                    txtMaTheLoai.Focus();

                }
                conn.Close();

            }
        }
        //------------------------------------------------------- Xu ly KeyDown
        private void txtMaSach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                kiemTra("SACH", "MaSach", txtMaSach.Text);
            }
        }

        private void txtTenSach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTacGia.Focus();
            }
        }

        private void txtTacGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checkBox1.CheckState == CheckState.Checked)
                    txtMaTheLoai.Focus();
                else
                    txtSoLuong.Focus();
            }
        }

        private void txtMaTheLoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                kiemTra_2("THE_LOAI", "MaTheLoai", txtMaTheLoai.Text);
            }
        }

        private void txtSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDonGia.Focus();
            }
        }

        private void txtDonGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLuu_Click(null, null);
            }
        }
        //-------------------------------------------------------- Xu ly CHECKBOX
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                txtMaTheLoai.Enabled = true;
            }
            else
            {
                txtMaTheLoai.Enabled = false;
            }
        }
        //-------------------------------------------------------- xuLy Lable
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmThemTheLoai f = new FrmThemTheLoai();
            f.ShowDialog();
        }

        private void llbGoiy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmGoiYTheLoai F = new frmGoiYTheLoai();
            F.ShowDialog();
        }
    }
}
  

    
