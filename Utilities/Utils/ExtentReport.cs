using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using MarsCompetitionTaskAutomation.Helpers;

namespace MarsCompetitionTaskAutomation.Utils
{
    public class ExtentReportManager
    {
        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;

        public static String testResultPath = ConstantHelpers.ReportsPath;

        public static void ExtentReportInit()
        {
            var htmlReporter = new ExtentHtmlReporter(Path.Combine(testResultPath, "AutomationStatusReport.html"));
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Start();

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Application", "Test App");
            _extentReports.AddSystemInfo("Browser", "Chrome");
            _extentReports.AddSystemInfo("OS", "Windows");
        }

        public static void CreateTest(string testName)
        {
            _feature = _extentReports.CreateTest(testName);
        }

        public static void LogTestStep(Status status, string stepDescription)
        {
            _feature.Log(status, stepDescription);
        }

        public static void LogTestStep(Status status, string stepDescription, string details)
        {
            _feature.Log(status, stepDescription).Info(details);
        }

        public static void ExtentReportTearDown()
        {
            _extentReports.Flush();
        }
    }
}
