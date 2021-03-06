using DemoQAWebApp.Common;
using DemoQAWebApp.Common.Constants;
using DemoQAWebApp.Common.Services;
using NUnit.Framework;
using SimpleSeleniumFramework.Selenium;

namespace DemoQAWebApp.Tests
{
    [TestFixture]
    public class PageNavigationTests
    {
        [SetUp]
        public void Setup()
        {
            Driver.Init("chrome");
            Driver.GoToUrl("https://demoqa.com");
        }

        [TestCase(Card.ELEMENTS)]
        [TestCase(Card.FORMS)]
        [TestCase(Card.ALERTS_FRAME_WINDOWS)]
        [TestCase(Card.WIDGETS)]
        [TestCase(Card.INTERACTIONS)]
        [TestCase(Card.BOOKSTORE)]
        [Parallelizable(ParallelScope.Children)]
        public void Navigation_Should_Return_Correct_Header(string cardName)
        {
            var headerOnPage = PageNavigationFactory.GetHeader(cardName);
            var expectedCard = new InMemoryCardService().GetCardByName(cardName);

            Assert.AreEqual(expectedCard.Header, headerOnPage.Text);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Current.Quit();
        }
    }
}
