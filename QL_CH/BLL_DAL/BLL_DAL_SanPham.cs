using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_DAL_SanPham
    {
        QLCHDataContext qlch = new QLCHDataContext();
        public BLL_DAL_SanPham()
        {

        }
        public List<SANPHAM> GetDataSanPham()
        {
            var sanphams = from d in qlch.SANPHAMs select d;
            List<SANPHAM> list_sanpham = sanphams.ToList<SANPHAM>();
            return list_sanpham;
        }
        public List<SANPHAM> GetDataSanPham(string ncc)
        {
            var sanphams = from d in qlch.SANPHAMs where d.MANCC == ncc select d;
            List<SANPHAM> list_sanpham = sanphams.ToList<SANPHAM>();
            return list_sanpham;
        }
        public bool ThemSanPham(SANPHAM  DD)
        {
            try
            {
                //tao san pham
                SANPHAM sp = new SANPHAM();

                sp.MASP = DD.MASP;
                sp.hinh = DD.hinh;
                sp.TENSP = DD.TENSP;
                sp.MOTA = DD.MOTA;
                sp.MALOAI = DD.MALOAI;
                sp.MANCC = DD.MANCC;
                sp.SOLUONG = DD.SOLUONG;
                sp.DONVITINH = DD.DONVITINH;
                sp.DONGIA = DD.DONGIA;
                //add
                qlch.SANPHAMs.InsertOnSubmit(sp);
                qlch.SubmitChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            
        }

        public bool XoaSanPham(string masp)
        {
            try
            {
                SANPHAM sp = qlch.SANPHAMs.Where(t => t.MASP == masp).FirstOrDefault();
                qlch.SANPHAMs.DeleteOnSubmit(sp);
                qlch.SubmitChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }

           
        }
        public bool SuaSanPham(string masp, string mancc, int sl)
        {
            try
            {
                SANPHAM edit = qlch.SANPHAMs.Where(n => n.MASP.Equals(masp)).SingleOrDefault();
                if (edit != null)
                {

                    edit.MANCC = mancc;
                    edit.SOLUONG += sl;
                    qlch.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool SuaSanPham_Ban(string masp, int sl)
        {
            try
            {
                SANPHAM edit = qlch.SANPHAMs.Where(n => n.MASP.Equals(masp)).SingleOrDefault();
                if (edit != null)
                {

                   // edit.MANCC = mancc;
                    edit.SOLUONG -= sl;
                    qlch.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public bool SuaSanPham(SANPHAM DD)
        {
            try
            {
                SANPHAM sp = qlch.SANPHAMs.Where(t => t.MASP == DD.MASP).FirstOrDefault();
                if (sp != null)
                {
                    
                    sp.TENSP = DD.TENSP;
                    sp.hinh = DD.hinh;
                    sp.MOTA = DD.MOTA;
                    sp.MALOAI = DD.MALOAI;
                    sp.MANCC = DD.MANCC;
                    sp.SOLUONG = DD.SOLUONG;
                    sp.DONVITINH = DD.DONVITINH;
                    sp.DONGIA = DD.DONGIA;
                    qlch.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<SANPHAM> TimSanPham(string keyword)
        {
            List<SANPHAM> sanPhamList = new List<SANPHAM>();
            var sanphams = from d in qlch.SANPHAMs
                           where d.TENSP.Contains(keyword) || d.MASP.Contains(keyword) || d.MOTA.Contains(keyword)
                           select d;
            sanPhamList = sanphams.ToList<SANPHAM>();
            return sanPhamList;
        }

        public List<SANPHAM> TimSanPham_Loai(string maloai)
        {
            List<SANPHAM> sanPhamList = new List<SANPHAM>();
            var sanphams = from d in qlch.SANPHAMs
                        where d.MALOAI == maloai 
                        select d;
            sanPhamList = sanphams.ToList<SANPHAM>();
            return sanPhamList;
        }

        public List<SANPHAM> TimSanPham_NCC(string keyword)
        {
            List<SANPHAM> sanPhamList = new List<SANPHAM>();
            var sanphams = from d in qlch.SANPHAMs
                           where d.MANCC.Contains (keyword )
                           select d;
            sanPhamList = sanphams.ToList<SANPHAM>();
            return sanPhamList;
        }



    }
}
