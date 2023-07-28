using MarsCompetitionTaskAutomation.Utils;
using MarsCompetitionTaskAutomation.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static System.Collections.Specialized.BitVector32;

namespace MarsCompetitionTaskAutomation.Pages
{
    public class ProfilePage : CommonMethods
    {
        private IWebDriver driver;

        public ProfilePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement EducationBtn => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));
        private IWebElement EducationText => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[1]/h3"));
        private IWebElement EducationAddNewBtn => driver.FindElement(By.XPath("//table[@class='ui fixed table']//th[6]/div[@class='ui teal button ']"));
        private IWebElement UniversityTextBox => driver.FindElement(By.XPath("//input[@name='instituteName']"));
        private IWebElement CountryDropdownBtn => driver.FindElement(By.XPath("//select[@class='ui dropdown' and @name='country']"));
        private SelectElement CountryDropdown => new SelectElement(driver.FindElement(By.XPath("//select[@class='ui dropdown' and @name='country']")));
        private IWebElement TitleDropdownBtn => driver.FindElement(By.XPath("//select[@class='ui dropdown' and @name='title']"));
        private SelectElement TitleDropdown => new SelectElement(driver.FindElement(By.XPath("//select[@class='ui dropdown' and @name='title']")));
        private IWebElement DegreeTextBox => driver.FindElement(By.XPath("//input[@name='degree']"));
        private IWebElement YearDropdownBtn => driver.FindElement(By.XPath("//select[@class='ui dropdown' and @name='yearOfGraduation']"));
        private SelectElement YearDropdown => new SelectElement(driver.FindElement(By.XPath("//select[@class='ui dropdown' and @name='yearOfGraduation']")));
        private IWebElement EducationAddBtn => driver.FindElement(By.XPath("//input[@value='Add']"));
        private IWebElement EducationCancelBtn => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[2]"));
        private IWebElement EducationEditBtn => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[1]/i"));
        private IWebElement EducationUpdateBtn => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td/div[3]/input[1]"));
        private IWebElement UpdatePopUpMsg => driver.FindElement(By.XPath("//input[@value='Add']"));


        private IWebElement CertificationBtn => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));
        private IWebElement CertificationAddNewBtn => driver.FindElement(By.XPath("//table[@class='ui fixed table']//th[4]/div[@class='ui teal button ']"));
        private IWebElement CertificateTextBox => driver.FindElement(By.XPath("//input[@name='certificationName']"));
        private IWebElement FromTextBox => driver.FindElement(By.XPath("//input[@name='certificationFrom']"));
        private IWebElement GraduatedYearDropdownBtn => driver.FindElement(By.XPath("//select[@class='ui fluid dropdown' and @name='certificationYear']"));
        private SelectElement GraduatedYearDropDown => new SelectElement(driver.FindElement(By.XPath("//select[@class='ui fluid dropdown' and @name='certificationYear']")));
        private IWebElement CertificationAddBtn => driver.FindElement(By.XPath("/html/body/div[1]"));


        public void NavigateEducationSectionStep() 
        {
            EducationBtn.Click();
            Wait.WaitFor(1000);
            Assert.IsTrue(EducationText.Text.Equals("Education"), "Education section not visible");
        }
        public void EducationAddNewButtonStep()
        {
            EducationAddNewBtn.Click();
            Wait.WaitFor(500);
            Assert.IsTrue(UniversityTextBox.Displayed.Equals("University"), "University section not visible");
        }
        public void AddEducationStep(string university, string country, string title, string degree, string year)
        {
 
            SetField(UniversityTextBox, university);
            CountryDropdownBtn.Click();
            CountryDropdown.SelectByText(country);
            TitleDropdownBtn.Click();
            TitleDropdown.SelectByText(title);
            SetField(DegreeTextBox, degree);
            YearDropdownBtn.Click();
            YearDropdown.SelectByText(year);
            EducationAddBtn.Click();
            Wait.WaitFor(1000);
            Assert.IsTrue(UniversityTextBox.Displayed.Equals("university"), "Education is not added successfully");
        }

        public void CancelButtonStep(string university)
        {
            EducationAddNewBtn.Click();
            UniversityTextBox.SendKeys(university);
            EducationCancelBtn.Click();
            Wait.WaitFor(1000);
            Assert.IsTrue(EducationAddNewBtn.Displayed, "Cancel button not clicked correctly");
        }

        public void EditAndUpdateStep(string university)
        {
            EducationEditBtn.Click();
            UniversityTextBox.SendKeys(university);
            EducationUpdateBtn.Click();

            Assert.That(UpdatePopUpMsg.Displayed, "Education details not updated successfully");

        }

        public void AddCertificationStep(string certification, string from, string year)
        {
            CertificationBtn.Click();
            Wait.WaitFor(1000);
            CertificationAddNewBtn.Click();
            Wait.WaitFor(500);
            SetField(CertificateTextBox, certification);
            SetField(FromTextBox, from);
            GraduatedYearDropdownBtn.Click();
            GraduatedYearDropDown.SelectByText(year);
            CertificationAddBtn.Click();
            Wait.WaitFor(1000);
            Assert.IsTrue(CertificateTextBox.Displayed.Equals("certification"), "Certification is not added successfully");
        }

        


        private void DeleteTableRowIfExists(IWebElement table)
        {
            try
            {
                IReadOnlyCollection<IWebElement> rows = table.FindElements(By.TagName("tbody"));
                if (rows.Count > 0)
                {
                    IWebElement deleteButton = null;
                    bool deleteButtonFound = false;
                    foreach (IWebElement row in rows)
                    {
                        deleteButton = row.FindElement(By.CssSelector("td.right.aligned > span:nth-child(2)"));
                        if (deleteButton != null)
                        {
                            deleteButtonFound = true;
                            break;
                        }
                    }
                    if (deleteButtonFound)
                    {
                        deleteButton.Click();
                    }
                    else
                    {
                        Console.WriteLine("Delete button not found in any row.");
                    }
                }
                else
                {
                    Console.WriteLine("No rows found in the table.");
                }
            }
            catch
            {
                Console.WriteLine("Table or delete button not found.");
            }
        }

        private bool IsDataVisibleInTableRow(IWebElement table, string qualification)
        {
            IReadOnlyCollection<IWebElement> tableRows = table.FindElements(By.TagName("tbody"));

            foreach (IWebElement row in tableRows)
            {
                IEnumerable<IWebElement> tableData = row.FindElements(By.TagName("td"));

                foreach (IWebElement data in tableData)
                {
                    if (data.Text.Contains(qualification))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        
    }
}
