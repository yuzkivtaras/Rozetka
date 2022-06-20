using InternetShop.InitializationWebDriver;
using OpenQA.Selenium;
using log4net;
using log4net.Config;
using log4net.Repository;
using InternetShop.Tests;
using OpenQA.Selenium.Support.Events;
using System.Reflection;
using System.IO;
using System;

[assembly: XmlConfigurator(Watch =true)]

namespace InternetShop
{
    public class BaseTest
    {
        public IWebDriver Driver;
        protected static readonly ILog log = LogManager.GetLogger(typeof(ProductSearchTest));
        private static readonly ILoggerRepository repository = LogManager.GetLoggerRepository(Assembly.GetCallingAssembly());

        private EventFiringWebDriver eventFiringWebDriver;
        public EventFiringWebDriver EventFiringWebDriver { get { return eventFiringWebDriver; } }
        public IWebDriver _driver { get { return Driver; } }

        public IWebDriver GetWebDriver()
        {
            var fileInfo = new FileInfo("D:/AQA/C#/.NetProjects AQA/InternetShop/InternetShop/Tests/log4net.config");
            XmlConfigurator.Configure(repository, fileInfo);
            BasicConfigurator.Configure();
            log.Info("OnetimeSetup Configured");

            WebDriverFactory driverFactory = new WebDriverFactory();
            FilterReader reader = new FilterReader();
            driverFactory.Lounch(reader.Config.BrowserType, reader.Config.StartingUrl);

    
            return driverFactory.WebDriver;
        }
    }
}
