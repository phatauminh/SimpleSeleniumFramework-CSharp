using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SimpleSeleniumFramework.DemoQA.Framework.Selenium;

namespace SimpleSeleniumFramework.DemoQA.PageObjects
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

        public IWebElement GetHeader()
        {
            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.ProfileHeader.FoundBy));
            return Map.ProfileHeader;
        }

        public string SelectBookFromCollection(string title)
        {
            Driver.Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(Map.BookFromCollection.FoundBy));

            var selectedBook = Map.BookFromCollection.Where(x => x.Text.Contains(title)).FirstOrDefault();
            return selectedBook?.Text;
        }

        public void WaitForUserInProfilePage()
        {
            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.ProfileHeader.FoundBy));
            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.UsernameLabel.FoundBy));
        }


        public void ClickOnDeleteIconFromCollection(string title)
        {
            Driver.Wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(Map.BookFromCollection.FoundBy));
            Map.DeleteButton(title).Click();
        }

        public void WaitForModalVisible()
           => Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.ModalContent.FoundBy));
        
        
        public void ClickOnConfirmToDeleteItem()
           => Driver.Wait.Until(ExpectedConditions.ElementToBeClickable(Map.ConfirmedModalButton.FoundBy)).Click();


        public void WaitForTheAlertPresent()
           => Driver.Wait.Until(ExpectedConditions.AlertIsPresent());

        public void AcceptAlert() => Map.Alert.Accept();
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

        public Element UsernameLabel
               => Driver.FindElement(By.Id("userName-value"));

    }
}
