namespace SimpleSeleniumFramework.DemoQA.PageObjects
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
