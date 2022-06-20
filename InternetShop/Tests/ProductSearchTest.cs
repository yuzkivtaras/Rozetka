using NUnit.Framework;
using InternetShop.PageObgject;
using InternetShop.PageObject;
using InternetShop.Util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using System;

[assembly: LevelOfParallelism(3)]
namespace InternetShop.Tests
{
    [TestFixture]
    [Parallelizable(scope: ParallelScope.All)]
    public class ProductSearchTest : BaseTest
    {
        [TestCaseSource(typeof(GetDataBrandFromXml), "GetData")]
        public void ProductSearch(Filter filter)
        {
            log.Info("Test started with parametrs");
            log.Info($"item = {filter.ProductName}, brand = {filter.BrandName}, price = {filter.OrderSum}");

            string nameProduct = filter.ProductName;
            string nameBrand = filter.BrandName;

            IWebDriver driver = GetWebDriver();

            EventFiringWebDriver eventDriver = new EventFiringWebDriver(driver);
            eventDriver.ElementClicked += OnDriverElementClicked;
            driver = eventDriver;
          
            SearchPage searchPage = new SearchPage(driver);
            searchPage.EnterSearchText(nameProduct);
            searchPage.SearchBrandField();
            searchPage.EnterSearchBrand(nameBrand);
            System.Threading.Thread.Sleep(2000);
            searchPage.ChooseBrandName();
            searchPage.ChooseCategoryItem();
            System.Threading.Thread.Sleep(2000);
            searchPage.AddElements();
            searchPage.AddToCartElement(searchPage.GetFirstElement());
            System.Threading.Thread.Sleep(2000);


            CartPage cartPage = new CartPage(driver);
            cartPage.cart();    

            string priviosPrice = cartPage.SumProductsInCart();
            string currentPrice = filter.OrderSum;

            Assert.IsTrue(SimilitudePrice.PriceTrue(priviosPrice, currentPrice));

            driver.Quit();

        }

        private void OnDriverElementClicked(object? sender, WebElementEventArgs e)
        {
            log.Info(e.Element.ToString());
        }
    }


}
