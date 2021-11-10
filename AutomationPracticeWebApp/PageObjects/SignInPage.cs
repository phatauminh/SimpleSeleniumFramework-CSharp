using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SimpleSeleniumFramework.Selenium;

namespace AutomationPracticeWebApp.PageObjects
{
    public class SignInPage : BasePage
    {
        private readonly SignInMap Map;

        public SignInPage()
        {
            Map = new SignInMap();
        }

        public CreateAccountPage EnterValidEmailAddress(string email)
        {
            WaitForUserInAuthenticationPage();
            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.CreateAccountTextField.FoundBy));
            Map.CreateAccountTextField.SendKeys(email);
            Driver.Wait.Until(ExpectedConditions.ElementToBeClickable(Map.CreateAccountButton.FoundBy)).Click();

            return new CreateAccountPage();
        }
        private void WaitForUserInAuthenticationPage()
        {
            WaitForUserIn("Authentication");
        }
    }

    public class SignInMap
    {
        public Element CreateAccountTextField
            => Driver.FindElement(By.Id("email_create"));

        public Element CreateAccountButton
            => Driver.FindElement(By.Id("SubmitCreate"));
    }
}
