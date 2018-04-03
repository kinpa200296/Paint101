using NLog;
using NLog.Config;
using NLog.Targets;

namespace Paint101.Desktop
{
    public static class NlogHelper
    {
        public static void Configure()
        {
            var target = new FileTarget
            {
                FileName = "${basedir}/Logs/app.log",
            };

            var rule = new LoggingRule("*", LogLevel.Debug, target);

            var config = new LoggingConfiguration();
            config.LoggingRules.Add(rule);

            LogManager.Configuration = config;
        }
    }
}
