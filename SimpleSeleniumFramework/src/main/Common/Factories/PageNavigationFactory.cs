using OpenQA.Selenium;
using SimpleSeleniumFramework.src.main.Common.Constants;
using SimpleSeleniumFramework.src.main.PageObjects;
using System;

namespace SimpleSeleniumFramework.src.main.Common.Factories
{
    public static class PageNavigationFactory
    {
        public static IWebElement GetHeader(string cardName)
        {
            switch (cardName)
            {
                case Card.ELEMENTS:
                    var elementsPage = new ElementsPage();
                    return elementsPage.GoTo().GetHeader();

                case Card.FORMS:
                    var formsPage = new FormsPage();
                    return formsPage.GoTo().GetHeader();

                case Card.WIDGETS:
                    var widgetsPage = new WidgetsPage();
                    return widgetsPage.GoTo().GetHeader();

                case Card.ALERTS_FRAME_WINDOWS:
                    var alertsFrameWindowsPage = new AlertsFrameWindowsPage();
                    return alertsFrameWindowsPage.GoTo().GetHeader();

                case Card.INTERACTIONS:
                    var interactionsPage = new InteractionsPage();
                    return interactionsPage.GoTo().GetHeader();

                case Card.BOOKSTORE:
                    var bookStorePage = new BookStorePage();
                    return bookStorePage.GoTo().GetHeader();
                
                default:
                    throw new ArgumentException($"{cardName} is not available.");
            }
        }
    }
}
