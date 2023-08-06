using System;
using System.IO;
using System.Reflection;

namespace MarsCompetitionTaskAutomation.Utilities.DataModel
{
    public class CertificationTestData
    {
        public string testCase { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string certification { get; set; }
        public string from { get; set; }
        public string year { get; set; }
        public string newCertification { get; set; }
    }
}