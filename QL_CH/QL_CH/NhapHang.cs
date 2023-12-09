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
    public partial class NhapHang : Form
    {
        BLL_DAL_PhieuNhap apn = new BLL_DAL_PhieuNhap();
        BLL_DAL_NCC ncc = new BLL_DAL_NCC();
        BLL_DAL_SanPham sp = new BLL_DAL_SanPham();
        BLL_DAL_CTPN actpn = new BLL_DAL_CTPN();
        int tongTien = 0;
        Extract extract = new Extract();
        public NhapHang()
        {
            InitializeComponent();
           
            this.Load += NhapHang_Load1;
        }

        private void NhapHang_Load1(object sender, EventArgs e)
        {
            //loadDGV_SP();
            loadDGV_DSSP();
            loadDGV_PN();
            loadcbb();
            loadsp();

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
            dgvSanPham.DataSource = ketQua.ToList();
            //dgvSanPham.Columns[""].Visible = false;
            //dgvSanPham.Columns[""].Visible = false;
            DataGridViewColumnCollection columns = dgvSanPham.Columns;

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
        public void loadDGV_PN()
        {
            List<PHIEUNHAPHANG> pn = apn.GetDataPhieuNhap();

            var ketQua = from sp in pn
                         select new
                         {
                             MAPHIEUNHAP = sp.MAPHIEUNHAP,
                             MANCC = sp.MANCC,
                             NGAYNHAP = sp.NGAYNHAP,
                             TONGTIEN = sp.TONGTIEN
                         };

            dgvPhieuNhapa.DataSource = ketQua.ToList();
            DataGridViewColumnCollection columns = dgvPhieuNhapa.Columns;

            // Sửa HeaderText của mỗi cột
            columns["MAPHIEUNHAP"].HeaderText = "Mã PN";
            columns["MANCC"].HeaderText = "Mã NCC";
            columns["NGAYNHAP"].HeaderText = "Ngày nhập";
            columns["TONGTIEN"].HeaderText = "Tổng tiền";
        }
        public void loadDGV_DSSP()
        {
            dgvPhieuNhap.DataSource = null;
            dgvPhieuNhap.Rows.Clear();
            dgvPhieuNhap.Columns.Clear();
            dgvPhieuNhap.Columns.Add("MASP", "Mã SP");
            dgvPhieuNhap.Columns.Add("SOLUONG", "Số lượng");
            dgvPhieuNhap.Columns.Add("DONVITINH", "Đơn vị tính");
            dgvPhieuNhap.Columns.Add("THANHTIEN", "Thành tiền");
        }

        public void loadcbb()
        {
            List<NHACC> nc = ncc.GetDataNhaCC();
            var query = from nhacc in nc
                        select new
                        {
                            MANCC = nhacc.MANCC,
                            TENNCC = nhacc.TENNCC
                        };

            // Xóa các mục hiện có trong Combobox (nếu cần)
            comboBoxTenNCC.Items.Clear();
            comboBox1.Items.Clear();
            //// Đổ dữ liệu vào Combobox
            foreach (var nhacc in query)
            {
                comboBoxTenNCC.Items.Add(new ComboboxItem { Text = nhacc.TENNCC, Value = nhacc.MANCC });
                comboBox1.Items.Add(new ComboboxItem { Text = nhacc.TENNCC, Value = nhacc.MANCC });
            }

        }
        public void loadDGV_NCC()
        {
            // dgvNCC.DataSource = ncc.GetDataNhaCC();
        }
        public void loadDGV_SP()
        {
            dgvSanPham.DataSource = null;
            dgvSanPham.Rows.Clear();
            dgvSanPham.Columns.Clear();
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
                             DONVITINH = sp.DONVITINH
                         };
            dgvSanPham.DataSource = ketQua.ToList();
            //dgvSanPham.Columns[""].Visible = false;
            //dgvSanPham.Columns[""].Visible = false;
            DataGridViewColumnCollection columns = dgvSanPham.Columns;

            // Sửa HeaderText của mỗi cột
            columns["MASP"].HeaderText = "Mã SP";
            columns["TENSP"].HeaderText = "Tên SP";
            columns["MOTA"].HeaderText = "Mô tả";
            columns["MALOAI"].HeaderText = "Mã loại";
            columns["MANCC"].HeaderText = "Mã NCC";
            columns["SOLUONG"].HeaderText = "Số lượng";
            columns["DONVITINH"].HeaderText = "Đơn vị tính";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<SANPHAM> s = sp.GetDataSanPham();
            string tenSanPham = txtTimKiem.Text;

            var ketQua = from sp in s
                         where sp.TENSP.Contains(tenSanPham)
                         select sp;

            dgvSanPham.DataSource = ketQua.ToList();
        }

        private void btnTaoPn_Click(object sender, EventArgs e)
        {
            if (comboBoxTenNCC.Text == "")
            {
                MessageBox.Show("Bạn phải chọn nhà cung cấp");
            }
            else
            {
                //string s = "";
                //if (dgvPhieuNhapa.Rows.Count > 0)
                //{
                //    int rowIndex = dgvPhieuNhapa.Rows.Count -1; // Lấy chỉ mục của dòng cuối cùng

                //    // Truy cập dòng cuối cùng và lấy giá trị từ cột cụ thể
                //    DataGridViewRow lastRow = dgvPhieuNhapa.Rows[rowIndex];

                //    // Lấy giá trị từ cột đầu tiên (cột 0)
                //    string makh = lastRow.Cells[0].Value.ToString();

                //    string ma = extract.ExtractLetters(makh);
                //    int so = Int32.Parse(extract.ExtractNumbers(makh)) + 1;

                //    s = ma + so;
                //} 


                string s = "";
                int v = 0;
                if (dgvPhieuNhapa.Rows.Count > 0)
                {

                    for (int i = 0; i < dgvPhieuNhapa.Rows.Count; i++)
                    {
                        DataGridViewRow r = dgvPhieuNhapa.Rows[i];
                        string makh = r.Cells[0].Value.ToString();
                        int so = Int32.Parse(extract.ExtractNumbers(makh));
                        if (so > v)
                            v = so;
                    }

                    int rowIndex = dgvPhieuNhapa.Rows.Count - 1; // Lấy chỉ mục của dòng cuối cùng
                                                              //string ma = extract.ExtractLetters(row);
                    DataGridViewRow lastRow = dgvPhieuNhapa.Rows[rowIndex];
                    string ma = extract.ExtractLetters(lastRow.Cells[0].Value.ToString());
                    v = v + 1;

                    s = ma + v;
                }


                ComboboxItem selectedItem = (ComboboxItem)comboBoxTenNCC.SelectedItem;
                string mancc = selectedItem.Value;
                int stt = 0;

                foreach (DataGridViewRow row in dgvPhieuNhap.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        tongTien += Convert.ToInt32(row.Cells[3].Value) * Convert.ToInt32(row.Cells[1].Value);
                    }
                }

                PHIEUNHAPHANG insert = new PHIEUNHAPHANG();

                insert.MAPHIEUNHAP = s;
                insert.MANCC = mancc;
                DateTime now = DateTime.Now;
                SqlDateTime sqlDate = new SqlDateTime(now.Year, now.Month, now.Day);
                insert.NGAYNHAP = sqlDate.Value;
                insert.TONGTIEN = tongTien;

                apn.ThemPhieuNhap(insert);


                foreach (DataGridViewRow row in dgvPhieuNhap.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        //--------them ctpn
                        CTPHIEUNHAPHANG ctpn = new CTPHIEUNHAPHANG();

                        ctpn.MACTPHIEUNHAP = s + stt.ToString();
                        ctpn.MAPHIEUNHAP = s;
                        ctpn.MASP = row.Cells[0].Value.ToString();
                        ctpn.SOLUONG = Convert.ToInt32(row.Cells[1].Value);
                        ctpn.DONVITINH = row.Cells[2].Value.ToString();
                        ctpn.THANHTIEN = Convert.ToInt32(row.Cells[3].Value);
                        stt++;

                        // Thêm đối tượng CTPHIEUNHAPHANG vào CSDL
                        actpn.ThemCTPhieuNhap(ctpn);
                        //sp.SuaSanPham(row.Cells[0].Value.ToString(), mancc, Convert.ToInt32(row.Cells[1].Value));
                        //suaSL(Convert.ToInt32(row.Cells[1].Value), row.Cells[0].Value.ToString(), mancc);
                        suaSL(row.Cells[0].Value.ToString(), mancc, Convert.ToInt32(row.Cells[1].Value));
                    }
                }

                dgvPhieuNhapa.DataSource = null;

                dgvPhieuNhap.DataSource = null;
                dgvPhieuNhap.Rows.Clear();
                dgvPhieuNhap.Columns.Clear();

                dgvSanPham.DataSource = null;

                tongTien = 0;
               // loadDGV_SP();
                loadDGV_PN();
                loadsp();
                loadDGV_DSSP();
                MessageBox.Show("Tạo phiếu nhập thành công");
            }
        }
        public void suaSL( string masp, string ncc,int sl)
        {
            // Gọi phương thức SuaSanPham từ BLL_DAL_SanPham để cập nhật CSDL
            sp.SuaSanPham(masp, ncc, sl);

            // Sau khi cập nhật CSDL, bạn có thể cập nhật danh sách sản phẩm hiển thị trên DataGridView
            //loadsp();
        }

        public void suaSL(int sl, string masp, string ncc)
        {
            List<SANPHAM> s = sp.GetDataSanPham();
            SANPHAM edit = s.Where(n => n.MASP.Equals(masp)).SingleOrDefault();
            edit.MANCC = ncc;
            edit.SOLUONG += sl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvPhieuNhap.Rows.Clear();
            dgvPhieuNhap.Columns.Clear();
            loadDGV_DSSP();
        }

        private void dgvPhieuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPhieuNhap.SelectedRows.Count > 0)
            {
                dgvPhieuNhap.Rows.RemoveAt(dgvPhieuNhap.SelectedRows[0].Index);
            }
        }

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
                string masp = row.Cells["MASP"].Value.ToString();
                string dvt = row.Cells["DONVITINH"].Value.ToString();

                //DataGridViewRow rowPN = (DataGridViewRow)dgvPhieuNhap.row.Clone();
                //row.Cells[0].Value = masp;
                //row.Cells[1].Value = 1;
                //row.Cells[2].Value = dvt;
                //row.Cells[3].Value = 1;
                //dgvPhieuNhap.Rows.Add(row);
                DataGridViewRow rowNhap = new DataGridViewRow();
                rowNhap.CreateCells(dgvPhieuNhap);

                rowNhap.Cells[0].Value = row.Cells["MASP"].Value;
                rowNhap.Cells[1].Value = row.Cells["SOLUONG"].Value;
                rowNhap.Cells[2].Value = row.Cells["DONVITINH"].Value;
                rowNhap.Cells[3].Value = 0;

                dgvPhieuNhap.Rows.Add(rowNhap);
            }
        }

        private void dgvPhieuNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPhieuNhap.SelectedRows.Count > 0)
            {
                dgvPhieuNhap.Rows.RemoveAt(dgvPhieuNhap.SelectedRows[0].Index);
            }
        }

        private void dgvPhieuNhapa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhieuNhapa.Rows[e.RowIndex];
                //F_CTPN
                string mapn = row.Cells["MAPHIEUNHAP"].Value.ToString();
                F_CTPN f = new F_CTPN(row.Cells["MAPHIEUNHAP"].Value.ToString());
                f.ShowDialog();

            }
        }

        private void comboBoxTenNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxItem selectedItem = (ComboboxItem)comboBoxTenNCC.SelectedItem;
            string mancc = selectedItem.Value;
            List<SANPHAM> l = sp.GetDataSanPham(mancc);
            var ketQua = from sp in l
                         select new
                         {
                             MASP = sp.MASP,
                             TENSP = sp.TENSP,
                             MOTA = sp.MOTA,
                             MALOAI = sp.MALOAI,
                             MANCC = sp.MANCC,
                             SOLUONG = sp.SOLUONG,
                             DONVITINH = sp.DONVITINH
                         };
            dgvSanPham.DataSource = ketQua.ToList();
            //dgvSanPham.Columns[""].Visible = false;
            //dgvSanPham.Columns[""].Visible = false;
            DataGridViewColumnCollection columns = dgvSanPham.Columns;

            // Sửa HeaderText của mỗi cột
            columns["MASP"].HeaderText = "Mã SP";
            columns["TENSP"].HeaderText = "Tên SP";
            columns["MOTA"].HeaderText = "Mô tả";
            columns["MALOAI"].HeaderText = "Mã loại";
            columns["MANCC"].HeaderText = "Mã NCC";
            columns["SOLUONG"].HeaderText = "Số lượng";
            columns["DONVITINH"].HeaderText = "Đơn vị tính";
        }

        private void btnLamMoiDSSP_Click(object sender, EventArgs e)
        {
            // loadDGV_SP();
            loadsp();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxItem selectedItem = (ComboboxItem)comboBox1.SelectedItem;
            string ma = selectedItem.Value;
            List<PHIEUNHAPHANG> l = apn.GetDataPhieuNhap(ma);
            var ketQua = from sp in l
                         select new
                         {
                             MAPN = sp.MAPHIEUNHAP,
                             MANCC = sp.MANCC,
                             NGAYNHAP = sp.NGAYNHAP,
                             TONGTIEN = sp.TONGTIEN
                         };
            dgvPhieuNhapa.DataSource = ketQua.ToList();
            //dgvSanPham.Columns[""].Visible = false;
            //dgvSanPham.Columns[""].Visible = false;
            DataGridViewColumnCollection columns = dgvPhieuNhapa.Columns;

            // Sửa HeaderText của mỗi cột
            columns["MAPN"].HeaderText = "Mã PN";
            columns["MANCC"].HeaderText = "Nhà cung cấp";
            columns["NGAYNHAP"].HeaderText = "Ngày nhập";
            columns["TONGTIEN"].HeaderText = "Tổng tiền";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // loadDGV_SP();
            loadDGV_DSSP();
            loadDGV_PN();
            loadcbb();
            loadsp();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void NhapHang_Load(object sender, EventArgs e)
        {
            //loadDGV_SP();
            loadDGV_DSSP();
            loadDGV_PN();
            loadcbb();
            loadsp();
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
        private void dgvPhieuNhap_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string input = e.FormattedValue.ToString();

                // Kiểm tra xem giá trị nhập vào có phải là số không âm hay không
                if (!IsNonNegativeInteger(input))
                {
                    e.Cancel = true;
                    dgvPhieuNhap.Rows[e.RowIndex].ErrorText = "Vui lòng nhập số dương.";
                }
            }
        }

        private void dgvPhieuNhap_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvPhieuNhap.Rows[e.RowIndex].ErrorText = string.Empty;
        }
    }
}
