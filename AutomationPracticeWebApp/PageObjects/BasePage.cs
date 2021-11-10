using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SimpleSeleniumFramework.Selenium;

namespace AutomationPracticeWebApp.PageObjects
{
    public abstract class BasePage
    {
        protected void WaitForUserIn(string page)
        {
            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(NavigationTo(page).FoundBy));
        }

        private Element NavigationTo(string page)
            => Driver.FindElement(By.XPath($"//span[@class = 'navigation_page' and normalize-space()='{page}'] "));
    }
}
