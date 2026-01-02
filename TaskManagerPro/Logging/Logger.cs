using System;
using System.IO;

namespace TaskManagerPro.Logging
{
    public static class Logger
    {
        private const string FileName = "log.txt";

        public static void Log(string message)
        {
            string logEntry = $"{DateTime.Now}: {message}";
            File.AppendAllText(FileName, logEntry + Environment.NewLine);
        }
    }
}

