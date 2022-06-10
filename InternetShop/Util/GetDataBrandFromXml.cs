using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Util
{
    public static class GetDataBrandFromXml
    {
        public static IEnumerable<Filter> GetData()
        {
            FilterReadaderFromXml filterReaderFromXML = new FilterReadaderFromXml();
            Filters filters = filterReaderFromXML.ReadFilterFromXml();

            for (int i = 0; i < filters.FiltersList.Length; i++)
            {
                yield return filters.FiltersList[i];
            }
        }
    }
}
