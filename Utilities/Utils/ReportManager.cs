using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.IO;

namespace MarsCompetitionTaskAutomation.Utilities
{
    public static class ReportManager
    {
        private static ExtentReports extent;
        private static ExtentHtmlReporter htmlReporter;

        public static ExtentReports CreateInstance(string reportPath, string reportName)
        {
            if (extent == null)
            {
                htmlReporter = new ExtentHtmlReporter(Path.Combine(reportPath, reportName));
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
            }
            return extent;
        }

        public static ExtentReports GetExtent()
        {
            return extent;
        }

        public static void FlushReports()
        {
            extent.Flush();
        }
    }
}
