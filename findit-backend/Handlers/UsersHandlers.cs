using findit_backend.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
namespace findit_backend.Handlers
{
    public class UsersHandler
    {
        private SqlConnection _connection;
        private string _connectionRoute;
        public UsersHandler()
        {
            var builder = WebApplication.CreateBuilder();
            _connectionRoute =
            builder.Configuration.GetConnectionString("FindItDatabase");
            _connection = new SqlConnection(_connectionRoute);
        }
        // Generate a DataTable based on passed query:
        private DataTable CreateQueryTable(string query)
        {
            SqlCommand queryCommand = new SqlCommand(query, _connection);
            SqlDataAdapter tableAdapter = new SqlDataAdapter(queryCommand);
            DataTable TableFormatQuery = new DataTable();
            _connection.Open();
            tableAdapter.Fill(TableFormatQuery);
            _connection.Close();
            return TableFormatQuery;
        }
        public async Task<string> validateUser(UserLoginModel user)
        {
            // Creates query and stores resulting table:
            string query = $"SELECT * FROM dbo.Users WHERE Email = '{user.Email}'";
            DataTable resultingTable = this.CreateQueryTable(query);

            string result;
            // User doesn't exist:
            if (resultingTable.Rows.Count == 0)
            {
                result = "NoUser";
            }
            else
            {
                DataRow userRow = resultingTable.Rows[0];
                // User is not verified yet:
                if (!Convert.ToBoolean(userRow["IsVerified"]))
                {
                    result = "NotVer";
                }
                else
                {
                    // Check password:
                    if (Convert.ToString(userRow["PasswordHash"]) == user.Password)
                    {
                        result = "Allow";
                    }
                    else
                    {
                        result = "NotPass";
                    }
                }
            }
            return result;
        }
    }
}