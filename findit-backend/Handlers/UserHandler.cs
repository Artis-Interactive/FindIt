using findit_backend.Models;
using System.Data;
using System.Data.SqlClient;
namespace findit_backend.Handlers
{
    public class UserHandler : BaseHandler
    {
        public List<UserModel> ObtainUsers()
        {
            List<UserModel> users = new List<UserModel>();
            string query = "SELECT * FROM dbo.Users ";
            DataTable tableResult = CreateQueryTable(query);
            foreach (DataRow column in tableResult.Rows)
            {
                users.Add(
                new UserModel
                {
                    LegalId = Convert.ToString(column["LegalId"]),
                    Name = Convert.ToString(column["Name"]),
                    LastNames = Convert.ToString(column["LastNames"]),
                    Email = Convert.ToString(column["Email"]),
                    BirthDate = Convert.ToString(column["BirthDate"]),
                    PhoneNumber = Convert.ToString(column["PhoneNumber"]),
                    Password = Convert.ToString(column["PasswordHash"]),
                });
            }
            return users;
        }

        public bool CreateUser(UserModel user)
        {
            var query = @"INSERT INTO [dbo].[Users] ([Name], [LastNames], [LegalID], [Email], [PasswordHash], 
                                                      [PhoneNumber], [BirthDate])
                        VALUES (@Name, @LastNames, @LegalID, @Email, @PasswordHash, @PhoneNumber, @BirthDate)";

            var queryCommand = new SqlCommand(query, _connection);

            queryCommand.Parameters.AddWithValue("@Name", user.Name);
            queryCommand.Parameters.AddWithValue("@LastNames", user.LastNames);
            queryCommand.Parameters.AddWithValue("@LegalID", user.LegalId);
            queryCommand.Parameters.AddWithValue("@Email", user.Email);
            queryCommand.Parameters.AddWithValue("@PasswordHash", user.Password);
            queryCommand.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
            queryCommand.Parameters.AddWithValue("@Birthdate", user.BirthDate);

            return ExecuteNonQuery(queryCommand);
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
                // User is banned:
                if (Convert.ToString(userRow["AccountState"]) == "BAN")
                {
                    result = "Ban";
                }
                // User is not verified yet:
                else if (Convert.ToString(userRow["AccountState"]) == "NotVER")
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
        public async Task<string> getUserRole(UserLoginModel user)
        {
            // Creates query and stores resulting table:
            string query = $"SELECT * FROM dbo.Users WHERE Email = '{user.Email}'";
            DataTable resultingTable = this.CreateQueryTable(query);

            // User doesn't exist:
            if (resultingTable.Rows.Count == 0)
            {
                return "NoUser";
            }
            else
            {
                DataRow userRow = resultingTable.Rows[0];
                return Convert.ToString(userRow["AccountState"]);
            }
                
        } 
    }
}

