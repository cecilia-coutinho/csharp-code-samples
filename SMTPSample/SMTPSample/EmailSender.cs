using System.Net.Mail;
using System.Net;

namespace SMTPSample
{
    public class EmailSender
    {
        private readonly IEmailSender _emailSender;
        private string _fromAddress;
        private string _toAddress;

        public EmailSender(IEmailSender emailSender, string fromAddress, string toAddress)
        {
            _emailSender = emailSender;
            _fromAddress = fromAddress;
            _toAddress = toAddress;
        }

        public async Task<bool> SendEmail(string subject, string body)
        {
            if (string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(body))
            {
                return false;
            }

            using (var mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(_fromAddress);
                mailMessage.To.Add(new MailAddress(_toAddress));
                mailMessage.Subject = subject;
                mailMessage.Body = body;

                try
                {
                    await _emailSender.SendEmailAsync(mailMessage);
                    return true;
                }
                catch (SmtpException ex)
                {
                    return false;
                }
            }
        }
    }
}
