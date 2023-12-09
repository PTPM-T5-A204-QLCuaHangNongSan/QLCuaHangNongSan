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
    public partial class HoaDonWeb : Form
    {
        BLL_DAL_HoaDon hd = new BLL_DAL_HoaDon();
        BLL_DAL_CTHD cthd = new BLL_DAL_CTHD();
        BLL_DAL_SanPham sp = new BLL_DAL_SanPham();
        public HoaDonWeb()
        {
            InitializeComponent();
        }
        public void loadhd()
        {
            dtg_HoaDon.DataSource = hd.GetDataHoaDonChuaDuyet();
            // dtg_HoaDon.Columns[7].Visible=false;
        }
        private void HoaDonWeb_Load(object sender, EventArgs e)
        {
            loadhd();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtMaHD.Text=="")
            {
                MessageBox.Show("Vui lòng chọn hóa đơn");
            }    
            else
            if(cbTT.Checked)
            {
                HOADON h = new HOADON();
                h.MAHD = txtMaHD.Text;
                h.MAKH = txtMaKh.Text;
                h.NGAYDAT = DateTime.Parse( txtNgayDat.Text);
                h.TONGTIEN = int.Parse(txtTongTien.Text);
                h.TRANGTHAI = 1;

                List<CTHOADON> cthdList = cthd.GetDataCTHoaDon(h.MAHD);
                foreach (CTHOADON ct in cthdList)
                {
                    // Assuming that sp.SuaSanPham_Ban takes the product ID (MASP) and quantity (SOLUONG) as parameters
                    sp.SuaSanPham_Ban(ct.MASP, ct.SOLUONG.Value);
                    MessageBox.Show("Cập nhật sl thành công");
                }
               if( hd.CapNhatTrangThaiKhachHang(h))
                {
                    MessageBox.Show("sửa trạng thái hóa đơn thành công");
                }    

            }

            loadhd();
        }
        private void bidingData()
        {
            
            
            BindingSource bs = new BindingSource();
            bs.DataSource = hd.GetDataHoaDonChuaDuyet(); 

            txtMaHD.DataBindings.Clear();
            txtMaKh.DataBindings.Clear();
            txtNgayDat.DataBindings.Clear();
            txtTongTien.DataBindings.Clear();
            cbTT.DataBindings.Clear();


            txtMaHD.DataBindings.Add("text", bs, "MAHD");
            txtMaKh.DataBindings.Add("text", bs, "MAKH");
            txtNgayDat.DataBindings.Add("text", bs, "NGAYDAT");
            txtTongTien.DataBindings.Add("text", bs, "TONGTIEN");

            dtg_HoaDon.DataSource = bs;

        }

        private void dtg_HoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bidingData();
        }

        private void cbTT_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dtg_HoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtg_HoaDon.Rows[e.RowIndex];
                //F_CTHD
                string mahd = row.Cells["MAHD"].Value.ToString();
                F_CTHD f = new F_CTHD(row.Cells["MAHD"].Value.ToString());
                f.ShowDialog();

            }
            
        }
    }
}
