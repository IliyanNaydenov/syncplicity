using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;

namespace Syncplicity.Utils
{
    public static class ExtentReportManager
    {
        private static readonly string reportPath = "C:\\Users\\inaid\\source\\repos\\Syncplicity\\ExtentReports\\ExtentReport.html";
        private static ExtentReports extent;
        private static ExtentV3HtmlReporter htmlReporter;

        static ExtentReportManager()
        {
            if (extent == null)
            {
                htmlReporter = new ExtentV3HtmlReporter(reportPath);
                extent = new ExtentReports();
                extent.AttachReporter((AventStack.ExtentReports.Core.IExtentReporter)htmlReporter);

                // You can add system info or any other configurations here
                extent.AddSystemInfo("Environment", "Environment");
                extent.AddSystemInfo("User Name", "Iliyan Naydenov");
            }
        }

        public static ExtentReports GetExtent()
        {
            return extent;
        }

        public static void FlushReport()
        {
            extent.Flush();
        }
    }
}
