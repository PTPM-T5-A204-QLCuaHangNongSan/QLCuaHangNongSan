using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class ThongKe
    {
        QLCHDataContext qlch = new QLCHDataContext();

        public ThongKe()
        {

        }
        public List<HOADON> ListHoaDon(DateTime ngayA, DateTime ngayB)
        {
            var hoadons = qlch.HOADONs.Where(hd => hd.NGAYDAT >= ngayA && hd.NGAYDAT <= ngayB).ToList();
            return hoadons;
        }

        public List<PHIEUNHAPHANG> listPhieuNhap(DateTime ngayA, DateTime ngayB)
        {
            var nhaps = qlch.PHIEUNHAPHANGs.Where(hd => hd.NGAYNHAP >= ngayA && hd.NGAYNHAP <= ngayB).ToList();
            return nhaps;
        }
        public List<NHANVIEN> listNhanVien()
        {
            var nv = from d in qlch.NHANVIENs select d;
            List<NHANVIEN> list_nv = nv.ToList<NHANVIEN>();
            return list_nv;
        }


        public int TongSanPhamDaBan()
        {
            List<SANPHAM> slBan = qlch.SANPHAMs.ToList();
            int tong = slBan.Sum(t => t.SOLUONG) ?? 0;
            return tong;
        }

        public int TongDoanhThu()
        {
            var doanhThu = qlch.HOADONs.Where(hd => hd.TONGTIEN.HasValue).Select(hd => hd.TONGTIEN.Value);

            int tong = doanhThu.Sum();

            return tong;
        }


        public int TongSanPhamDaNhap()
        {
            var chiTietPhieuNhap = qlch.CTPHIEUNHAPHANGs.Where(ct => ct.SOLUONG.HasValue);

            int tong = chiTietPhieuNhap.Sum(ct => ct.SOLUONG.Value);

            return tong;
        }


        public int TongTienNhap()
        {
            List<PHIEUNHAPHANG> slBan = qlch.PHIEUNHAPHANGs.ToList();
            int tong = slBan.Sum(t => t.TONGTIEN) ?? 0;
            return tong;
        }
        public int TongMatHang()
        {
            List<CTHOADON> slBan = qlch.CTHOADONs.ToList();
            int tong = slBan.Sum(t => t.SOLUONG) ?? 0;
            return tong;
        }

        public int TongNhanVien()
        {
            List<NHANVIEN> slBan = qlch.NHANVIENs.ToList();
            int tong = slBan.Count();
            return tong;
        }

        public int TongLuongNhanVien()
        {
            List<NHANVIEN> slBan = qlch.NHANVIENs.ToList();
            int tong = slBan.Sum(t => t.LUONG) ?? 0;
            return tong;
        }




    }
}
