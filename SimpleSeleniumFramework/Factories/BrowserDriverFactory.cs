using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SimpleSeleniumFramework.Constants;
using WebDriverManager.DriverConfigs.Impl;

namespace SimpleSeleniumFramework.Factories
{
    public static class BrowserDriverFactory
    {
        public static IWebDriver Create(string browserName)
        {
            switch (browserName)
            {
                case Browser.CHROME:
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    return new ChromeDriver();
                case Browser.FIREFOX:
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    return new FirefoxDriver();
                case Browser.EDGE:
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    return new EdgeDriver();
                default:
                    return null;
            }
        }
    }
}