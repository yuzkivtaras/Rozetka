using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace InternetShop.Util
{
    public static class Expectation
    {
        public static IWebElement WaitUntil(IWebDriver webDriver, By webElement)
        {
            try
            {
                return new WebDriverWait(webDriver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementIsVisible(webElement));
            }
            catch (Exception ex)
            {
                throw new Exception($"Cannot find lacator {webElement}", ex);
            }
        }

        public static IWebElement WaitAndFindElement(IWebDriver webDriver, By webElement)
        {
            webDriver.TimerLoop(() => webDriver.FindElement(webElement).Displayed, false, "");
            IWebElement element = webDriver.FindElement(webElement);
            return element;
        }

        public static void WaitForElementToAppear(this ISearchContext driver, By locator)
        {
            driver.TimerLoop(() => driver.FindElement(locator).Displayed, false, "Timeout: Element not visible at: " + locator);
        }

        public static void TimerLoop(this ISearchContext driver, Func<bool> isComplete, bool exceptionCompleteResult, string timeoutMsg)
        {

            const int timeoutinteger = 10;

            for (int second = 0; ; second++)
            {
                try
                {
                    if (isComplete())
                        return;
                    if (second >= timeoutinteger)
                        throw new TimeoutException(timeoutMsg);
                }
                catch (Exception ex)
                {
                    if (exceptionCompleteResult)
                        return;
                    if (second >= timeoutinteger)
                        throw new TimeoutException(timeoutMsg, ex);
                }
                System.Threading.Thread.Sleep(3000);
            }
        }
    }
}
