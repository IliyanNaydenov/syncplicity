using OpenQA.Selenium;

namespace Syncplicity.Pages
{
    public class UserAccountsPage : BasePage
    {
        public UserAccountsPage(IWebDriver driver) : base(driver) { }

        private IWebElement addUserButton => Driver.FindElement(By.XPath("//*[contains(text(),'Add a User')]"));
        private IWebElement searchForUserField => Driver.FindElement(By.XPath("//input[@search='email']"));
        private IWebElement firstResultsEmail => Driver.FindElement(By.XPath("(//a[contains(@href,'EditUser')])[1]"));

        public void selectAddUserButton()
        {
            addUserButton.Click();
        }

        /// <summary>
        /// Enters the specified email into the search field and submits the search.
        /// </summary>
        /// <param name="email">The email address to search for.</param>
        public void searchForUserByEmail(string email)
        {
            searchForUserField.SendKeys(email);
            searchForUserField.SendKeys(Keys.Enter);
        }

        /// <summary>
        /// Retrieves the email address from the first search result.
        /// </summary>
        /// <returns>The email address displayed in the first search result.</returns>
        public string getUserEmail()
        {
            
            return firstResultsEmail.Text;
        }

        /// <summary>
        /// Clicks on the first search result to select the user.
        /// </summary>
        public void selectUser()
        {
            firstResultsEmail.Click();
        }
    }
}
