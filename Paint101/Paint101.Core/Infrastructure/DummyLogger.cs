using System;

namespace Paint101.Core
{
    public class DummyLogger : ICoreLogger
    {
        public void Log(string message)
        {
        }

        public void LogError(string message)
        {
        }

        public void LogError(string message, Exception ex)
        {
        }

        public void LogError(Exception ex)
        {
        }
    }
}
