using findit_backend.Models;
using findit_backend.Handlers;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
namespace findit_backend.Handlers
{
  public class CompanyHandler : BaseHandler
  {
    public List<CompanyModel> ObtainCompanies()
    {

      List<CompanyModel> companies = new List<CompanyModel>();
            
      string query = "SELECT * FROM dbo.Companies ";
      DataTable tableResult = CreateQueryTable(query);
      string companyId;
      foreach (DataRow column in tableResult.Rows)
      {
        companyId = Convert.ToString(column["CompanyID"]);
        CompanyModel company = new CompanyModel
        {
          Name = Convert.ToString(column["Name"]),
          LegalID = Convert.ToString(column["LegalID"]),
          Type = Convert.ToString(column["Type"]),
          Description = Convert.ToString(column["Description"]),
          PhoneNumber = Convert.ToInt32(column["PhoneNumber"]),
          Logo = Convert.ToString(column["Logo"]),
          HeroImage = Convert.ToString(column["HeroImage"])
        };

        WorkingDayHandler _workingDayHandler = new WorkingDayHandler();
        company.workingDays = _workingDayHandler.GetByCompany(companyId);

        AddressHandler _addressHandler = new AddressHandler();
        company.Address = _addressHandler.GetByCompany(companyId);
        companies.Add(company);
      }  
      return companies;
    }

    public CompanyModel GetByCompany(string companyId)
    {
      string query = $"SELECT * FROM dbo.Companies WHERE CompanyID = '{companyId}'";
      DataTable tableResult = CreateQueryTable(query);

      if (tableResult.Rows.Count == 0)
      {
        return null;
      }
      DataRow column = tableResult.Rows[0];
      CompanyModel company = new CompanyModel
      {
        Name = Convert.ToString(column["Name"]),
        LegalID = Convert.ToString(column["LegalID"]),
        Type = Convert.ToString(column["Type"]),
        Description = Convert.ToString(column["Description"]),
        PhoneNumber = Convert.ToInt32(column["PhoneNumber"]),
        Logo = Convert.ToString(column["Logo"]),
        HeroImage = Convert.ToString(column["HeroImage"])
      };

      WorkingDayHandler _workingDayHandler = new WorkingDayHandler();
      company.workingDays = _workingDayHandler.GetByCompany(companyId);
        
      AddressHandler _addressHandler = new AddressHandler();
      company.Address = _addressHandler.GetByCompany(companyId);
      return company;
    }
  }
}
