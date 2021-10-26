using OpenQA.Selenium;
using SimpleSeleniumFramework.src.main.Framework.Selenium;

namespace SimpleSeleniumFramework.src.main.PageObjects
{
    public class AlertsFrameWindowsPage : BasePage
    {
        private readonly AlertsFrameWindowsMap Map;

        public AlertsFrameWindowsPage()
        {
            Map = new AlertsFrameWindowsMap();
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
        public Element AlertsFrameWindowsHeader
                => Driver.FindElement(By.XPath("//div[@class='main-header' and text()='Alerts, Frame & Windows']"));
    }
}
