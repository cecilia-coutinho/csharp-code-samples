using FluentAssertions;
using SMTPSample;
using System.Net;
using System.Net.Mail;

namespace SMTPSampleTest
{
    public class EmailValidatorTest
    {
        [Fact]
        public void Test1()
        //public void Test1()
        {
            //Arrange
            string smtpHost = "smtp.example.com";
            int smtpPort = 587;
            string smtpUsername = "username";
            string smtpPassword = "password";

            string from = "sender@example.com";
            string to = "recipient@example.com";
            string subject = "Test Email";
            string body = "This is a test email sent using SMTP.";

            //Act
            Action SendEmailAction = () =>
            {
                EmailValidator email = new EmailValidator(from, to, subject, body);
                email.SendEmail(smtpHost, smtpPort, smtpUsername, smtpPassword);
            };

            //Assert
            SendEmailAction.Should().Throw<System.Exception>();
        }
    }
}