using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerDemo
{
    public class Logger
    {
        private static readonly string AppSettingKey = "logPath";
        public static string? LogPath = ConfigurationManager.AppSettings[AppSettingKey];

        public string WriteLog(string message)
        {
            var logPath = Logger.LogPath;

            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                var log = $"{DateTime.Now}: {message}";
                return log;
            }
        }
    }
}
