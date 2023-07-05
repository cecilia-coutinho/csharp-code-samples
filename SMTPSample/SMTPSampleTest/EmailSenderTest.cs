using FluentAssertions;
using Moq;
using SMTPSample;
using System.Net;
using System.Net.Mail;

namespace SMTPSampleTest
{
    public class EmailSenderTest
    {
        [Fact]
        public async Task SendEmail_ResultTrue()
        {
            //Arrange
            Mock<IEmailSender> emailSenderMock = new Mock<IEmailSender>();
            string from = "sender@example.com";
            string to = "recipient@example.com";
            string subject = "Test Email";
            string body = "This is a test email sent using SMTP.";

            //Act
            EmailSender emailSender = new EmailSender(emailSenderMock.Object, from, to);
            var result = await emailSender.SendEmail(subject, body);

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task SendEmail_Should_Handle_Exception()
        {
            //Arrange
            Mock<IEmailSender> emailSenderMock = new Mock<IEmailSender>();
            string from = "sender@example.com";
            string to = "recipient@example.com";
            string subject = "Test Email";
            string body = "This is a test email sent using SMTP.";

            //mock behavior
            emailSenderMock.Setup(x => x.SendEmailAsync(It.IsAny<MailMessage>()))
                           .Throws<SmtpException>();

            //Act
            EmailSender emailSender = new EmailSender(emailSenderMock.Object, from, to);
            var result = await emailSender.SendEmail(subject, body);

            //Assert
            result.Should().BeFalse();
        }


        [Fact]
        public async Task SendEmail_MockVerify_Should_Invoke_Once()
        {
            //Arrange
            Mock<IEmailSender> emailSenderMock = new Mock<IEmailSender>();
            string from = "sender@example.com";
            string to = "recipient@example.com";
            string subject = "Test Email";
            string body = "This is a test email sent using SMTP.";

            //mock behavior
            emailSenderMock.Setup(x => x.SendEmailAsync(It.IsAny<MailMessage>()))
                           .Returns(Task.CompletedTask);

            //Act
            EmailSender emailSender = new EmailSender(emailSenderMock.Object, from, to);
            await emailSender.SendEmail(subject, body);

            //Assert
            emailSenderMock.Verify(c => c.SendEmailAsync(It.IsAny<MailMessage>()), Times.Once);
        }

        [Fact]
        public async Task SendEmail_With_Null_Subject_Should_Return_False()
        {
            //Arrange
            Mock<IEmailSender> emailSenderMock = new Mock<IEmailSender>();
            string from = "sender@example.com";
            string to = "recipient@example.com";
            string subject = null;
            string body = "This is a test email sent using SMTP.";

            emailSenderMock.Setup(x => x.SendEmailAsync(It.IsAny<MailMessage>()))
                           .Returns(Task.CompletedTask);

            //Act
            EmailSender emailSender = new EmailSender(emailSenderMock.Object, from, to);
            var result = await emailSender.SendEmail(subject, body);

            //Assert
            result.Should().BeFalse();
        }
    }
}
