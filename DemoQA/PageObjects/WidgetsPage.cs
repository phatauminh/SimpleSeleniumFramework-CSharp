using DemoQAWebApp.Common.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SimpleSeleniumFramework.Selenium;

namespace DemoQAWebApp.PageObjects
{
    public class WidgetsPage : BasePage
    {
        private readonly WidgetsMap Map;

        public WidgetsPage()
        {
            Map = new WidgetsMap();
        }

        public WidgetsPage GoTo()
        {
            PageNavigation.GoToPageBy(Card.WIDGETS);
            return this;
        }

        public IWebElement GetHeader()
        {
            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.WidgetsHeader.FoundBy));
            return Map.WidgetsHeader;
        }
    }

    public class WidgetsMap
    {
        public Element WidgetsHeader
                => Driver.FindElement(By.XPath("//div[@class='main-header' and text()='Widgets']"));
    }
}
