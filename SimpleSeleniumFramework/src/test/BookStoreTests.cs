using NUnit.Framework;
using OpenQA.Selenium;
using SimpleSeleniumFramework.src.main.Common.Constants;
using SimpleSeleniumFramework.src.main.Common.Factories;
using SimpleSeleniumFramework.src.main.Common.Services;
using SimpleSeleniumFramework.src.main.Driver;

namespace SimpleSeleniumFramework.src.test
{
    [TestFixture]
    public class BookStoreTests
    { 
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = WebDriverManagers.CreateBrowserDriver("chrome");
            driver.Navigate().GoToUrl("https://demoqa.com");
        }

        [TestCase(Card.ELEMENTS)]
        [TestCase(Card.BOOKSTORE)]
        public void Navigation_Should_Return_Correct_Header(string cardName)
        {
            var headerOnPage = PageNavigationFactory.GetHeader(driver,cardName);
            var expectedBookStore = new CardService().GetCardByName(cardName);

            Assert.AreEqual(expectedBookStore.Header, headerOnPage.Text);
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
