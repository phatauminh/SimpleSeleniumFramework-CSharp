using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using SimpleSeleniumFramework.src.main.Driver;
using SimpleSeleniumFramework.src.main.PageObjects;

namespace SimpleSeleniumFramework.src.test
{
    [TestFixture]
    public class BookStoreTests
    { 
        [SetUp]
        public void Setup()
        {
            WebDriverManagers.CreateBrowserDriver("chrome");
            WebDriverManagers.Current.Manage().Window.Maximize();
            WebDriverManagers.Current.Navigate().GoToUrl("https://demoqa.com/books");

        }

        [TestCase("nhudinh", "Demo@123","nhudinh")]
        [TestCase("phatau", "Demo@123","phatau")]
        [Parallelizable(ParallelScope.Children)]
        public void TC_01_Login_To_BookStore(string userName, string passWord, string expectedUsernameOnPage)
        {
            var loginPage = new LoginPage(WebDriverManagers.Current);
            loginPage.GoTo().UserLogin(userName, passWord);
            var bookStorePage = new BookStorePage(WebDriverManagers.Current);
            var userNameOnPage = bookStorePage.GetUsernameLabel();
            Assert.AreEqual(expectedUsernameOnPage, userNameOnPage);
        }

        [Test]
        public void TC_02_Add_Book_To_Collection()
        {
            var loginPage = new LoginPage(WebDriverManagers.Current);
            loginPage.GoTo().UserLogin("phatau", "Demo@123");
            Thread.Sleep(3000);

            var bookStorePage = new BookStorePage(WebDriverManagers.Current);

            bookStorePage.SelectBookByTitle("Git Pocket Guide");
            bookStorePage.AddBookToCollection();

            Thread.Sleep(3000);
            bookStorePage.AcceptAlert();
            Thread.Sleep(3000);



        }

        [TearDown]
        public void TearDown()
        {
            WebDriverManagers.Current.Quit();
        }
    }
}
