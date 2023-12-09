using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_DAL_NhomNguoiDung
    {
        QLCHDataContext qlch = new QLCHDataContext();

        public BLL_DAL_NhomNguoiDung()
        {

        }
        public List<QL_NhomNguoiDung> GetNhomNguoiDung()
        {
            return qlch.QL_NhomNguoiDungs.Select(k => k).ToList<QL_NhomNguoiDung>();
        }

        public List<string> ListMaNhom()
        {
            return qlch.QL_NhomNguoiDungs.Select(k => k.MaNhom).ToList();
        }
    }
}
