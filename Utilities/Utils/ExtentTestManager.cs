using AventStack.ExtentReports;

namespace MarsCompetitionTaskAutomation.Utilities.Utils
{
    public static class ExtentTestManager
    {
        private static ExtentReports extent;
        private static ExtentTest currentTest;

        public static void StartTest(string testName, string testDescription)
        {
            extent = ReportManager.GetExtent();
            currentTest = extent.CreateTest(testName, testDescription);
        }

        public static void LogInfo(string message)
        {
            currentTest.Log(Status.Info, message);
        }

        public static void LogPass(string message)
        {
            currentTest.Pass(message);
        }

        public static void LogFail(string message)
        {
            currentTest.Fail(message);
        }

        public static void LogDescription(string description)
        {
            currentTest.Info(description);
        }

        public static void LogStep(string stepDescription)
        {
            currentTest.Info(stepDescription);
        }

        public static void FlushReports()
        {
            extent.Flush();
        }
    }
}
