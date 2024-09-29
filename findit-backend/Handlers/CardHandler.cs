using findit_backend.Models;
using System.Data;
using System.Data.SqlClient;
namespace findit_backend.Handlers
{
    public class CardHandler : BaseHandler
    {
        public bool CardExists(string CardNumber)
        {
            string query = "SELECT COUNT(*) FROM dbo.Cards WHERE CardNumber = @CardNumber";
            using (var command = new SqlCommand(query, _connection))
            {  
                command.Parameters.AddWithValue("@CardNumber", CardNumber);
                _connection.Open();
                int count = (int)command.ExecuteScalar();
                _connection.Close();
                return count > 0;
            }
        }

        public bool CreateCard(CardModel card)
        {
            var query = @"INSERT INTO [dbo].[Cards] ([CardNumber], [NameOnCard], [ExpirationDate])
                        VALUES (@CardNumber, @NameOnCard, @ExpirationDate)";

            var queryCommand = new SqlCommand(query, _connection);

            queryCommand.Parameters.AddWithValue("@CardNumber", card.CardNumber);
            queryCommand.Parameters.AddWithValue("@NameOnCard", card.NameOnCard);
            queryCommand.Parameters.AddWithValue("@ExpirationDate", card.ExpirationDate);

            return ExecuteNonQuery(queryCommand);
        }

        public Guid GetCardId(string cardNumber)
        {
            string query = "SELECT CardID from dbo.Cards WHERE CardNumber = @CardNumber";
            using (var command = new SqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@CardNumber", cardNumber);
                _connection.Open();
                var result = command.ExecuteScalar();
                _connection.Close();
                if (result != null)
                {
                    return (Guid)result;
                }
                else
                {
                    return Guid.Empty;
                }
            }
        }

        public bool CreateUserCard(Guid cardId, Guid userId)
        {
            var query = @"INSERT INTO [dbo].[UserCards] ([CardID], [UserID])
                        VALUES (@CardID, @UserID)";

            var queryCommand = new SqlCommand(query, _connection);

            queryCommand.Parameters.AddWithValue("@CardID", cardId);
            queryCommand.Parameters.AddWithValue("@UserID", userId);

            return ExecuteNonQuery(queryCommand);
        }
    }
}
