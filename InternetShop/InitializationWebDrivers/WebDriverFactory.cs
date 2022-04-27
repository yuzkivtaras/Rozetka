using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace InternetShop.InitializationWebDriver;

public class WebDriverFactory
{
    public IWebDriver WebDriver;  
    public virtual IWebDriver Lounch(string browserType, string startingUrl)
    {
        
        var driver = CreateWebDriver(browserType);
        WebDriver = driver;
        driver.Navigate().GoToUrl(startingUrl);
        driver.Manage().Window.Maximize();
        return driver;
    }
    private IWebDriver CreateWebDriver(string browserType)
    {
        switch (browserType)
        {
            case "Chrome":
                return new ChromeDriver();
            default:
                throw new NotSupportedException($"{browserType}) is not supported local  browse type.");
        }
    }

}
