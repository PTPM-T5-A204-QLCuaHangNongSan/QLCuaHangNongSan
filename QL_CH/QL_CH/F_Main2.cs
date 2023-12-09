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
    public partial class F_Main2 : Form
    {
        public F_Main2(string tenDangNhap)
        {
            InitializeComponent();
            TenDangNhap = tenDangNhap;
        }
        BLL_DAL_DangNhap dn = new BLL_DAL_DangNhap();
        private string TenDangNhap { get; set; }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap F_login = new DangNhap();
            this.Close();
            F_login.Show();

           
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLy A = new QuanLy();
            A.MdiParent = this;
            A.Show();
        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BanHang A = new BanHang(TenDangNhap);
            A.MdiParent = this;
            A.Show();
        }

        private void nhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhapHang A = new NhapHang();
            A.MdiParent = this;
            A.Show();
        }

        private void F_Main2_Load(object sender, EventArgs e)
        {
            // Đặt chế độ full màn hình
            this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;

            label1.Text = TenDangNhap;

            // Lấy mã nhóm người dùng từ tên đăng nhập
            var maNhomNguoiDungList = dn.GetMaNhomNguoiDung(label1.Text);
            var menuStripItems = menuStrip1.Items.OfType<ToolStripMenuItem>().ToList();

            bool isUserInAdminGroup = false;
            bool isUserInUserGroup = false;
            bool isUserInAnyGroup = false;

            // Kiểm tra xem người dùng có thuộc các nhóm "Admin" hoặc "User" hay không
            foreach (var maNhomNguoiDung in maNhomNguoiDungList)
            {
                var maManHinhList = dn.GetMaManHinh(maNhomNguoiDung);

                if (maNhomNguoiDung == "Admin")
                {
                    isUserInAdminGroup = true;
                }
                else if (maNhomNguoiDung == "User")
                {
                    isUserInUserGroup = true;
                }

                // Nếu người dùng thuộc cả hai nhóm "Admin" và "User"
                if (isUserInAdminGroup && isUserInUserGroup)
                {
                    isUserInAnyGroup = true;
                    break;
                }
            }

            // Xét quyền truy cập và hiển thị của menu items và submenu items
            foreach (var menuItem in menuStripItems)
            {
                menuItem.Visible = true;

                foreach (var subMenuItem in menuItem.DropDownItems)
                {
                    if (subMenuItem is ToolStripMenuItem)
                    {
                        var subMenu = (ToolStripMenuItem)subMenuItem;
                        var tag = (subMenu.Tag != null) ? subMenu.Tag.ToString() : null;

                        // Kiểm tra quyền truy cập cho mục con dựa trên nhóm người dùng và tag của mục con
                        if (isUserInAnyGroup || (isUserInAdminGroup && tag == "MH001") || (isUserInUserGroup && tag == "MH002"))
                        {
                            subMenu.Enabled = true; // Có quyền truy cập mục con
                        }
                        else
                        {
                            subMenu.Enabled = false; // Không có quyền truy cập mục con
                        }
                    }
                }
            }
        }

        private void heToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_QuanLyTaiKhoan A = new F_QuanLyTaiKhoan();
            A.MdiParent = this;
            A.Show();
        }

        private void quảnLýNhómNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_NguoiDungNhomNguoiDung A = new F_NguoiDungNhomNguoiDung();
            A.MdiParent = this;
            A.Show();
        }

        private void dựBáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDonWeb A = new HoaDonWeb();
            A.MdiParent = this;
            A.Show();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_QuanLyTaiKhoan A = new F_QuanLyTaiKhoan();
            A.MdiParent = this;
            A.Show();
        }

        private void dựBáoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DuBaoSpBanChay A = new DuBaoSpBanChay();
            A.MdiParent = this;
            A.Show();
        }
    }
}
