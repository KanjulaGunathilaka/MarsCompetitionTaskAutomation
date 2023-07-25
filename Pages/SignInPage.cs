using MarsCompetitionTaskAutomation.Helpers;
using OpenQA.Selenium;

namespace MarsCompetitionTaskAutomation.Pages
{
    public class SignInPage
    {
        private IWebDriver driver;

        public SignInPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement SignInBtn => driver.FindElement(By.XPath("//a[@class='item'][text()='Sign In']"));
        private IWebElement Email => driver.FindElement(By.XPath("(//input[@type='text'])[2]"));
        private IWebElement Password => driver.FindElement(By.XPath("//input[@type='password']"));
        private IWebElement LoginBtn => driver.FindElement(By.XPath("//button[@class='fluid ui teal button'][text()='Login']"));

        public void SignIn(string email, string password)
        {
            CommonDriver.NavigateToUrl();
            Thread.Sleep(1000);
            SignInBtn.Click();
            Email.SendKeys(email);
            Password.SendKeys(password);
            LoginBtn.Click();
            Thread.Sleep(2000);
        }
    }
}
