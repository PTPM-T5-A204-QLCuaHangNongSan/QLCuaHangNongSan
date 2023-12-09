using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_DAL_HoaDon
    {
        QLCHDataContext qlch = new QLCHDataContext();
        public BLL_DAL_HoaDon()
        {

        }
        public List<HOADON> GetDataHoaDon()
        {
            var sanphams = from d in qlch.HOADONs select d;
            List<HOADON> list_sanpham = sanphams.ToList<HOADON>();
            return list_sanpham;
        }

        public List<HOADON> GetDataHoaDonChuaDuyet()
        {
            var hoadons = from h in qlch.HOADONs
                          where h.TRANGTHAI == null || h.TRANGTHAI == 0
                          select h;

            List<HOADON> list_hoadon = hoadons.ToList();
            return list_hoadon;
        }

        public bool CapNhatTrangThaiKhachHang(HOADON DD)
        {
            try
            {
                HOADON kh = qlch.HOADONs.Where(t => t.MAHD == DD.MAHD).FirstOrDefault();
                if (kh != null)
                {
                    kh.NGAYDAT = DD.NGAYDAT;
                    kh.MAKH = DD.MAKH;
                    kh.MANV = DD.MANV;
                    kh.TONGTIEN = DD.TONGTIEN;
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


        public bool ThemHoaDon(HOADON DD)
        {
            try
            {
                //tao san pham
                HOADON sp = new HOADON();

                sp.MAHD = DD.MAHD;
                sp.NGAYDAT = DD.NGAYDAT;
                sp.MAKH = DD.MAKH;
                sp.MANV = DD.MANV;
                sp.TONGTIEN = DD.TONGTIEN;
                sp.TRANGTHAI = DD.TRANGTHAI;
                //add
                qlch.HOADONs.InsertOnSubmit(sp);
                qlch.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool XoaHoaDon(string masp)
        {
            try
            {
                HOADON sp = qlch.HOADONs.Where(t => t.MAHD == masp).FirstOrDefault();
                qlch.HOADONs.DeleteOnSubmit(sp);
                qlch.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }


        }





    }
}
