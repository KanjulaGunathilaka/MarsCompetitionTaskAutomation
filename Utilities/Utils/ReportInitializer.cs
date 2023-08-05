using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetitionTaskAutomation.Utilities.Utils
{
    public static class ReportInitializer
    {
        public static ExtentReports InitializeReport(string reportPath, string reportName)
        {
            return ReportManager.CreateInstance(reportPath, reportName);
        }

        public static void FinalizeReport()
        {
            ReportManager.FlushReports();
        }
    }
}
