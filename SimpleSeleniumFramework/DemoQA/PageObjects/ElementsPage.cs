using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SimpleSeleniumFramework.DemoQA.Common.Constants;
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
            PageNavigation.GoToPageBy(Card.ELEMENTS);
            return this;
        }

        public IWebElement GetHeader()
        {
            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.ElementsHeader.FoundBy));
            return Map.ElementsHeader; 
        }
        
    }

    public class ElementsMap
    {
        public Element ElementsHeader
                => Driver.FindElement(By.XPath("//div[@class='main-header' and text()='Elements']"));
    }
}
