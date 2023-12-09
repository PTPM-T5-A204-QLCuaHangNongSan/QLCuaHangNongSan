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
    public partial class DangNhap : Form
    {
        BLL_DAL_DangNhap dn = new BLL_DAL_DangNhap();
        public DangNhap()
        {
            InitializeComponent();
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Chắc chắn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QL_NguoiDung nguoiDungTimThay = dn.Login(textBox1.Text, textBox2.Text);
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản");

            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");

            }
            else if (nguoiDungTimThay != null)
            {
                string tenDangNhap = textBox1.Text; // Lưu tên đăng nhập vào thuộc tính TenDangNhap
                F_Main2 m = new F_Main2(tenDangNhap);
                this.Hide();
                m.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại tài khoản và mật khẩu");
            }
        }
    }
}
