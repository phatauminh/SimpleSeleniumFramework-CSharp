using OpenQA.Selenium;

namespace SimpleSeleniumFramework.src.main.PageObjects
{
    public class PageNavigation
    {
        public readonly PageNavigationMap Map;
        public readonly IJavaScriptExecutor js;

        public PageNavigation(IWebDriver driver)
        {
            Map = new PageNavigationMap(driver);
            js = (IJavaScriptExecutor)driver;
        }

        public void GoToBookStorePage()
        {
            js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
            Map.BookStoreCard.Click();
        }

        public void GoToElementsPage() => Map.ElementsCard.Click();

        public void GoToFormsPage() => Map.FormsCard.Click();

        public void GoToWidgetsPage() => Map.WidgetsCard.Click();

        public void GoToAlertsFrameWindowsPage() => Map.AlertsFrameWindowsCard.Click();

        public void GoToInteractionsPage() => Map.InteractionsCard.Click();
    }

    public class PageNavigationMap
    {
        public readonly IWebDriver _driver;

        public PageNavigationMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement ElementsCard
                 => _driver.FindElement(By.XPath("//h5[text() = 'Elements']"));

        public IWebElement FormsCard
                 => _driver.FindElement(By.XPath("//h5[text() = 'Forms']"));

        public IWebElement WidgetsCard
                => _driver.FindElement(By.XPath("//h5[text() = 'Widgets']"));

        public IWebElement AlertsFrameWindowsCard
                => _driver.FindElement(By.XPath("//h5[text() = 'Alerts, Frame & Windows']"));

        public IWebElement InteractionsCard
         => _driver.FindElement(By.XPath("//h5[text() = 'Interactions']"));

        public IWebElement BookStoreCard
                => _driver.FindElement(By.XPath("//h5[text() = 'Book Store Application']"));


    }
}
