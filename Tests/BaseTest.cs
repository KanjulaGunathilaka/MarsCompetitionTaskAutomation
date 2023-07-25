using MarsCompetitionTaskAutomation.Helpers;
using MarsCompetitionTaskAutomation.Pages;
using NUnit.Framework;

namespace MarsCompetitionTaskAutomation.Tests
{
    public class BaseTest
    {
        protected SignInPage signInPage;
        protected ProfilePage profilePage;
        protected ManageListingPage manageListingPage;
        protected SharePage sharePage;

        [SetUp]
        public void BeforeEachTest()
        {
            CommonDriver.Initialize();
        }

        [SetUp]
        public void BeforeEachTestCase()
        {
            signInPage = new SignInPage(CommonDriver.driver);
            profilePage = new ProfilePage(CommonDriver.driver);
            sharePage = new SharePage(CommonDriver.driver);
            manageListingPage = new ManageListingPage(CommonDriver.driver);
        }

        [TearDown]
        public void AfterEachTest()
        {
            CommonDriver.CloseDriver();
        }
    }
}