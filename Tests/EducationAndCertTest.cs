using AventStack.ExtentReports.Model;
using NUnit.Framework;
using System.Diagnostics.Metrics;

namespace MarsCompetitionTaskAutomation.Tests
{
    [TestFixture]
    public class EducationAndCertTest : BaseTest
    {
        /**
         * This test user login flow with correct user details and check the profile update flow
         * This test user navigate to Education section by clicking Education Button
         
         */
        [Test, Order(1), Description("This test checks if a user is able to Navigate Education section")]
        public void TestSellerNavigateEducationSection()
        {
            signInPage.SignIn("sandhaherath93@gmail.com", "Sandha@93");
            profilePage.NavigateEducationSectionStep();
            profilePage.EducationAddNewButtonStep();
            profilePage.AddEducationStep("Victoria University", "Australia", "B.Tech", "BSc IT", "2022");
            profilePage.CancelButtonStep("Peradeniya");
            profilePage.EditAndUpdateStep("Peradeniya");



            
        }

        /**
        * This test will verify the user login flow with correct user details and check seller can see the added skill details correctly
        * There are multiple parameters passed to the test case
        * Need to update test to get the test data from a json file
        */
        [Test, Order(2), Description("This test checks if a user is able to see the added skills details")]
        public void TestSellerViewAddedSkillsDetails()
        {
            signInPage.SignIn("sandhaherath93@gmail.com", "Sandha@93");
            sharePage.NavigateStep();
            sharePage.AddTitleStep("View Skills Shared");
            sharePage.AddShareDescriptionStep("This is to test View Skills page");
            sharePage.SelectCategoryStep("Graphics & Design", "Logo Design");
            sharePage.AddTags("viewTag1", "viewTag2");
            sharePage.SelectServiceTypeStep("Hourly basis service");
            sharePage.SelectLocationTypeStep("On-site");
            sharePage.AvailableDaysStep("31/12/2023", "30/12/2024");
            sharePage.SelectSkillTradeStep("On-site");
            sharePage.ActiveStep("Active");
            sharePage.SaveSharePageStep();

            manageListingPage.NavigateToManageListingsStep();
            manageListingPage.ViewProfileDetailsStep();

            manageListingPage.verifySharedSkillDetails("View Skills Shared", "This is to test View Skills page", "Graphics & Design", "Logo Design", "Hourly");
            manageListingPage.NavigateToManageListingsStep();
            manageListingPage.DeleteSkillsStep();
        }
    }
}