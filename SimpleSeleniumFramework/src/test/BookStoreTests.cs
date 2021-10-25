using System.Threading;
using NUnit.Framework;
using SimpleSeleniumFramework.src.main.Common;
using SimpleSeleniumFramework.src.main.PageObjects;

namespace SimpleSeleniumFramework.src.test
{
    [TestFixture]
    public class BookStoreTests
    {
         static string[] testcase = { "Git Pocket Guide", "Learning JavaScript Design Patterns" };

        [SetUp]
        public void Setup()
        {
            Driver.Init("chrome");
            Pages.Init();
            Driver.GoToUrl("https://demoqa.com/books");
        }

        [TestCase("nhudinh", "Demo@123","nhudinh")]
        [TestCase("phatau", "Demo@123","phatau")]
        [Parallelizable(ParallelScope.Children)]
        public void TC_01_Login_To_BookStore(string userName, string passWord, string expectedUsernameOnPage)
        {
            var loginPage = Pages.Login;
            loginPage.GoTo().UserLogin(userName, passWord);

            var bookStorePage = Pages.BookStore;
            var userNameOnPage = bookStorePage.GetUsernameLabel();

            Assert.AreEqual(expectedUsernameOnPage, userNameOnPage);
        }

        [TestCase("Git Pocket Guide")]
        [TestCase("Learning JavaScript Design Patterns")]
        [Parallelizable(ParallelScope.Children)]
        public void TC_02_Add_Book_To_Collection(string book)
        {
            var loginPage = Pages.Login;
            loginPage.GoTo().UserLogin("phatau", "Demo@123");
            Thread.Sleep(3000);

            var bookStorePage = Pages.BookStore;

            bookStorePage.AddBookToCollection(book);

            Thread.Sleep(3000);
            bookStorePage.AcceptAlert();
            Thread.Sleep(3000);

            var profilePage = Pages.Profile;

            profilePage.GoTo();
            Thread.Sleep(3000);
            var bookOnCollection = profilePage.SelectBookFromCollectionByTitle(book).Text;

            Assert.AreEqual(book, bookOnCollection);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
