using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
namespace CustomControl
{
    class upperTextBox: MetroTextBox
    {
        public upperTextBox()
        {
            this.KeyPress += upperTextBox_KeyPress;
        }

        void upperTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsUpper(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
