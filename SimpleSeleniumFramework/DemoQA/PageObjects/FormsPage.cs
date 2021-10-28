using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SimpleSeleniumFramework.DemoQA.Common.Constants;
using SimpleSeleniumFramework.DemoQA.Framework.Selenium;

namespace SimpleSeleniumFramework.DemoQA.PageObjects
{
    public class FormsPage : BasePage
    {
        private readonly FormsMap Map;

        public FormsPage()
        {
            Map = new FormsMap();
        }

        public FormsPage GoTo()
        {
            PageNavigation.GoToPageBy(Card.FORMS);
            return this;
        }

        public IWebElement GetHeader()
        {
            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.FormsHeader.FoundBy));
            return Map.FormsHeader;
        }
    }

    public class FormsMap
    {
        public Element FormsHeader
                => Driver.FindElement(By.XPath("//div[@class='main-header' and text()='Forms']"));
    }
}
