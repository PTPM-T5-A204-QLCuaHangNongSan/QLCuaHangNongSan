using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_DAL_KhachHang
    {
        QLCHDataContext qlch = new QLCHDataContext();

        public BLL_DAL_KhachHang()
        {

        }

        public List<KHACHHANG> GetDataKhachHang()
        {
            var khachhangs = from d in qlch.KHACHHANGs select d;
            List<KHACHHANG> list_khachhang = khachhangs.ToList<KHACHHANG>();
            return list_khachhang;
        }
        public string TimKhachHangTheoMa(string hoten)
        {
            var khachHang = qlch.KHACHHANGs.FirstOrDefault(kh => kh.HOTEN == hoten);
            if (khachHang != null)
            {
                return khachHang.MAKH;
            }
            return null; 
        }



        public bool ThemKhachHang(KHACHHANG DD)
        {
            try
            {
                KHACHHANG kh = new KHACHHANG();
                kh.MAKH = DD.MAKH;
                kh.HOTEN = DD.HOTEN;
                kh.DIACHI = DD.DIACHI;
                kh.TRANGTHAI = DD.TRANGTHAI;
            
                //add
                qlch.KHACHHANGs.InsertOnSubmit(kh);
                qlch.SubmitChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            //tao
           
        }

        public bool XoaKhachHang(string DD)
        {
            try
            {
                KHACHHANG khs = qlch.KHACHHANGs.Where(t => t.MAKH == DD).FirstOrDefault();
                qlch.KHACHHANGs.DeleteOnSubmit(khs);
                qlch.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SuaKhachHang(KHACHHANG DD)
        {
            try
            {
                KHACHHANG kh = qlch.KHACHHANGs.Where(t => t == DD).FirstOrDefault();
                if (kh != null)
                {

                    kh.HOTEN = DD.HOTEN;
                    kh.DIACHI = DD.DIACHI;
                    kh.TRANGTHAI = DD.TRANGTHAI;
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



    }
}
