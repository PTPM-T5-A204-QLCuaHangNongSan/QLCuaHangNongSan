using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLL_DAL_NCC
    {
        QLCHDataContext qlch = new QLCHDataContext();
        public BLL_DAL_NCC()
        {

        }
        public List<NHACC> GetDataNhaCC()
        {
            var ncc = from d in qlch.NHACCs select d;
            List<NHACC> list_ncc = ncc.ToList<NHACC>();
            return list_ncc;
        }

        public bool ThemNhacc(NHACC DD)
        {
            try
            {
                //tao san pham
                NHACC sp = new NHACC();

                sp.MANCC = DD.MANCC;
                sp.TENNCC = DD.TENNCC;

                //add diem
                qlch.NHACCs.InsertOnSubmit(sp);
                qlch.SubmitChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            
        }

        public bool deleteNhacc(string DD)
        {
            try
            {
                NHACC lsp = qlch.NHACCs.Where(t => t.MANCC == DD).FirstOrDefault();
                qlch.NHACCs.DeleteOnSubmit(lsp);
                qlch.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }




        }
        public bool SuaNhaCc(NHACC DD)
        {
            try
            {
                NHACC sp = qlch.NHACCs.Where(t => t == DD).FirstOrDefault();
                if (sp != null)
                {

                    sp.TENNCC = DD.TENNCC;
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

        public string GetTenLoaiNhaCCByMaLoai(string mancc)
        {
            NHACC b = qlch.NHACCs.FirstOrDefault(l => l.MANCC == mancc);

            if (b != null)
            {
                return b.TENNCC;
            }
            else
            {
                return "Loại sản phẩm không tồn tại";
            }
        }
      
        public NHACC GetMaNhaCCByTen(string ten)
        {
            NHACC loaiSanPham = qlch.NHACCs.FirstOrDefault(l => l.TENNCC == ten);

            // Trả về đối tượng LOAISP nếu tìm thấy, ngược lại trả về null
            return loaiSanPham;
        }

    }
}
