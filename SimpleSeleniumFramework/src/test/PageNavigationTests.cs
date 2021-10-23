using NUnit.Framework;
using OpenQA.Selenium;
using SimpleSeleniumFramework.src.main.Common.Constants;
using SimpleSeleniumFramework.src.main.Common.Factories;
using SimpleSeleniumFramework.src.main.Common.Services;
using SimpleSeleniumFramework.src.main.Driver;

namespace SimpleSeleniumFramework.src.test
{
    [TestFixture]
    public class PageNavigationTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = WebDriverManagers.CreateBrowserDriver("chrome");
            driver.Navigate().GoToUrl("https://demoqa.com");
        }

        [TestCase(Card.ELEMENTS)]
        [TestCase(Card.FORMS)]
        [TestCase(Card.ALERTS_FRAME_WINDOWS)]
        [TestCase(Card.WIDGETS)]
        [TestCase(Card.INTERACTIONS)]
        [TestCase(Card.BOOKSTORE)]
        public void Navigation_Should_Return_Correct_Header(string cardName)
        {
            var headerOnPage = PageNavigationFactory.GetHeader(driver, cardName);
            var expectedCard = new CardService().GetCardByName(cardName);

            Assert.AreEqual(expectedCard.Header, headerOnPage.Text);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
