using System;
using OpenQA.Selenium;
using SimpleSeleniumFramework.src.main.Factories;

namespace SimpleSeleniumFramework.src.main.Driver
{
    public static class WebDriverManagers
	{
		[ThreadStatic]
        private static IWebDriver _driver;

		public static IWebDriver CreateBrowserDriver(String browserName)
		{
            _driver = BrowserDriverFactory.Create(browserName);
			return _driver;
		}

		public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is Null");
	}
}
