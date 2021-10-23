using OpenQA.Selenium;
using SimpleSeleniumFramework.src.main.Common.Constants;
using SimpleSeleniumFramework.src.main.PageObjects;
using System;

namespace SimpleSeleniumFramework.src.main.Common.Factories
{
    public static class PageNavigationFactory
    {
        public static IWebElement GetHeader(IWebDriver driver, string cardName)
        {
            switch (cardName)
            {
                case Card.ELEMENTS:
                    var elementsPage = new ElementsPage(driver);
                    return elementsPage.GoTo().GetHeader();

                case Card.FORMS:
                    var formsPage = new FormsPage(driver);
                    return formsPage.GoTo().GetHeader();

                case Card.WIDGETS:
                    var widgetsPage = new WidgetsPage(driver);
                    return widgetsPage.GoTo().GetHeader();

                case Card.ALERTS_FRAME_WINDOWS:
                    var alertsFrameWindowsPage = new AlertsFrameWindowsPage(driver);
                    return alertsFrameWindowsPage.GoTo().GetHeader();

                case Card.INTERACTIONS:
                    var interactionsPage = new InteractionsPage(driver);
                    return interactionsPage.GoTo().GetHeader();

                case Card.BOOKSTORE:
                    var bookStorePage = new BookStorePage(driver);
                    return bookStorePage.GoTo().GetHeader();
                
                default:
                    throw new ArgumentException($"{cardName} is not available.");
            }
        }
    }
}
