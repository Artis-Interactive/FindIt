namespace findit_backend.Handlers.UserHandler;

using findit_backend.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Data;
using System.Data.SqlClient;

public class UserHandler : BaseHandler, IUserHandler
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
                AccountState = Convert.ToString(column["AccountState"]),
                Role = Convert.ToString(column["UserType"])
                
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
            return Convert.ToString(userRow["UserType"]);
        }
    }

    public UserModel? GetUserByEmail(string email)
    {
        List<UserModel> users = this.ObtainUsers();
        UserModel? userByEmail = users.FirstOrDefault(user => user.Email == email);
        if (userByEmail is null)
        {
            return null;
        }
        return userByEmail!;
    }

    public async Task<bool> VerifyUserByEmail(string email)
    {
        if (email != null)
        {
            // Mark user as verified
            _connection.Open();
            string updateQuery = "UPDATE Users SET AccountState = 'ACT' WHERE Email = @Email";
            SqlCommand command = new SqlCommand(updateQuery, _connection);
            command.Parameters.AddWithValue("@Email", email);
            command.ExecuteNonQuery();

            return true;
        }
        return false;
    }
    public async Task<string> GetUserID(string email)
    {
        // Creates query and stores resulting table:
        string query = $"SELECT * FROM dbo.Users WHERE Email = '{email}'";
        DataTable resultingTable = this.CreateQueryTable(query);
        string result = "NoUser";
        if (resultingTable.Rows.Count > 0)
        {
            DataRow userRow = resultingTable.Rows[0];
            result = Convert.ToString(userRow["UserID"]);
        }
        Console.WriteLine(result);
        return result;
    }
}
