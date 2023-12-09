using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace BLL_DAL
{
    public class Extract
    {
        public string ExtractLetters(string input)
        {
            StringBuilder letters = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    letters.Append(c);
                }
            }

            return letters.ToString();
        }

        public string ExtractNumbers(string input)
        {
            StringBuilder numbers = new StringBuilder();

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    numbers.Append(c);
                }
            }

            return numbers.ToString();
        }




    }
}
