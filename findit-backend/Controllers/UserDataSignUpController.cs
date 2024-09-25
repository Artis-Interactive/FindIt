using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using findit_backend.Models;
using findit_backend.Handlers;
using System.Linq.Expressions;

namespace findit_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataSignUpController : ControllerBase
    {
        private readonly UserHandler _userHandler;

        public UserDataSignUpController()
        {
            _userHandler = new UserHandler();
        }

        [HttpGet("Email/{email}")]
        public ActionResult EmailExists(string email)
        {
            var users = _userHandler.ObtainUsers();
            var emailAccountExits = users.Any(user => user.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (emailAccountExits)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet("LegalID/{legalID}")]
        public ActionResult LegalIDExists(string legalID)
        {
            var users = _userHandler.ObtainUsers();
            var legalIDExits = users.Any(user => user.LegalId.Equals(legalID, StringComparison.Ordinal));
            if (legalIDExits)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateUser(UserModel user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest();
                }
                UserHandler userHandler = new UserHandler();
                var result = userHandler.CreateUser(user);
                return new JsonResult(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating user");
            }
        }
    }
}