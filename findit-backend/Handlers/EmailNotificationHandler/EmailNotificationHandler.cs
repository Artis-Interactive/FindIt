using findit_backend.Handlers.EmailNotificationHandler;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace findit_backend.Handlers.EmailNotificationHandler;

public class EmailNotificationHandler : BaseHandler, IEmailNotificationHandler
{
    public async Task SendEmailAsync(string to, string subject, string body)
    {
        var fromAddress = new MailAddress("findit@bolanos.cr", "FindIt - NoReply");
        var toAddress = new MailAddress(to);
        const string fromPassword = "v]1JGsEB";

        var smtp = new SmtpClient
        {
            Host = "smtp.hostinger.com",
            Port = 587,
            EnableSsl = false,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };

        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = body,
            IsBodyHtml = false
        })
        {
            await smtp.SendMailAsync(message);
        }
    }

    public async Task SendHtmlEmailAsync(string to, string subject, string htmlBody)
    {
        var fromAddress = new MailAddress("findit@bolanos.cr", "FindIt - NoReply");
        var toAddress = new MailAddress(to);
        const string fromPassword = "v]1JGsEB";

        var smtp = new SmtpClient
        {
            Host = "smtp.hostinger.com",
            Port = 587,
            EnableSsl = false,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };

        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = htmlBody,
            IsBodyHtml = true
        })
        {
            await smtp.SendMailAsync(message);
        }
    }
}
