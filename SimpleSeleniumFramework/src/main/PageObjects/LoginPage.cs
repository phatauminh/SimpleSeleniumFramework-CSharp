using OpenQA.Selenium;

namespace SimpleSeleniumFramework.src.main.PageObjects
{
    public class LoginPage : BasePage
    {
        private readonly LoginMap Map;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            Map = new LoginMap(driver);
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
        private readonly IWebDriver _driver;

        public LoginMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement LoginHeader
                => _driver.FindElement(By.XPath("//div[@class='main-header' and text()='Login']"));

        public IWebElement UsernameTextbox
               => _driver.FindElement(By.Id("userName"));

        public IWebElement PasswordTextbox
                => _driver.FindElement(By.Id("password"));

        public IWebElement LoginButton
               => _driver.FindElement(By.Id("login"));
    }
}
