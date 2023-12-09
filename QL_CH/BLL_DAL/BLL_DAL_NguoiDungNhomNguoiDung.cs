using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_DAL_NguoiDungNhomNguoiDung
    {
        QLCHDataContext qlch = new QLCHDataContext();
        public BLL_DAL_NguoiDungNhomNguoiDung()
        {

        }
        public List<QL_NguoiDungNhomNguoiDung> GetData()
        {
            return qlch.QL_NguoiDungNhomNguoiDungs.Select(k => k).ToList<QL_NguoiDungNhomNguoiDung>();
        }

        public void themNguoiDungVaoNhom(string tendn, string nhomnguoidung)
        {
            QL_NguoiDungNhomNguoiDung nd = new QL_NguoiDungNhomNguoiDung();
            nd.TenDangNhap = tendn;
            nd.MaNhomNguoiDung = nhomnguoidung;
            qlch.QL_NguoiDungNhomNguoiDungs.InsertOnSubmit(nd);
            qlch.SubmitChanges();
        }
        public void xoaNguoiDungKhoiNhom(string tendn)
        {
            QL_NguoiDungNhomNguoiDung nd = qlch.QL_NguoiDungNhomNguoiDungs.Where(k => k.TenDangNhap == tendn).FirstOrDefault();


            qlch.QL_NguoiDungNhomNguoiDungs.DeleteOnSubmit(nd);
            qlch.SubmitChanges();

        }

        public bool kiemtra(string _tendn, string _maNhomNguoiDung  )
        {
            return qlch.QL_NguoiDungNhomNguoiDungs.Any(k => k.TenDangNhap.Trim() == _tendn && k.MaNhomNguoiDung.Trim() == _maNhomNguoiDung);

        }
    }
}
