using AutomationPracticeWebApp.Common.Enums;
using AutomationPracticeWebApp.Common.Models;
using AutomationPracticeWebApp.PageObjects;
using NUnit.Framework;
using SimpleSeleniumFramework.Selenium;
using System;
using System.Threading;

namespace AutomationPracticeWebApp.Tests
{
    public class AccountRegistrationTests
    {
        [SetUp]
        public void Setup()
        {
            Driver.Init("chrome");
            Driver.GoToUrl("http://automationpractice.com/index.php");
        }

        [Test]
        public void TC_01_Register_Account()
        {
            var homePage = new HomePage();
            var signInPage = homePage.GoToSignInPage();
            var createAccountPage = signInPage.EnterValidEmailAddress("testing12311994@gmail.com");
            createAccountPage.FillUserAccountInformation(GenerateUserAccount());
            Thread.Sleep(10000);
        }

        private UserAccount GenerateUserAccount()
        {
            return new UserAccount
            {
                FirstName = "Phat",
                LastName = "Au",
                DoB = new DateTime(1993, 08, 01),
                Gender = Gender.Male,
                Password = "123456",
                Address = new UserAddress
                {
                    FirstName = "Phat",
                    LastName = "Au",
                    Address = "491 Test",
                    Address2 = "491 Test2",
                    AdditionalInformation = "Additional Information",
                    City = "Califonia",
                    State = "Alaska",
                    Country = "United States",
                    AddressAlias = "Alias",
                    Company = "AMP Company",
                    HomePhone = "028111611",
                    MobilePhone = "035555412",
                    ZipPostalCode = "700000"
                }
            };
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Current.Quit();
        }
    }
}
