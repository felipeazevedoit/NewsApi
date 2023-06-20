using System;
using System.IO;

namespace NewsAPI.Aplication.Helper
{
    public class LogHelper
    {
        private readonly string logFilePath;

        public LogHelper(string logFilePath)
        {
            this.logFilePath = logFilePath;
        }

        public void LogInformation(string message)
        {
            Log(LogLevel.Information, message);
        }

        public void LogWarning(string message)
        {
            Log(LogLevel.Warning, message);
        }

        public void LogError(string message)
        {
            Log(LogLevel.Error, message);
        }

        private void Log(LogLevel level, string message)
        {
            var logEntry = $"{DateTime.Now} [{level.ToString().ToUpper()}]: {message}";
            Console.WriteLine(logEntry);
            WriteToFile(logEntry);
        }

        private void WriteToFile(string logEntry)
        {
            try
            {
                using (var writer = new StreamWriter(logFilePath, append: true))
                {
                    writer.WriteLine(logEntry);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao escrever no arquivo de log '{logFilePath}': {ex}");
            }
        }
    }
}
