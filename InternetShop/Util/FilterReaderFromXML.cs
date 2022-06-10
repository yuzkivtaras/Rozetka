using System.IO;
using System.Xml.Serialization;

namespace InternetShop.Util
{
    public class FilterReadaderFromXml
    {
        public Filters ReadFilterFromXml()
        {
            Filters readFilterfromXml = new Filters();
            XmlSerializer xmlserializer = new XmlSerializer(readFilterfromXml.GetType());
            using (StreamReader streamReader = new StreamReader("d:/AQA/C#/.NetProjects AQA/InternetShop/InternetShop/resources/databrand.xml"))
            {
                return (Filters)xmlserializer.Deserialize(streamReader);
            }
        }
    }
}
