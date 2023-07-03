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
            // Given
            var messages = new List<string>() {
                "a log test (1st).",
                "a log test (2nd)."
            };
            Logger logger = new Logger();
            string log = "";

            // When
            foreach (var message in messages)
            {
                log = logger.WriteLog(message);
            }

            // Then
            log.Should().EndWith(messages[messages.Count - 1]);
        }

        [Fact]
        public void ReadLog_Should_Print_Message()
        {
            //given
            Logger logger = new Logger();

            //when
            var log = logger.ReadLogs();

            //then
            log.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void ReadLogs_Should_Read_All_Lines()
        {
            // Given
            Logger logger = new Logger();

            // When
            var lines = logger.ReadLogs();
            //var expectedLineCount = lines.Split('\n').Length;

            // Then
            lines.Split('\n').Should().HaveCountGreaterThanOrEqualTo(1);
        }
    }
}