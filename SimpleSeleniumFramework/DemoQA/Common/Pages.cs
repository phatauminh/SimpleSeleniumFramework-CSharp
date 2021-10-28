using System;
using SimpleSeleniumFramework.DemoQA.PageObjects;

namespace SimpleSeleniumFramework.DemoQA.Common
{
    public static class Pages
    {
        [ThreadStatic]
        public static LoginPage Login;

        [ThreadStatic]
        public static BookStorePage BookStore;

        [ThreadStatic]
        public static ProfilePage Profile;

        [ThreadStatic]
        public static BookDetailPage BookDetail;

        public static void Init()
        {
            Login = new LoginPage();
            BookStore = new BookStorePage();
            Profile = new ProfilePage();
            BookDetail = new BookDetailPage();
        }
    }
}
