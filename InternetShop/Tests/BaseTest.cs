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

        [SetUp]
        public void Setup()
        {
            WebDriverFactory driverFactory = new WebDriverFactory();
            FilterReader reader = new FilterReader();
            driverFactory.Lounch(reader.Config.BrowserType, reader.Config.StartingUrl);
            Driver = driverFactory.WebDriver;
            
        } 
    
        public Filter GetCurrentFilter()
        {
            FilterReaderJson filterReaderJson = new FilterReaderJson();
            Filter filter = filterReaderJson.ReadFilterJson();
            Filters.SetFilter(filter);
            return Filters.CurrentFilter;
        }
    }
}
