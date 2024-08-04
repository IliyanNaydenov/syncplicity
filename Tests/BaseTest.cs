using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using Syncplicity.Drivers;
using Syncplicity.Utils;
using System;

namespace Syncplicity.Tests
{
    public abstract class BaseTest
    {
        protected IWebDriver Driver;
        protected ExtentReports extent;
        protected ExtentTest test;

        [OneTimeSetUp]
        public void SetupReporting()
        {
            extent = ExtentReportManager.GetExtent();

        }
        [SetUp]
        public void SetUp()
        {
            string baseUrl = Utils.PropertiesReader.Get("baseUrl");
            string browser = Utils.PropertiesReader.Get("browser");

            if (string.IsNullOrEmpty(baseUrl) || string.IsNullOrEmpty(browser))
            {
                throw new ArgumentException("Base URL or browser is not configured in App.config");
            }

            Console.WriteLine("Base URL: " + baseUrl);
            Console.WriteLine("Browser: " + browser);

            Driver = WebDriverFactory.CreateDriver(browser);

            if (Driver == null)
            {
                throw new NullReferenceException("Driver was not initialized. Check WebDriverFactory.CreateDriver implementation.");
            }
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            Driver.Manage().Window.Maximize();

            // Set implicit wait timeout
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // Set page load timeout
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

            // Set script timeout
            Driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);

            // Navigate to the base URL
            Driver.Navigate().GoToUrl(baseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test.Fail("Test failed", MediaEntityBuilder.CreateScreenCaptureFromPath(TakeScreenshot()).Build());
                test.Log(Status.Fail, $"Stacktrace: {stackTrace}");
                test.Log(Status.Fail, $"Message: {errorMessage}");
            }
            else if (status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                test.Pass("Test passed");
            }
            Driver.Quit();
        }

        [OneTimeTearDown]
        public void TearDownReporting()
        {
            ExtentReportManager.FlushReport();
        }
        private string TakeScreenshot()
        {
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            var filePath = "C:\\Users\\inaid\\source\\repos\\Syncplicity\\Screenshots\\{TestContext.CurrentContext.Test.Name}.png";
            screenshot.SaveAsFile("Screenshot");
            return filePath;
        }

    }
}
