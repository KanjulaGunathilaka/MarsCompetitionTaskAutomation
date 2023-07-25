using MarsCompetitionTaskAutomation.Utils;
using MarsCompetitionTaskAutomation.Helpers;
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

        //Profile Section
        private IWebElement profileSectionLink => driver.FindElement(By.XPath("//div[@class='ui eight item menu']/a[2]"));
        private IWebElement profileNameDiv => driver.FindElement(By.XPath("//div[@class='ui fluid']"));
        private IWebElement profileDescDiv => driver.FindElement(By.XPath("//div[@class='eight wide column']//div[@class='ui fluid card']"));
        private IWebElement profileQualificationsDiv => driver.FindElement(By.XPath("//form[@class='ui form']"));

        //User Name Details Section
        private IWebElement nameExpandBtn => driver.FindElement(By.XPath("//*[@id='account-profile-section']//div[@class='title']/i"));
        private IWebElement firstNameTextBox => driver.FindElement(By.XPath("//input[@name='firstName']"));
        private IWebElement lastNameTextBox => driver.FindElement(By.XPath("//input[@name='lastName']"));
        private IWebElement nameSaveBtn => driver.FindElement(By.XPath("//button[@class='ui teal button']"));
        private IWebElement fullNameDiv => driver.FindElement(By.XPath("//div[@class='title']"));

        //User Preference of Work Section
        private IWebElement availabilityEditBtn => driver.FindElement(By.XPath("//div[@class='item'][2]//div/span/i"));
        private IWebElement availabilityDropDownBtn => driver.FindElement(By.XPath("//select[@class='ui right labeled dropdown' and @name='availabiltyType']"));
        private SelectElement availabilityDropDown => new SelectElement(driver.FindElement(By.XPath("//select[@class='ui right labeled dropdown' and @name='availabiltyType']")));

        private IWebElement hoursEditBtn => driver.FindElement(By.XPath("//div[@class='item'][3]//div/span/i"));
        private IWebElement hoursDropDownBtn => driver.FindElement(By.XPath("//select[@class='ui right labeled dropdown' and @name='availabiltyHour']"));
        private SelectElement hoursDropDown => new SelectElement(driver.FindElement(By.XPath("//select[@class='ui right labeled dropdown' and @name='availabiltyHour']")));

        private IWebElement earnTargetsEditBtn => driver.FindElement(By.XPath("//div[@class='item'][4]//div/span/i"));
        private IWebElement earnTargetsDropDownBtn => driver.FindElement(By.XPath("//select[@class='ui right labeled dropdown' and @name='availabiltyTarget']"));
        private SelectElement earnTargetsDropDown => new SelectElement(driver.FindElement(By.XPath("//select[@class='ui right labeled dropdown' and @name='availabiltyTarget']")));

        //User Description Section
        private IWebElement descriptionEditButton => driver.FindElement(By.XPath("//h3[@class='ui dividing header'][text()='Description']/span/i"));
        private IWebElement descriptionTextArea => driver.FindElement(By.XPath("//textarea[@name='value']"));
        private IWebElement descriptionSaveBtn => driver.FindElement(By.XPath("//div[@class='ui twelve wide column']//button[@class='ui teal button']"));
        private IWebElement successMessageDiv => driver.FindElement(By.XPath("body:nth-child(2) div.ns-box.ns-growl.ns-effect-jelly.ns-type-success.ns-show:nth-child(1) > div.ns-box-inner"));

        //Qualifications Section
        private IWebElement languagesTable => driver.FindElement(By.XPath("//form/div[2]//div[2]/div/table"));
        private IWebElement skillsTable => driver.FindElement(By.XPath("//form/div[3]//div[2]/div/table"));
        private IWebElement educationTable => driver.FindElement(By.XPath("//form/div[4]//div[2]/div/table"));
        private IWebElement certificationsTable => driver.FindElement(By.XPath("//form/div[5]//div[2]/div/table"));

        private IWebElement languageTabLink => driver.FindElement(By.XPath("//a[@data-tab='first']"));
        private IWebElement skillsTabLink => driver.FindElement(By.XPath("//a[@data-tab='second']"));
        private IWebElement educationTabLink => driver.FindElement(By.XPath("//a[@data-tab='third']"));
        private IWebElement certificationTabLink => driver.FindElement(By.XPath("//a[@data-tab='fourth']"));

        private IWebElement LanguageAddNewButton => driver.FindElement(By.XPath("//table[@class='ui fixed table']//th[3]/div[@class='ui teal button ']"));
        private IWebElement LanguageTextBox => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        private IWebElement LanguageLevelDropdownBtn => driver.FindElement(By.XPath("//select[@class='ui dropdown' and @name='level']"));
        private SelectElement LanguageLevelDropDown => new SelectElement(driver.FindElement(By.XPath("//select[@class='ui dropdown' and @name='level']")));
        private IWebElement LanguageAddBtn => driver.FindElement(By.XPath("//input[@value='Add']"));
        private IWebElement LanguageDeleteBtn => driver.FindElement(By.XPath("//tbody//td[@class='right aligned']/span[2]"));


        private IWebElement skillsAddNewBtn => driver.FindElement(By.XPath("//table[@class='ui fixed table']//th[3]/div[@class='ui teal button']"));
        private IWebElement skillsTextBox => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        private IWebElement skillsLevelDropDownBtn => driver.FindElement(By.XPath("//select[@class='ui fluid dropdown' and @name='level']"));
        private SelectElement skillsLevelDropDown => new SelectElement(driver.FindElement(By.XPath("//select[@class='ui fluid dropdown' and @name='level']")));
        private IWebElement skillsAddBtn => driver.FindElement(By.XPath("//input[@value='Add']"));


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

        private IWebElement CertificationAddNewBtn => driver.FindElement(By.XPath("//table[@class='ui fixed table']//th[4]/div[@class='ui teal button ']"));
        private IWebElement CertificateTextBox => driver.FindElement(By.XPath("//input[@name='certificationName']"));
        private IWebElement FromTextBox => driver.FindElement(By.XPath("//input[@name='certificationFrom']"));
        private IWebElement GraduatedYearDropdownBtn => driver.FindElement(By.XPath("//select[@class='ui fluid dropdown' and @name='certificationYear']"));
        private SelectElement GraduatedYearDropDown => new SelectElement(driver.FindElement(By.XPath("//select[@class='ui fluid dropdown' and @name='certificationYear']")));
        private IWebElement CertificationAddBtn => driver.FindElement(By.XPath("//input[@value='Add']"));

        public void EnterNameStep(string firstName, string lastName)
        {
            nameExpandBtn.Click();
            ScrollToElement(driver, firstNameTextBox);
            SetField(firstNameTextBox, firstName);
            SetField(lastNameTextBox, lastName);
        }

        public void SaveNameStep()
        {
            ScrollToElement(driver, nameSaveBtn);
            nameSaveBtn.Click();
            Wait.WaitFor(1000);
        }

        public void VerifyNameStep()
        {
            Assert.That(fullNameDiv.Text == "Sandha Herath", "Save name details successfully.");
        }

        public void AvailabilityStep(string availabilityType)
        {
            ScrollToElement(driver, availabilityEditBtn);
            availabilityEditBtn.Click();
            availabilityDropDownBtn.Click();
            Thread.Sleep(1000);
            availabilityDropDown.SelectByText(availabilityType);
        }

        public void HoursStep(string HoursType)
        {
            hoursEditBtn.Click();
            hoursDropDownBtn.Click();
            Thread.Sleep(1000);
            hoursDropDown.SelectByText(HoursType);
        }

        public void TargetStep(string TargetsType)
        {
            earnTargetsEditBtn.Click();
            earnTargetsDropDownBtn.Click();
            Wait.WaitFor(500);
            earnTargetsDropDown.SelectByText(TargetsType);
        }

        public void AddDescriptionStep(string description)
        {
            descriptionEditButton.Click();
            descriptionTextArea.Click();
            SetField(descriptionTextArea, description);
            descriptionSaveBtn.Click();
            Wait.WaitFor(5000);
        }

        public void AddLanguagesStep(string language, string level)
        {
            DeleteTableRowIfExists(languagesTable);
            LanguageAddNewButton.Click();
            Wait.WaitFor(500);
            SetField(LanguageTextBox, language);
            LanguageLevelDropdownBtn.Click();
            LanguageLevelDropDown.SelectByText(level);
            LanguageAddBtn.Click();
            Wait.WaitFor(500);
            Assert.IsTrue(IsDataVisibleInTableRow(languagesTable, language), "Language is not added successfully");
        }

        public void AddSkillsStep(string skill, string level)
        {
            skillsTabLink.Click();
            Wait.WaitFor(500);
            DeleteTableRowIfExists(skillsTable);
            skillsAddNewBtn.Click();
            Wait.WaitFor(500);
            SetField(skillsTextBox, skill);
            skillsLevelDropDownBtn.Click();
            skillsLevelDropDown.SelectByText(level);
            skillsAddBtn.Click();
            Wait.WaitFor(500);
            Assert.IsTrue(IsDataVisibleInTableRow(skillsTable, skill), "Skill is not added successfully");
        }

        public void AddEducationStep(string university, string country, string title, string degree, string year)
        {
            educationTabLink.Click();
            Wait.WaitFor(1000);
            DeleteTableRowIfExists(educationTable);
            EducationAddNewBtn.Click();
            Wait.WaitFor(500);
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
            Assert.IsTrue(IsDataVisibleInTableRow(educationTable, country), "Education is not added successfully");
        }

        public void AddCertificationStep(string certification, string from, string year)
        {
            certificationTabLink.Click();
            Wait.WaitFor(1000);
            DeleteTableRowIfExists(certificationsTable);
            CertificationAddNewBtn.Click();
            Wait.WaitFor(500);
            SetField(CertificateTextBox, certification);
            SetField(FromTextBox, from);
            GraduatedYearDropdownBtn.Click();
            GraduatedYearDropDown.SelectByText(year);
            CertificationAddBtn.Click();
            Wait.WaitFor(1000);
            Assert.IsTrue(IsDataVisibleInTableRow(certificationsTable, certification), "Certification is not added successfully");
        }

        public void VerifyProfileSection()
        {
            profileSectionLink.Click();
            Wait.WaitFor(10000);
            Assert.IsTrue(profileNameDiv.Displayed, "profileNameDiv is not visible");
            Assert.IsTrue(profileDescDiv.Displayed, "profileDescDiv is not visible");
            Assert.IsTrue(profileQualificationsDiv.Displayed, "profileQualificationsDiv is not visible");
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
