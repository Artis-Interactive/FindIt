using findit_backend.Handlers.EmailNotificationHandler;
using findit_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace findit_backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailNotificationController : ControllerBase
{
    private readonly IEmailNotificationHandler _emailNotificationHandler;

    public EmailNotificationController(IEmailNotificationHandler emailNotificationHandler)
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

    [HttpPost("sendNewOrderEmail")]
    public async Task<IActionResult> SendNewOrderEmail()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            string to = "sebasbose@gmail.com";
            string subject = "¡Nuevo pedido recibido!";
            string htmlContent = $"" +
                $"<h1>{subject}</h1>" +
                $"<p>¡Se ha recibido un nuevo pedido! ¿Deseas aprobarlo o rechazarlo?</p>" +
                $"<a href=\"https://google.com\">Aprobar!</a>   o   <a href=\"https://google.com\">Rechazar!</a>";

            // Llamamos a la función que envía el correo con HTML
            await _emailNotificationHandler.SendHtmlEmailAsync(to, subject, htmlContent);
            return Ok("New order email sent successfully.");
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, $"Error sending new order email: {ex.Message}");
        }
    }
}
