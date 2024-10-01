using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using findit_backend.Models;
using findit_backend.Handlers;
using System.Linq.Expressions;
using Microsoft.IdentityModel.Tokens;

namespace findit_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressHandler _addressHandler;
        private readonly UserIdHandler _userIdHandler;
        private readonly CompanyHandler _companyHandler;

        public AddressController()
        {
            _addressHandler = new AddressHandler();
            _userIdHandler = new UserIdHandler();
            _companyHandler = new CompanyHandler();
        }

        [HttpGet]
        public List<AddressModel> Get()
        {
            var address = _addressHandler.GetAddresses();
            return address;
        }

        [HttpGet("CompanyID/{companyId}")]
        public ActionResult GetAddressById(string companyId)
        {
            var address = _addressHandler.GetByCompany(companyId);
            if (address == null)
            {
                return BadRequest();
            }
            return Ok(address);
        }

        [HttpPost("AddAddress")]
        public ActionResult<bool> CreateAddress(AddressModel address, string legalId)
        {
            try
            {
                if (address == null)
                {
                    return BadRequest("Invalid input. Address is missing.");
                }

                // Retrieve the UserID based on the LegalId
                UserIdHandler userIdHandler = new UserIdHandler();
                var userId = userIdHandler.GetUserId(legalId);

                if (userId == Guid.Empty)
                {
                    return BadRequest("Invalid Legal ID.");
                }

                // Create the address in the DB with the UserID
                AddressHandler addressHandler = new AddressHandler();
                var result = addressHandler.CreateAddress(address, userId);

                return new JsonResult(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("AddCompanyAddress")]
        public ActionResult<bool> CreateCompanyAddress(AddressModel address, string legalId)
        {
            try
            {
                if (address == null)
                {
                    return BadRequest("Invalid input. Address is missing.");
                }

                // Retrieve the CompanyID based on the LegalId
                string companyId = this._companyHandler.GetCompanyIdByLegalId(legalId);

                if (companyId.IsNullOrEmpty())
                {
                    return BadRequest("The company does not exist.");
                }

                // Create the address in the DB with the Company Id
                var result = this._addressHandler.CreateCompanyAddress(address, companyId);

                return new JsonResult(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}