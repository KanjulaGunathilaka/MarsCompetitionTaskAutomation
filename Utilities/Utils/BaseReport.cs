using AventStack.ExtentReports;
using MarsCompetitionTaskAutomation.Utilities.Utils;

namespace MarsCompetitionTaskAutomation.Utilities
{
    public class BaseReport
    {
        protected static ExtentTest test;
        protected static ExtentReports extent;

        public static void StartTest(string testName, string testDescription)
        {
            test = extent.CreateTest(testName, testDescription);
        }

        public static void LogInfo(string message)
        {
            test.Log(Status.Info, message);
        }

        public static void LogPass(string message)
        {
            test.Log(Status.Pass, message);
        }

        public static void LogFail(string message)
        {
            test.Log(Status.Fail, message);
        }
    }
}
