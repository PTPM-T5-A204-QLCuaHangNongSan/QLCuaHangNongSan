using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;
namespace QL_CH
{
    public partial class F_NguoiDungNhomNguoiDung : Form
    {
        QLCHDataContext qlch = new QLCHDataContext();
        BLL_DAL_NhomNguoiDung nnd = new BLL_DAL_NhomNguoiDung();
        BLL_DAL_DangNhap tk = new BLL_DAL_DangNhap();
        BLL_DAL_NguoiDungNhomNguoiDung ndnnd = new BLL_DAL_NguoiDungNhomNguoiDung();
        public F_NguoiDungNhomNguoiDung()
        {
            InitializeComponent();
        }

        private void F_NguoiDungNhomNguoiDung_Load(object sender, EventArgs e)
        {
            var _maNhom = nnd.ListMaNhom();
            comboBox1.DataSource = _maNhom;

            dataGridView1.DataSource = tk.GetDataNguoiDung();
            dataGridView2.DataSource = ndnnd.GetData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string _tendn = row.Cells[0].Value.ToString();
                string _maNhomNguoiDung = comboBox1.SelectedValue.ToString().Trim();

                if (!string.IsNullOrEmpty(_tendn) && !string.IsNullOrEmpty(_maNhomNguoiDung))
                {
                    bool kiemtra = ndnnd.kiemtra(_tendn, _maNhomNguoiDung);
                    if (!kiemtra)
                    {
                        ndnnd.themNguoiDungVaoNhom(_tendn, _maNhomNguoiDung);
                        dataGridView2.DataSource = ndnnd.GetData();
                    }
                    else
                    {
                        MessageBox.Show("Đã có người dùng trong nhóm.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn người dùng và nhóm người dùng.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                int selectedRowindex = dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView2.Rows[selectedRowindex];
                string _tendn = selectedRow.Cells[0].Value.ToString();
                ndnnd.xoaNguoiDungKhoiNhom(_tendn);

                dataGridView2.DataSource = ndnnd.GetData();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBox1.SelectedValue.ToString();
            var duplicateData = ndnnd.GetData().Where(data => data.MaNhomNguoiDung == selectedValue).ToList();
            dataGridView2.DataSource = duplicateData;
        }
    }
}
