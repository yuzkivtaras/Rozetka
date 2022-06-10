using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using InternetShop.Util;


namespace InternetShop.PageObgject
{
    public class SearchPage
    {
        IWebDriver driver;

        private List<IWebElement> _elements = new List<IWebElement>();

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public readonly By _searchField = By.XPath("//input[@name='search']");
        public readonly By _searchFieldBrand = By.XPath("/html/body/app-root/div/div/rz-category/div/main/rz-catalog/div/div/aside/rz-filter-stack/div[2]/div/rz-filter-searchline/div[1]/input");
        public readonly By _nameBrand = By.XPath("//div[2]//li//a[@class='checkbox-filter__link']");
        public readonly By _filterSorted = By.XPath("//div[@class = 'catalog-settings']//select");
        public readonly By _categoryItem = By.XPath("//option[contains(text(), 'От дорогих к дешевым')]");
        public readonly By _elments = By.XPath("//button[@aria-label='Купить']");

        public void EnterSearchText(string searchTerm) => driver.FindElement(_searchField).SendKeys(searchTerm + Keys.Enter);
        public void SearchBrandField() => Expectation.WaitAndFindElement(driver, _searchFieldBrand).Click();
        public void EnterSearchBrand(string searchBrand) => driver.FindElement(_searchFieldBrand).SendKeys(searchBrand + Keys.Enter);
        public void ChooseBrandName() => Expectation.WaitAndFindElement(driver, _nameBrand).Click();
        public void ChooseSorted() => Expectation.WaitAndFindElement(driver, _filterSorted).Click();
        public void ChooseCategoryItem() => Expectation.WaitAndFindElement(driver, _categoryItem).Click();

        public List<IWebElement> AddElements() 
        {
            var elements = Expectation.WaitUntil(driver, _elments).FindElements(_elments).ToList();
            _elements = elements;
            return _elements;
        } 

        public IWebElement GetFirstElement()
        {
            return _elements.First();
        }

        public void AddToCartElement(IWebElement element)
        {
            element.Click();    
        }
    }
}
