using OpenQA.Selenium;

namespace SimpleSeleniumFramework.src.main.PageObjects
{
    public class WidgetsPage : PageBase
    {
        public readonly WidgetsMap Map;

        public WidgetsPage(IWebDriver driver) : base(driver)
        {
            Map = new WidgetsMap(driver);
        }

        public WidgetsPage GoTo()
        {
            PageNavigation.GoToWidgetsPage();
            return this;
        }

        public IWebElement GetHeader() => Map.WidgetsHeader;
    }

    public class WidgetsMap
    {
        private readonly IWebDriver _driver;

        public WidgetsMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement WidgetsHeader
                => _driver.FindElement(By.XPath("//div[@class='main-header' and text()='Widgets']"));
    }
}
