using OpenQA.Selenium;
using SimpleSeleniumFramework.src.main.Common;

namespace SimpleSeleniumFramework.src.main.PageObjects
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
            Map.UsernameTextbox.SendKeys(username);
            Map.PasswordTextbox.SendKeys(password);

            Map.LoginButton.Click();
        }


        public IWebElement GetHeader() => Map.LoginHeader;
    }

    public class LoginMap
    {

        public IWebElement LoginHeader
                => Driver.FindElement(By.XPath("//div[@class='main-header' and text()='Login']"));

        public IWebElement UsernameTextbox
               => Driver.FindElement(By.Id("userName"));

        public IWebElement PasswordTextbox
                => Driver.FindElement(By.Id("password"));

        public IWebElement LoginButton
               => Driver.FindElement(By.Id("login"));
    }
}
