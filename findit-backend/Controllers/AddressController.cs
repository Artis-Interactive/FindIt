using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using findit_backend.Models;
using findit_backend.Handlers;
using System.Linq.Expressions;

namespace findit_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
       private readonly AddressHandler _addressHandler;

            public AddressController()
            {
            _addressHandler = new AddressHandler();
            }

            [HttpGet]
            public List<AddressModel> Get() {
            {
                var address = _addressHandler.GetAddresses();
                return address;
            }

            

        }
    }
}
