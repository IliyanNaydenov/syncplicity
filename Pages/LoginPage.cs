using OpenQA.Selenium;

namespace Syncplicity.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        private IWebElement emailField => Driver.FindElement(By.XPath("//input[contains(@class,'email')]"));
        private IWebElement nextBottun => Driver.FindElement(By.XPath("//input[contains(@id,'btnNext')]"));
        private IWebElement passwordField => Driver.FindElement(By.XPath("//input[contains(@id,'Password')]"));
        private IWebElement loginButton => Driver.FindElement(By.XPath("//input[contains(@id,'Login')]"));
        private IWebElement logoutButton => Driver.FindElement(By.XPath("//*[contains(@id,'Logout')]"));
        private IWebElement errorMessage => Driver.FindElement(By.XPath("//label[contains(@id,'MainContent_login_UserName-error')]"));

        /// <summary>
        /// Enters the given email address into the email field.
        /// </summary>
        /// <param name="email">The email address to enter.</param>
        public void enterEmailAddress(string email)
        {
            emailField.SendKeys(email);
        }

        /// <summary>
        /// Clicks the next button.
        /// </summary>
        public void selectNextButton()
        {
            nextBottun.Click();
        }

        /// <summary>
        /// Enters the given password into the password field.
        /// </summary>
        /// <param name="password">The password to enter.</param>
        public void enterPassword(string password)
        {
            passwordField.SendKeys(password);
        }

        /// <summary>
        /// Clicks the login button.
        /// </summary>
        public void selectLoginButton()
        {
            loginButton.Click();
        }

        /// <summary>
        /// Checks if the logout button is visible.
        /// </summary>
        /// <returns><c>true</c> if the logout button is visible; otherwise, <c>false</c>.</returns>
        public bool isVisibleLogoutButton()
        {
          return logoutButton.Displayed;
        }

        /// <summary>
        /// Checks if the error message is visible.
        /// </summary>
        /// <returns><c>true</c> if the error message is visible; otherwise, <c>false</c>.</returns>
        public bool isVisibleErrorMessage()
        {
            return errorMessage.Displayed;
        }
    }
}
