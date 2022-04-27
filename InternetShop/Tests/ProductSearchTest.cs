using NUnit.Framework;
using InternetShop.PageObgject;
using InternetShop.PageObject;
using InternetShop.Util;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace InternetShop.Tests
{
    public class ProductSearchTest : BaseTest
    {

        [Test]        
        public void ProductSearch()
        {
            SearchPage searchPage = new SearchPage(Driver);
            searchPage.EnterSearchText("Ноутбук");
            searchPage.ChooseCategory();
            searchPage.ChooseCategoryItem();
            searchPage.AddToCartItem();

            CartPage cartPage = new CartPage(Driver);
            cartPage.Cart();
            System.Threading.Thread.Sleep(2000);

            string priviosPrice = cartPage.sumProductsInCart();
            string currentPrice = GetCurrentFilter().OrderSum;
     
            Assert.IsTrue(SimilitudePrice.MyIsTrue(priviosPrice, currentPrice), "don't incorect sum product in cart");         
        }
        
    }
}
