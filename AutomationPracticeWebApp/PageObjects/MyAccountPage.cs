using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SimpleSeleniumFramework.Selenium;

namespace AutomationPracticeWebApp.PageObjects
{
    public class MyAccountPage : BasePage
    {
        private readonly MyAccountMap Map;
        public MyAccountPage()
        {
            Map = new MyAccountMap();
        }

        public string GetUserInfo()
        {
            WaitForUserInMyAccountPage();
            var user = Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.HeaderUserInfo.FoundBy)).Text;

            return user;
        }

        private void WaitForUserInMyAccountPage()
        {
            WaitForUserIn("My account");
        }
    }

    public class MyAccountMap
    {
        public Element HeaderUserInfo 
                => Driver.FindElement(By.XPath("//a[@class = 'account']/span"));
    }
}
