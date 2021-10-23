using OpenQA.Selenium;

namespace SimpleSeleniumFramework.src.main.PageObjects
{
    public abstract class PageBase
    {
        protected readonly PageNavigation PageNavigation;

        public PageBase(IWebDriver driver)
        {
            PageNavigation = new PageNavigation(driver);
        }
    }
}
