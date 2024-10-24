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

        string styledHtml = $@"
            <html>
                <head>
                    <title>{subject}</title>
                </head>
                <body style='font-family: Arial, sans-serif; margin: 0; padding: 20px;'>
                    <div style='max-width: 600px; margin: 0 auto; border: 1px solid #dddddd; padding: 20px;'>
                        <h1 style='color: #333333; text-align: center;'>{subject}</h1>
                        {htmlBody}
                        <footer style='margin-top: 20px; border-top: 1px solid #eeeeee; padding-top: 10px; text-align: center; font-size: 12px; color: #aaaaaa;'>
                            <p>&copy; 2024 FindIt. Todos los derechos reservados.</p>
                        </footer>
                    </div>
                </body>
            </html>";

        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = styledHtml,
            IsBodyHtml = true
        })
        {
            await smtp.SendMailAsync(message);
        }
    }
}
