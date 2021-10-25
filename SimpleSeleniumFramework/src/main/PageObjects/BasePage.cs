using OpenQA.Selenium;

namespace SimpleSeleniumFramework.src.main.PageObjects
{
    public abstract class BasePage
    {
        protected readonly PageNavigation PageNavigation;

        public BasePage()
        {
            PageNavigation = new PageNavigation();
        }
    }
}
