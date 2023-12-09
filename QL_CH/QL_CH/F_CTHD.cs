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
    public partial class F_CTHD : Form
    {
        string mahd;
        BLL_DAL_CTHD cthd = new BLL_DAL_CTHD();
        public F_CTHD(string mahd)
        {
            InitializeComponent();
            this.mahd = mahd;
        }

        private void F_CTHD_Load(object sender, EventArgs e)
        {
            metroGrid1.DataSource = cthd.GetDataCTHoaDon(mahd);
        }
    }
}
