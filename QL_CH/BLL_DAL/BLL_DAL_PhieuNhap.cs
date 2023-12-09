using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace BLL_DAL
{
    public class BLL_DAL_PhieuNhap
    {
        QLCHDataContext qlch = new QLCHDataContext();
        BLL_DAL_NCC ncc = new BLL_DAL_NCC();
        public BLL_DAL_PhieuNhap()
        {
            
        }
        public List<PHIEUNHAPHANG> GetDataPhieuNhap()
        {
            var sanphams = from d in qlch.PHIEUNHAPHANGs select d;
            List<PHIEUNHAPHANG> list_sanpham = sanphams.ToList<PHIEUNHAPHANG>();
            return list_sanpham;
        }

        public List<PHIEUNHAPHANG> GetDataPhieuNhap(string ncc)
        {
            var sanphams = from d in qlch.PHIEUNHAPHANGs where d.MANCC == ncc select d;
            List<PHIEUNHAPHANG> list_sanpham = sanphams.ToList<PHIEUNHAPHANG>();
            return list_sanpham;
        }
        public bool ThemPhieuNhap(PHIEUNHAPHANG DD)
        {
            try
            {
                PHIEUNHAPHANG insert = new PHIEUNHAPHANG();
                insert.MAPHIEUNHAP = DD.MAPHIEUNHAP;
                insert.MANCC = DD.MANCC;
                DateTime now = DateTime.Now;
                SqlDateTime sqlDate = new SqlDateTime(now.Year, now.Month, now.Day);
                insert.NGAYNHAP = sqlDate.Value;
                insert.TONGTIEN = DD.TONGTIEN;

                qlch.PHIEUNHAPHANGs.InsertOnSubmit(insert);

                qlch.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }


        public bool KtraTrungMa(string ma)
        {
            return qlch.PHIEUNHAPHANGs.Any(d => d.MAPHIEUNHAP == ma);
        }
















    }
}
