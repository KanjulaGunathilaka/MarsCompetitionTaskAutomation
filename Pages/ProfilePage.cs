using MarsCompetitionTaskAutomation.Helpers;
using MarsCompetitionTaskAutomation.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
        private IWebElement EducationEditBtn => driver.FindElement(By.XPath("//td[@class='right aligned']//span/i[@class='outline write icon']"));
        private IWebElement EducationUpdateBtn => driver.FindElement(By.XPath("//input[@value='Update']"));
        private IWebElement UpdatePopUpMsg => driver.FindElement(By.XPath("//div[contains(text(),'Education as been updated')]"));
        private IWebElement AddSuccessMsg => driver.FindElement(By.XPath("/html/body/div[1]"));
        private IWebElement EducationDeleteBtn => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[2]/i"));
        private IWebElement RemovePopUpMsg => driver.FindElement(By.XPath("/html/body/div[1]/div"));
        private IWebElement IncompletePopUpMsg => driver.FindElement(By.XPath("//div[contains(text(),'Please enter all the fields')]"));
        private IWebElement ExistPopUpMsg => driver.FindElement(By.XPath("//div[contains(text(),'This information is already exist.')]"));

        private IWebElement CertificationText => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[1]/h3"));
        private IWebElement CertificationAddBtn => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]"));
        private IWebElement certificationTabLink => driver.FindElement(By.XPath("//a[@data-tab='fourth']"));
        private IWebElement CertificationAddNewBtn => driver.FindElement(By.XPath("//table[@class='ui fixed table']//th[4]/div[@class='ui teal button ']"));
        private IWebElement CertificateTextBox => driver.FindElement(By.XPath("//input[@name='certificationName']"));
        private IWebElement FromTextBox => driver.FindElement(By.XPath("//input[@name='certificationFrom']"));
        private IWebElement GraduatedYearDropdownBtn => driver.FindElement(By.XPath("//select[@class='ui fluid dropdown' and @name='certificationYear']"));
        private SelectElement GraduatedYearDropDown => new SelectElement(driver.FindElement(By.XPath("//select[@class='ui fluid dropdown' and @name='certificationYear']")));
        private IWebElement AddedSuccessMSG => driver.FindElement(By.XPath("//div[contains(text(),'has been added to your certification')]"));
        private IWebElement CertificationCancelBtn => driver.FindElement(By.XPath("//form/div[4]//div[2]/div/table"));
        private IWebElement certificationUpdateBtn => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
        private IWebElement UpdatedPopUpMsg => driver.FindElement(By.XPath("//div[contains(text(),'IT has been updated to your certification')]"));
        private IWebElement CertificationDeleteBtn => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i"));
        private IWebElement RemovedPopUpMsg => driver.FindElement(By.XPath("//div[contains(text(),'istqb has been deleted from your certification')]"));

        private IWebElement educationTable => driver.FindElement(By.XPath("//form/div[4]//div[2]/div/table"));
        private IWebElement certificationsTable => driver.FindElement(By.XPath("//form/div[5]//div[2]/div/table"));


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
            Assert.IsTrue(UniversityTextBox.Displayed, "University section not visible");
        }
        public void AddEducationStep(string university, string country, string title, string degree, string year)
        {
            DeleteTableRowIfExists(educationTable);
            Wait.WaitFor(4000);
            SetField(UniversityTextBox, university);
            CountryDropdownBtn.Click();
            CountryDropdown.SelectByText(country);
            TitleDropdownBtn.Click();
            TitleDropdown.SelectByText(title);
            SetField(DegreeTextBox, degree);
            YearDropdownBtn.Click();
            YearDropdown.SelectByText(year);
            EducationAddBtn.Click();
            Assert.IsTrue(AddSuccessMsg.Displayed, "Education is not added successfully");
            Wait.WaitFor(4000);
        }

        public void CancelButtonStep(string university)
        {
            UniversityTextBox.SendKeys(university);
            EducationCancelBtn.Click();
            Wait.WaitFor(1000);
            Assert.IsTrue(EducationAddNewBtn.Displayed, "Cancel button not clicked correctly");
        }

        public void EducationEditAndUpdateStep(string university)
        {
            EditTableRowIfExists(educationTable);
            Wait.WaitFor(2000);
            SetField(UniversityTextBox, university);
            EducationUpdateBtn.Click();

            Assert.That(UpdatePopUpMsg.Text.Equals("Education as been updated"), "Education details not updated successfully");

        }

        public void EducationDeleteStep()
        {
            EducationDeleteBtn.Click();
            Assert.That(RemovePopUpMsg.Displayed, "Education details not Deleted successfully");

        }

        public void EducationIncompleteStep()
        {
            EducationAddBtn.Click();
            Wait.WaitFor(2000);
            Assert.That(IncompletePopUpMsg.Text.Equals("Please enter all the fields"), "Education details  added successfully");
        }
        public void EducationIncompleteStep1(string university)
        {

            SetField(UniversityTextBox, university);
            EducationAddBtn.Click();
            Wait.WaitFor(2000);
            Assert.That(IncompletePopUpMsg.Text.Equals("Please enter all the fields"), "Education details  added successfully");

        }

        public void EducationIncompleteStep2(string university, string country)
        {

            SetField(UniversityTextBox, university);
            CountryDropdownBtn.Click();
            CountryDropdown.SelectByText(country);
            EducationAddBtn.Click();
            Wait.WaitFor(2000);
            Assert.That(IncompletePopUpMsg.Text.Equals("Please enter all the fields"), "Education details  added successfully");

        }
        public void EducationExistingStep(string university, string country, string title, string degree, string year)
        {
            Wait.WaitFor(2000);
            SetField(UniversityTextBox, university);
            CountryDropdownBtn.Click();
            CountryDropdown.SelectByText(country);
            TitleDropdownBtn.Click();
            TitleDropdown.SelectByText(title);
            SetField(DegreeTextBox, degree);
            YearDropdownBtn.Click();
            YearDropdown.SelectByText(year);
            EducationAddBtn.Click();
            Assert.That(ExistPopUpMsg.Text.Contains("This information is already exist"), "Error not displayed correctly");

        }

        public void NavigateCertificationSectionStep()
        {
            certificationTabLink.Click();
            Wait.WaitFor(1000);
            Assert.IsTrue(CertificationText.Text.Equals("Certification"), "Certification section not visible");
        }

        public void CertificationAddNewButtonStep()
        {
            CertificationAddNewBtn.Click();
            Wait.WaitFor(500);
            Assert.IsTrue(CertificateTextBox.Displayed, "Certification section not visible");
        }

        public void AddCertificationStep(string certification, string from, string year)
        {
            DeleteTableRowIfExists(certificationsTable);
            Wait.WaitFor(3000);
            SetField(CertificateTextBox, certification);
            SetField(FromTextBox, from);
            GraduatedYearDropdownBtn.Click();
            GraduatedYearDropDown.SelectByText(year);
            CertificationAddBtn.Click();
            Assert.IsTrue(AddedSuccessMSG.Displayed, "Certification is not added successfully");
            Wait.WaitFor(1000);
        }

        public void CertificateCancelButtonStep(string certification)
        {
            CertificateTextBox.SendKeys(certification);
            CertificationCancelBtn.Click();
            Wait.WaitFor(1000);
            Assert.IsTrue(CertificationAddNewBtn.Displayed, "Cancel button not clicked correctly");
        }

        public void CertificationEditAndUpdateStep(string certification)
        {
            EditTableRowIfExists(certificationsTable);
            Wait.WaitFor(2000);
            SetField(UniversityTextBox, certification);
            certificationUpdateBtn.Click();

            Assert.That(UpdatedPopUpMsg.Text.Equals("Certification as been updated"), "Certification details not updated successfully");

        }

        public void CertificationDeleteStep()
        {
            CertificationDeleteBtn.Click();
            Assert.That(RemovedPopUpMsg.Displayed, "Certification details not Deleted successfully");

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

        private void EditTableRowIfExists(IWebElement table)
        {
            try
            {
                IReadOnlyCollection<IWebElement> rows = table.FindElements(By.TagName("tbody"));
                if (rows.Count > 0)
                {
                    IWebElement editButton = null;
                    bool editButtonFound = false;
                    foreach (IWebElement row in rows)
                    {
                        editButton = row.FindElement(By.CssSelector("td.right.aligned > span:nth-child(1)"));
                        if (editButton != null)
                        {
                            editButtonFound = true;
                            break;
                        }
                    }
                    if (editButtonFound)
                    {
                        editButton.Click();
                    }
                    else
                    {
                        Console.WriteLine("Edit button not found in any row.");
                    }
                }
                else
                {
                    Console.WriteLine("No rows found in the table.");
                }
            }
            catch
            {
                Console.WriteLine("Table or edit button not found.");
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
