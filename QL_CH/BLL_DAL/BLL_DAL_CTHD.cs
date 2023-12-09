using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_DAL_CTHD
    {
        QLCHDataContext qlch = new QLCHDataContext();
        public BLL_DAL_CTHD()
        {

        }


        public List<CTHOADON> GetDataCTHoaDon(string ma)
        {
            var Kq = qlch.CTHOADONs
                .Where(ctpn => ctpn.MAHD == ma)
                .ToList();
            return Kq;
        }
        public bool ThemHoaDon(CTHOADON DD)
        {
            try
            {
                //tao san pham
                CTHOADON sp = new CTHOADON();

                sp.MACTHD = DD.MACTHD;
                sp.MAHD = DD.MAHD;
                sp.MASP = DD.MASP;
                sp.SOLUONG = DD.SOLUONG;
                sp.DONGIA = DD.DONGIA;
                //add
                qlch.CTHOADONs.InsertOnSubmit(sp);
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
