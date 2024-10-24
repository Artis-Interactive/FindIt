using findit_backend.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace findit_backend.Handlers
{
    public class AddressHandler : BaseHandler
    {
        public bool CreateAddress(AddressModel address, Guid userId)
        {
            var query = @"INSERT INTO dbo.Address (UserID, Coords)
           VALUES (@UserID, @Coords)";

            var queryCommand = new SqlCommand(query, _connection);

            queryCommand.Parameters.AddWithValue("@UserID", userId);
            queryCommand.Parameters.AddWithValue("@Coords", address.Coords);

            return ExecuteNonQuery(queryCommand);
        }

        public bool CreateCompanyAddress(AddressModel address, string companyId)
        {
            var query = @"INSERT INTO dbo.Address (CompanyID, Coords)
                  VALUES (@CompanyID, @Coords)";

            var queryCommand = new SqlCommand(query, _connection);

            queryCommand.Parameters.AddWithValue("@CompanyID", companyId);
            queryCommand.Parameters.AddWithValue("@Coords", address.Coords);

            return ExecuteNonQuery(queryCommand);
        }

        public List<AddressModel> GetAddresses()
        {
            List<AddressModel> addresses = new List<AddressModel>();
            string query = "SELECT Coords FROM dbo.Address"; ;
            DataTable tableResult = CreateQueryTable(query);
            foreach (DataRow row in tableResult.Rows)
            {
                addresses.Add(
                new AddressModel
                {
                    Coords = Convert.ToString(row["Coords"])
                });
            }
            return addresses;
        }

        public AddressModel GetByCompanyName(string companyName)
        {
            CompanyModel company = new CompanyModel();
            string query = $"SELECT CompanyID FROM dbo.Companies" +
                           $" WHERE Name = '{companyName}'";
            DataTable tableResult = CreateQueryTable(query);
            DataRow row = tableResult.Rows[0];

            string companyId = Convert.ToString(row["CompanyID"]);
            AddressModel address = new AddressModel();
            query = $"SELECT Coords FROM dbo.Address" +
                           $" WHERE CompanyID = '{companyId}'";
            tableResult = CreateQueryTable(query);
            row = tableResult.Rows[0];

            address = new AddressModel
            {
                Coords = Convert.ToString(row["Coords"])
            };
            return address;
        }


        public AddressModel GetByCompany(string companyId)
        {
            AddressModel address = new AddressModel();
            string query = $"SELECT Coords FROM dbo.Address" +
                           $" WHERE CompanyID = '{companyId}'";
            DataTable tableResult = CreateQueryTable(query);
            DataRow row = tableResult.Rows[0];

            address = new AddressModel
            {
                Coords = Convert.ToString(row["Coords"])
            };
            return address;
        }

        public List<AddressModel> GetUserAddresses(string userId)
        {
            List<AddressModel> addresses = [];
            string query = $"SELECT Coords FROM dbo.Address" +
                           $" WHERE UserID = '{userId}'";
            DataTable tableResult = CreateQueryTable(query);

            foreach (DataRow row in tableResult.Rows)
            {
                addresses.Add(new AddressModel {
                    Coords = Convert.ToString(row["Coords"])!
                });
            }

            return addresses;
        }
    }
}
