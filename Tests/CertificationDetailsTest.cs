using AventStack.ExtentReports.Model;
using MarsCompetitionTaskAutomation.Helpers;
using MarsCompetitionTaskAutomation.Utilities.DataModel;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Diagnostics.Metrics;

namespace MarsCompetitionTaskAutomation.Tests
{
    [TestFixture]
    public class CertificationDetailsTest : BaseTest
    {
        private CertificationTestData testData;

        [SetUp]
        public void TestSetUp()
        {
            testData = TestDataProviders.GetCertificationTestDataForTestCase(TestContext.CurrentContext.Test.Name);
        }

        /**
         * This test user login flow with correct user details and check the profile update flow
         * This test user navigate to Education section by clicking Education Button
         
         */
        [Test, Order(1),  Description("This test checks if a user is able to see the Certification Section")]
        public void NavigateCertificationSectionStep()
        {
            signInPage.SignIn(testData.email, testData.password);
            profilePage.NavigateCertificationSectionStep();

        }

        [Test, Order(2), Description("This test checks if a user is able to navigate Add Education section")]
        public void TestAddCertificationSection()
        {
            signInPage.SignIn(testData.email, testData.password);
            profilePage.NavigateCertificationSectionStep();
            profilePage.CertificationAddNewButtonStep();
            profilePage.AddCertificationStep(testData.certification, testData.from, testData.year);

        }

        [Test, Order(3), Description("This test checks if a user is able to cancel added details section")]
        public void TestCancelCertificationSection()
        {
            signInPage.SignIn(testData.email, testData.password);
            profilePage.NavigateCertificationSectionStep();
            profilePage.CertificationAddNewButtonStep();
            profilePage.CertificateCancelButtonStep(testData.certification);

        }

        [Test, Order(4), Description("This test checks if a user is able to Edit and Update Added Education details section")]
        public void CertificationEditAndUpdateSection()
        {
            signInPage.SignIn(testData.email, testData.password);
            profilePage.NavigateCertificationSectionStep();
            profilePage.CertificationAddNewButtonStep();
            profilePage.AddCertificationStep(testData.certification, testData.from, testData.year);
            profilePage.CertificationEditAndUpdateStep(testData.newCertification);
        }

        [Test, Order(5), Description("This test checks if a user is able to Delete added Education details section")]
        public void CertificationDeleteSection()
        {
            signInPage.SignIn(testData.email, testData.password);
            profilePage.NavigateCertificationSectionStep();
            profilePage.CertificationAddNewButtonStep();
            profilePage.AddCertificationStep(testData.certification, testData.from, testData.year);
            profilePage.CertificationDeleteStep();
        }

        [Test, Order(6), Description("This test checks if a user trying to added new entry with all incomplete Certification details section")]
        public void TestIncompleteStepAllFields()
        {
            signInPage.SignIn(testData.email, testData.password);
            profilePage.NavigateCertificationSectionStep();
            profilePage.CertificationAddNewButtonStep();
            profilePage.CertificationIncompleteStep();
        }

        [Test, Order(7), Description("This test checks if a user trying to added new entry with Only Certification")]
        public void TestIncompleteStepOnlyCertification()
        {
            signInPage.SignIn(testData.email, testData.password);
            profilePage.NavigateCertificationSectionStep();
            profilePage.CertificationAddNewButtonStep();
            profilePage.CertificationIncompleteStep1(testData.certification);
        }

        [Test, Order(8), Description("This test checks if a user trying to added new entry with only Certification and From")]
        public void TestIncompleteStepNoYear()
        {
            signInPage.SignIn(testData.email, testData.password);
            profilePage.NavigateCertificationSectionStep();
            profilePage.CertificationAddNewButtonStep();
            profilePage.CertificationIncompleteStep2(testData.certification, testData.from);
        }

        [Test, Order(9), Description("This test checks if a user trying to added new entry with existing Education details")]
        public void CertificationExistingStep()
        {
            signInPage.SignIn(testData.email, testData.password);
            profilePage.NavigateCertificationSectionStep();
            profilePage.CertificationAddNewButtonStep();
            profilePage.AddCertificationStep(testData.certification, testData.from, testData.year);
            profilePage.CertificationAddNewButtonStep();
            profilePage.CertificationExistingStep(testData.certification, testData.from, testData.year);
        }
    }

}