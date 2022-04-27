using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace InternetShop.PageObgject
{
    public class SearchPage
    {
        IWebDriver driver;
        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;   
        }

        IWebElement SearchField
        {
            get
            {
                return driver.FindElement(By.XPath("//input[@name='search']"));
            }
        }
        IWebElement CategoryName
        {
            get
            {
                return driver.FindElement(By.XPath("//a[@data-id = 'HP']"));
            }
        }
        IWebElement FilterSoted
        {
            get
            {
                return driver.FindElement(By.XPath("//div[@class = 'catalog-settings']//select"));
            }
        }
        IWebElement CategoryItem
        {
            get
            {
                return driver.FindElement(By.XPath("//option[contains(text(), 'От дорогих к дешевым')]"));
            }
        }
        IWebElement AddToCart
        {
            get
            {
                return driver.FindElement(By.XPath("//app-buy-button[@goods_id = '339200809']//button[@aria-label='Купить']"));
            }
        }

        public void EnterSearchText(string searchTerm)
        {
            SearchField.SendKeys(searchTerm);
            SearchField.SendKeys(Keys.Return);
        }

        public void ChooseCategory()
        {
            CategoryName.Click();
        }

        public void ChooseSorted()
        {
            FilterSoted.Click();
        }

        public void ChooseCategoryItem()
        {
            CategoryItem.Click();   
        }

        public void AddToCartItem()
        {
            AddToCart.Click();
        }
    }
}
