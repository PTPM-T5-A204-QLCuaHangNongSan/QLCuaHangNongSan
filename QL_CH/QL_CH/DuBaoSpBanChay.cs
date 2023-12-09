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
    public partial class DuBaoSpBanChay : Form
    {
        private dynamic tbNextDay;

        public DuBaoSpBanChay()
        {
            InitializeComponent();
        }

        private void DuBaoSpBanChay_Load(object sender, EventArgs e)
        {
            tbNextDay = DuBao.Instances.LoadDataGC();
            dataGridView1.DataSource = tbNextDay;

        



        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Số sản phẩm Điều rang muối bán ngày " + DateTime.Now.AddDays(1).ToShortDateString() + " là: " + DuBao.Instances.ReturnResult().ToString());
        }
    }
}
