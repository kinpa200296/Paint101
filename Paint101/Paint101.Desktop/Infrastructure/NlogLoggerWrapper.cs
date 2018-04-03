using System;
using Paint101.Core;
using NLog;

namespace Paint101.Desktop
{
    public class NlogLoggerWrapper : ICoreLogger
    {
        private ILogger _logger;


        public NlogLoggerWrapper(string name)
        {
            _logger = LogManager.GetLogger(name);
        }


        public void Log(string message)
        {
            _logger.Info(message);
        }

        public void LogError(string message)
        {
            _logger.Error(message);
        }

        public void LogError(string message, Exception ex)
        {
            _logger.Error(string.Join(Environment.NewLine, message, ex.ToString()));
        }

        public void LogError(Exception ex)
        {
            _logger.Error(ex.ToString());
        }
    }
}
