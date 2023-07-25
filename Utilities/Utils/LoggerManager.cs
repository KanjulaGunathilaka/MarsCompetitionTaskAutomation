using NLog;

namespace MarsCompetitionTaskAutomation.Utils
{
    public static class LoggerManager
    {
        public static Logger Logger { get; } = LogManager.GetCurrentClassLogger();
    }

}
