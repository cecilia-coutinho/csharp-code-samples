using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SMTPSample
{
    public interface IEmailSender
    {
        Task SendEmailAsync(MailMessage mailMessage);
    }
}
