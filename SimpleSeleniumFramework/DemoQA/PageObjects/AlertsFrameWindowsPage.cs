using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SimpleSeleniumFramework.DemoQA.Common.Constants;
using SimpleSeleniumFramework.DemoQA.Framework.Selenium;

namespace SimpleSeleniumFramework.DemoQA.PageObjects
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
            PageNavigation.GoToPageBy(Card.ALERTS_FRAME_WINDOWS);
            return this;
        }

        public IWebElement GetHeader()
        {
            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.AlertsFrameWindowsHeader.FoundBy));
            return Map.AlertsFrameWindowsHeader;
        } 
    }

    public class AlertsFrameWindowsMap
    {
        public Element AlertsFrameWindowsHeader
                => Driver.FindElement(By.XPath("//div[@class='main-header' and text()='Alerts, Frame & Windows']"));
    }
}
