using OpenQA.Selenium;
using SimpleSeleniumFramework.src.main.Framework.Selenium;

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
            ScrollToBottom();
            Map.BookStoreCard.Click();
        }

        public void GoToElementsPage()
        {
            ScrollToBottom();
            Map.ElementsCard.Click();
        }

        public void GoToFormsPage()
        {
            ScrollToBottom();
            Map.FormsCard.Click();
        }

        public void GoToWidgetsPage()
        {
            ScrollToBottom();
            Map.WidgetsCard.Click();
        }

        public void GoToAlertsFrameWindowsPage()
        {
            ScrollToBottom();
            Map.AlertsFrameWindowsCard.Click();
        }

        public void GoToInteractionsPage()
        {
            ScrollToBottom();
            Map.InteractionsCard.Click();
        }

        public void GoToLoginPage()
        {
            ScrollToBottom();
            Map.LoginCard.Click();
        }

        public void GoToProfilePage()
        {
            ScrollToBottom();
            Map.ProfileCard.Click();
        }

        private void ScrollToBottom()
        {
            js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
        }
    }

    public class PageNavigationMap
    {

        public Element ElementsCard
                 => Driver.FindElement(By.XPath("//h5[text() = 'Elements']"));

        public Element FormsCard
                 => Driver.FindElement(By.XPath("//h5[text() = 'Forms']"));

        public Element WidgetsCard
                => Driver.FindElement(By.XPath("//h5[text() = 'Widgets']"));

        public Element AlertsFrameWindowsCard
                => Driver.FindElement(By.XPath("//h5[text() = 'Alerts, Frame & Windows']"));

        public Element InteractionsCard
                => Driver.FindElement(By.XPath("//h5[text() = 'Interactions']"));

        public Element BookStoreCard
                => Driver.FindElement(By.XPath("//h5[text() = 'Book Store Application']"));

        public Element LoginCard
               => Driver.FindElement(By.Id("login"));

        public Element ProfileCard
               => Driver.FindElement(By.XPath("//span[@class='text' and text() = 'Profile']"));
    }
}
