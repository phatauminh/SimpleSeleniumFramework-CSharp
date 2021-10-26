using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SimpleSeleniumFramework.src.main.Framework.Selenium;

namespace SimpleSeleniumFramework.src.main.PageObjects
{
    public class ProfilePage : BasePage
    {
        private readonly ProfileMap Map;

        public ProfilePage()
        {
            Map = new ProfileMap();
        }

        public ProfilePage GoTo()
        {
            PageNavigation.GoToProfilePage();
            return this;
        }

        public IWebElement GetHeader() => Map.ProfileHeader;

        public string SelectBookFromCollection(string title)
        {
            Driver.Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(Map.BookFromCollection.FoundBy));

            var selectedBook = Map.BookFromCollection.Where(x => x.Text.Contains(title)).FirstOrDefault();
            return selectedBook?.Text;
        }

        public void DeleteBookFromCollection(string title)
        {
            Driver.Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(Map.BookFromCollection.FoundBy));
            Map.DeleteButton(title).Click();

            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.ModalContent.FoundBy));
            Map.ConfirmedModalButton.Click();

            Driver.Wait.Until(ExpectedConditions.AlertIsPresent());
            AcceptAlert();
        }

        private void AcceptAlert() => Map.Alert.Accept();
    }

    public class ProfileMap
    {

        public Element ProfileHeader
                => Driver.FindElement(By.XPath("//div[@class='main-header' and text()='Profile']"));

        public Elements BookFromCollection
                => Driver.FindElements(By.XPath("//span[contains(@id, 'see-book-')]"));

        public Element DeleteButton(string title)
                => Driver.FindElement(By.XPath($"//span[contains(@id,'{title}')]//..//parent::div//following-sibling::div//span[@title='Delete'] "));

        public Element ConfirmedModalButton
                => Driver.FindElement(By.Id("closeSmallModal-ok"));

        public Element ModalContent
                => Driver.FindElement(By.ClassName("modal-content"));

        public IAlert Alert
                => Driver.SwitchTo().Alert();

    }
}
