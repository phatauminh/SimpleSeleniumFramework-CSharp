using OpenQA.Selenium;

namespace SimpleSeleniumFramework.src.main.PageObjects
{
    public class FormsPage : PageBase
    {
        public readonly FormsMap Map;

        public FormsPage(IWebDriver driver) : base(driver)
        {
            Map = new FormsMap(driver);
        }

        public FormsPage GoTo()
        {
            PageNavigation.GoToFormsPage();
            return this;
        }

        public IWebElement GetHeader() => Map.FormsHeader;
    }

    public class FormsMap
    {
        private readonly IWebDriver _driver;

        public FormsMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement FormsHeader
                => _driver.FindElement(By.XPath("//div[@class='main-header' and text()='Forms']"));
    }
}
