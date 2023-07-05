using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SMTPSample
{
    public class EmailService : IEmailSender
    {
        public SmtpClient SmtpClient { get; set; }
        public EmailService(string smtpHost, int smtpPort)
        {
            SmtpClient = new SmtpClient(smtpHost, smtpPort);
        }
        public async Task SendEmailAsync(MailMessage mailMessage)
        {
            await SmtpClient.SendMailAsync(mailMessage);
        }
    }
}
