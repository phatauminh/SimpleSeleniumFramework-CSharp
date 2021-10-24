using OpenQA.Selenium;

namespace SimpleSeleniumFramework.src.main.PageObjects
{
    public class ElementsPage : BasePage
    {
        private readonly ElementsMap Map;

        public ElementsPage(IWebDriver driver) : base(driver)
        {
            Map = new ElementsMap(driver);
        }

        public ElementsPage GoTo()
        {
            PageNavigation.GoToElementsPage();
            return this;
        }

        public IWebElement GetHeader() => Map.ElementsHeader;
    }

    public class ElementsMap
    {
        private readonly IWebDriver _driver;

        public ElementsMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement ElementsHeader
                => _driver.FindElement(By.XPath("//div[@class='main-header' and text()='Elements']"));
    }
}
