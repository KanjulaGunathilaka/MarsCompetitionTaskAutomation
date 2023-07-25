using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using MarsCompetitionTaskAutomation.Utils;
using NLog;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace MarsCompetitionTaskAutomation.Helpers
{
    public class CommonDriver
    {
        public static IWebDriver driver;
        private static readonly Logger Logger = LoggerManager.Logger;

        public static void Initialize()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public static string BaseUrl => ConstantHelpers.baseUrl;

        public static IWebDriver Instance => driver;

        public static void NavigateToUrl()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }

        public static void CloseDriver()
        {
            try
            {
                driver?.Quit();
                driver.Dispose();
            }
            catch (Exception ex)
            {
                Logger.Info($"An error occurred while closing the driver: {ex.Message}");
            }
            finally
            {
                driver = null;
            }
        }
    }
}

