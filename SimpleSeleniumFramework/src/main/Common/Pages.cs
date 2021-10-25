using System;
using SimpleSeleniumFramework.src.main.PageObjects;

namespace SimpleSeleniumFramework.src.main.Common
{
    public static class Pages
    {
        [ThreadStatic]
        public static LoginPage Login;

        [ThreadStatic]
        public static BookStorePage BookStore;

        [ThreadStatic]
        public static ProfilePage Profile;

        public static void Init()
        {
            Login = new LoginPage();
            BookStore = new BookStorePage();
            Profile = new ProfilePage();
        }
    }
}
