using OpenQA.Selenium;

namespace Syncplicity.Pages
{
    public class UserDetailsPage : BasePage
    {
        public UserDetailsPage(IWebDriver driver) : base(driver) { }

        private IWebElement role => Driver.FindElement(By.XPath("//span[@class='user-property']"));
        private IWebElement email => Driver.FindElement(By.XPath("//span[@class='wraped-Column']"));

        /// <summary>
        /// Retrieves the role text.
        /// </summary>
        /// <returns>The text representing the role.</returns>
        public string getRole()
        {
            return role.Text;
        }

        /// <summary>
        /// Retrieves the email text.
        /// </summary>
        /// <returns>The text representing the email address.</returns>
        public string getEmail()
        {
            return email.Text;
        }

    }
}
