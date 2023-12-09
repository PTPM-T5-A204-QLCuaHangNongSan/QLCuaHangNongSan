using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class ItemNoronNextDay
    {
        private DateTime date;
        private string _tensp;
        private double? _soluongBan;
        private string convertsoluongBan;


        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }



        public double? soluongBan
        {
            get
            {
                return _soluongBan;
            }

            set
            {
                _soluongBan = value;
            }
        }

      
        public string ConvertsoluongBan
        {
            get
            {
                return convertsoluongBan;
            }

            set
            {
                convertsoluongBan = value;
            }
        }

        public string tensp
        {
            get
            {
                return _tensp;
            }

            set
            {
                _tensp = value;
            }
        }
    }
}
