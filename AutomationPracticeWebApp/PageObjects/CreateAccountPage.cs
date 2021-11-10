using AutomationPracticeWebApp.Common.Enums;
using AutomationPracticeWebApp.Common.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SimpleSeleniumFramework.Selenium;

namespace AutomationPracticeWebApp.PageObjects
{
    public class CreateAccountPage : BasePage
    {
        private readonly CreateAccountMap Map;

        public CreateAccountPage()
        {
            Map = new CreateAccountMap();
        }

        public void FillUserAccountInformation(UserAccount userAccount)
        {
            WaitForUserInAuthenticationPage();
            WaitForAccountCreationFormVisible();

            if(userAccount.Gender != Gender.Unknown)
            {
                var title = userAccount.Gender == Gender.Male ? "Mr." : "Mrs.";
                var element = Driver.FindElement(Map.TitleCheckBox(title).FoundBy);
                Driver.Wait.Until(ExpectedConditions.ElementToBeClickable(Map.TitleCheckBox(title).FoundBy)).Click();
            }

            Map.CustomerFirstNameTextField.SendKeys(userAccount.FirstName);
            Map.CustomerLastNameTextField.SendKeys(userAccount.LastName);
            Map.PasswordTextField.SendKeys(userAccount.Password);

            if (userAccount.Address != null)
                FillUserAddress(userAccount.Address);
        }

        private void FillUserAddress(UserAddress userAddress)
        {
            Map.FirstNameTextField.SendKeys(userAddress.FirstName);
            Map.LastNameTextField.SendKeys(userAddress.LastName);
            Map.CompanyTextField.SendKeys(userAddress.Company);
            Map.AddressTextField.SendKeys(userAddress.Address);
            Map.Address2TextField.SendKeys(userAddress.Address2);
            Map.CityTextField.SendKeys(userAddress.City);
            Map.StateDropdown(userAddress.State).Click();
            Map.ZipPostalCodeTextField.SendKeys(userAddress.ZipPostalCode);
            Map.CountryDropdown(userAddress.Country).Click();
            Map.AdditionalInfomationTextField.SendKeys(userAddress.AdditionalInformation);
            Map.HomePhoneTextField.SendKeys(userAddress.HomePhone);
            Map.MobilePhoneTextField.SendKeys(userAddress.MobilePhone);
        }

        private void WaitForUserInAuthenticationPage()
        {
            WaitForUserIn("Authentication");
        }

        private void WaitForAccountCreationFormVisible()
        {
            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(Map.CreateAccountForm.FoundBy));
        }
    }

    public class CreateAccountMap
    {
        public Element CreateAccountForm
            => Driver.FindElement(By.Id("account-creation_form"));

        public Element TitleCheckBox(string title)
            => Driver.FindElement(By.XPath($"//label[normalize-space()='{title}']"));

        public Element CustomerFirstNameTextField
            => Driver.FindElement(By.Id("customer_firstname"));

        public Element CustomerLastNameTextField
            => Driver.FindElement(By.Id("customer_lastname"));

        public Element PasswordTextField
            => Driver.FindElement(By.Id("passwd"));

        public Element FirstNameTextField
            => Driver.FindElement(By.Id("firstname"));

        public Element LastNameTextField
            => Driver.FindElement(By.Id("lastname"));

        public Element CompanyTextField
            => Driver.FindElement(By.Id("company"));

        public Element AddressTextField
            => Driver.FindElement(By.Id("address1"));

        public Element Address2TextField
            => Driver.FindElement(By.Id("address2"));

        public Element CityTextField
             => Driver.FindElement(By.Id("city"));

        public Element StateDropdown(string state)
             => Driver.FindElement(By.XPath($"//select[@id = 'id_state']//option[text() = '{state}']"));

        public Element ZipPostalCodeTextField
            => Driver.FindElement(By.Id("postcode"));

        public Element CountryDropdown(string country)
            => Driver.FindElement(By.XPath($"//select[@id = 'id_country']//option[text() = '{country}']"));

        public Element AdditionalInfomationTextField
            => Driver.FindElement(By.Id("other"));

        public Element HomePhoneTextField
            => Driver.FindElement(By.Id("phone"));

        public Element MobilePhoneTextField
            => Driver.FindElement(By.Id("phone_mobile"));

        public Element AddressAliasTextField
            => Driver.FindElement(By.Id("alias"));

        public Element SubmitAccountButton
            => Driver.FindElement(By.Id("submitAccount"));
    }
}
