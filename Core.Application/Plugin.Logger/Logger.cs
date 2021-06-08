using Core.Contracts;
using System;
using System.Text;

namespace Plugin.Logger
{
    public class Logger : ILogger
    {
        public void Debug(string message) => Write("Debug", message);

        public void Error(string message) => Write("Error", message);

        public void Error(Exception ex)
        {
            var stackTrace = ex.StackTrace.Split('\n');
            var lines = new string[stackTrace.Length + 1];
            lines[0] = ex.Message;
            for (int i = 1; i <= lines.Length; i++)
            {
                lines[i] = stackTrace[i - 1];
            }
            Write("Error", lines);
        }

        public void Info(string message) => Write("Info", message);

        public void Trace(string message) => Write("Trace", message);

        public void Warn(string message) => Write("Warn", message);

        private void Write(string level, params string[] lines) 
        {
            var builder = new StringBuilder(DateTime.Now.ToString())
                .Append(" ")
                .Append(level)
                .Append(" ");
            foreach (var line in lines)
            {
                builder.Append(line);
                builder.Append(Environment.NewLine);
            }
            Console.WriteLine(builder.ToString());
        }
    }
}
