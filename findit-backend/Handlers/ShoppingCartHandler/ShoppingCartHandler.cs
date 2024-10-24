using System.Data;
using System.Data.SqlClient;

namespace findit_backend.Handlers.CartHandler
{
    public class ShoppingCartHandler : BaseHandler, IShoppingCartHandler
    {
        public string getCartID(string userID)
        {
            string query = $"SELECT * FROM dbo.ShoppingCarts WHERE UserID = @UserID";
            SqlParameter userIDParam = new SqlParameter("@UserID", userID);
            DataTable resultingTable = this.CreateQueryTable(query, userIDParam);
            string result;
            if (resultingTable.Rows.Count == 0)
            {
                result = "NoCart";
            }
            else
            {
                DataRow userRow = resultingTable.Rows[0];
                result = Convert.ToString(userRow["CartID"]);
            }
            return result;
        }
        public bool AddProductToCart(string userID, string productID, int quantity)
        {
            bool result = false;
            string cartID = this.getCartID(userID);
            if (cartID != "NoCart")
            {
                var query = @"INSERT INTO [dbo].[ProductsInCart] ([CartID], [ProductID], [Quantity])
                            VALUES (@CartID, @ProductID, @Quantity)";

                var queryCommand = new SqlCommand(query, this._connection);

                queryCommand.Parameters.AddWithValue("@CartID", cartID);
                queryCommand.Parameters.AddWithValue("@ProductID", productID);
                queryCommand.Parameters.AddWithValue("@Quantity", quantity);

                result = ExecuteNonQuery(queryCommand);
            }
            return result;
        }
    }
}
