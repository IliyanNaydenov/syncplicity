using OpenQA.Selenium;

namespace Syncplicity.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        private IWebElement loginButton => Driver.FindElement(By.XPath("(//div[@class='elementor-button-wrapper']//a[contains(@href,'https://my.syncplicity.com/')])[1]"));
        private IWebElement acceptCookiesButton => Driver.FindElement(By.XPath("//button[@class='cmplz-btn cmplz-accept']"));
        private IWebElement userAccounts => Driver.FindElement(By.XPath("//a[contains(@href,'UserSearch')]"));

        /// <summary>
        /// Clicks the login button.
        /// </summary>
        public void selectLoginButton()
        {
            loginButton.Click();
        }

        /// <summary>
        /// Clicks the accept cookies button.
        /// </summary>
        public void acceptCookies()
        {
            acceptCookiesButton.Click();
        }

        /// <summary>
        /// Clicks the user accounts button.
        /// </summary>
        public void selectUserAccounts()
        {
            userAccounts.Click();
        }
    }
}
