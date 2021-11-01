using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SimpleSeleniumFramework.Selenium
{
    public class Wait
    {
        private readonly WebDriverWait _wait;

        public Wait(int waitSeconds)
        {
            _wait = new WebDriverWait(Driver.Current, TimeSpan.FromSeconds(waitSeconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };

            _wait.IgnoreExceptionTypes(
                typeof(NoSuchElementException),
                typeof(ElementNotVisibleException),
                typeof(StaleElementReferenceException)
            );
        }

        public bool Until(Func<IWebDriver, bool> condition)
        {
            return _wait.Until(condition);
        }

        public IWebElement Until(Func<IWebDriver, IWebElement> condition)
        {
            return _wait.Until(condition);
        }

        public IAlert Until(Func<IWebDriver, IAlert> condition)
        {
            return _wait.Until(condition);
        }

        public IList<IWebElement> Until(Func<IWebDriver, IList<IWebElement>> condition)
        {
            return _wait.Until(condition);
        }
    }
}
