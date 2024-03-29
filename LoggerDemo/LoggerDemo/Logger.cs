﻿using System;
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
            var logPath = Logger.LogPath ?? throw new InvalidOperationException("LogPath is not set."); ;
            string log;

            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                log = $"{DateTime.Now}: {message}";
                //add log to the file
                writer.WriteLine(log);
            }
            return log;
        }
        public string ReadLogs()
        {
            string? line;
            var logPath = Logger.LogPath ?? throw new InvalidOperationException("LogPath is not set."); ;

            using (StreamReader sr = new StreamReader(logPath))
            {
                line = sr.ReadToEnd();
            }
            return line;
        }

    }
}
