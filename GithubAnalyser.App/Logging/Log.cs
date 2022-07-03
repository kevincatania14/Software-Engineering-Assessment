using NLog;

namespace GithubAnalyser.App.Logging
{
    /// <summary>
    /// Static NLog class for cleaner log usage
    /// </summary>
    public static class Log
    {
        public static Logger Logger = LogManager.GetLogger("kevin-log");
        //public static Logger EventLog = LogManager.GetLogger("ApplicationEventLog");
    }
}
