using MarsCompetitionTaskAutomation.Utilities.DataModel;
using Newtonsoft.Json;

namespace MarsCompetitionTaskAutomation.Helpers
{
    public class TestDataHelper
    {

        public static List<CertificationTestData> GetCertificationTestData()
        {
            string jsonData = File.ReadAllText(ConstantHelpers.CertificationTestDataPath);
            List<CertificationTestData> testDataList = JsonConvert.DeserializeObject<List<CertificationTestData>>(jsonData);
            return testDataList;
        }

        public static List<EducationTestData> GetEducationTestData()
        {
            string jsonData = File.ReadAllText(ConstantHelpers.EducationTestDataPath);
            List<EducationTestData> testDataList = JsonConvert.DeserializeObject<List<EducationTestData>>(jsonData);
            return testDataList;
        }


    }
}