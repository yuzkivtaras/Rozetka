using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace InternetShop.PageObject
{
    public class CartPage
    {
        IWebDriver driver;
        private readonly By _sumProductsInCart = By.XPath("//div[@class ='cart-receipt__sum-price']//span[contains(@class,'')]");
        public string sumProductsInCart() => driver.FindElement(_sumProductsInCart).Text;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement CartButton
        {
            get
            {
                return driver.FindElement(By.XPath("//rz-cart[@class='header-actions__component']//button[@type ='button']"));
            }
        }

        public void Cart()
        {
            CartButton.Click(); 
        }


    }
}
