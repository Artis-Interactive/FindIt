using findit_backend.Models;
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
                    CompanyID = Convert.ToString(column["CompanyID"]),
                    Name = Convert.ToString(column["Name"]),
                    Type = Convert.ToString(column["Type"]),
                    Description = Convert.ToString(column["Description"]),
                    PhoneNumber = Convert.ToInt32(column["PhoneNumber"]),
                    Logo = Convert.ToString(column["Logo"]),
                    HeroImage = Convert.ToString(column["HeroImage"])
                };

                query = $"SELECT * FROM dbo.WorkingDays WHERE CompanyID = '{companyId}'";
                DataTable daysTableResult = CreateQueryTable(query);

                if (daysTableResult.Rows.Count > 0)
                {
                    DataRow WorkingDaysColumn = daysTableResult.Rows[0];
                    company.Day = Convert.ToString(WorkingDaysColumn["Day"]);
                    company.StartTime = TimeSpan.Parse(Convert.ToString(WorkingDaysColumn["StartTime"]));
                    company.EndTime = TimeSpan.Parse(Convert.ToString(WorkingDaysColumn["EndTime"]));
                }

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
                CompanyID = Convert.ToString(column["CompanyID"]),
                Name = Convert.ToString(column["Name"]),
                Type = Convert.ToString(column["Type"]),
                Description = Convert.ToString(column["Description"]),
                PhoneNumber = Convert.ToInt32(column["PhoneNumber"]),
                Logo = Convert.ToString(column["Logo"]),
                HeroImage = Convert.ToString(column["HeroImage"])
            };

            query = $"SELECT * FROM dbo.WorkingDays WHERE CompanyID = '{companyId}'";
            DataTable daysTableResult = CreateQueryTable(query);

             DataRow workingDaysColumn = daysTableResult.Rows[0];
             company.Day = Convert.ToString(workingDaysColumn["Day"]);
             company.StartTime = TimeSpan.Parse(Convert.ToString(workingDaysColumn["StartTime"]));
             company.EndTime = TimeSpan.Parse(Convert.ToString(workingDaysColumn["EndTime"]));


            query = $"SELECT CompanyID, UserID, Province, Canton, District, Details FROM dbo.Address WHERE CompanyID = '{companyId}'";
            DataTable addressTableResult = CreateQueryTable(query);
            DataRow addressColumn = addressTableResult.Rows[0];
            company.Address = new AddressModel
            {
                CompanyID = Convert.ToString(addressColumn["CompanyID"]),
                UserID = Convert.ToString(addressColumn["UserID"]),
                Province = Convert.ToString(addressColumn["Province"]),
                Canton = Convert.ToString(addressColumn["Canton"]),
                District = Convert.ToString(addressColumn["District"]),
                Details = Convert.ToString(addressColumn["Details"]),
            };
            
            return company;
        }

    }
}
