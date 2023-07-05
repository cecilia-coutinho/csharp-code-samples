using System.Net.Mail;
using System.Net;

namespace SMTPSample
{
    public class EmailValidator
    {
        private string? _fromAddress;
        private string? _toAddress;
        private string? _subject;
        private string? _body;

        public EmailValidator(string from, string to, string subject, string body)
        {
            _fromAddress = from;
            _toAddress = to;
            _subject = subject;
            _body = body;
        }

        public void SendEmail(string smtpHost, int smtpPort, string smtpUsername, string smtpPassword)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort))
                {
                    smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                    smtpClient.EnableSsl = true;

                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(_fromAddress);
                    mailMessage.To.Add(new MailAddress(_toAddress));
                    mailMessage.Subject = _subject;
                    mailMessage.Body = _body;

                    smtpClient.Send(mailMessage);
                }
            }
            catch (SmtpException ex)
            {
                throw new Exception("Error sending email", ex);
            }
        }
    }
}
