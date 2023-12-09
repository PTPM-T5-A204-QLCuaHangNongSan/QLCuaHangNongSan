using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
namespace CustomControl
{
    public class txtChiNhapSo : MetroTextBox
    {
        public txtChiNhapSo()
        {
            this.KeyPress += txtChiNhapSo_KeyPress;
        }
        void txtChiNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
