using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThietKeCSDL;

namespace QuanLyNongSan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Class1 a = new Class1();
            a.createConnection();
            if (a.testConnection() == true)
            {
                MessageBox.Show("Kết nối thành công !!!");
            }
            else
            {
                MessageBox.Show("Kết nối thất bại !!!");
            }
        }
    }
}
