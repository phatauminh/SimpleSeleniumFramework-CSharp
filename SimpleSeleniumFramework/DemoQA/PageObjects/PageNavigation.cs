using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SimpleSeleniumFramework.DemoQA.Framework.Selenium;

namespace SimpleSeleniumFramework.DemoQA.PageObjects
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

        public void GoToPageBy(string cardName)
        {
            ScrollToBottom();
            Map.NavigateBy(cardName).Click();
        }

        public void GoToBookDetailBy(string title)
        {
            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.GoToBookDetail(title).FoundBy)).Click();
        }

        public void GoToLoginPage()
        {
            ScrollToBottom();
            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.LoginCard.FoundBy)).Click();
        }

        public void GoToProfilePage()
        {
            ScrollToBottom();
            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.ProfileCard.FoundBy)).Click();
        }

        private void ScrollToBottom()
        {
            js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
        }
    }

    public class PageNavigationMap
    {

        public Element NavigateBy(string cardName)
               => Driver.FindElement(By.XPath($"//h5[text() = '{cardName}']"));

        public Element LoginCard
               => Driver.FindElement(By.Id("login"));

        public Element ProfileCard
               => Driver.FindElement(By.XPath("//span[@class='text' and text() = 'Profile']"));

        public Elements GoToBookDetail(string title)
               => Driver.FindElements(By.XPath($"//span[contains(@id, 'see-book-{title}')]"));
    }
}
