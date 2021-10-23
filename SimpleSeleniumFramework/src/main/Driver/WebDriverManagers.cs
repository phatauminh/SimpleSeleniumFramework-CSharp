using System;
using OpenQA.Selenium;
using SimpleSeleniumFramework.src.main.Factories;

namespace SimpleSeleniumFramework.src.main.Driver
{
    public class WebDriverManagers
	{
        private static IWebDriver _driver;

		public static IWebDriver CreateBrowserDriver(String browserName)
		{
            _driver = BrowserDriverFactory.Create(browserName);
			_driver.Manage().Window.Maximize();
			return _driver;
		}
	}
}
