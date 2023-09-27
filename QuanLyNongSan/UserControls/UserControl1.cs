using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using ThietKeCSDL;

namespace UserControls
{
    public partial class UserControl1 : UserControl
    {
        SqlConnection connec;
        public UserControl1()
        {
            InitializeComponent();
            this.Load += UserControl1_Load;
            connec = new SqlConnection("Data Source = HUYENTRAN; Initial Catalog = QLNONGSAN; Integrated Security = true");
        }

        void UserControl1_Load(object sender, EventArgs e)
        {
            loadDL();
            load_dgv();
        }
        public void loadDL()
        {
            Class1 a = new Class1();
            DataTable dt = new DataTable();
            dt = a.ExcuteQuery();

            foreach (DataRow row in dt.Rows)
            {
                txt_maSP.Text = row["MASP"].ToString();
                txt_tenSP.Text = row["TENSP"].ToString();
                txt_donGia.Text = row["GIA"].ToString();
                txt_soLuong.Text = row["SL"].ToString();
            }
        }
        public void load_dgv()
        {
            DataSet ds = new DataSet();
            string strselect = "select * from SANPHAM";
            SqlDataAdapter table_SP = new SqlDataAdapter(strselect, connec);
            table_SP.Fill(ds, "SANPHAM");
            dgv_dssp.DataSource = ds.Tables["SANPHAM"];

            DataColumn[] key = new DataColumn[1]; //khởi tạo bộ nhớ cho cột "key"
            key[0] = ds.Tables["SANPHAM"].Columns[0];
            ds.Tables["SANPHAM"].PrimaryKey = key;
        }
        private void dgv_dssp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgv_dssp.Rows[e.RowIndex];
            txt_maSP.Text = Convert.ToString(row.Cells["MASP"].Value);
            txt_tenSP.Text = Convert.ToString(row.Cells["TENSP"].Value);
            txt_donGia.Text = Convert.ToString(row.Cells["GIA"].Value);
            txt_soLuong.Text = Convert.ToString(row.Cells["SL"].Value);
        }


    }
}
