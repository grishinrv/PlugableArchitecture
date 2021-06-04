using System;

namespace Core.Contracts
{
    /// <summary>
    /// Логгер.
    /// </summary>
    public interface ILogger
    {
        void Error(string message);
        void Info(string message);
        void Error(Exception ex);
        void Trace(string message);
        void Debug(string message);
        void Warn(string message);
    }
}
