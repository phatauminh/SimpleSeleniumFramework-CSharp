using OpenQA.Selenium;
using SimpleSeleniumFramework.src.main.Framework.Selenium;

namespace SimpleSeleniumFramework.src.main.PageObjects
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
            PageNavigation.GoToFormsPage();
            return this;
        }

        public IWebElement GetHeader() => Map.FormsHeader;
    }

    public class FormsMap
    {
        public Element FormsHeader
                => Driver.FindElement(By.XPath("//div[@class='main-header' and text()='Forms']"));
    }
}
