using NUnit.Framework;
using OpenQA.Selenium;
using SimpleSeleniumFramework.src.main.Driver;
using SimpleSeleniumFramework.src.main.PageObjects;

namespace SimpleSeleniumFramework.src.test
{
    [TestFixture]
    public class BookStoreTests
    { 
        IWebDriver driver;

        public BookStoreTests()
        {

        }

        [SetUp]
        public void Setup()
        {
            driver = WebDriverManagers.CreateBrowserDriver("chrome");
            driver.Navigate().GoToUrl("https://demoqa.com");
        }

  

        [Test]
        public void TC_01_BookStoreNavigation()
        {
            var bookStorePage = new BookStorePage(driver);
            var header = bookStorePage.GoTo().GetBookStoreHeader();

            Assert.IsTrue(header.Displayed);
        }

        //[Test]
        //public void TC_02_UserLogin()
        //{

        //}


        //[Test]
        //public void TC_03_AddBooksToCollection()
        //{

        //}

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
