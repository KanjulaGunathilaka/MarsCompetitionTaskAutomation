using MarsCompetitionTaskAutomation.Helpers;
using MarsCompetitionTaskAutomation.Pages;
using MarsCompetitionTaskAutomation.Utilities;
using MarsCompetitionTaskAutomation.Utilities.Utils;
using Microsoft.Extensions.Primitives;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MarsCompetitionTaskAutomation.Tests
{
    public class BaseTest
    {
        protected SignInPage signInPage;
        protected ProfilePage profilePage;
        protected ManageListingPage manageListingPage;
        protected SharePage sharePage;

        private string reportPath = ConstantHelpers.ReportsPath;
        private string reportName = "AutomationResultsReport.html";

        [OneTimeSetUp]
        public void InitializeReport()
        {
            ReportInitializer.InitializeReport(reportPath, reportName);
        }

        [SetUp]
        public void StartTest()
        {
            string testName = TestContext.CurrentContext.Test.Name;
            string testDescription = TestContext.CurrentContext.Test.FullName;
            ExtentTestManager.StartTest(testName, testDescription);
        }

        [SetUp]
        public void BeforeEachTest()
        {
            CommonDriver.Initialize();
        }

        [SetUp]
        public void BeforeEachTestCase()
        {
            signInPage = new SignInPage(CommonDriver.driver);
            profilePage = new ProfilePage(CommonDriver.driver);
            sharePage = new SharePage(CommonDriver.driver);
            manageListingPage = new ManageListingPage(CommonDriver.driver);
        }

        [TearDown]
        public void AfterEachTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            string screenshotFileName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMddHHmmss}.png";

            if (testStatus == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                string screenshotPath = TakeScreenshot(screenshotFileName);
                TakeScreenshot(screenshotFileName);
                ExtentTestManager.LogFail("Test Failed." + TestContext.CurrentContext.Test.Name);
                ExtentTestManager.LogFail("Test Outcome: " + TestContext.CurrentContext.Result.Outcome);
                ExtentTestManager.LogFail(TestContext.CurrentContext.Result.Message);
                ExtentTestManager.LogInfo($"Screenshot: {screenshotFileName}");
                ExtentTestManager.LogInfo($"Screenshot: {screenshotPath}");
            }
            else if (testStatus == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                ExtentTestManager.LogPass("Test Passed." + TestContext.CurrentContext.Test.Name);
                ExtentTestManager.LogPass("Test Outcome: " + TestContext.CurrentContext.Result.Outcome);
            }

            ExtentTestManager.FlushReports();
            CommonDriver.CloseDriver();

        }

        [OneTimeTearDown]
        public void FinalizeReport()
        {
            ExtentTestManager.FlushReports();
            ReportInitializer.FinalizeReport();
        }

        private string TakeScreenshot(string screenshotFileName)
        {
            ITakesScreenshot screenshotDriver = CommonDriver.driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            string screenshotPath = Path.Combine(ConstantHelpers.ScreenshotPath, screenshotFileName);
            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);

            return screenshotPath;
        }

    }
}