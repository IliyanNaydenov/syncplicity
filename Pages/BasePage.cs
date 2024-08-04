using OpenQA.Selenium;

namespace Syncplicity.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
