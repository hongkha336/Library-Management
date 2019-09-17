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
    public partial class frmGoiYLoaiNguoiDung : Form
    {
        string conStr = @"Data Source = UX305FA;" + "Initial Catalog = QLTV_16110112_Thu3;" + "User ID = sa; Password = hongkha123";
        SqlConnection conn = null;
        SqlDataAdapter daUS = null;
        DataTable dtUS = null;
        private void openConnect()
        {
            conn = new SqlConnection(conStr);
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
        }
        public frmGoiYLoaiNguoiDung()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGoiYLoaiNguoiDung_Load(object sender, EventArgs e)
        {
            try
            {
                openConnect();
                daUS = new SqlDataAdapter("Select * from LOAI_NGUOI_DUNG", conn);
                dtUS = new DataTable();
                daUS.Fill(dtUS);
                conn.Close();
                dataGridView1.DataSource = dtUS;
            }
            catch(SqlException)
            {
                MessageBox.Show("Lỗi");
            }
        }
    }
}
