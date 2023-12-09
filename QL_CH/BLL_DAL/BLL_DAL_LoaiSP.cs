using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_DAL_LoaiSP
    {
        QLCHDataContext qlch = new QLCHDataContext();
        public BLL_DAL_LoaiSP()
        {

        }
        public string TenLoai { get; set; }
        public BLL_DAL_LoaiSP(string tenLoai)
        {
            this.TenLoai = tenLoai;
        }
        public List<LOAISP> GetDataLoaisp()
        {
            var lsanphams = from d in qlch.LOAISPs select d;
            List<LOAISP> list_lsanpham = lsanphams.ToList<LOAISP>();
            return list_lsanpham;
        }

        public bool ThemLoaisp(LOAISP DD)
        {
            try
            {
                //tao san pham
                LOAISP sp = new LOAISP();

                sp.MALOAI = DD.MALOAI;
                sp.TENLOAI = DD.TENLOAI;
            
                //add diem
                qlch.LOAISPs.InsertOnSubmit(sp);
                qlch.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
           
        }

        public bool deleteLoaiSp(string DD)
        {
            try
            {
                LOAISP lsp = qlch.LOAISPs.Where(t => t.MALOAI == DD).FirstOrDefault();
                qlch.LOAISPs.DeleteOnSubmit(lsp);
                qlch.SubmitChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }




        }
        public bool SuaLoaiSanPham(LOAISP DD)
        {
            try
            {
                LOAISP sp = qlch.LOAISPs.Where(t => t == DD).FirstOrDefault();
                if (sp != null)
                {

                    sp.TENLOAI = DD.TENLOAI;
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

        public string GetTenLoaiSanPhamByMaLoai(string maLoai)
        {
            LOAISP loaiSanPham = qlch.LOAISPs.FirstOrDefault(l => l.MALOAI == maLoai);

            if (loaiSanPham != null)
            {
                return loaiSanPham.TENLOAI;
            }
            else
            {
                return "Loại sản phẩm không tồn tại";
            }
        }

        public LOAISP GetMaLoaiSanPhamByTenLoai(string ten)
        {
            LOAISP loaiSanPham = qlch.LOAISPs.FirstOrDefault(l => l.TENLOAI == ten);

           
            return loaiSanPham;
        }









    }
}
