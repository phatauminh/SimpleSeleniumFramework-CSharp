using OpenQA.Selenium;
using SimpleSeleniumFramework.src.main.Framework.Selenium;

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
        public Element WidgetsHeader
                => Driver.FindElement(By.XPath("//div[@class='main-header' and text()='Widgets']"));
    }
}
