namespace findit_backend.Controllers;

using findit_backend.Handlers;
using findit_backend.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BusinessAddressController : ControllerBase
{
    private readonly BusinessAccountHandler _businessAccountHandler;

    public BusinessAddressController()
    {
        _businessAccountHandler = new();
    }

    [HttpPost]
    public async Task<ActionResult<bool>> CreateBusinessAccount(BusinessAccountModel businessAccount)
    {
        try
        {
            if (businessAccount == null)
            {
                return BadRequest();
            }

            var result = this._businessAccountHandler.CreateBusinessAccount(businessAccount);

            return new(result);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating business account");
        }
    }
}
