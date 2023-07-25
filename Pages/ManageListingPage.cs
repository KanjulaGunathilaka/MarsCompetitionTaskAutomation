using AventStack.ExtentReports.Model;
using MarsCompetitionTaskAutomation.Utils;
using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetitionTaskAutomation.Pages
{
    public class ManageListingPage
    {
        private IWebDriver driver;
        private static readonly Logger Logger = LoggerManager.Logger;

        public ManageListingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement manageListingLink => driver.FindElement(By.XPath("//div[@class='ui eight item menu']/a[3]"));
        private IWebElement manageListingHeader => driver.FindElement(By.XPath("//h2[text()='Manage Listings']"));
        private IWebElement manageListingTable => driver.FindElement(By.XPath("//table[@class='ui striped table']"));

        private IWebElement skillTitleSpan => driver.FindElement(By.XPath("//span[@class='skill-title']"));
        private IWebElement descriptionSpan => driver.FindElement(By.XPath("//div[text()='Description']/following-sibling::div"));
        private IWebElement categorySpan => driver.FindElement(By.XPath("//div[text()='Category']/following-sibling::div"));
        private IWebElement subCategorySpan => driver.FindElement(By.XPath("//div[text()='Subcategory']/following-sibling::div"));
        private IWebElement serviceTypeOption => driver.FindElement(By.XPath("//div[text()='Service Type']/following-sibling::div"));

        private IWebElement listingTableViewBtn => driver.FindElement(By.XPath("//td[@class='two wide ']//button/i[@class='eye icon']"));
        private IWebElement listingTableEditBtn => driver.FindElement(By.XPath("//td[@class='two wide ']//button/i[@class='outline write icon']"));
        private IWebElement listingTableRemoveBtn => driver.FindElement(By.XPath("//td[@class='two wide ']//button/i[@class='remove icon']"));
        private IWebElement actionModalDeleteYesBtn => driver.FindElement(By.XPath("//div[@class='actions']/button[2]"));
        private IWebElement actionModalDeleteNoBtn => driver.FindElement(By.XPath("//div[@class='actions']/button[1]"));

        public void NavigateToManageListingsStep()
        {
            manageListingLink.Click();
            Wait.WaitFor(500);
        }

        public void verifySharedSkillDetails(string title, string description, string category, string subCategory, string serviceType)
        {
                Assert.That(skillTitleSpan.Text == title, "Saved title details mismatch.");
                Assert.That(descriptionSpan.Text == description, "Saved Description details mismatch.");
                Assert.That(categorySpan.Text == category, "Category type details mismatch.");
                Assert.That(subCategorySpan.Text == subCategory, "Sub Category type details mismatch.");
                Assert.That(serviceTypeOption.Text == serviceType, "Saved Service type details mismatch.");
        }

        //public void verifySavedSkillStep(Table table)
        //{
        //    bool isDataPresent = IsDataPresentInTable(manageListingTable, table);
        //    Assert.IsTrue(isDataPresent, "Table does not contain the specified data.");
        //}

        public void DeleteSkillsStep()
        {
            if (IsElementDisplayed(manageListingHeader))
            {
                RemoveSkillsFromTableRowIfExists(manageListingTable);
            }
            else
            {
                manageListingLink.Click();
                Wait.WaitFor(500);
                RemoveSkillsFromTableRowIfExists(manageListingTable);
            }
        }

        public void ViewProfileDetailsStep()
        {
            listingTableViewBtn.Click();
            Wait.WaitFor(1000);
            Assert.IsTrue(skillTitleSpan.Displayed, "Skill Title is not displayed");
        }

        private bool IsElementDisplayed(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch
            {
                return false;
            }
        }

        //private bool IsDataPresentInTable(IWebElement table, Table expectedData)
        //{
        //    try
        //    {
        //        if (!table.Displayed)
        //        {
        //            Logger.Info("Table is not displayed.");
        //            return false;
        //        }

        //        IReadOnlyCollection<IWebElement> rows = table.FindElements(By.TagName("tr"));

        //        foreach (IWebElement row in rows)
        //        {
        //            IList<IWebElement> rowData = row.FindElements(By.TagName("td"));

        //            if (rowData.Count >= 3)
        //            {
        //                string category = rowData[1].Text;
        //                string title = rowData[2].Text;

        //                if (expectedData.Rows.Any(expectedRow =>
        //                    expectedRow["Title"] == title && expectedRow["Category"] == category))
        //                {
        //                    return true;
        //                }
        //            }
        //        }
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        Logger.Info("Table is not present.");
        //        return false;
        //    }

        //    return false;
        //}

        private void RemoveSkillsFromTableRowIfExists(IWebElement table)
        {
            try
            {
                IReadOnlyCollection<IWebElement> rows = table.FindElements(By.TagName("tr"));
                if (rows.Count > 0)
                {
                    IWebElement deleteButton = null;
                    bool deleteButtonFound = false;
                    foreach (IWebElement row in rows)
                    {
                        deleteButton = row.FindElement(By.XPath("//td[@class='two wide ']//button/i[@class='remove icon']"));
                        if (deleteButton != null)
                        {
                            deleteButtonFound = true;
                            break;
                        }
                    }
                    if (deleteButtonFound)
                    {
                        deleteButton.Click();
                        Wait.WaitFor(500);
                        actionModalDeleteYesBtn.Click();
                        Wait.WaitFor(1000);
                    }
                    else
                    {
                        Logger.Info("Delete button not found in any row.");
                    }
                }
                else
                {
                    Logger.Info("No rows found in the table.");
                }
            }
            catch
            {
                Logger.Info("Table or delete button not found.");
            }
        }

    }
}
