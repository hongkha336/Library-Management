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
    public partial class frmKhachHang : Form
    {
        string conStr = @"Data Source = UX305FA;" + "Initial Catalog = QLTV_16110112_Thu3;" + "User ID = sa; Password = hongkha123";
        SqlConnection conn = null;
        SqlDataAdapter daKH = null;
        DataTable dtKH = null;
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            ToolTip();
            loadData();
            loadIcon();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Thoát chương trình", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
                Application.Exit();
        }
        void ToolTip()
        {
            //btnClose
            ToolTip btnClo = new ToolTip();
            btnClo.SetToolTip(btnClose, "Đóng chương trình");
            //btnRestart
            ToolTip btnRes = new ToolTip();
            btnRes.SetToolTip(btnRestart, "Tải lại dữ liệu");
            //btnBack
            ToolTip btnBac = new ToolTip();
            btnBac.SetToolTip(btnBack, "Trở về trang trước");

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
        private void openConnect()
        {
            conn = new SqlConnection(conStr);
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
        }
        private void loadData()
        {
            try
            {
                openConnect();
                daKH = new SqlDataAdapter("Select * from KHACH_HANG", conn);
                dtKH = new DataTable();

                daKH.Fill(dtKH);
                dgvKhachHang.DataSource = dtKH;

                conn.Close();

            }
            catch (SqlException)
            {
                MessageBox.Show("Không thể kết nối đến CSDL", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemKhachHang f = new frmThemKhachHang();
            f.ShowDialog();
            loadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Xóa khách Hàng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                openConnect();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    int r = dgvKhachHang.CurrentCell.RowIndex;
                    string sMaKH = dgvKhachHang.Rows[r].Cells[0].Value.ToString();
                    // xoa CT_PHIEUMUON
                    cmd.CommandText = "delete from CT_PHIEUMUON where MAPM in " +
                         "( select MaPM " +
                         "from PHIEU_MUON_SACH join KHACH_HANG on PHIEU_MUON_SACH.MAKH = KHACH_HANG.MAKH " +
                         "where KHACH_HANG.MAKH = '" + sMaKH + "')";
                    cmd.ExecuteNonQuery();
                    //xoa PHIEU_MUON_SACH
                    cmd.CommandText = "delete from PHIEU_MUON_SACH where MaKH = '" + sMaKH + "';";
                    cmd.ExecuteNonQuery();
                    //xoa CT don Hang
                    cmd.CommandText = "delete from CT_DONHANG where MADH in " +
                        "( select MADH " +
                        "from DON_HANG join KHACH_HANG on DON_HANG.MAKH = KHACH_HANG.MAKH " +
                        "where DON_HANG.MAKH = '" + sMaKH + "')";
                    cmd.ExecuteNonQuery();
                    // xoa Don Hang
                    cmd.CommandText = "delete from DON_HANG where MAKH = '" + sMaKH + "';";
                    cmd.ExecuteNonQuery();

                    // xoa KHACH_HANG
                    cmd.CommandText = "delete from KHACH_HANG where MaKH = '" + sMaKH + "';";
                    cmd.ExecuteNonQuery();
                    loadData();
                    MessageBox.Show("Đã xóa xong Khách Hàng");
                    conn.Close();

                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi");
                    conn.Close();

                }
            }
        }

        private void btnSửa_Click(object sender, EventArgs e)
        {
            string a, b, c, d, e1;
            int r = dgvKhachHang.CurrentCell.RowIndex;
            a = dgvKhachHang.Rows[r].Cells[0].Value.ToString();
            b = dgvKhachHang.Rows[r].Cells[1].Value.ToString();
            c = dgvKhachHang.Rows[r].Cells[2].Value.ToString();
            d = dgvKhachHang.Rows[r].Cells[3].Value.ToString();
            e1 = dgvKhachHang.Rows[r].Cells[4].Value.ToString();

            frmSuaKhachHang f = new frmSuaKhachHang(a,b,c,d,e1);
            f.ShowDialog();
            loadData();
        }
    }
}
