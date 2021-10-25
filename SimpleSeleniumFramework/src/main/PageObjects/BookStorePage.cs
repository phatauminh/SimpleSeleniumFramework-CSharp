using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using SimpleSeleniumFramework.src.main.Common;

namespace SimpleSeleniumFramework.src.main.PageObjects
{
    public class BookStorePage : BasePage
    {
        private readonly BookStoreMap Map;

        public BookStorePage()
        {
            Map = new BookStoreMap();
        }

        public BookStorePage GoTo()
        {
            PageNavigation.GoToBookStorePage();
            return this;
        }

        public IWebElement GetHeader() => Map.BookStoreHeader;

        public string GetUsernameLabel() => Map.UsernameLabel.Text;



        public void AddBookToCollection(string title)
        {
            SelectBookByTitle(title);
            Map.AddNewRecordButton.Click();
        }


        public void AcceptAlert() => Map.Alert.Accept();


        private void SelectBookByTitle(string title)
        {
            var selectedBook = Map.Books.Where(x => x.Text.Contains(title)).FirstOrDefault();

            if (selectedBook != null)
                selectedBook.Click();
        }

    }

    public class BookStoreMap
    {
        public IWebElement BookStoreHeader
                => Driver.FindElement(By.XPath("//div[@class='main-header' and text()='Book Store']"));

        public IWebElement UsernameLabel
                => Driver.FindElement(By.Id("userName-value"));

        public IList<IWebElement> Books
                => Driver.FindElements(By.XPath("//span[contains(@id, 'see-book-')]"));

        public IWebElement AddNewRecordButton
                => Driver.FindElement(By.XPath("//button[@id = 'addNewRecordButton' and text() = 'Add To Your Collection']"));

        public IAlert Alert
                => Driver.SwitchTo().Alert();
    }
}
