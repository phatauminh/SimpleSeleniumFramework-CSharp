using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SimpleSeleniumFramework.DemoQA.Framework.Selenium;

namespace SimpleSeleniumFramework.DemoQA.PageObjects
{
    public class BookStorePage : BasePage
    {
        public readonly BookStoreMap Map;
        private readonly IJavaScriptExecutor js;

        public BookStorePage()
        {
            Map = new BookStoreMap();
            js = (IJavaScriptExecutor)Driver.Current;
        }

        public BookStorePage GoTo()
        {
            PageNavigation.GoToBookStorePage();
            return this;
        }

        public IWebElement GetHeader() => Map.BookStoreHeader;

        public string GetUsernameLabel()
        {
            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.UsernameLabel.FoundBy));   
            return Map.UsernameLabel.Text;
        }

        public void AddBookToCollection(string title)
        {
            Driver.Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(Map.Books.FoundBy));

            var selectedBook = Map.Books.Where(x => x.Text.Contains(title)).FirstOrDefault();

            if (selectedBook != null)
                selectedBook.Click();

            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.BookStoreHeader.FoundBy));

            js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");

            Driver.Wait.Until(ExpectedConditions.ElementToBeClickable(Map.AddNewRecordButton.FoundBy));
            Map.AddNewRecordButton.Click();

            Driver.Wait.Until(ExpectedConditions.AlertIsPresent());
            AcceptAlert();
        }

        private void AcceptAlert() => Map.Alert.Accept();

        public void FindBooksByTitle(string title) 
        {
            Map.SearchTextbox.Clear();
            Map.SearchTextbox.SendKeys(title);
        }

        public List<string> GetBookStore()
        {
            var books = Map.Books;

            Driver.Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(books.FoundBy));

            var bookStored = new List<string>();

            foreach (var book in books)
            {
                bookStored.Add(book.Text);
            }

            return bookStored;
        }
    }

    public class BookStoreMap
    {
        public Element BookStoreHeader
                => Driver.FindElement(By.XPath("//div[@class='main-header' and text()='Book Store']"));

        public Element UsernameLabel
                => Driver.FindElement(By.Id("userName-value"));

        public Elements Books
                => Driver.FindElements(By.XPath("//span[contains(@id, 'see-book-')]"));

        public Element AddNewRecordButton
                => Driver.FindElement(By.XPath("//button[@id = 'addNewRecordButton' and text() = 'Add To Your Collection']"));

        public Element SearchTextbox
                => Driver.FindElement(By.Id("searchBox"));

        public IAlert Alert
                => Driver.SwitchTo().Alert();
    }
}
