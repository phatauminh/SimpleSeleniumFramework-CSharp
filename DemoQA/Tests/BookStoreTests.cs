using System;
using System.Collections.Generic;
using DemoQAWebApp.Common;
using NUnit.Framework;
using SimpleSeleniumFramework.Selenium;

namespace DemoQAWebApp.Tests
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
            Driver.GoToUrl("https://demoqa.com");
            Console.WriteLine("Setup");
        }

        [TestCase("Git Pocket Guide")]
        [TestCase("Learning JavaScript Design Patterns")]
        public void TC_01_Add_Book_To_Collection(string title)
        {
            Pages.BookStore.GoTo();

            Pages.Login.GoTo();

            Pages.Login.EnterUserCredential("phatau", "Demo@123");

            Pages.Login.ClickOnLoginButton();

            Pages.BookStore.WaitForUserInBookStorePage();

            Pages.BookDetail.GoToBy(title);

            Pages.BookDetail.ClickOnAddBookToYourCollection();

            Pages.BookDetail.WaitForTheAlertPresent();

            Pages.BookDetail.AcceptAlert();

            Pages.Profile.GoTo();

            var bookOnCollection = Pages.Profile.SelectBookFromCollection(title);

            Assert.AreEqual(title, bookOnCollection);
        }

        [TestCase("Design")]
        [TestCase("design")]
        [Parallelizable(ParallelScope.Children)]
        public void TC_02_Search_Book_With_Multiple_Results(string title)
        {
            Pages.BookStore.GoTo();

            Pages.BookStore.FindBooksByTitle(title);

            var storedBookOnPage = Pages.BookStore.GetBookStore();
            Assert.AreEqual(expectedStoredBook, storedBookOnPage);
        }

        [TestCase("Designing Evolvable Web APIs with ASP.NET")]
        public void TC_03_Delete_Book_From_Collection(string title)
        {
            Pages.BookStore.GoTo();

            Pages.Login.GoTo();

            Pages.Login.EnterUserCredential("phatau", "Demo@123");

            Pages.Login.ClickOnLoginButton();

            Pages.BookStore.WaitForUserInBookStorePage();

            Pages.BookDetail.GoToBy(title);

            Pages.BookDetail.ClickOnAddBookToYourCollection();

            Pages.BookDetail.WaitForTheAlertPresent();

            Pages.BookDetail.AcceptAlert();

            Pages.Profile.GoTo();

            Pages.Profile.WaitForUserInProfilePage();

            Pages.Profile.ClickOnDeleteIconFromCollection(title);

            Pages.Profile.WaitForModalVisible();

            Pages.Profile.ClickOnConfirmToDeleteItem();

            Pages.Profile.WaitForTheAlertPresent();

            Pages.Profile.AcceptAlert();

            string bookOnPage = Pages.Profile.SelectBookFromCollection(title);

            Assert.IsNull(bookOnPage);

        }

        [TearDown]
        public void TearDown()
        {
            Driver.Current.Quit();
        }
    }
}
