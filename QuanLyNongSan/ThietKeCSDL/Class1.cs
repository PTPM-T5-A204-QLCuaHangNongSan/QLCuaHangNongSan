using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ThietKeCSDL
{
    public class Class1
    {
        DataSet ds;
        string connec = "Data Source = HUYENTRAN; Initial Catalog = QLNONGSAN; Integrated Security = true";
        public void createConnection()
        {
            using (SqlConnection connection = new SqlConnection(connec))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi kết nối !!!");
                }
            }
        }
        public bool testConnection()
        {
            using (SqlConnection connection = new SqlConnection(connec))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi kết nối !!!");
                    return false;
                }
            }
        }
        public DataTable ExcuteQuery()
        {
            ds = new DataSet();
            //string sql = "select * from SANPHAM where MASP='" + query + "'";
            string sql = "select * from SANPHAM";
            SqlDataAdapter da = new SqlDataAdapter(sql, connec);
            da.Fill(ds, "SANPHAM");

            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["SANPHAM"].Columns[0];
            ds.Tables["SANPHAM"].PrimaryKey = key;
            return ds.Tables["SANPHAM"];
        }
    }
}
