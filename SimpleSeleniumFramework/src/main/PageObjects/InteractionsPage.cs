using OpenQA.Selenium;

namespace SimpleSeleniumFramework.src.main.PageObjects
{
    public class InteractionsPage : PageBase
    {
        public readonly InteractionsMap Map;

        public InteractionsPage(IWebDriver driver) : base(driver)
        {
            Map = new InteractionsMap(driver);
        }

        public InteractionsPage GoTo()
        {
            PageNavigation.GoToInteractionsPage();
            return this;
        }

        public IWebElement GetHeader() => Map.AlertsFrameWindowsHeader;
    }

    public class InteractionsMap
    {
        private readonly IWebDriver _driver;

        public InteractionsMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement AlertsFrameWindowsHeader
                => _driver.FindElement(By.XPath("//div[@class='main-header' and text()='Interactions']"));
    }
}
