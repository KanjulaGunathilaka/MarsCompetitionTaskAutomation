using AventStack.ExtentReports.Model;
using NUnit.Framework;

namespace MarsCompetitionTaskAutomation.Tests
{
    [TestFixture]
    public class EducationAndCertTest : BaseTest
    {
        /**
         * This test will verify the user login flow with correct user details and check the profile update flow
         * There are multiple parameters passed to the test case
         * Need to update test to get the test data from a json file
         */
        [Test, Order(1), Description("This test checks if a user is able to login to website and add profile details")]
        public void TestSignInAndProfileVerification()
        {
            signInPage.SignIn("sandhaherath93@gmail.com", "Sandha@93");
            profilePage.EnterNameStep("Sandha", "Herath");
            profilePage.AvailabilityStep("Part Time");
            profilePage.HoursStep("Less than 30hours a week");
            profilePage.TargetStep("Less than $500 per month");
            profilePage.AddDescriptionStep("Experienced IT Solutions");
            profilePage.AddLanguagesStep("English", "Basic");
            profilePage.AddSkillsStep("Functional Testing", "Beginner");
            profilePage.AddEducationStep("Victoria University", "Australia", "B.Tech", "BSc IT", "2022");
            profilePage.AddCertificationStep("ISTQB CTFL", "ISTQB", "2022");
            profilePage.VerifyProfileSection();
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