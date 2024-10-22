using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace findit_backend.Handlers;

public class EmailNotificationHandler : BaseHandler
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
            EnableSsl = false
            ,
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
