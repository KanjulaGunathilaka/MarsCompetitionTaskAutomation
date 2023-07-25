using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace MarsCompetitionTaskAutomation.Utils
{
    public static class Wait
    {
        public static void WaitToBeClickable(IWebDriver driver, string locatorType, string locatorValue, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            By locator = GetLocator(locatorType, locatorValue);
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static void WaitToBeVisible(IWebDriver driver, string locatorType, string locatorValue, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            By locator = GetLocator(locatorType, locatorValue);
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        private static IWebElement WaitForElementToBeVisible(IWebDriver driver, By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitForElementDisplayed(IWebDriver driver, IWebElement locator, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible((By)locator));
        }

        public static void WaitFor(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
        private static By GetLocator(string locatorType, string locatorValue)
        {
            switch (locatorType.ToLower())
            {
                case "xpath":
                    return By.XPath(locatorValue);
                case "id":
                    return By.Id(locatorValue);
                case "cssselector":
                    return By.CssSelector(locatorValue);
                default:
                    throw new ArgumentException($"Invalid locator type: {locatorType}");
            }
        }
    }
}
