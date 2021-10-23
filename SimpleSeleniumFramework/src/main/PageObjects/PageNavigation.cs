using OpenQA.Selenium;

namespace SimpleSeleniumFramework.src.main.PageObjects
{
    public class PageNavigation
    {
        public readonly PageNavigationMap Map;

        public PageNavigation(IWebDriver driver)
        {
            Map = new PageNavigationMap(driver);
        }

        public void GoToBookStorePage() => Map.BookStoreCard.Click();
    }

    public class PageNavigationMap
    {
        private readonly IWebDriver _driver;

        public PageNavigationMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement BookStoreCard
                => _driver.FindElement(By.XPath("//h5[text() = 'Book Store Application']"));
         
    }
}
