using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Util
{

    public static class Filters
    {
        public static Filter CurrentFilter { get; set; }

        public static void SetFilter(Filter filter)
        {
            CurrentFilter = filter;
        }
    }
}
