using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SimpleSeleniumFramework.src.main.Factories;

namespace SimpleSeleniumFramework.src.main.Common
{
	public static class Driver
	{
		[ThreadStatic]
		private static IWebDriver _driver;

		public static IWebDriver Init(String browserName)
		{
			_driver = BrowserDriverFactory.Create(browserName);
			_driver.Manage().Window.Maximize();

			return _driver;
		}

		public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is Null");

		public static IWebElement FindElement(By by) => Current.FindElement(by);

		public static IList<IWebElement> FindElements(By by) => Current.FindElements(by);

		public static ITargetLocator SwitchTo() => Current.SwitchTo();

		public static void Quit() => Current.Quit();

		public static void GoToUrl(string url) => Current.Navigate().GoToUrl(url);
	}
}
		