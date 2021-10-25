using OpenQA.Selenium;
using SimpleSeleniumFramework.src.main.Common;

namespace SimpleSeleniumFramework.src.main.PageObjects
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
            PageNavigation.GoToWidgetsPage();
            return this;
        }

        public IWebElement GetHeader() => Map.WidgetsHeader;
    }

    public class WidgetsMap
    {
        public IWebElement WidgetsHeader
                => Driver.FindElement(By.XPath("//div[@class='main-header' and text()='Widgets']"));
    }
}
