using OpenQA.Selenium;
using SimpleSeleniumFramework.src.main.Common;

namespace SimpleSeleniumFramework.src.main.PageObjects
{
    public class InteractionsPage : BasePage
    {
        private readonly InteractionsMap Map;

        public InteractionsPage(IWebDriver driver)
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

        public IWebElement AlertsFrameWindowsHeader
                => Driver.FindElement(By.XPath("//div[@class='main-header' and text()='Interactions']"));
    }
}
