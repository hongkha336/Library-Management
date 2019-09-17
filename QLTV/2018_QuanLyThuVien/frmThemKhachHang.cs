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
    public partial class frmThemKhachHang : Form
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
        public frmThemKhachHang()
        {
            InitializeComponent();
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
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThemKhachHang_Load(object sender, EventArgs e)
        {
            txtMaLoaiKH.Enabled = false;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.CheckState == CheckState.Checked)
            {
                txtMaLoaiKH.Enabled = true;
            }
            else
            {
                txtMaLoaiKH.Enabled = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kiemTraSo())
            {
                if (KiemTraToiDa())
                {
                    if (!txtHoTen.Text.Equals("") && !txtMaKH.Text.Equals(""))
                    {
                        openConnect();
                        try
                        {
                        
                         SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                         cmd.CommandText = "insert into KHACH_HANG (MaKH) values ('"+txtMaKH.Text+"')";
                            cmd.ExecuteNonQuery();
                         cmd.CommandType = CommandType.Text;
                            if (!txtMaLoaiKH.Text.Equals("") && checkBox2.CheckState == CheckState.Checked)
                            {
                                // conn.Open();
                                SqlCommand cmd2 = new SqlCommand();
                                cmd2.Connection = conn;
                                cmd2.CommandType = CommandType.Text;
                                cmd2.CommandText = "update KHACH_HANG set MaLoaiKH = '" + txtMaLoaiKH.Text + "' where MaKH = '" + txtMaKH.Text + "';";
                                cmd2.ExecuteNonQuery();
                                //    conn.Close();
                            }
                            // cmd.CommandText = "update KHACH_HANG set values( N'" + txtHoTen.Text + "'," + Int32.Parse(txtTienNo.Text) + "," + Int32.Parse(txtDiemTichLuy.Text) + ");";
                            cmd.CommandText = "update KHACH_HANG set HoTen = N'" + txtHoTen.Text + "' where MaKH = '" + txtMaKH.Text + "';";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "update KHACH_HANG set TienNo = " + Int32.Parse(txtTienNo.Text) + " where MaKH = '" + txtMaKH.Text + "';";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "update KHACH_HANG set DiemTichLuy = " + Int32.Parse(txtDiemTichLuy.Text) + " where MaKH = '" + txtMaKH.Text + "';";
                            cmd.ExecuteNonQuery();
                            conn.Close();

                            MessageBox.Show("Đã thêm khách hàng");
                            this.Close();
                        }
                        catch (SqlException)
                        {
                            MessageBox.Show("Mã Loại khách hàng không có sẵn");
                            txtMaKH.Focus();
                        }
                    }
                    else
                    {

                        if (txtMaKH.Text.Equals(""))
                        {
                            MessageBox.Show("Mã khách hàng không thể bỏ trống");
                            txtMaKH.Focus();

                        }
                        else
                        {
                            MessageBox.Show("Tên khách hàng không thể bỏ trống");
                            txtHoTen.Focus();
                        }
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Số tiền nợ vượt quá mức cho phép của loại người dùng " + txtMaLoaiKH.Text);
                    txtTienNo.Focus();
                }
            }

        }

        private void txtMaKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMaKH.Text.Equals(""))
                {
                    MessageBox.Show("Mã Khách Hàng không được để trống");
                    txtMaKH.Focus();
                    return;
                }
                kiemTra("KHACH_HANG", "MaKH", txtMaKH.Text);
            }
        }

        private void txtHoTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtHoTen.Text.Equals(""))
                {
                    MessageBox.Show("Tên Khách Hàng không được để trống");
                    txtHoTen.Focus();
                    return;
                }
                if (checkBox2.CheckState == CheckState.Checked)
                {
                    txtMaLoaiKH.Focus();
                }
                else
                {
                    txtTienNo.Focus();
                }
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmThemTheLoaiKH f = new frmThemTheLoaiKH();
            f.ShowDialog();
        }

        private void txtMaLoaiKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                kiemTra_2("LOAI_NGUOI_DUNG", "MaLoai", txtMaLoaiKH.Text);
        }

        private void llbGoiy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmGoiYLoaiNguoiDung f = new frmGoiYLoaiNguoiDung();
            f.ShowDialog();
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
    } 
}
