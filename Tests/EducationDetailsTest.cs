using AventStack.ExtentReports.Model;
using NUnit.Framework;
using System.Diagnostics.Metrics;

namespace MarsCompetitionTaskAutomation.Tests
{
    [TestFixture]
    public class EducationDetailsTest : BaseTest
    {
        /**
         * This test user login flow with correct user details and check the profile update flow
         * This test user navigate to Education section by clicking Education Button
         
         */
        [Test, Order(1), Description("This test checks if a user is able to Navigate Education section")]
        public void TestUserNavigateEducationSection()
        {
            signInPage.SignIn("sandhaherath93@gmail.com", "Sandha@93");
            profilePage.NavigateEducationSectionStep();
        }

        [Test, Order(2), Description("This test checks if a user is able to Add Education Details Education section")]
        public void TestAddEducationSection()
        {
            signInPage.SignIn("sandhaherath93@gmail.com", "Sandha@93");
            profilePage.NavigateEducationSectionStep();
            profilePage.EducationAddNewButtonStep();
            profilePage.AddEducationStep("Victoria University", "Australia", "B.Tech", "BSc IT", "2022");

        }

        [Test, Order(3), Description("This test checks if a user is able to cancel added details section")]
        public void TestCancelEducationSection()
        {
            signInPage.SignIn("sandhaherath93@gmail.com", "Sandha@93");
            profilePage.NavigateEducationSectionStep();
            profilePage.EducationAddNewButtonStep();
            profilePage.CancelButtonStep("Massey");

        }

        [Test, Order(4), Description("This test checks if a user is able to Edit and Update Added Education  details section")]
        public void TestEditAndUpdateSection()
        {
            signInPage.SignIn("sandhaherath93@gmail.com", "Sandha@93");
            profilePage.NavigateEducationSectionStep();
            profilePage.EducationAddNewButtonStep();
            profilePage.AddEducationStep("Victoria University", "Australia", "B.Tech", "BSc IT", "2022");
            profilePage.EducationEditAndUpdateStep("Oxford");
        }

        [Test, Order(5), Description("This test checks if a user is able to Delete added Education details section")]
        public void TestDeleteSection()
        {
            signInPage.SignIn("sandhaherath93@gmail.com", "Sandha@93");
            profilePage.NavigateEducationSectionStep();
            profilePage.EducationAddNewButtonStep();
            profilePage.AddEducationStep("Victoria University", "Australia", "B.Tech", "BSc IT", "2022");
            profilePage.EducationDeleteStep();
        }

        [Test, Order(6), Description("This test checks if a user trying to added new entry with uncomplete Education details section")]
        public void TestIncompleteStep()
        {
            signInPage.SignIn("sandhaherath93@gmail.com", "Sandha@93");
            profilePage.NavigateEducationSectionStep();
            profilePage.EducationAddNewButtonStep();
            profilePage.EducationIncompleteStep();
        }

        [Test, Order(7), Description("This test checks if a user trying to added new entry with uncomplete Education details section")]
        public void TestIncompleteStep1()
        {
            signInPage.SignIn("sandhaherath93@gmail.com", "Sandha@93");
            profilePage.NavigateEducationSectionStep();
            profilePage.EducationAddNewButtonStep();
            profilePage.EducationIncompleteStep1("Massey");
        }

        [Test, Order(8), Description("This test checks if a user trying to added new entry with uncomplete Education details section")]
        public void TestIncompleteStep2()
        {
            signInPage.SignIn("sandhaherath93@gmail.com", "Sandha@93");
            profilePage.NavigateEducationSectionStep();
            profilePage.EducationAddNewButtonStep();
            profilePage.EducationIncompleteStep2("Massey", "New Zealand");
        }

        [Test, Order(9), Description("This test checks if a user trying to added new entry with uncomplete Education details section")]
        public void EducationExistingStep()
        {
            signInPage.SignIn("sandhaherath93@gmail.com", "Sandha@93");
            profilePage.NavigateEducationSectionStep();
            profilePage.EducationAddNewButtonStep();
            profilePage.AddEducationStep("Victoria University", "Australia", "B.Tech", "BSc IT", "2022");
            profilePage.EducationAddNewButtonStep();
            profilePage.EducationExistingStep("Victoria University", "Australia", "B.Tech", "BSc IT", "2022");
        }

    }

}