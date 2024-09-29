using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using findit_backend.Models;
using findit_backend.Handlers;
using System.Linq.Expressions;

namespace findit_backend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class WorkingDayController : ControllerBase
  {
    private readonly WorkingDayHandler _workingDayHandler;

    public WorkingDayController()
    {
      _workingDayHandler = new WorkingDayHandler();
    }

    [HttpGet]
    public List<WorkingDayModel> Get()
    {
      var workingDays = _workingDayHandler.GetWorkingDays();
      return workingDays;
    }

    [HttpGet("CompanyID/{companyId}")]
    public ActionResult GetDaysById(string companyId)
    {
      var workingDays = _workingDayHandler.GetByCompany(companyId);
      if (workingDays == null)
      {
        return BadRequest();
      }
      return Ok(workingDays);
    }
  }
}
