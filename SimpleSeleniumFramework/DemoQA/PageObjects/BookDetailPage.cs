using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SimpleSeleniumFramework.DemoQA.Framework.Selenium;

namespace SimpleSeleniumFramework.DemoQA.PageObjects
{
    public class BookDetailPage : BasePage
    {
        public readonly BookDetailMap Map;
        private readonly IJavaScriptExecutor js;

        public BookDetailPage()
        {
            Map = new BookDetailMap();
            js = (IJavaScriptExecutor)Driver.Current;
        }

        public void GoToBy(string title) => PageNavigation.GoToBookDetailBy(title);

        public void ClickOnAddBookToYourCollection()
        {
            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.BookStoreHeader.FoundBy));

            js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");

            Driver.Wait.Until(ExpectedConditions.ElementToBeClickable(Map.AddNewRecordButton.FoundBy)).Click();
        }

        public void WaitForTheAlertPresent() => Driver.Wait.Until(ExpectedConditions.AlertIsPresent());

        public void AcceptAlert() => Map.Alert.Accept();
    }

    public class BookDetailMap
    {
        public Element BookStoreHeader
                => Driver.FindElement(By.XPath("//div[@class='main-header' and text()='Book Store']"));

        public Element AddNewRecordButton
                => Driver.FindElement(By.XPath("//button[@id = 'addNewRecordButton' and text() = 'Add To Your Collection']"));

        public IAlert Alert
                => Driver.SwitchTo().Alert();
    }
}
