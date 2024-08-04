using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;

namespace Syncplicity.Pages
{
    public class AddUserPage : BasePage
    {
        public AddUserPage(IWebDriver driver) : base(driver) { }

        private IWebElement emailInputField => Driver.FindElement(By.XPath("//*[@id='txtUserEmails']"));
        private IWebElement RoleDropDownMenuGlobalAdministrator => Driver.FindElement(By.XPath("//li[@roleid='2']"));
        private IWebElement RoleDropDownArrow => Driver.FindElement(By.XPath("//input[@id='roleselect']"));
        private IWebElement selectedValue => Driver.FindElement(By.Id("roleselect"));
        private IWebElement viewExistingUsersLink => Driver.FindElement(By.Id("//a[text()='View and edit existing users']"));


        /// <summary>
        /// Generates a random email address, enters it into the email input field, and returns the email address.
        /// </summary>
        /// <returns>The randomly generated email address.</returns>
        public string enterRandomEmail()
        {
            Random random = new Random();
            int number = random.Next(10, 1000);
            string email = $"test{number}@dispostable.com";
            emailInputField.SendKeys(email);
            return email;
        }

        /// <summary>
        /// Opens the role dropdown menu and selects the 'Global Administrator' role.
        /// </summary>
        public void selectFromRoleDropDownMenu()
        {
            RoleDropDownArrow.Click();
            RoleDropDownMenuGlobalAdministrator.Click();
        }

        /// <summary>
        /// Retrieves the value of the selected role from the dropdown menu.
        /// </summary>
        /// <returns>The value attribute of the selected role.</returns>
        public string returnRole()
        {
            return selectedValue.GetAttribute("value");
        }

        /// <summary>
        /// Finds the button with the specified name and clicks it after ensuring it is clickable.
        /// </summary>
        /// <param name="buttonName">The partial ID of the button to be clicked.</param>
        public void selectNextButton(string buttonName)
        {
            IWebElement dropdownButton = Driver.FindElement(By.XPath("//*[contains(@id,'" + buttonName + "')]"));
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(dropdownButton));
            dropdownButton.Click();
        }

        /// <summary>
        /// Clicks the link to view existing users.
        /// </summary>
        public void selectViewUsersLink()
        {
            viewExistingUsersLink.Click();
        }

    }
}
