using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace findit_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hola Mundo";
        }

    }
}
