using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using SimpleSeleniumFramework.src.main.Common;

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

        public IWebElement SelectBookFromCollectionByTitle(string title)
        {
            var selectedBook = Map.BookFromCollection.Where(x => x.Text.Contains(title)).FirstOrDefault();
            return selectedBook;
        }
    }

    public class ProfileMap
    {

        public IWebElement ProfileHeader
                => Driver.FindElement(By.XPath("//div[@class='main-header' and text()='Profile']"));

        public IList<IWebElement> BookFromCollection
                => Driver.FindElements(By.XPath("//span[contains(@id, 'see-book-')]"));
    }
}
