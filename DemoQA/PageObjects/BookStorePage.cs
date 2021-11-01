using System.Collections.Generic;
using DemoQAWebApp.Common.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SimpleSeleniumFramework.Selenium;

namespace DemoQAWebApp.PageObjects
{
    public class BookStorePage : BasePage
    {
        public readonly BookStoreMap Map;
        

        public BookStorePage()
        {
            Map = new BookStoreMap();
        }

        public BookStorePage GoTo()
        {
            PageNavigation.GoToPageBy(Card.BOOKSTORE_APPLICATION);
            return this;
        }

        public IWebElement GetHeader()
        {
            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.BookStoreHeader.FoundBy));
            return Map.BookStoreHeader;
        } 

        public void WaitForUserInBookStorePage()
        {
            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.BookStoreHeader.FoundBy));
            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.UsernameLabel.FoundBy));
        }

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
