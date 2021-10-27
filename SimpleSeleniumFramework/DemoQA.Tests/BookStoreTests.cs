using System.Collections.Generic;
using NUnit.Framework;
using SimpleSeleniumFramework.DemoQA.Common;
using SimpleSeleniumFramework.DemoQA.Framework.Selenium;

namespace SimpleSeleniumFramework.DemoQA.Tests
{
    [TestFixture]
    public class BookStoreTests
    {
        private static List<string> expectedStoredBook = new()
        {
            "Learning JavaScript Design Patterns",
            "Designing Evolvable Web APIs with ASP.NET"
        };


        [SetUp]
        public void Setup()
        {
            Driver.Init("chrome");
            Pages.Init();
            Driver.GoToUrl("https://demoqa.com/books");
        }

        [TestCase("nhudinh", "Demo@123", "nhudinh")]
        [TestCase("phatau", "Demo@123", "phatau")]
        [Parallelizable(ParallelScope.Children)]
        public void TC_01_Login_To_BookStore(string userName, string passWord, string expectedUsernameOnPage)
        {
            Pages.Login.GoTo().UserLogin(userName, passWord);

            var userNameOnPage = Pages.BookStore.GetUsernameLabel();

            Assert.AreEqual(expectedUsernameOnPage, userNameOnPage);
        }

        [TestCase("Git Pocket Guide")]
        [TestCase("Learning JavaScript Design Patterns")]
        [Parallelizable(ParallelScope.Children)]
        public void TC_02_Add_Book_To_Collection(string book)
        {
            Pages.Login.GoTo().UserLogin("phatau", "Demo@123");

            Pages.BookStore.AddBookToCollection(book);

            var bookOnCollection = Pages.Profile.GoTo().SelectBookFromCollection(book);

            Assert.AreEqual(book, bookOnCollection);
        }

        [Test]
        public void TC_03_Search_Book_With_Multiple_Results()
        {
            Pages.BookStore.FindBooksByTitle("Design");
            var storedBookOnPage = Pages.BookStore.GetBookStore();
            Assert.AreEqual(expectedStoredBook, storedBookOnPage);
        }

        [TestCase("Designing Evolvable Web APIs with ASP.NET")]
        public void TC_04_Delete_Book_From_Collection(string book)
        {
            Pages.Login.GoTo().UserLogin("phatau", "Demo@123");
            Pages.BookStore.AddBookToCollection(book);

            Pages.Profile.GoTo().DeleteBookFromCollection(book);

            string bookOnPage = Pages.Profile.SelectBookFromCollection(book);

            Assert.IsNull(bookOnPage);

        }

        [TearDown]
        public void TearDown()
        {
            Driver.Current.Quit();
        }
    }
}
