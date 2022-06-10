using InternetShop.Util;
using OpenQA.Selenium;


namespace InternetShop.PageObject
{
    public class CartPage
    {
        IWebDriver driver;       
        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private readonly By _cartButton = By.XPath("//rz-cart[@class='header-actions__component']//button[@type ='button']");
        private readonly By _sumProductsInCart = By.XPath("//div[@class='cart-receipt__sum-price']//span[1]");

        public void cart() => Expectation.WaitAndFindElement(driver, _cartButton).Click();
        public string SumProductsInCart()
        {
            var element = Expectation.WaitAndFindElement(driver, _sumProductsInCart);
            return element.Text;
        }
    }
}
