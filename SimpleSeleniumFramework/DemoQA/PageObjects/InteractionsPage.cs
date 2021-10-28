using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SimpleSeleniumFramework.DemoQA.Common.Constants;
using SimpleSeleniumFramework.DemoQA.Framework.Selenium;

namespace SimpleSeleniumFramework.DemoQA.PageObjects
{
    public class InteractionsPage : BasePage
    {
        private readonly InteractionsMap Map;

        public InteractionsPage()
        {
            Map = new InteractionsMap();
        }

        public InteractionsPage GoTo()
        {
            PageNavigation.GoToPageBy(Card.INTERACTIONS);
            return this;
        }

        public IWebElement GetHeader()
        {
            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.InteractionsHeader.FoundBy));
            return Map.InteractionsHeader;
        }
    }

    public class InteractionsMap
    {

        public Element InteractionsHeader
                => Driver.FindElement(By.XPath("//div[@class='main-header' and text()='Interactions']"));
    }
}
