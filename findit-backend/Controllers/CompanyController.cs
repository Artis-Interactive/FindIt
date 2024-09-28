using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using findit_backend.Handlers;
using findit_backend.Models;

namespace findit_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyHandler _companyHandler;

        public CompanyController()
        {
            _companyHandler = new CompanyHandler();
        }

        [HttpGet]
        public List<CompanyModel> Get()
        {
            {
                var companies = _companyHandler.ObtainCompanies();
                return companies;
            }

        }

        [HttpGet("CompanyID/{companyId}")]
        public ActionResult GetCompanyById(string companyId)
        {
            var company = _companyHandler.GetByCompany(companyId);
            if (company == null)
            {
                return BadRequest();
            }
            return Ok(company);
        }
    }
}
