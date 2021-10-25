using OpenQA.Selenium;
using SimpleSeleniumFramework.src.main.Common;

namespace SimpleSeleniumFramework.src.main.PageObjects
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
        public IWebElement ElementsHeader
                => Driver.FindElement(By.XPath("//div[@class='main-header' and text()='Elements']"));
    }
}
