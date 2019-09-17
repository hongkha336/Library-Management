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
    public partial class frmSua : Form
    {
        string conStr = @"Data Source = UX305FA;" + "Initial Catalog = QLTV_16110112_Thu3;" + "User ID = sa; Password = hongkha123";
        SqlConnection conn = null;
        string MaSach, TenSach, TacGia, MaTL, SoLuong, DonGia;
        private void openConnect()
        {
            conn = new SqlConnection(conStr);
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
        }

        private void loadData()
        {
            txtMaSach.Text = MaSach;
            txtMaTheLoai.Text = MaTL;
            // txtMaSach va txtMaTheLoai khong the sua
            txtDonGia.Text = DonGia;
            txtSoLuong.Text = SoLuong;
            txtTacGia.Text = TacGia;
            txtTenSach.Text = TenSach;
        }
        public frmSua(string a, string b, string c, string d, string e, string f)
        {
            MaSach = a;
            TenSach = b;
            TacGia = c;
            MaTL = d;
            SoLuong = e;
            DonGia = f;
            InitializeComponent();
        }

        private void frmSua_Load(object sender, EventArgs e)
        {
            txtMaSach.Enabled = false;
            txtMaTheLoai.Enabled = false;
            loadData();
        }

        //--------------------------------------------------------------------------- HÀM KIỂM TRA
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
        private bool kiemTra()
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
        //---------------------------------------------------------------------------- XỬ LÝ LỖI ĐƠN GIÁ
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

        //------------------------------------------------------------------------------ KeyDOWN
        private void txtTacGia_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSoLuong.Focus();
            }
        }

        private void txtSoLuong_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDonGia.Focus();
            }
        }

        private void txtTenSach_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTacGia.Focus();
            }
        }

        private void txtDonGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLuu_Click(null, null);
        }
        //-----------------------------------------------------------------------------
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //------------------------------------------------------------------------------ btnLuu very Important
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kiemTra())
            {
                openConnect();
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // đơn giá có dấu .00 nên đổi qua số bị lỗi, phải cắt bỏ
                    cmd.CommandText = "update SACH set DonGia = " + Int32.Parse(takeString(txtDonGia.Text)) + " where MaSach = '" + txtMaSach.Text + "';";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "update SACH set SoLuong = " + Int32.Parse(txtSoLuong.Text) + " where MaSach = '" + txtMaSach.Text + "';";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "update SACH set TacGia = N'" + txtTacGia.Text + "' where MaSach = '" + txtMaSach.Text + "';";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "update SACH set TenSach = N'" + txtTenSach.Text + "' where MaSach = '" + txtMaSach.Text + "';";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa đổi thành công!");

                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi trong quá trình chỉnh sửa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
                this.Close();
            }
        }

    }
}
