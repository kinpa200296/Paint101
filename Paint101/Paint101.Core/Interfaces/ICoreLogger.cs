using System;

namespace Paint101.Core
{
    public interface ICoreLogger
    {
        void Log(string message);

        void LogError(string message);

        void LogError(string message, Exception ex);

        void LogError(Exception ex);
    }
}
