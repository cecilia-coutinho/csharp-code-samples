using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerDemo
{
    public static class Logger
    {
        private static readonly string AppSettingKey = "logPath";
        public static string? LogPath = ConfigurationManager.AppSettings[AppSettingKey];
    }
}
