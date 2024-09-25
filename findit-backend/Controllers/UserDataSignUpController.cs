using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using findit_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public List<UserModel> Get()
        {
            var usuarios = _userHandler.ObtenerUsuarios();
            return usuarios;
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