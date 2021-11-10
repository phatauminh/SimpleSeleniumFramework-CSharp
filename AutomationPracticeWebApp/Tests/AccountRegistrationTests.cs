using AutomationPracticeWebApp.Common.Enums;
using AutomationPracticeWebApp.Common.Models;
using AutomationPracticeWebApp.PageObjects;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NUnit.Framework;
using SimpleSeleniumFramework.Selenium;
using System;
using System.IO;

namespace AutomationPracticeWebApp.Tests
{
    public class AccountRegistrationTests
    {
        private readonly string REPORT_PATH = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Tests\Report\account_report.xlsx"));

        [SetUp]
        public void Setup()
        {
            Driver.Init("chrome");
            Driver.GoToUrl("http://automationpractice.com/index.php");
        }

        [TestCase("PhatA", "Au", "PhatA Au")]
        [TestCase("Jame", "Walk", "Jame Walk")]
        [TestCase("John", "Wood", "John Wood")]
        public void TC_01_Register_Account(string firstName, string lastName, string expectedUser)
        {
            var userAccount = GenerateUserAccount();
            userAccount.Email = $"test{DateTime.Now.Ticks}@gmail.com";
            userAccount.FirstName = firstName;
            userAccount.LastName = lastName;

            var homePage = new HomePage();
            var signInPage = homePage.GoToSignInPage();
            var createAccountPage = signInPage.EnterValidEmailAddress(userAccount.Email);
            var myAccountPage = createAccountPage.RegisterAccountWithValidInfos(userAccount);
            var userOnPage = myAccountPage.GetUserInfo();

            Assert.AreEqual(expectedUser, userOnPage);
            ExportUserAccountReport(userAccount);
        }

        private void ExportUserAccountReport(UserAccount userAccount)
        {
            IWorkbook workbook;
            ISheet sheet;
            IRow row;
            bool isFileExist = File.Exists(REPORT_PATH);

            if (isFileExist)
            {
                using (FileStream file = new FileStream(REPORT_PATH, FileMode.Open, FileAccess.Read))
                {
                    workbook = new XSSFWorkbook(file);
                }

                sheet = workbook.GetSheet("User Information");
                row = sheet.CreateRow(sheet.LastRowNum + 1);
            }
            else
            {
                workbook = new XSSFWorkbook();
                sheet = workbook.CreateSheet("User Information");

                IRow header = sheet.CreateRow(0);
                header.CreateCell(0).SetCellValue("Email");
                header.CreateCell(1).SetCellValue("Password");
                header.CreateCell(2).SetCellValue("First Name");
                header.CreateCell(3).SetCellValue("Last Name");
                header.CreateCell(4).SetCellValue("Created Date");

                row = sheet.CreateRow(1);
            }

            var newDataFormat = workbook.CreateDataFormat();
            var style = workbook.CreateCellStyle();
            style.DataFormat = newDataFormat.GetFormat("MM/dd/yyyy HH:mm:ss");

            row.CreateCell(0).SetCellValue(userAccount.Email);
            row.CreateCell(1).SetCellValue(userAccount.Password);
            row.CreateCell(2).SetCellValue(userAccount.FirstName);
            row.CreateCell(3).SetCellValue(userAccount.LastName);

            var cell4 = row.CreateCell(4);
            cell4.SetCellValue(userAccount.CreatedDate);
            cell4.CellStyle = style;

            FileStream sw = isFileExist ? File.OpenWrite(REPORT_PATH) : File.Create(REPORT_PATH);
            workbook.Write(sw);
            sw.Close();
        }

        private UserAccount GenerateUserAccount()
        {
            return new UserAccount
            {
                FirstName = "PhatHoc",
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
                    ZipPostalCode = "70000"
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
