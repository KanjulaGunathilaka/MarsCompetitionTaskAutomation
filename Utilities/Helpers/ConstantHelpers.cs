using System;
using System.IO;
using System.Reflection;

namespace MarsCompetitionTaskAutomation.Helpers
{
    public class ConstantHelpers
    {
        public static string baseUrl = "http://localhost:5000";

        public static string projectRelativePath = @"..\..\..\MarsCompetitionTaskNunit\";
        public static string projectPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, projectRelativePath);
        public static string baseProjectPath = Path.GetFullPath(projectPath);
        public static string ScreenshotPath = baseProjectPath + @"TestReports\Screenshots\";
        public static string ReportsPath = baseProjectPath + @"TestReports\Test_files\";
        public static string ReportXMLPath = baseProjectPath + @"TestReports\Test_files\";

        public static string GetRelativeFilePath(string fileName)
        {
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string projectDirectory = Path.GetDirectoryName(assemblyLocation);
            string relativeFilePath = Path.Combine(projectDirectory, "Resources", fileName);

            return relativeFilePath;
        }
    }
}