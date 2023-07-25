using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using MarsCompetitionTaskAutomation.Helpers;
using BoDi;
using MarsCompetitionTaskAutomation.Utils;
using NLog;

[SetUpFixture]
public class Hooks
{
    private static readonly Logger Logger = LoggerManager.Logger;

    [OneTimeSetUp]
    public void BeforeTestSuite()
    {
        Logger.Info($"{Environment.NewLine}==========================Running Before Test Run=========================={Environment.NewLine}");
        CommonDriver.Initialize();
    }

    [OneTimeTearDown]
    public void AfterTestSuite()
    {
        Logger.Info($"{Environment.NewLine}==========================Running After Test Run=========================={Environment.NewLine}");
        CommonDriver.CloseDriver();
        LogManager.Shutdown();
    }
}