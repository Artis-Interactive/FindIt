using findit_backend.Models;
using System.Data;
using System.Data.SqlClient;
namespace findit_backend.Handlers
{
    public class UserIdHandler : BaseHandler
    {
        public List<UserIdModel> ObtainUserId()
        {
            List<UserIdModel> usersId = new List<UserIdModel>();
            string query = "SELECT * FROM dbo.Users ";
            DataTable tableResult = CreateQueryTable(query);
            foreach (DataRow column in tableResult.Rows)
            {
                usersId.Add(
                new UserIdModel
                {
                    UserId = (Guid)column["UserID"],
                    LegalId = Convert.ToString(column["LegalId"])
                });
            }
            return usersId;
        }

        public Guid GetUserId(string legalId) 
        {
            string query = "SELECT UserID FROM dbo.Users WHERE LegalID = @LegalID";

            using (var command = new SqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@LegalID", legalId);
                _connection.Open();
                var result = command.ExecuteScalar();
                _connection.Close();

                if (result != null)
                {
                    return (Guid)result;
                } else
                {
                    return Guid.Empty;
                }
            }
        }
    }
}
