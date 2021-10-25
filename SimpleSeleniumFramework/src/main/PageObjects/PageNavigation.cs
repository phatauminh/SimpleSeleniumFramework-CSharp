using OpenQA.Selenium;
using SimpleSeleniumFramework.src.main.Common;

namespace SimpleSeleniumFramework.src.main.PageObjects
{
    public class PageNavigation
    {
        private readonly PageNavigationMap Map;
        private readonly IJavaScriptExecutor js;

        public PageNavigation()
        {
            Map = new PageNavigationMap();
            js = (IJavaScriptExecutor)Driver.Current;
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

        public void GoToLoginPage() => Map.LoginCard.Click();

        public void GoToProfilePage() => Map.ProfileCard.Click();
    }

    public class PageNavigationMap
    {

        public IWebElement ElementsCard
                 => Driver.FindElement(By.XPath("//h5[text() = 'Elements']"));

        public IWebElement FormsCard
                 => Driver.FindElement(By.XPath("//h5[text() = 'Forms']"));

        public IWebElement WidgetsCard
                => Driver.FindElement(By.XPath("//h5[text() = 'Widgets']"));

        public IWebElement AlertsFrameWindowsCard
                => Driver.FindElement(By.XPath("//h5[text() = 'Alerts, Frame & Windows']"));

        public IWebElement InteractionsCard
                => Driver.FindElement(By.XPath("//h5[text() = 'Interactions']"));

        public IWebElement BookStoreCard
                => Driver.FindElement(By.XPath("//h5[text() = 'Book Store Application']"));

        public IWebElement LoginCard
               => Driver.FindElement(By.Id("login"));

        public IWebElement ProfileCard
               => Driver.FindElement(By.XPath("//span[@class='text' and text() = 'Profile']"));
    }
}
