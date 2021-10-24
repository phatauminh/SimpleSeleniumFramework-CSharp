using OpenQA.Selenium;

namespace SimpleSeleniumFramework.src.main.PageObjects
{
    public class ProfilePage : BasePage
    {
        private readonly ProfileMap Map;

        public ProfilePage(IWebDriver driver) : base(driver)
        {
            Map = new ProfileMap(driver);
        }

        public ProfilePage GoTo()
        {
            PageNavigation.GoToProfilePage();
            return this;
        }

        public IWebElement GetHeader() => Map.ProfileHeader;
    }

    public class ProfileMap
    {
        private readonly IWebDriver _driver;

        public ProfileMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement ProfileHeader
                => _driver.FindElement(By.XPath("//div[@class='main-header' and text()='Profile']"));
    }
}
