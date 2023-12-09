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
    public partial class F_QuanLyTaiKhoan : Form
    {
        BLL_DAL_DangNhap login = new BLL_DAL_DangNhap();
        QLCHDataContext qlch = new QLCHDataContext();
        BLL_DAL_NhanVien nv = new BLL_DAL_NhanVien();
        public F_QuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void F_QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {

            var maNhanVienList = nv.LayMaNhanVien();

            cbbmanhanvien.DataSource = maNhanVienList;

            dataGridView1.DataSource = login.GetDataNguoiDung();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string tendangnhap = cbbmanhanvien.SelectedItem.ToString();

            // Kiểm tra nếu thông tin tài khoản đã tồn tại
            if (login.GetDataNguoiDung().Any(nd => nd.TenDangNhap == tendangnhap))
            {
                // Thông báo lỗi nếu tài khoản đã tồn tại
                MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên đăng nhập khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Kết thúc sự kiện
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Nhập mật khẩu cho người dùng");
            }
            else
            {
                // Nếu thông tin tài khoản chưa tồn tại, tiến hành thêm tài khoản

                string matkhau = textBox1.Text;
                login.ThemTaiKhoan(tendangnhap, matkhau);
                dataGridView1.DataSource = login.GetDataNguoiDung();
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Sửa mật khẩu");
                return;
            }
            else
            {
                login.SuaTaiKhoan(cbbmanhanvien.SelectedItem.ToString(), textBox1.Text);
                dataGridView1.DataSource = login.GetDataNguoiDung();
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chưa chọn thông tin để xóa");
                return;
            }
            else
            {
                login.XoaTaiKhoan(cbbmanhanvien.SelectedItem.ToString());
                dataGridView1.DataSource = login.GetDataNguoiDung();
            }
        }
    }
}
