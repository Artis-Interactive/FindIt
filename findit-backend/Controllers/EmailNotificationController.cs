using findit_backend.Handlers;
using findit_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace findit_backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailNotificationController : ControllerBase
{
    private readonly EmailNotificationHandler _emailNotificationHandler;

    public EmailNotificationController(EmailNotificationHandler emailNotificationHandler)
    {
        _emailNotificationHandler = emailNotificationHandler;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendEmail([FromBody] EmailModel emailModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _emailNotificationHandler.SendEmailAsync(emailModel.To, emailModel.Subject, emailModel.Body);
            return Ok("Email sent successfully.");
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, $"Error sending email: {ex.Message}");
        }
    }
}
