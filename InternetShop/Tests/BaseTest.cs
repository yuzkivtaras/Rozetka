using NUnit.Framework;
using InternetShop.InitializationWebDriver;
using OpenQA.Selenium;
using InternetShop.Util;
using System;
using OpenQA.Selenium.Support.UI;


namespace InternetShop
{
    public class BaseTest
    {
        public IWebDriver Driver;
        public IWebDriver GetWebDriver()
        {
            WebDriverFactory driverFactory = new WebDriverFactory();
            FilterReader reader = new FilterReader();
            driverFactory.Lounch(reader.Config.BrowserType, reader.Config.StartingUrl);
            return driverFactory.WebDriver;
        }
    }
}
