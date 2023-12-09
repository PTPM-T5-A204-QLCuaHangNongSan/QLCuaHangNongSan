using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace BLL_DAL
{
    public class BLL_DAL_CTPN
    {
        QLCHDataContext qlch = new QLCHDataContext();
        public bool ThemCTPhieuNhap(CTPHIEUNHAPHANG DD)
        {
            //chua them duoc ct phieu nhap
            try
            {
                
                CTPHIEUNHAPHANG ctpn = new CTPHIEUNHAPHANG();
                ctpn.MACTPHIEUNHAP = DD.MACTPHIEUNHAP ;
                ctpn.MAPHIEUNHAP = DD.MAPHIEUNHAP;
                ctpn.MASP = DD.MASP;
                ctpn.SOLUONG = DD.SOLUONG;
                ctpn.DONVITINH = DD.DONVITINH;
                ctpn.THANHTIEN = DD.THANHTIEN;
                
                // Thêm đối tượng CTPHIEUNHAPHANG vào CSDL
                qlch.CTPHIEUNHAPHANGs.InsertOnSubmit(ctpn);
                qlch.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public List<CTPHIEUNHAPHANG> GetDataCTPNTheoMa(string ma)
        {
            var Kq = qlch.CTPHIEUNHAPHANGs
                .Where(ctpn => ctpn.MAPHIEUNHAP == ma)
                .ToList();

            return Kq;
        }
        

    }
}
