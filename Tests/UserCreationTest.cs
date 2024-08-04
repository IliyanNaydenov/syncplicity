using NUnit.Framework;
using Syncplicity.Pages;
using System;
using System.Threading;

namespace Syncplicity.Tests
{
    public class UserCreation : BaseTest
    {
        private HomePage homePage;
        private LoginPage loginPage;
        private UserAccountsPage userAccountsPage;
        private AddUserPage addUserPage;
        private UserDetailsPage userDetailsPage;

        [SetUp]
        public void Setup()
        {
            homePage = new HomePage(Driver);
            loginPage = new LoginPage(Driver);
            userAccountsPage = new UserAccountsPage(Driver);
            addUserPage = new AddUserPage(Driver);
            userDetailsPage = new UserDetailsPage(Driver);
        }

            [Test]
        public void CreateUser()
        {
            Utils.Logger.LogInfo("Login with a valid credetials");
            homePage.acceptCookies();
            homePage.selectLoginButton();
            loginPage.enterEmailAddress(Constants.Constants.VALID_EMAIL_ADRESS);
            loginPage.selectNextButton();
            loginPage.enterPassword(Constants.Constants.VALID_PASSWORD);
            loginPage.selectLoginButton();

            Utils.Logger.LogInfo("Go to Admin → User Accounts");
            homePage.selectUserAccounts();

            Utils.Logger.LogInfo("Click on the Add a User button");
            userAccountsPage.selectAddUserButton();

            Utils.Logger.LogInfo("Fill in a valid email address in the form.");
            string email = addUserPage.enterRandomEmail();
            Console.WriteLine($"email is {email}!");

            Utils.Logger.LogInfo("From the User Role dropdown,select 'Global Administrator'.");          
            addUserPage.selectFromRoleDropDownMenu();
            string role = addUserPage.returnRole();
            Console.WriteLine($"{role} is selected!");
            Assert.AreEqual("Global Administrator", role, "The Role is not correct!");

            Utils.Logger.LogInfo("Select Next button on UserEmails tab");
            addUserPage.selectNextButton("nextButtonUserEmails");

            Utils.Logger.LogInfo("Select Next button on roupMembership tab");
            addUserPage.selectNextButton("nextButtonGroupMembership");

            Utils.Logger.LogInfo("Select Next button on UserFolders tab");
            addUserPage.selectNextButton("nextButtonUserFolders");

            Utils.Logger.LogInfo("Verify page URL");
            Assert.True(Driver.Url.Contains("AddUser.aspx#congratulations"), "The page title is not correct");
           
            Utils.Logger.LogInfo("Proceed to the all users page");
            homePage.selectUserAccounts(); ;

            Utils.Logger.LogInfo("Search for new user");
            userAccountsPage.searchForUserByEmail(email);
            
            Utils.Logger.LogInfo("Verify results for new user");
            Assert.AreEqual(userAccountsPage.getUserEmail(), email, "The email is not correct");
            userAccountsPage.selectUser();
            Assert.AreEqual(userDetailsPage.getEmail(), email, "The email is not correct");
            Assert.AreEqual(userDetailsPage.getRole(), role, "The role is not correct");
        }
    }
}
