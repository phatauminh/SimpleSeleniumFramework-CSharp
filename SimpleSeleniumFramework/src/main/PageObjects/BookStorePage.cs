using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace SimpleSeleniumFramework.src.main.PageObjects
{
    public class BookStorePage : BasePage
    {
        private readonly BookStoreMap Map;

        public BookStorePage(IWebDriver driver) : base(driver)
        {
            Map = new BookStoreMap(driver);
        }

        public BookStorePage GoTo()
        {
            PageNavigation.GoToBookStorePage();
            return this;
        }

        public IWebElement GetHeader() => Map.BookStoreHeader;

        public string GetUsernameLabel() => Map.UsernameLabel.Text;

        public void SelectBookByTitle(string title)
        {
            var selectedBook = Map.Books.Where(x => x.Text.Contains(title)).FirstOrDefault();

            if (selectedBook != null)
                selectedBook.Click();
        }

        public void AddBookToCollection() => Map.AddNewRecordButton.Click();

        public void AcceptAlert() => Map.Alert.Accept();
            
    }

    public class BookStoreMap
    {
        private readonly IWebDriver _driver;

        public BookStoreMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement BookStoreHeader
                => _driver.FindElement(By.XPath("//div[@class='main-header' and text()='Book Store']"));

       

        public IWebElement UsernameLabel
                => _driver.FindElement(By.Id("userName-value"));

        public List<IWebElement> Books
                => _driver.FindElements(By.XPath("//span[contains(@id, 'see-book-')]")).ToList();

        public IWebElement AddNewRecordButton
                => _driver.FindElement(By.XPath("//button[@id = 'addNewRecordButton' and text() = 'Add To Your Collection']"));

        public IAlert Alert
                => _driver.SwitchTo().Alert();
    }
}
