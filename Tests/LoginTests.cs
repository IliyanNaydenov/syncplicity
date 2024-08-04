using NUnit.Framework;
using Syncplicity.Pages;


namespace Syncplicity.Tests
{
    public class LoginTests : BaseTest
    {
        private HomePage homePage;
        private LoginPage loginPage;

        [SetUp]
        public void Setup()
        {
            homePage = new HomePage(Driver);
            loginPage = new LoginPage(Driver);
        }


        [Test]
        public void Loginsuccessfully()
        {

            homePage.acceptCookies();
            homePage.selectLoginButton();

            Utils.Logger.LogInfo("Enter a valdi e-mail address");
            loginPage.enterEmailAddress(Constants.Constants.VALID_EMAIL_ADRESS);

            Utils.Logger.LogInfo("Select Next button");
            loginPage.selectNextButton();

            Utils.Logger.LogInfo("Enter a valdi password address");
            loginPage.enterPassword(Constants.Constants.VALID_PASSWORD);

            Utils.Logger.LogInfo("Select login button");
            loginPage.selectLoginButton();

            Utils.Logger.LogInfo("Verify succesfully login");
            Assert.IsTrue(loginPage.isVisibleLogoutButton(), "The user is not logged in");
        }

        [Test]
        public void InvalidLogin()
        {
            homePage.acceptCookies();
            homePage.selectLoginButton();

            Utils.Logger.LogInfo("Enter a valdi e-mail address");
            loginPage.enterEmailAddress(Constants.Constants.INVALID_EMAIL_ADRESS);

            Utils.Logger.LogInfo("Select Next button");
            loginPage.selectNextButton();


            Utils.Logger.LogInfo("Verify incorrect email error message");
            Assert.IsTrue(loginPage.isVisibleErrorMessage(), "The error message is missing");
        }

    }
}
