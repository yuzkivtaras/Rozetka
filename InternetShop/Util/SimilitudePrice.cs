using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Util
{
    public static class SimilitudePrice
    {
        public static bool MyIsTrue(string first, string second)
        {
            string numericString = "";
            foreach (char c in second)
            {
                if ((c >= '0' && c <= '9') || c == ' ' || c == '-')
                {
                    numericString = String.Concat(numericString, c);
                }
                else
                    break;
            }
            if (Convert.ToInt32(first) < Convert.ToInt32(numericString))
            {
                return true;
            }
            else
                return false;
        }
    }
}
