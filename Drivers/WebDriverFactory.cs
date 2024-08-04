using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;

namespace Syncplicity.Drivers
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateDriver(string browser)
        {
                switch (browser.ToLower())
                {
                    case "chrome":
                        return CreateChromeDriver();
                    // You can add cases for other browsers here
                    default:
                        throw new ArgumentException($"Browser '{browser}' is not supported.");
                }
            }

            private static IWebDriver CreateChromeDriver()
            {
                var options = new ChromeOptions();
                options.AddArguments("start-maximized"); // Start browser maximized
                options.AddArguments("disable-infobars"); // Disable the infobars
                options.AddArguments("--disable-extensions"); // Disable extensions
                options.AddArguments("--disable-popup-blocking"); // Disable popup blocking
                options.AddArguments("--disable-default-apps"); // Disable default apps
                options.AddArguments("--disable-notifications"); // Disable notifications
                options.AddArguments("--disable-translate"); // Disable translate prompt
                options.AddArguments("--no-first-run"); // Disable the first run
                options.AddArguments("--disable-blink-features=AutomationControlled"); // Disable Chrome being controlled by automated test software
                options.AddUserProfilePreference("profile.default_content_setting_values.notifications", 2); // Disable notifications
                options.AddUserProfilePreference("profile.password_manager_enabled", false); // Disable password manager
                options.AddUserProfilePreference("credentials_enable_service", false); // Disable credential service

                return new ChromeDriver(options);
            }
        }
    }
