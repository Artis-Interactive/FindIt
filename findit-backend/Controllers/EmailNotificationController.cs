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
    public async Task<IActionResult> SendNewOrderEmail(string hostedUrl)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            string to = "sebasbose@gmail.com";
            string subject = "¡Nuevo pedido recibido!";
            string htmlContent = @$"
                <p style='color: #555555; font-size: 16px; line-height: 1.5;'>¡Se ha recibido un nuevo pedido! Haz click en el boton a continuación para aprobarlo o rechazarlo.</p>
                <center>
            	    <p>
                      <a href='{hostedUrl}' style='border: none; color: white; padding: 15px 32px; text-align: center; text-decoration: none; display: inline-block; font-size: 16px; margin: 4px 2px; cursor: pointer; background-color: #8263A8;'>Aprobar o rechazar pedido</a>
                    </p>
                </center>";

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
