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
    public partial class frmThemTheLoaiKH : Form
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
                Int32.Parse(takeString(txtTienNoToiDa.Text));

            }
            catch
            {
                MessageBox.Show("Tiền nợ tối đa phải là số");
                txtTienNoToiDa.Focus();
                return false;
            }
            try
            {
                Int32.Parse(txtHeSoDiemThuong.Text);
            }
            catch
            {
                MessageBox.Show("Hệ số điểm thưởng phải là số");
                txtHeSoDiemThuong.Focus();
                return false;
            }
            try
            {
                Int32.Parse(txtDiemTichLuyCanThiet.Text);
            }
            catch
            {
                MessageBox.Show("Điểm tích lũy cần thiết phải là số");
               txtDiemTichLuyCanThiet.Focus();
                return false;
            }
            try
            {
                Int32.Parse(txtSoLuongSachMuonToiDa.Text);
            }
            catch
            {
                MessageBox.Show("Số lượng sách mượn tối đa phải là số");
                txtSoLuongSachMuonToiDa.Focus();
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
                    txtMaLoai.ResetText();
                    txtMaLoai.Focus();
                }
                else
                {
                    txtTenLoai.Focus();
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
        public frmThemTheLoaiKH()
        {
            InitializeComponent();
        }

        private void frmThemTheLoaiKH_Load(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kiemTraSo())
            {
                if (!txtMaLoai.Text.Equals("") && !txtTenLoai.Text.Equals(""))
                {
                    openConnect();
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Insert into LOAI_NGUOI_DUNG values ('" + txtMaLoai.Text + "',N'" + txtTenLoai.Text + "',"
                            + Int32.Parse(txtTienNoToiDa.Text) + "," + Int32.Parse(txtHeSoDiemThuong.Text) + "," + Int32.Parse(txtDiemTichLuyCanThiet.Text) + "," + Int32.Parse(txtSoLuongSachMuonToiDa.Text) + ");";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đã thêm Loại người dùng thành công");
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

        private void txtTenLoai_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(txtTenLoai.Text.Equals(""))
                {
                    MessageBox.Show("Không thể để trống tên Loại");
                    txtTenLoai.Focus();
                    return;
                }
                txtTienNoToiDa.Focus();
            }
        }

        private void txtTienNoToiDa_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (txtTienNoToiDa.Text.Equals(""))
                {
                    txtTienNoToiDa.Text = "0";
                }
                txtHeSoDiemThuong.Focus();
            }
        }

        private void txtHeSoDiemThuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtHeSoDiemThuong.Text.Equals(""))
                {
                    txtHeSoDiemThuong.Text = "0";
                }
                txtDiemTichLuyCanThiet.Focus();
            }
        }

        private void txtDiemTichLuyCanThiet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtDiemTichLuyCanThiet.Text.Equals(""))
                {
                    txtDiemTichLuyCanThiet.Text = "0";
                }
                txtSoLuongSachMuonToiDa.Focus();
            }
        }

        private void txtSoLuongSachMuonToiDa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSoLuongSachMuonToiDa.Text.Equals(""))
                {
                    txtSoLuongSachMuonToiDa.Text = "0";
                }
                btnLuu_Click(null, null);
            }
        }

        private void txtMaLoai_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                kiemTra("LOAI_NGUOI_DUNG","MaLoai",txtMaLoai.Text);
            }
        }
    }
}
