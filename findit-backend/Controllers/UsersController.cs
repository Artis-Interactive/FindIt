using findit_backend.Handlers;
using findit_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace findit_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersHandler _usersHandler;
        public UsersController()
        {
            _usersHandler = new UsersHandler();
        }
        [HttpPost]
        public async Task<ActionResult<string>> userLogin(UserLoginModel user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("User data is null");
                }
                Console.WriteLine($"Email: {user.Email}, Password: {user.Password}");
                string resultado = await _usersHandler.validateUser(user);
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error iniciando sesión");
            }
        }

    }
}
