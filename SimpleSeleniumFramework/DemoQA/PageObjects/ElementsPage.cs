using OpenQA.Selenium;
using SimpleSeleniumFramework.DemoQA.Framework.Selenium;

namespace SimpleSeleniumFramework.DemoQA.PageObjects
{
    public class ElementsPage : BasePage
    {
        private readonly ElementsMap Map;

        public ElementsPage()
        {
            Map = new ElementsMap();
        }

        public ElementsPage GoTo()
        {
            PageNavigation.GoToElementsPage();
            return this;
        }

        public IWebElement GetHeader() => Map.ElementsHeader;
    }

    public class ElementsMap
    {
        public Element ElementsHeader
                => Driver.FindElement(By.XPath("//div[@class='main-header' and text()='Elements']"));
    }
}
