﻿namespace findit_backend.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using findit_backend.Handlers;
using findit_backend.Models;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly CompanyHandler _companyHandler;
    private readonly UserHandler _userHandler;

    public CompanyController()
    {
        _companyHandler = new CompanyHandler();
        _userHandler = new UserHandler();
    }

    [HttpGet]
    public List<CompanyModel> Get()
    {
        var companies = _companyHandler.ObtainCompanies();
        return companies;
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

    [HttpGet("UserCompanies/{email}")]
    [Authorize]
    public async Task<ActionResult> GetUserCompanies(string email)
    {
        string userID = await _userHandler.GetUserID(email);

        var companies = _companyHandler.OobtainUserCompanies(userID);
        if (companies == null)
        {
            return BadRequest();
        }
        return Ok(companies);
    }

    [HttpPost("CreateCompany")]
    public async Task<ActionResult<bool>> CreateCompany(CompanyModel company)
    {
        try
        {
            if (company == null)
            {
                return BadRequest();
            }
            var result = this._companyHandler.CreateCompany(company);


            return new JsonResult(result);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating company");
        }
    }
}
