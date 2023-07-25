using MarsCompetitionTaskAutomation.Helpers;
using MarsCompetitionTaskAutomation.Pages;
using NUnit.Framework;

namespace MarsCompetitionTaskAutomation.Tests
{
    [TestFixture]
    public class BaseTest
    {
        public static SignInPage signInPage;
        public static ProfilePage profilePage;
        public static SharePage sharePage;
        public static ManageListingPage manageListingPage;

        [SetUp]
        public void BeforeEachTest()
        {
            signInPage = new SignInPage(CommonDriver.driver);
            profilePage = new ProfilePage(CommonDriver.driver);
            sharePage = new SharePage(CommonDriver.driver);
            manageListingPage = new ManageListingPage(CommonDriver.driver);
        }
    }
}