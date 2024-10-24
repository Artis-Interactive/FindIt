using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace findit_backend.Handlers.EmailNotificationHandler
{
    public interface IEmailNotificationHandler
    {
        Task SendEmailAsync(string to, string subject, string body);
        Task SendHtmlEmailAsync(string to, string subject, string htmlBody);

    }
}
