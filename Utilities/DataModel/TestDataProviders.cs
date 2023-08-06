using MarsCompetitionTaskAutomation.Helpers;

namespace MarsCompetitionTaskAutomation.Utilities.DataModel
{
    public class TestDataProviders
    {
        private static List<CertificationTestData> GetCertificationTestData()
        {
            return TestDataHelper.GetCertificationTestData();
        }

        public static CertificationTestData GetCertificationTestDataForTestCase(string testCase)
        {
            return GetCertificationTestData().FirstOrDefault(data => data.testCase == testCase);
        }

        private static List<EducationTestData> GetEducationTestData()
        {
            return TestDataHelper.GetEducationTestData();
        }

        public static EducationTestData GetEducationTestDataForTestCase(string testCase)
        {
            return GetEducationTestData().FirstOrDefault(data => data.testCase == testCase);
        }
    }
}