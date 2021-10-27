using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SimpleSeleniumFramework.DemoQA.Framework.Selenium;

namespace SimpleSeleniumFramework.DemoQA.PageObjects
{
    public class LoginPage : BasePage
    {
        private readonly LoginMap Map;

        public LoginPage()
        {
            Map = new LoginMap();
        }

        public LoginPage GoTo()
        {
            PageNavigation.GoToLoginPage();
            return this;
        }

        public void UserLogin(string username, string password)
        {
            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.LoginHeader.FoundBy));

            Map.UsernameTextbox.Clear();
            Map.UsernameTextbox.SendKeys(username);

            Map.PasswordTextbox.Clear();
            Map.PasswordTextbox.SendKeys(password);

            Map.LoginButton.Click();
        }


        public IWebElement GetHeader() => Map.LoginHeader;
    }

    public class LoginMap
    {

        public Element LoginHeader
                => Driver.FindElement(By.XPath("//div[@class='main-header' and text()='Login']"));

        public Element UsernameTextbox
               => Driver.FindElement(By.Id("userName"));

        public Element PasswordTextbox
                => Driver.FindElement(By.Id("password"));

        public Element LoginButton
               => Driver.FindElement(By.Id("login"));
    }
}
