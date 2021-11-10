using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SimpleSeleniumFramework.Selenium;

namespace AutomationPracticeWebApp.PageObjects
{
    public class HomePage : BasePage
    {
        private readonly HomeMap Map;

        public HomePage()
        {
            Map = new HomeMap();
        }

        public SignInPage GoToSignInPage()
        {
            Driver.Wait.Until(ExpectedConditions.ElementToBeClickable(Map.SignInButton.FoundBy)).Click();
            return new SignInPage();
        }
    }

    public class HomeMap
    {
        public Element SignInButton
               => Driver.FindElement(By.ClassName("login"));
    }
}
