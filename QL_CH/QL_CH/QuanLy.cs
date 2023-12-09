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
    public partial class QuanLy : Form
    {
        BLL_DAL_SanPham qlch = new BLL_DAL_SanPham();
        BLL_DAL_LoaiSP lsp = new BLL_DAL_LoaiSP();
        BLL_DAL_NCC ncc = new BLL_DAL_NCC();
        Extract extract = new Extract();
        BLL_DAL_KhachHang kh = new BLL_DAL_KhachHang();
        BLL_DAL_NCC nc = new BLL_DAL_NCC();

        public QuanLy()
        {
            InitializeComponent();
            datagirdloadsp();
            loadsp();
            datagirdloadLoaisp();
            datagirdloadNCC();
            datagirdloadKH();
        }
        #region load
        private void datagirdloadNCC()
        {
            metroGrid3.DataSource = ncc.GetDataNhaCC();

            metroTextBox11.Enabled = false;
        }
        private void datagirdloadKH()
        {
            metroGrid1.DataSource = kh.GetDataKhachHang();

            metroTextBox6.Enabled = false;
        }
        private void datagirdloadLoaisp()
        {
            dataGridView1.DataSource = lsp.GetDataLoaisp();

            textBox1.Enabled = false;
        }
        private void datagirdloadsp()
        {
            dtg_sanpham.DataSource = qlch.GetDataSanPham();
            string columnNameToMakeReadOnly = "SOLUONG";

            // Find the column by name and set the ReadOnly property
            if (dtg_sanpham.Columns.Contains(columnNameToMakeReadOnly))
            {
                dtg_sanpham.Columns[columnNameToMakeReadOnly].ReadOnly = true;
            }


        }
        private void loadsp()
        {



            List<LOAISP> loaisp = lsp.GetDataLoaisp();
            cboLoaiSP.DataSource = loaisp;
            cboLoaiSP.DisplayMember = "TENLOAI";
            cboLoaiSP.ValueMember = "MALOAI";

            List<NHACC> NCC = ncc.GetDataNhaCC();
            cboNcc.DataSource = NCC;
            cboNcc.DisplayMember = "TENNCC";
            cboNcc.ValueMember = "MANCC";

            List<LOAISP> cboTKloaisp = lsp.GetDataLoaisp();
            cbo_Loaisp.DataSource = cboTKloaisp;
            cbo_Loaisp.DisplayMember = "TENLOAI";
            cbo_Loaisp.ValueMember = "MALOAI";

            List<NHACC> cboTKNcc = ncc.GetDataNhaCC();
            cbo_NhaCC.DataSource = cboTKNcc;
            cbo_NhaCC.DisplayMember = "TENNCC";
            cbo_NhaCC.ValueMember = "MANCC";


        }

        #endregion


        private void metroTextBox8_Click(object sender, EventArgs e)
        {

        }
        private void htmlPanel1_Click(object sender, EventArgs e)
        {

        }
        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }
        #region sanpham
        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        private void cbo_NhaCC_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedNhacc = cbo_NhaCC.SelectedValue as string;
            if (!string.IsNullOrEmpty(selectedNhacc))
            {
                dtg_sanpham.DataSource = qlch.TimSanPham_NCC(selectedNhacc);
            }
        }
        private void txtTuKhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                if (!string.IsNullOrEmpty(txtTuKhoa.Text))
                {
                    if (qlch.TimSanPham(txtTuKhoa.Text).Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm phù hợp");
                    }
                    else
                    {
                        dtg_sanpham.DataSource = qlch.TimSanPham(txtTuKhoa.Text);
                    }
                }
                e.Handled = true;
            }
        }
        private void cbo_Loaisp_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void cbo_Loaisp_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedLoaiSanPham = cbo_Loaisp.SelectedValue as string;
            if (!string.IsNullOrEmpty(selectedLoaiSanPham))
            {
                dtg_sanpham.DataSource = qlch.TimSanPham_Loai(selectedLoaiSanPham);
            }
        }
        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbo_NhaCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            SANPHAM sp = new SANPHAM();
            //string s = "";
            //if (dtg_sanpham.Rows.Count > 0)
            //{
            //    int rowIndex = dtg_sanpham.Rows.Count - 1; // Lấy chỉ mục của dòng cuối cùng

            //    // Truy cập dòng cuối cùng và lấy giá trị từ cột cụ thể
            //    DataGridViewRow lastRow = dtg_sanpham.Rows[rowIndex];

            //    // Lấy giá trị từ cột đầu tiên (cột 0)
            //    string makh = lastRow.Cells[0].Value.ToString();

            //    string ma = extract.ExtractLetters(makh);
            //    int so = Int32.Parse(extract.ExtractNumbers(makh)) + 1;

            //    s = ma + so;
            //}

            string s = "";
            int v = 0;
            if (dtg_sanpham.Rows.Count > 0)
            {

                for (int i = 0; i < dtg_sanpham.Rows.Count; i++)
                {
                    DataGridViewRow r = dtg_sanpham.Rows[i];
                    string makh = r.Cells[0].Value.ToString();
                    int so = Int32.Parse(extract.ExtractNumbers(makh));
                    if (so > v)
                        v = so;
                }

                int rowIndex = dtg_sanpham.Rows.Count - 1; // Lấy chỉ mục của dòng cuối cùng
                //string ma = extract.ExtractLetters(row);
                DataGridViewRow lastRow = dtg_sanpham.Rows[rowIndex];
                string ma = extract.ExtractLetters(lastRow.Cells[0].Value.ToString());
                v = v + 1;

                s = ma + v;
            }


            sp.MASP = s;

            sp.TENSP = txtTensp.Text;
            if(metroTextBox1.Text == "")
            {
                sp.hinh = "logo.jpg";
            }    
            else
            {
                sp.hinh = metroTextBox1.Text;
            }   
            sp.MOTA = txtMota.Text;
            sp.MALOAI = cboLoaiSP.SelectedValue as string;
            sp.MANCC = cboNcc.SelectedValue as string;
            sp.SOLUONG = 0;
            sp.DONVITINH = txtDonvitinh.Text;
            sp.DONGIA = int.Parse(txtDonGia.Text);
            DialogResult result = MessageBox.Show("Chắc chắn thêm sản phẩm " + txtTensp.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (qlch.ThemSanPham(sp))
                {
                    MessageBox.Show("Thêm thành công");
                    datagirdloadsp();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dtg_sanpham.SelectedRows[0];
            //tên sản phẩm
            if (!string.IsNullOrEmpty(selectedRow.Cells[0].Value.ToString()))
            {
                DialogResult result = MessageBox.Show("Chắc chắn xóa sản phẩm " + txtTensp.Text + " không?", "Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (qlch.XoaSanPham(selectedRow.Cells[0].Value.ToString()))
                    {
                        MessageBox.Show("Xóa thành công");
                        datagirdloadsp();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }


            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
        

            if (dtg_sanpham.SelectedCells.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dtg_sanpham.Rows[dtg_sanpham.SelectedCells[0].RowIndex];

                // Tạo đối tượng SANPHAM và gán giá trị từ các ô của dòng được chọn
                SANPHAM sp = new SANPHAM();
                sp.MASP = selectedRow.Cells[0].Value.ToString();
                if(metroTextBox1.Text !="")
                {
                    sp.hinh = metroTextBox1.Text;
                }    
                else
                {
                    sp.hinh = selectedRow.Cells[1].Value.ToString();
                }    
                
                sp.TENSP = selectedRow.Cells[2].Value.ToString();
                sp.MOTA = selectedRow.Cells[3].Value.ToString();
                sp.MALOAI = selectedRow.Cells[4].Value.ToString();
                sp.MANCC = selectedRow.Cells[5].Value.ToString();
                sp.SOLUONG = int.Parse(selectedRow.Cells[6].Value.ToString());
                sp.DONVITINH = selectedRow.Cells[7].Value.ToString();
                sp.DONGIA =int.Parse( selectedRow.Cells[8].Value.ToString());

                DialogResult result = MessageBox.Show("Chắc chắn sửa sản phẩm không?", "Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (qlch.SuaSanPham(sp))
                    {
                        MessageBox.Show("Sửa thành công");
                        datagirdloadsp();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại");
                    }
                }
                // Hiển thị thông tin (bạn có thể thực hiện các hành động khác tại đây)
            }
            else
            {
                MessageBox.Show("Không có ô nào được chọn.");
            }
            metroTextBox1.Text = "";
        }
# endregion


        
        #region loaisanpham

        private void button6_Click(object sender, EventArgs e)
        {

            LOAISP sp = new LOAISP();
            if (dataGridView1.Rows.Count > 0)
            {
                DataGridViewRow slted = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex];

                sp.MALOAI = slted.Cells[0].Value.ToString();
                DialogResult result = MessageBox.Show("Chắc chắn xóa loại sản phẩm " + sp.MALOAI + " không?", "Thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (lsp.deleteLoaiSp(sp.MALOAI))
                    {
                        MessageBox.Show("Xóa thành công");
                        dataGridView1.DataSource = lsp.GetDataLoaisp();

                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }

            }




        }

        private void button7_Click(object sender, EventArgs e)
        {
            //string s = "";
            //if (dataGridView1.Rows.Count > 0)
            //{
            //    int rowIndex = dataGridView1.Rows.Count - 1; // Lấy chỉ mục của dòng cuối cùng

            //    // Truy cập dòng cuối cùng và lấy giá trị từ cột cụ thể
            //    DataGridViewRow lastRow = dataGridView1.Rows[rowIndex];

            //    // Lấy giá trị từ cột đầu tiên (cột 0)
            //    string makh = lastRow.Cells[0].Value.ToString();

            //    string ma = extract.ExtractLetters(makh);
            //    int so = Int32.Parse(extract.ExtractNumbers(makh)) + 1;

            //    s = ma + so;
            //}
            string s = "";
            int v = 0;
            if (dataGridView1.Rows.Count > 0)
            {

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow r = dataGridView1.Rows[i];
                    string makh = r.Cells[0].Value.ToString();
                    int so = Int32.Parse(extract.ExtractNumbers(makh));
                    if (so > v)
                        v = so;
                }

                int rowIndex = dataGridView1.Rows.Count - 1; // Lấy chỉ mục của dòng cuối cùng
                //string ma = extract.ExtractLetters(row);
                DataGridViewRow lastRow = dataGridView1.Rows[rowIndex];
                string ma = extract.ExtractLetters(lastRow.Cells[0].Value.ToString());
                v = v + 1;

                s = ma + v;
            }


            LOAISP l = new LOAISP();
            l.MALOAI = s;
            l.TENLOAI = textBox2.Text;
           if( lsp.ThemLoaisp(l))
            {
                MessageBox.Show("Thêm thành công");
            }    
           else
                MessageBox.Show("Thêm thất bại");

            dataGridView1.DataSource = lsp.GetDataLoaisp();
        }

        private void button5_Click(object sender, EventArgs e)
        {
             LOAISP sp = new LOAISP();
            if (dataGridView1.SelectedCells.Count > 0)
            {
                DataGridViewRow slted = dataGridView1.Rows[dtg_sanpham.SelectedCells[0].RowIndex];
               
                sp.MALOAI = slted.Cells[0].Value.ToString();
                sp.TENLOAI = slted.Cells[1].Value.ToString();
            }
            DialogResult result = MessageBox.Show("Chắc chắn sửa loại sản phẩm " + textBox1.Text + " không?", "Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (lsp.SuaLoaiSanPham(sp))
                {
                    MessageBox.Show("Sửa thành công");
                    dataGridView1.DataSource = lsp.GetDataLoaisp();

                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
        }
        #endregion


       


        #region khachhang
        private void button3_Click(object sender, EventArgs e)
        {
            //string s = "";
            //if (metroGrid1.Rows.Count > 0)
            //{
            //    int rowIndex = metroGrid1.Rows.Count - 2; // Lấy chỉ mục của dòng cuối cùng

            //    // Truy cập dòng cuối cùng và lấy giá trị từ cột cụ thể
            //    DataGridViewRow lastRow = metroGrid1.Rows[rowIndex];

            //    // Lấy giá trị từ cột đầu tiên (cột 0)
            //    string makh = lastRow.Cells[0].Value.ToString();

            //    string ma = extract.ExtractLetters(makh);
            //    int so = Int32.Parse(extract.ExtractNumbers(makh)) + 1;

            //    s = ma + so;
            //}

            string s = "";
            int v = 0;
            if (metroGrid1.Rows.Count > 0)
            {

                for (int i = 0; i < metroGrid1.Rows.Count-1; i++)
                {
                    DataGridViewRow r = metroGrid1.Rows[i];
                    string makh = r.Cells[0].Value.ToString();
                    int so = Int32.Parse(extract.ExtractNumbers(makh));
                    if (so > v)
                        v = so;
                }

                int rowIndex = metroGrid1.Rows.Count - 1; // Lấy chỉ mục của dòng cuối cùng
                //string ma = extract.ExtractLetters(row);
                DataGridViewRow lastRow = metroGrid1.Rows[rowIndex-1];
                string ma = extract.ExtractLetters(lastRow.Cells[0].Value.ToString());
                v = v + 1;

                s = ma + v;
            }



            KHACHHANG l = new KHACHHANG();
            l.MAKH = s;
            l.HOTEN = metroTextBox4.Text;
            l.DIACHI = metroTextBox5.Text;
            l.TRANGTHAI = metroTextBox3.Text;
            if (kh.ThemKhachHang(l))
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
            metroGrid1.DataSource = kh.GetDataKhachHang();
        }
         private void button2_Click(object sender, EventArgs e)
         {
            KHACHHANG kha = new KHACHHANG();
            if (metroGrid1.Rows.Count > 0)
            {
                DataGridViewRow slted = metroGrid1.Rows[metroGrid1.SelectedCells[0].RowIndex];
                kha.MAKH = slted.Cells[0].Value.ToString();
                kha.HOTEN = slted.Cells[1].Value.ToString();
                DialogResult result = MessageBox.Show("Chắc chắn xóa khách hàng " + kha.HOTEN + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (kh.XoaKhachHang(kha.MAKH))
                    {
                        MessageBox.Show("Xóa thành công");
                        metroGrid1.DataSource = kh.GetDataKhachHang();
                       
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }
            }    
         }

        private void button1_Click(object sender, EventArgs e)
        {
            KHACHHANG sp = new KHACHHANG();

            if (dataGridView1.SelectedCells.Count > 0)
            {
                DataGridViewRow slted = dataGridView1.Rows[dtg_sanpham.SelectedCells[0].RowIndex];

                sp.MAKH = slted.Cells[0].Value.ToString();
                sp.HOTEN = slted.Cells[1].Value.ToString();
                sp.DIACHI = slted.Cells[2].Value.ToString();
                sp.TRANGTHAI = slted.Cells[3].Value.ToString();

            }


            DialogResult result = MessageBox.Show("Chắc chắn sửa khách hàng " + textBox1.Text + " không?", "Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (kh.SuaKhachHang(sp))
                {
                    MessageBox.Show("Sửa thành công");
                    dataGridView1.DataSource = kh.GetDataKhachHang();
                    // biding();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
        }


        #endregion

        #region nhacc

        private void button9_Click(object sender, EventArgs e)
        {
            NHACC l = new NHACC();

            //string s = "";
            //if (metroGrid3.Rows.Count > 0)
            //{
            //    int rowIndex = metroGrid3.Rows.Count - 1; // Lấy chỉ mục của dòng cuối cùng

            //    // Truy cập dòng cuối cùng và lấy giá trị từ cột cụ thể
            //    DataGridViewRow lastRow = metroGrid3.Rows[rowIndex];

            //    // Lấy giá trị từ cột đầu tiên (cột 0)
            //    string makh = lastRow.Cells[0].Value.ToString();

            //    string ma = extract.ExtractLetters(makh);
            //    int so = Int32.Parse(extract.ExtractNumbers(makh)) + 1;

            //    s = ma + so;
            //}
            string s = "";
            int v = 0;
            if (metroGrid3.Rows.Count > 0)
            {

                for (int i = 0; i < metroGrid3.Rows.Count; i++)
                {
                    DataGridViewRow r = metroGrid3.Rows[i];
                    string makh = r.Cells[0].Value.ToString();
                    int so = Int32.Parse(extract.ExtractNumbers(makh));
                    if (so > v)
                        v = so;
                }

                int rowIndex = metroGrid3.Rows.Count - 1; // Lấy chỉ mục của dòng cuối cùng
                //string ma = extract.ExtractLetters(row);
                DataGridViewRow lastRow = metroGrid3.Rows[rowIndex];
                string ma = extract.ExtractLetters(lastRow.Cells[0].Value.ToString());
                v = v + 1;

                s = ma + v;
            }

            l.MANCC = s;
            l.TENNCC = metroTextBox10.Text;
            if (nc.ThemNhacc(l))
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
            metroGrid3.DataSource = nc.GetDataNhaCC();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = metroGrid3.SelectedRows[0];
            //tên sản phẩm
            if (!string.IsNullOrEmpty(selectedRow.Cells[0].Value.ToString()))
            {
                DialogResult result = MessageBox.Show("Chắc chắn xóa nhà cung cấp " + metroTextBox10.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (nc.deleteNhacc(selectedRow.Cells[0].Value.ToString()))
                    {
                        MessageBox.Show("Xóa thành công");
                        metroGrid3.DataSource = nc.GetDataNhaCC();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NHACC sp = new NHACC();
            DataGridViewRow selectedRow = metroGrid3.SelectedRows[0];
            sp.MANCC = selectedRow.Cells[0].Value.ToString();
            sp.TENNCC = selectedRow.Cells[1].Value.ToString();

            DialogResult result = MessageBox.Show("Chắc chắn sửa loại sản phẩm " + sp.TENNCC + " không?", "Sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (nc.SuaNhaCc(sp))
                {
                    MessageBox.Show("Sửa thành công");
                    metroGrid3.DataSource = nc.GetDataNhaCC();

                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
        }
        #endregion

        private void metroButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose Image";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
             
                string imagePath = openFileDialog.FileName;
                //MessageBox.Show("Selected Image: " + openFileDialog.SafeFileName);
                metroTextBox1.Text = openFileDialog.SafeFileName;
                //pictureBox.ImageLocation = imagePath;
            }
        }
    }
}
