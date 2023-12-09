using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_DAL_NhanVien
    {
        QLCHDataContext qlch = new QLCHDataContext();
        public BLL_DAL_NhanVien()
        {

        }
        public List<NHANVIEN> GetNhanVien()
        {
            //var nguoidungs = from d in qlch.NGUOIDUNGs select d;
            //List<NGUOIDUNG> list_nguoidung = nguoidungs.ToList<NGUOIDUNG>();
            return qlch.NHANVIENs.Select(k => k).ToList<NHANVIEN>();
        }

        public void ThemNhanVien(string manv, string tennv, string gioitinh, string diachi, int luong, string sdt)
        {
            NHANVIEN nhanvien = new NHANVIEN();
            nhanvien.MANV = manv;
            nhanvien.TENNV = tennv;
            nhanvien.GIOITINH = gioitinh;
            nhanvien.DIACHI = diachi;
            nhanvien.LUONG = luong;
            nhanvien.SDT = sdt;

            qlch.NHANVIENs.InsertOnSubmit(nhanvien);
            qlch.SubmitChanges();
        }
        public void XoaNhanVien(string _manv)
        {

            // Xóa các bản ghi có tham chiếu khóa ngoại tới nhân viên trong bảng NGUOIDUNG
            var nguoiDungList = qlch.QL_NguoiDungs.Where(nd => nd.TenDangNhap == _manv).ToList();
            qlch.QL_NguoiDungs.DeleteAllOnSubmit(nguoiDungList);

            // Lưu thay đổi trong bảng NGUOIDUNG trước
            qlch.SubmitChanges();

            // Xóa nhân viên trong bảng NHANVIEN
            NHANVIEN nhanvien = qlch.NHANVIENs.FirstOrDefault(t => t.MANV == _manv);
            if (nhanvien != null)
            {
                qlch.NHANVIENs.DeleteOnSubmit(nhanvien);

                // Lưu thay đổi trong bảng NHANVIEN sau
                qlch.SubmitChanges();
            }
        }


        public void SuaNhanVien(string _manv, string _ten, string _gioitinh, string _diachi, string _sdt, int _luong)
        {
            NHANVIEN nv = new NHANVIEN();
            nv = qlch.NHANVIENs.Where(t => t.MANV == _manv).FirstOrDefault();
            nv.TENNV = _ten;
            nv.GIOITINH = _gioitinh;
            nv.SDT = _sdt;
            nv.LUONG = _luong;

            qlch.SubmitChanges();
        }
        public bool TimNhanVienTheoMa(string ma)
        {
            return qlch.NHANVIENs.Any(t => t.MANV == ma);
        }
        
        public List<string> LayMaNhanVien()
        {
            return qlch.NHANVIENs.Select(k => k.MANV).ToList();
        }
    }
}
