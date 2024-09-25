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

        [HttpGet]
        public ActionResult EmailExists(string email)
        {
            var users = _userHandler.ObteinUsers();
            var emailAccountExits = users.Any(user => user.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (emailAccountExits)
            {
                ModelState.AddModelError("Email", "User with this email already exists.");
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