using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_DAL_DangNhap
    {
        QLCHDataContext qlch = new QLCHDataContext();

        public BLL_DAL_DangNhap()
        {

        }

        public List<QL_NguoiDung> GetDataNguoiDung()
        {
            //var nguoidungs = from d in qlch.NGUOIDUNGs select d;
            //List<NGUOIDUNG> list_nguoidung = nguoidungs.ToList<NGUOIDUNG>();
            return qlch.QL_NguoiDungs.Select(k => k).ToList<QL_NguoiDung>();
        }
        public void XoaTaiKhoan(string _tendn)
        {
            QL_NguoiDung nd = new QL_NguoiDung();
            nd = qlch.QL_NguoiDungs.Where(t => t.TenDangNhap == _tendn).FirstOrDefault();
            qlch.QL_NguoiDungs.DeleteOnSubmit(nd);
            qlch.SubmitChanges();
        }
        public void SuaTaiKhoan(string _tendn, string matkhau)
        {
            QL_NguoiDung nd = new QL_NguoiDung();
            nd = qlch.QL_NguoiDungs.Where(t => t.TenDangNhap == _tendn).FirstOrDefault();

            nd.MatKhau = matkhau;
            qlch.SubmitChanges();
        }

        public void ThemTaiKhoan(string _tendn, string _password)
        {
            QL_NguoiDung nd = new QL_NguoiDung();
            nd.TenDangNhap = _tendn;
            nd.MatKhau = _password;

            qlch.QL_NguoiDungs.InsertOnSubmit(nd);
            qlch.SubmitChanges();
        }
        public QL_NguoiDung Login(string username, string password)
        {
            //var nguoidung = qlch.NGUOIDUNGs.FirstOrDefault(d => d.TenDangNhap == taiKhoan && d.MatKhau == matKhau);
            //return nguoidung;
            return qlch.QL_NguoiDungs.FirstOrDefault(d => d.TenDangNhap == username && d.MatKhau == password);
        }

        // Lấy nhóm người dùng từ tên đăng nhập
        public List<string> GetMaNhomNguoiDung(string tenDangNhap)
        {
            using (var context = new QLCHDataContext())
            {
                return context.QL_NguoiDungNhomNguoiDungs
                    .Where(x => x.TenDangNhap == tenDangNhap)
                    .Select(x => x.MaNhomNguoiDung)
                    .ToList();
            }
        }
        // Lấy danh sách mã màn hình từ mã nhóm người dùng
        public List<string> GetMaManHinh(string maNhomNguoiDung)
        {
            using (var context = new QLCHDataContext())
            {
                return context.QL_PhanQuyens
                    .Where(x => x.MaNhomNguoiDung == maNhomNguoiDung)
                    .Select(x => x.MaManHinh)
                    .ToList();
            }
        }
    }
}
