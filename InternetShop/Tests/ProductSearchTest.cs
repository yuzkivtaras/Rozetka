using NUnit.Framework;
using InternetShop.PageObgject;
using InternetShop.PageObject;
using InternetShop.Util;
using OpenQA.Selenium;

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
            string nameProduct = filter.ProductName;
            string nameBrand = filter.BrandName;

            IWebDriver driver = GetWebDriver();

            SearchPage searchPage = new SearchPage(driver);
            searchPage.EnterSearchText(nameProduct);
            searchPage.SearchBrandField();
            searchPage.EnterSearchBrand(nameBrand);
            searchPage.ChooseBrandName();
            searchPage.ChooseCategoryItem();
            searchPage.AddElements();
            searchPage.AddToCartElement(searchPage.GetFirstElement());
            System.Threading.Thread.Sleep(2000);


            CartPage cartPage = new CartPage(driver);
            cartPage.cart();    

            string priviosPrice = cartPage.SumProductsInCart();
            string currentPrice = filter.OrderSum;

            Assert.IsTrue(SimilitudePrice.PriceTrue(priviosPrice, currentPrice), "don't incorect sum product in cart");

            driver.Quit();

        }
    }


}
