using OpenQA.Selenium;

namespace SimpleSeleniumFramework.src.main.PageObjects
{
    public class AlertsFrameWindowsPage : BasePage
    {
        private readonly AlertsFrameWindowsMap Map;

        public AlertsFrameWindowsPage(IWebDriver driver) : base(driver)
        {
            Map = new AlertsFrameWindowsMap(driver);
        }

        public AlertsFrameWindowsPage GoTo()
        {
            PageNavigation.GoToAlertsFrameWindowsPage();
            return this;
        }

        public IWebElement GetHeader() => Map.AlertsFrameWindowsHeader;
    }

    public class AlertsFrameWindowsMap
    {
        private readonly IWebDriver _driver;

        public AlertsFrameWindowsMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement AlertsFrameWindowsHeader
                => _driver.FindElement(By.XPath("//div[@class='main-header' and text()='Alerts, Frame & Windows']"));
    }
}
