using OpenQA.Selenium;

namespace SimpleSeleniumFramework.src.main.PageObjects
{
    public abstract class BasePage
    {
        protected readonly PageNavigation PageNavigation;

        public BasePage(IWebDriver driver)
        {
            PageNavigation = new PageNavigation(driver);
        }
    }
}
