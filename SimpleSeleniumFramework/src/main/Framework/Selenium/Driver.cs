using System;
using OpenQA.Selenium;
using SimpleSeleniumFramework.src.main.Factories;

namespace SimpleSeleniumFramework.src.main.Framework.Selenium
{
	public static class Driver
	{
		[ThreadStatic]
		private static IWebDriver _driver;

		[ThreadStatic]
		public static Wait Wait;

		public static IWebDriver Init(String browserName)
		{
			_driver = BrowserDriverFactory.Create(browserName);
			_driver.Manage().Window.Maximize();

			Wait = new Wait(10);

			return _driver;
		}

		public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is Null");

        public static ITargetLocator SwitchTo() => Current.SwitchTo();

		public static void Quit() => Current.Quit();

		public static void GoToUrl(string url) => Current.Navigate().GoToUrl(url);

		public static Element FindElement(By by)
		{
			var element = Wait.Until(drvr => drvr.FindElement(by));
			return new Element(element)
			{
				FoundBy = by
			};
		}

        public static Elements FindElements(By by)
        {
            return new Elements(Current.FindElements(by))
            {
                FoundBy = by
            };
        }
    }
}
		