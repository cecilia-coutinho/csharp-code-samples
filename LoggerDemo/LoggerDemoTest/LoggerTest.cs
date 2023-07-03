using System.Configuration;
using LoggerDemo;
using FluentAssertions;
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
            string appSettingKey = "logPath";

            //when
            var key = ConfigurationManager.AppSettings[appSettingKey];

            //then
            key.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void AppSettings_Should_Match_ExpectedValue()
        {
            //given
            string expectedValue = "C:/TempStudy/log.txt";
            string appSettingKey = "logPath";

            //when
            var value = ConfigurationManager.AppSettings[appSettingKey];

            //then
            value.Should().Be(expectedValue);
        }
    }
}