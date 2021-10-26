using OpenQA.Selenium;
using SimpleSeleniumFramework.src.main.Framework.Selenium;

namespace SimpleSeleniumFramework.src.main.PageObjects
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
            PageNavigation.GoToInteractionsPage();
            return this;
        }

        public IWebElement GetHeader() => Map.AlertsFrameWindowsHeader;
    }

    public class InteractionsMap
    {

        public Element AlertsFrameWindowsHeader
                => Driver.FindElement(By.XPath("//div[@class='main-header' and text()='Interactions']"));
    }
}
