using findit_backend.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace findit_backend.Handlers
{
    public class AddressHandler : BaseHandler
    {
        public bool CreateAddress(AddressModel address)
        {
            var query = @"INSERT INTO [dbo].[Address] ([Province], [Canton], [District], [Details])
                        VALUES (@Province, @Canton, @District, @Details)"
            ;

            var queryCommand = new SqlCommand(query, _connection);

            queryCommand.Parameters.AddWithValue("@Province", address.Province);
            queryCommand.Parameters.AddWithValue("@Canton", address.Canton);
            queryCommand.Parameters.AddWithValue("@District", address.District);
            queryCommand.Parameters.AddWithValue("@Details", address.Details);

            return ExecuteNonQuery(queryCommand);
        }

        public List<AddressModel> GetAddresses() 
        { 
            List<AddressModel> addresses = new List<AddressModel>();
            string query = "SELECT * FROM dbo.Address";
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

    }
}
