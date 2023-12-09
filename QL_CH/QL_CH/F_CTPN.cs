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
    public partial class F_CTPN : Form
    {
        string mapn;
        BLL_DAL_CTPN ctpn = new BLL_DAL_CTPN();
        public F_CTPN(string mapn)
        {
            InitializeComponent();
            this.mapn = mapn;
        }

        private void F_CTPN_Load(object sender, EventArgs e)
        {
            metroGrid1.DataSource = ctpn.GetDataCTPNTheoMa(mapn);
        }
    }
}
