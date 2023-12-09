using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;
namespace QL_CH
{
    public partial class BanHang : Form
    {
        BLL_DAL_SanPham sp = new BLL_DAL_SanPham();
        BLL_DAL_HoaDon hd = new BLL_DAL_HoaDon();
        BLL_DAL_NCC ncc = new BLL_DAL_NCC();
        BLL_DAL_KhachHang kh = new BLL_DAL_KhachHang();
        BLL_DAL_CTHD cthd = new BLL_DAL_CTHD();
        Extract extract = new Extract();
        string manv;
        public BanHang(string manv)
        {
            this.Load += BanHang_Load1;
            InitializeComponent();
            this.manv = manv;
            
            tinhtien();
            
          
        }

        private void BanHang_Load1(object sender, EventArgs e)
        {
            loadhd();
            loadcboNCC();
            loadsp();
            loadcboKH();
            loadDGV_DSSP();
            textBox2.Enabled = false;
        }
        #region load_all
        public void loadhd()
        {
            dtg_HoaDon.DataSource = hd.GetDataHoaDon();
            // dtg_HoaDon.Columns[7].Visible=false;
        }

        public void loadcboNCC()
        {
            cboNcc.DataSource = ncc.GetDataNhaCC();
            cboNcc.DisplayMember = "TENNCC";
            cboNcc.ValueMember = "MANCC";
        }
        public void loadsp()
        {
            //dtg_SanPham.DataSource = sp.GetDataSanPham();
            List<SANPHAM> l = sp.GetDataSanPham();
            var ketQua = from sp in l
                         select new
                         {
                             MASP = sp.MASP,
                             TENSP = sp.TENSP,
                             MOTA = sp.MOTA,
                             MALOAI = sp.MALOAI,
                             MANCC = sp.MANCC,
                             SOLUONG = sp.SOLUONG,
                             DONVITINH = sp.DONVITINH,
                             DONGIA = sp.DONGIA
                         };
            dtg_SanPham.DataSource = ketQua.ToList();
            //dgvSanPham.Columns[""].Visible = false;
            //dgvSanPham.Columns[""].Visible = false;
            DataGridViewColumnCollection columns = dtg_SanPham.Columns;

            // Sửa HeaderText của mỗi cột
            columns["MASP"].HeaderText = "Mã SP";
            columns["TENSP"].HeaderText = "Tên SP";
            columns["MOTA"].HeaderText = "Mô tả";
            columns["MALOAI"].HeaderText = "Mã loại";
            columns["MANCC"].HeaderText = "Mã NCC";
            columns["SOLUONG"].HeaderText = "Số lượng";
            columns["DONVITINH"].HeaderText = "Đơn vị tính";
            columns["DONGIA"].HeaderText = "Đơn giá";
        }
        public void loadcboKH()
        {
            //comboBox1.DataSource = kh.GetDataKhachHang();
            //comboBox1.DisplayMember = "HOTEN";
            //comboBox1.ValueMember = "MAKH";

            List<KHACHHANG> k = kh.GetDataKhachHang();
            var query = from nhacc in k
                        select new
                        {
                            MAKH = nhacc.MAKH,
                            HOTEN = nhacc.HOTEN
                        };

            comboBox1.Items.Clear();

            //// Đổ dữ liệu vào Combobox
            foreach (var nhacc in query)
            {
                comboBox1.Items.Add(new ComboboxItem { Text = nhacc.HOTEN, Value = nhacc.MAKH });
            }
        }
        public void loadDGV_DSSP()
        {
            dtg_GioHang.Columns.Add("MASP", "Mã SP");
            dtg_GioHang.Columns.Add("SOLUONG", "Số lượng");
            dtg_GioHang.Columns.Add("DONVITINH", "Đơn vị tính");
            dtg_GioHang.Columns.Add("DONGIA", "Đơn giá");
        }
        #endregion
        private void dtg_SanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void tinhtien()
        {

            int tongTien = 0;
            foreach (DataGridViewRow row in dtg_GioHang.Rows)
            {

                int soLuong = 0;
                int donGia = 0;

                if (row.Cells["SOLUONG"].Value != null && row.Cells["DONGIA"].Value != null &&
                    int.TryParse(row.Cells["SOLUONG"].Value.ToString(), out soLuong) &&
                    int.TryParse(row.Cells["DONGIA"].Value.ToString(), out donGia))
                {
                    tongTien += soLuong * donGia;
                }

            }

            label9.Text = tongTien.ToString();
        }
        #region timkiem 
        private void txtTimSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                if (!string.IsNullOrEmpty(txtTimSP.Text))
                {
                    if (sp.TimSanPham(txtTimSP.Text).Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm phù hợp");
                    }
                    else
                    {
                        List<SANPHAM> l = sp.TimSanPham(txtTimSP.Text);
                        var ketQua = from sp in l
                                     select new
                                     {
                                         MASP = sp.MASP,
                                         TENSP = sp.TENSP,
                                         MOTA = sp.MOTA,
                                         MALOAI = sp.MALOAI,
                                         MANCC = sp.MANCC,
                                         SOLUONG = sp.SOLUONG,
                                         DONVITINH = sp.DONVITINH,
                                         DONGIA = sp.DONGIA
                                     };
                        dtg_SanPham.DataSource = ketQua.ToList();
                        DataGridViewColumnCollection columns = dtg_SanPham.Columns;

                        // Sửa HeaderText của mỗi cột
                        columns["MASP"].HeaderText = "Mã SP";
                        columns["TENSP"].HeaderText = "Tên SP";
                        columns["MOTA"].HeaderText = "Mô tả";
                        columns["MALOAI"].HeaderText = "Mã loại";
                        columns["MANCC"].HeaderText = "Mã NCC";
                        columns["SOLUONG"].HeaderText = "Số lượng";
                        columns["DONVITINH"].HeaderText = "Đơn vị tính";
                        columns["DONGIA"].HeaderText = "Đơn giá";
                    }
                }
                e.Handled = true;
            }
        }
        

        private void cboNcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedNhacc = cboNcc.SelectedValue as string;
            if (!string.IsNullOrEmpty(selectedNhacc))
            {
                List<SANPHAM> l = sp.TimSanPham_NCC(selectedNhacc);

                var ketQua = from sp in l
                             select new
                             {
                                 MASP = sp.MASP,
                                 TENSP = sp.TENSP,
                                 MOTA = sp.MOTA,
                                 MALOAI = sp.MALOAI,
                                 MANCC = sp.MANCC,
                                 SOLUONG = sp.SOLUONG,
                                 DONVITINH = sp.DONVITINH,
                                 DONGIA = sp.DONGIA
                             };
                dtg_SanPham.DataSource = ketQua.ToList();
                DataGridViewColumnCollection columns = dtg_SanPham.Columns;

                // Sửa HeaderText của mỗi cột
                columns["MASP"].HeaderText = "Mã SP";
                columns["TENSP"].HeaderText = "Tên SP";
                columns["MOTA"].HeaderText = "Mô tả";
                columns["MALOAI"].HeaderText = "Mã loại";
                columns["MANCC"].HeaderText = "Mã NCC";
                columns["SOLUONG"].HeaderText = "Số lượng";
                columns["DONVITINH"].HeaderText = "Đơn vị tính";
                columns["DONGIA"].HeaderText = "Đơn giá";

            }
        }



        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            // Xóa tất cả dữ liệu từ DataTable (nếu có)
            dtg_GioHang.Rows.Clear();

            // Sau đó, xóa tất cả các dòng trong DataGridView
            dtg_GioHang.Rows.Clear();

        }

        private void dtg_SanPham_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dtg_SanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtg_SanPham.Rows[e.RowIndex];
                string masp = row.Cells["MASP"].Value.ToString();
                string dvt = row.Cells["DONVITINH"].Value.ToString();

                DataGridViewRow rowNhap = new DataGridViewRow();
                rowNhap.CreateCells(dtg_GioHang);

                rowNhap.Cells[0].Value = row.Cells["MASP"].Value;
                rowNhap.Cells[1].Value = row.Cells["SOLUONG"].Value;
                rowNhap.Cells[2].Value = row.Cells["DONVITINH"].Value;
                rowNhap.Cells[3].Value = row.Cells["DONGIA"].Value;

                dtg_GioHang.Rows.Add(rowNhap);
                tinhtien();
            }
        }

        private void dtg_GioHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dtg_GioHang.SelectedRows.Count > 0)
            {
                dtg_GioHang.Rows.RemoveAt(dtg_GioHang.SelectedRows[0].Index);
                tinhtien();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxItem selectedItem = (ComboboxItem)comboBox1.SelectedItem;
            string mancc = selectedItem.Value;
            label6.Text = mancc;
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

        private void button6_Click(object sender, EventArgs e)
        {
            //string s = "";
            //if (dtg_HoaDon.Rows.Count > 0)
            //{
            //    int rowIndex = dtg_HoaDon.Rows.Count - 1; // Lấy chỉ mục của dòng cuối cùng

            //    // Truy cập dòng cuối cùng và lấy giá trị từ cột cụ thể
            //    DataGridViewRow lastRow = dtg_HoaDon.Rows[rowIndex];

            //    // Lấy giá trị từ cột đầu tiên (cột 0)
            //    string makh = lastRow.Cells[0].Value.ToString();

            //    string ma = extract.ExtractLetters(makh);
            //    int so = Int32.Parse(extract.ExtractNumbers(makh)) + 1;

            //    s = ma + so;
            //}


            string s = "";
            int v = 0;
            if (dtg_HoaDon.Rows.Count > 0)
            {
                
                for(int i=0;i<dtg_HoaDon.Rows.Count;i++)
                {
                    DataGridViewRow r = dtg_HoaDon.Rows[i];
                    string makh = r.Cells[0].Value.ToString();
                    int so = Int32.Parse(extract.ExtractNumbers(makh));
                    if (so > v)
                        v = so;
                }

                int rowIndex = dtg_HoaDon.Rows.Count - 1; // Lấy chỉ mục của dòng cuối cùng
                //string ma = extract.ExtractLetters(row);
                DataGridViewRow lastRow = dtg_HoaDon.Rows[rowIndex];
                string ma = extract.ExtractLetters(lastRow.Cells[0].Value.ToString());
                v = v + 1;

                s = ma + v;
            }



            textBox2.Text = s;


            HOADON h = new HOADON();
            h.MAHD = s;
            if (label6.Text == "KHVL")
            {
                h.MAKH = "KHVL";
            }
            else
            {
                h.MAKH = label6.Text;
            }


            h.MANV = manv;
            DateTime now = DateTime.Now;
            SqlDateTime sqlDate = new SqlDateTime(now.Year, now.Month, now.Day);
            h.NGAYDAT = sqlDate.Value;
            h.TRANGTHAI = 1;
            int tongTien = 0;
            if (int.TryParse(label9.Text, out tongTien))
            {
                h.TONGTIEN = tongTien;

                bool themHoaDonThanhCong = hd.ThemHoaDon(h);

                if (themHoaDonThanhCong)
                {
                   

                    // Thêm chi tiết hóa đơn
                    int stt = 0;
                    foreach (DataGridViewRow row in dtg_GioHang.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            //--------them ctpn
                            CTHOADON a = new CTHOADON();

                            a.MAHD = textBox2.Text;
                            a.MACTHD = textBox2.Text + stt.ToString();
                            a.MASP = row.Cells[0].Value.ToString();
                            a.SOLUONG = Convert.ToInt32(row.Cells[1].Value);
                            a.DONGIA = int.Parse(row.Cells[3].Value.ToString());

                            stt++;

                            // Thêm đối tượng CTPHIEUNHAPHANG vào CSDL
                            cthd.ThemHoaDon(a);
                            //sp.SuaSanPham_Ban(row.Cells[0].Value.ToString(), Convert.ToInt32(row.Cells[1].Value));
                            //suaSL(Convert.ToInt32(row.Cells[1].Value), row.Cells[0].Value.ToString(), mancc);
                            suaSL(row.Cells[0].Value.ToString(), Convert.ToInt32(row.Cells[1].Value));

                        }
                    }
                    dtg_GioHang.DataSource = null;

                    dtg_GioHang.DataSource = null;
                    dtg_GioHang.Rows.Clear();
                    dtg_GioHang.Columns.Clear();
                    dtg_SanPham.DataSource = null;
                    label6.Text = "KHVL";
                    label9.Text = label12.Text = "0";
                    textBox3.Text = "0"; 
                    richTextBox1.Text = "";
                    loadhd();
                    loadcboNCC();
                    loadsp();
                    loadcboKH();
                    loadDGV_DSSP();
                    tinhtien();
                    MessageBox.Show("Thêm hóa đơn Thành công", "Hoàn Thanh", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    MessageBox.Show("Thêm hóa đơn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Tổng tiền không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void suaSL(string masp, int sl)
        {
            // Gọi phương thức SuaSanPham từ BLL_DAL_SanPham để cập nhật CSDL
            sp.SuaSanPham_Ban(masp, sl);

            // Sau khi cập nhật CSDL, bạn có thể cập nhật danh sách sản phẩm hiển thị trên DataGridView
            //loadsp();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int s = 0;
            s = int.Parse(textBox3.Text) - int.Parse(label9.Text);
            label12.Text = s.ToString();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dtg_GioHang_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            tinhtien();
        }

        private void BanHang_Load(object sender, EventArgs e)
        {
            loadhd();
            loadcboNCC();
            loadsp();
            loadcboKH();
            loadDGV_DSSP();
            tinhtien();
            
        }

        private void btnLamMoiDSSP_Click(object sender, EventArgs e)
        {
            loadsp();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool IsNonNegativeInteger(string input)
        {
            // Kiểm tra xem chuỗi có phải là số không âm không
            if (int.TryParse(input, out int result) && result >= 0)
            {
                return true;
            }
            return false;
        }
        private void dtg_GioHang_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string input = e.FormattedValue.ToString();

                // Kiểm tra xem giá trị nhập vào có phải là số không âm hay không
                if (!IsNonNegativeInteger(input))
                {
                    e.Cancel = true;
                    dtg_GioHang.Rows[e.RowIndex].ErrorText = "Vui lòng nhập số dương.";
                }
               
            }
        }

        private void dtg_GioHang_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dtg_GioHang.Rows[e.RowIndex].ErrorText = string.Empty;
        }
    }
}
