using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using MarsCompetitionTaskAutomation.Helpers;
using MarsCompetitionTaskAutomation.Utilities.DataModel;
using MarsCompetitionTaskAutomation.Utilities.Utils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Diagnostics.Metrics;

namespace MarsCompetitionTaskAutomation.Tests
{
    [TestFixture]
    public class EducationDetailsTest : BaseTest
    {
        private EducationTestData testData;

        [SetUp]
        public void TestSetUp()
        {
            testData = TestDataProviders.GetEducationTestDataForTestCase(TestContext.CurrentContext.Test.Name);
        }

        /**
         * This test user login flow with correct user details and check the profile update flow
         * This test user navigate to Education section by clicking Education Button
         
         */
        [Test, Order(1), Description("This test checks if a user is able to Navigate Education section")]
        public void TestUserNavigateEducationSection()
        {
            signInPage.SignIn(testData.email, testData.password);
            profilePage.NavigateEducationSectionStep();
        }

        [Test, Order(2), Description("This test checks if a user is able to Add Education Details Education section")]
        public void TestAddEducationSection()
        {
            signInPage.SignIn(testData.email, testData.password);
            profilePage.NavigateEducationSectionStep();
            profilePage.EducationAddNewButtonStep();
            profilePage.AddEducationStep(testData.university, testData.country, testData.title, testData.degree, testData.year);
        }

        [Test, Order(3), Description("This test checks if a user is able to cancel added details section")]
        public void TestCancelEducationSection()
        {
            signInPage.SignIn(testData.email, testData.password);
            profilePage.NavigateEducationSectionStep();
            profilePage.EducationAddNewButtonStep();
            profilePage.CancelButtonStep(testData.university);
        }

        [Test, Order(4), Description("This test checks if a user is able to Edit and Update Added Education details section")]
        public void TestEditAndUpdateSection()
        {
            signInPage.SignIn(testData.email, testData.password);
            profilePage.NavigateEducationSectionStep();
            profilePage.EducationAddNewButtonStep();
            profilePage.AddEducationStep(testData.university, testData.country, testData.title, testData.degree, testData.year);
            profilePage.EducationEditAndUpdateStep(testData.newUniversity);
        }

        [Test, Order(5), Description("This test checks if a user is able to Delete added Education details section")]
        public void TestDeleteSection()
        {
            signInPage.SignIn(testData.email, testData.password);
            profilePage.NavigateEducationSectionStep();
            profilePage.EducationAddNewButtonStep();
            profilePage.AddEducationStep(testData.university, testData.country, testData.title, testData.degree, testData.year);
            profilePage.EducationDeleteStep();
        }

        [Test, Order(6), Description("This test checks if a user trying to added new entry with all incomplete Education details")]
        public void TestIncompleteStepAllFields()
        {
            signInPage.SignIn(testData.email, testData.password);
            profilePage.NavigateEducationSectionStep();
            profilePage.EducationAddNewButtonStep();
            profilePage.EducationIncompleteStep();
        }

        [Test, Order(7), Description("This test checks if a user trying to added new entry with just University")]
        public void TestIncompleteStepOnlyUniversityPresent()
        {
            signInPage.SignIn(testData.email, testData.password);
            profilePage.NavigateEducationSectionStep();
            profilePage.EducationAddNewButtonStep();
            profilePage.EducationIncompleteStep1(testData.university);
        }

        [Test, Order(8), Description("This test checks if a user trying to added new entry with just university and country")]
        public void TestIncompleteOnlyUniAndCountry()
        {
            signInPage.SignIn(testData.email, testData.password);
            profilePage.NavigateEducationSectionStep();
            profilePage.EducationAddNewButtonStep();
            profilePage.EducationIncompleteStep2(testData.university, testData.country);
        }

        [Test, Order(9), Description("This test checks if a user trying to added new entry with existing Education details")]
        public void EducationExistingStep()
        {
            signInPage.SignIn(testData.email, testData.password);
            profilePage.NavigateEducationSectionStep();
            profilePage.EducationAddNewButtonStep();
            profilePage.AddEducationStep(testData.university, testData.country, testData.title, testData.degree, testData.year);
            profilePage.EducationAddNewButtonStep();
            profilePage.EducationExistingStep(testData.university, testData.country, testData.title, testData.degree, testData.year);
        }

    }

}