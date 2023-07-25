using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.IO;

namespace MarsCompetitionTaskAutomation.Helpers
{
    public class CommonMethods
    {
        public static string AddScreenshot(IWebDriver driver)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(ConstantHelpers.ScreenshotPath, ".png");
            string[] existingScreenshots = Directory.GetFiles(ConstantHelpers.ScreenshotPath, "*.png");
            foreach (string existingScreenshot in existingScreenshots)
            {
                File.Delete(existingScreenshot);
            }
            screenshot.SaveAsFile(screenshotLocation, ScreenshotImageFormat.Png);
            return screenshotLocation;
        }

        public static void ScrollToElement(IWebDriver driver, IWebElement element)
        {
            var actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public static void SetField(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public string CheckGivenFieldIsDisplayed(IWebElement element, string message)
        {
            try
            {
                if (element.Displayed)
                {
                    return message + " is displayed";
                }
                else
                {
                    return message + " is NOT displayed";
                }
            }
            catch (NoSuchElementException)
            {
                return message + " is NOT displayed";
            }
        }


    }
}


