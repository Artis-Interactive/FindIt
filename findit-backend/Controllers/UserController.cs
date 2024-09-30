using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using findit_backend.Handlers;
using findit_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace findit_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserHandler _userHandler;
        private IConfiguration _config;

        public UserController(IConfiguration config)
        {
            _userHandler = new UserHandler();
            _config = config;
        }
        // Generate user authentication token:
        private async Task<string> GenerateJSONWebToken(UserLoginModel user)
        {
            // Obtains key from appsettings as a byte array:
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            // Defines signing method for token based on key and HMAC with SHA-256 encryption algorithm:
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userRole = await _userHandler.getUserRole(user);
            var claims = new[]
            {
                new Claim("email", user.Email),
                new Claim("role", userRole),
            };
            // create token:
            var token = new JwtSecurityToken(issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims: claims,
                expires: null,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpPost]
        // Handle log in:
        public async Task<ActionResult<object>> userLogin(UserLoginModel user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("User data is null");
                }
                string result = await _userHandler.validateUser(user);

                if (result == "Allow")
                {
                    var token = await GenerateJSONWebToken(user);
                    return Ok(new { token, message = result });
                }
                else
                {
                    return Ok(new { message = result });
                }
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
