﻿using findit_backend.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace findit_backend.Handlers
{
    public class AddressHandler : BaseHandler
    {
        public bool CreateAddress(AddressModel address, Guid userId)
        {
            var query = @"INSERT INTO dbo.Address (UserID, Province, Canton, District, Details)
                  VALUES (@UserID, @Province, @Canton, @District, @Details)";

            var queryCommand = new SqlCommand(query, _connection);

            queryCommand.Parameters.AddWithValue("@UserID", userId);
            queryCommand.Parameters.AddWithValue("@Province", address.Province);
            queryCommand.Parameters.AddWithValue("@Canton", address.Canton);
            queryCommand.Parameters.AddWithValue("@District", address.District);
            queryCommand.Parameters.AddWithValue("@Details", address.Details);

            return ExecuteNonQuery(queryCommand);
        }

        public bool CreateCompanyAddress(AddressModel address, string companyId)
        {
            var query = @"INSERT INTO dbo.Address (CompanyID, Province, Canton, District, Details)
                  VALUES (@CompanyID, @Province, @Canton, @District, @Details)";

            var queryCommand = new SqlCommand(query, _connection);

            queryCommand.Parameters.AddWithValue("@CompanyID", companyId);
            queryCommand.Parameters.AddWithValue("@Province", address.Province);
            queryCommand.Parameters.AddWithValue("@Canton", address.Canton);
            queryCommand.Parameters.AddWithValue("@District", address.District);
            queryCommand.Parameters.AddWithValue("@Details", address.Details);

            return ExecuteNonQuery(queryCommand);
        }

        public List<AddressModel> GetAddresses()
        {
            List<AddressModel> addresses = new List<AddressModel>();
            string query = "SELECT Province, Canton, District, Details FROM dbo.Address"; ;
            DataTable tableResult = CreateQueryTable(query);
            foreach (DataRow row in tableResult.Rows)
            {
                addresses.Add(
                new AddressModel
                {
                    Province = Convert.ToString(row["Province"]),
                    Canton = Convert.ToString(row["Canton"]),
                    District = Convert.ToString(row["District"]),
                    Details = Convert.ToString(row["Details"]),
                });
            }
            return addresses;
        }

        public AddressModel GetByCompany(string companyId)
        {
            AddressModel address = new AddressModel();
            string query = $"SELECT Province, Canton, District, Details FROM dbo.Address" +
                           $" WHERE CompanyID = '{companyId}'";
            DataTable tableResult = CreateQueryTable(query);
            DataRow row = tableResult.Rows[0];

            address = new AddressModel
            {
                Province = Convert.ToString(row["Province"]),
                Canton = Convert.ToString(row["Canton"]),
                District = Convert.ToString(row["District"]),
                Details = Convert.ToString(row["Details"]),
            };
            return address;
        }

        public List<AddressModel> GetUserAddresses(string userId)
        {
            List<AddressModel> addresses = [];
            string query = $"SELECT Province, Canton, District, Details FROM dbo.Address" +
                           $" WHERE UserID = '{userId}'";
            DataTable tableResult = CreateQueryTable(query);

            foreach (DataRow row in tableResult.Rows)
            {
                addresses.Add(new AddressModel {
                    Province = Convert.ToString(row["Province"])!,
                    Canton = Convert.ToString(row["Canton"])!,
                    District = Convert.ToString(row["District"])!,
                    Details = Convert.ToString(row["Details"])!,

                });
            }

            return addresses;
        }
    }
}
