using AventStack.ExtentReports.Model;
using NUnit.Framework;
using System.Diagnostics.Metrics;

namespace MarsCompetitionTaskAutomation.Tests
{
    [TestFixture]
    public class CertificationDetailsTest : BaseTest
    {
        /**
         * This test user login flow with correct user details and check the profile update flow
         * This test user navigate to Education section by clicking Education Button
         
         */
        [Test, Order(1), Description("This test checks if a user is able to see the Certification Section")]
        public void NavigateCertificationSectionStep()
        {
            signInPage.SignIn("sandhaherath93@gmail.com", "Sandha@93");
            profilePage.NavigateCertificationSectionStep();

        }
        [Test, Order(2), Description("This test checks if a user is able to navigate Add Education section")]
        public void TestAddCertificationSection()
        {
            signInPage.SignIn("sandhaherath93@gmail.com", "Sandha@93");
            profilePage.NavigateCertificationSectionStep();
            profilePage.CertificationAddNewButtonStep();
            profilePage.AddCertificationStep("ISTQB", "Adobe", "2022");

        }
        [Test, Order(3), Description("This test checks if a user is able to cancel added details section")]
        public void TestCancelCertificationSection()
        {
            signInPage.SignIn("sandhaherath93@gmail.com", "Sandha@93");
            profilePage.NavigateCertificationSectionStep();
            profilePage.CertificationAddNewButtonStep();
            profilePage.CertificateCancelButtonStep("IT");

        }

        [Test, Order(4), Description("This test checks if a user is able to Edit and Update Added Education  details section")]
        public void CertificationEditAndUpdateSection()
        {
            signInPage.SignIn("sandhaherath93@gmail.com", "Sandha@93");
            profilePage.NavigateCertificationSectionStep();
            profilePage.CertificationAddNewButtonStep();
            profilePage.AddCertificationStep("ISTQB", "Adobe", "2022");
            profilePage.CertificationEditAndUpdateStep("ICT");
        }

        [Test, Order(5), Description("This test checks if a user is able to Delete added Education details section")]
        public void CertificationDeleteSection()
        {
            signInPage.SignIn("sandhaherath93@gmail.com", "Sandha@93");
            profilePage.NavigateCertificationSectionStep();
            profilePage.CertificationAddNewButtonStep();
            profilePage.AddCertificationStep("ISTQB", "Adobe", "2022");
            profilePage.CertificationDeleteStep();
        }
        [Test, Order(6), Description("This test checks if a user trying to added new entry with incomplete Certification details section")]
        public void TestIncompleteStep()
        {
            signInPage.SignIn("sandhaherath93@gmail.com", "Sandha@93");
            profilePage.NavigateCertificationSectionStep();
            profilePage.CertificationAddNewButtonStep();
            profilePage.CertificationIncompleteStep();
        }

        [Test, Order(7), Description("This test checks if a user trying to added new entry with uncomplete Certification details section")]
        public void TestIncompleteStep1()
        {
            signInPage.SignIn("sandhaherath93@gmail.com", "Sandha@93");
            profilePage.NavigateCertificationSectionStep();
            profilePage.CertificationAddNewButtonStep();
            profilePage.CertificationIncompleteStep1("ISTQB");
        }

        [Test, Order(8), Description("This test checks if a user trying to added new entry with uncomplete Certification details section")]
        public void TestIncompleteStep2()
        {
            signInPage.SignIn("sandhaherath93@gmail.com", "Sandha@93");
            profilePage.NavigateCertificationSectionStep();
            profilePage.CertificationAddNewButtonStep();
            profilePage.CertificationIncompleteStep2("ISTQB", "Adobe");
        }

        [Test, Order(9), Description("This test checks if a user trying to added new entry with uncomplete Education details section")]
        public void CertificationExistingStep()
        {
            signInPage.SignIn("sandhaherath93@gmail.com", "Sandha@93");
            profilePage.NavigateCertificationSectionStep();
            profilePage.CertificationAddNewButtonStep();
            profilePage.AddCertificationStep("ISTQB", "Adobe", "2022");
            profilePage.CertificationAddNewButtonStep();
            profilePage.CertificationExistingStep("ISTQB", "Adobe", "2022");
        }
    }

}