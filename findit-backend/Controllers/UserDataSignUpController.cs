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
        private readonly UserCompanyHandler _userCompanyHandler;

        public UserDataSignUpController()
        {
            _userHandler = new UserHandler();
            _userCompanyHandler = new UserCompanyHandler();
        }

        [HttpGet("CompanyUsers")]
        public List<UserCompanyModel> GetAllWorkingUsers()
        {
            var workingUsers = _userCompanyHandler.GetAllUsersInCompanies();
            return workingUsers;
        }


        [HttpGet]
        public List<UserModel> Get()
        {
            var users = _userHandler.ObtainUsers();
            return users;
        }

        [HttpGet("GetUserByEmail/{email}")]
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

        // Endpoint for verifying the user by token
        [HttpPost("Verify")]
        public async Task<IActionResult> VerifyEmail(string email)
        {
            UserModel? user = _userHandler.GetUserByEmail(email);

            if (user == null)
            {
                return BadRequest("Invalid email");
            }

            bool success = await _userHandler.VerifyUserByEmail(user.Email);

            if (success == false)
            {
                return BadRequest("Error verifying user");
            }

            return Ok("Email successfully verified!");
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