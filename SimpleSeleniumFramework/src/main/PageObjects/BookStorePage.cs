using OpenQA.Selenium;

namespace SimpleSeleniumFramework.src.main.PageObjects
{
    public class BookStorePage : PageBase
    {
        public readonly BookStoreMap Map;

        public BookStorePage(IWebDriver driver) : base(driver)
        {
            Map = new BookStoreMap(driver);
        }

        public BookStorePage GoTo()
        {
            PageNavigation.GoToBookStorePage();
            return this;
        }

        public IWebElement GetBookStoreHeader() => Map.BookStoreHeader;
    }

    public class BookStoreMap
    {
        private readonly IWebDriver _driver;

        public BookStoreMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement BookStoreHeader
                => _driver.FindElement(By.XPath("//div[@class = 'main-header' and text() = 'Book Store']"));
    }
}
