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
    public partial class frmSuaKhachHang : Form
    {
        string conStr = @"Data Source = UX305FA;" + "Initial Catalog = QLTV_16110112_Thu3;" + "User ID = sa; Password = hongkha123";
        SqlConnection conn = null;
        string MaKH, HoTen, MaLoaiKH, TienNo, DiemTichLuy;
        public frmSuaKhachHang()
        {
            InitializeComponent();
        }
        public frmSuaKhachHang(string a, string b, string c, string d, string e)
        {
            MaKH = a;
            HoTen = b;
            MaLoaiKH = c;
            TienNo = d;
            DiemTichLuy = e;
            InitializeComponent();
        }
        private void loadData()
        {
            txtHoTen.Text = HoTen;
            txtDiemTichLuy.Text = DiemTichLuy;
            txtMaKH.Text = MaKH;
            txtMaLoaiKH.Text = MaLoaiKH;
            txtTienNo.Text = TienNo;
        } 
        
        private void frmSuaKhachHang_Load(object sender, EventArgs e)
        {
            txtMaKH.Enabled = false;
            txtMaLoaiKH.Enabled = false;
            loadData();
        }
        private void openConnect()
        {
            conn = new SqlConnection(conStr);
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
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
        private bool kiemTraSo()
        {
            try
            {
                Int32.Parse(takeString(txtTienNo.Text));

            }
            catch
            {
                MessageBox.Show("Tiền nợ phải là số");
                txtTienNo.Focus();
                return false;
            }
            try
            {
                Int32.Parse(txtDiemTichLuy.Text);
            }
            catch
            {
                MessageBox.Show("Điểm tích lũy phải là số");
                txtDiemTichLuy.Focus();
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
                    MessageBox.Show("Dữ liệu bị trùng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaKH.ResetText();
                    txtMaKH.Focus();
                }
                else
                {
                    txtHoTen.Focus();
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
                    txtMaLoaiKH.ResetText();
                    txtMaLoaiKH.Focus();
                }
                else
                {
                    if (txtTienNo.Text.Equals(""))
                        txtTienNo.Focus();
                    else
                    {
                        if (txtDiemTichLuy.Text.Equals(""))
                            txtDiemTichLuy.Focus();
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

        private void txtMaKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                return;
        }

        private void txtHoTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTienNo.Focus();
            }
        }

        private void txtTienNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtTienNo.Text.Equals(""))
                    txtTienNo.Text = "0";
                if (!KiemTraToiDa())
                {
                    MessageBox.Show("Số tiền nợ vượt quá mức cho phép của loại người dùng " + txtMaLoaiKH.Text);
                    txtTienNo.Focus();
                    return;
                }
                txtDiemTichLuy.Focus();
            }
        }

        private void txtDiemTichLuy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtDiemTichLuy.Text.Equals(""))
                    txtDiemTichLuy.Text = "0";
                btnLuu_Click(null, null);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kiemTraSo())
            {
                if (KiemTraToiDa())
                {
                    openConnect();
                    try
                    {

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        // đơn giá có dấu .00 nên đổi qua số bị lỗi, phải cắt bỏ
                        cmd.CommandText = "update KHACH_HANG set TienNo = " + Int32.Parse(takeString(txtTienNo.Text)) + " where MaKH = '" + txtMaKH.Text + "';";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "update KHACH_HANG set DiemTichLuy = " + Int32.Parse(txtDiemTichLuy.Text) + " where MaKH = '" + txtMaKH.Text + "';";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "update KHACH_HANG set HoTen = N'" + txtHoTen.Text + "' where MaKH = '" + txtMaKH.Text + "';";
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
            else
            {
                MessageBox.Show("Số tiền nợ vượt quá mức cho phép của loại người dùng " + txtMaLoaiKH.Text);
                txtTienNo.Focus();
            }
        }
        private int takeNo(string table, string primarykey, string str, string frkey, Int64 a)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select count(*) from " + table + " where " + primarykey + " ='" + str + "' and " + frkey + " > " + a;
            int soluong = Int16.Parse(cmd.ExecuteScalar().ToString());
            conn.Close();
            return soluong;
        }
        private bool KiemTraToiDa()
        {
            if (!txtMaLoaiKH.Text.Equals(""))
            {
                int soluong = takeNo("LOAI_NGUOI_DUNG", "MaLoai", txtMaLoaiKH.Text, "TienNoToiDa", Int64.Parse(txtTienNo.Text));
                if (soluong == 1)
                    return true;

            }
            return false;
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
