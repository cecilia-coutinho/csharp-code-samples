using System.Configuration;
using LoggerDemo;
using FluentAssertions;
using System.IO;
using System.Reflection;
using System.Collections.Specialized;

namespace LoggerDemoTest
{
    public class LoggerTest
    {
        [Fact]
        public void AppSettings_Should_NotBeNullOrEmpty()
        {
            //given

            //when
            var key = Logger.LogPath;
            //then
            key.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void AppSettings_Should_Match_ExpectedValue()
        {
            //given
            string expectedValue = "log.txt";

            //when
            var value = Logger.LogPath;

            //then
            Path.GetFileName(value).Should().Be(expectedValue);
        }

        [Fact]
        public void WriteLog_Should_Write_Correct_Message()
        {
            //given
            string message = "a log.";

            //when
            var log = WriteLog(message);

            //then
            log.Should().EndWith(message);
        }

        string WriteLog(string message)
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