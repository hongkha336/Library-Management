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
    public partial class frmGoiYTheLoai : Form
    {
        string conStr = @"Data Source = UX305FA;" + "Initial Catalog = QLTV_16110112_Thu3;" + "User ID = sa; Password = hongkha123";
        SqlConnection conn = null;
        SqlDataAdapter daTheLoai = null;
        DataTable dtTheLoai = null;
        private void openConnect()
        {
            conn = new SqlConnection(conStr);
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
        }
        public frmGoiYTheLoai()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGoiYTheLoai_Load(object sender, EventArgs e)
        {
            try
            {
                openConnect();
                daTheLoai = new SqlDataAdapter("Select * From THE_LOAI", conn);
                dtTheLoai = new DataTable();
                daTheLoai.Fill(dtTheLoai);
                conn.Close();
                dataGridView1.DataSource = dtTheLoai;

            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi");
            }
        }
    }
}

