using Microsoft.Extensions.Configuration;

namespace InternetShop
{
    public class FilterReader
    {
        public FilterSettingWebDriver Config;
        static string path = "d:/AQA/C#/.NetProjects AQA/InternetShop/InternetShop/resources/dataconfigsetting.json";
        public FilterReader()
        {
            Config = new FilterSettingWebDriver();
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(path);
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(Config);          
        }      
    }
   
}
