using findit_backend.Models;
using System.Data;

namespace findit_backend.Handlers
{
    public class UserCompanyHandler : BaseHandler
    {
        public List<UserCompanyModel> GetAllUsersInCompanies()
        {
            string query = @"
            SELECT 
                u.LegalID,
                u.Name AS UserName,       
                u.LastNames,
                u.Email,
                u.BirthDate,
                u.PhoneNumber,
                u.accountState,
                c.Name AS CompanyName      
            FROM 
                dbo.Users u
            JOIN 
                dbo.UsersCompany uc ON u.UserID = uc.UserID
            JOIN 
                dbo.Companies c ON uc.CompanyID = c.CompanyID";

            DataTable tableResult = CreateQueryTable(query);
            if (tableResult.Rows.Count == 0)
            {
                return new List<UserCompanyModel>();
            }

            List<UserCompanyModel> users = new List<UserCompanyModel>();
            foreach (DataRow row in tableResult.Rows)
            {
                UserCompanyModel user = new UserCompanyModel
                {
                    LegalId = Convert.ToString(row["LegalID"]),
                    Name = Convert.ToString(row["UserName"]),
                    LastNames = Convert.ToString(row["LastNames"]),
                    Email = Convert.ToString(row["Email"]),
                    BirthDate = Convert.ToString(row["BirthDate"]),
                    PhoneNumber = Convert.ToString(row["PhoneNumber"]),
                    AccountState = Convert.ToString(row["accountState"]),
                    CompanyName = Convert.ToString(row["CompanyName"]) 
                };
                users.Add(user);
            }
            return users;
        }

    }
}
