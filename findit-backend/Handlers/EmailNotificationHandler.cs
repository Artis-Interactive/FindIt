using System.Net.Mail;
using System.Net;

namespace findit_backend.Handlers;

public class EmailNotificationHandler : BaseHandler
{
    public async Task SendEmailAsync(string to, string subject, string body)
    {
        var fromAddress = new MailAddress("no-reply@bolanos.cr", "FindIt - NoReply");
        var toAddress = new MailAddress(to);
        const string fromPassword = "xxxx";

        var smtp = new SmtpClient
        {
            Host = "smtp.example.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };

        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = body
        })
        {
            await smtp.SendMailAsync(message);
        }
    }
}
