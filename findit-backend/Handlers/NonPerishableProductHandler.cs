using findit_backend.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace findit_backend.Handlers
{
    public class NonPerishableProductHandler : BaseHandler
    {
        public List<NonPerishableProductModel> GetNonPerishableProducts()
        {
            List<NonPerishableProductModel> nonPerishableProducts = new List<NonPerishableProductModel>();
            string query = "SELECT Stock FROM dbo.NonPerishableProducts";
            DataTable tableResult = CreateQueryTable(query);
            foreach (DataRow row in tableResult.Rows)
            {
                nonPerishableProducts.Add(
                new NonPerishableProductModel
                {
                    Amount = Convert.ToInt32(row["Amount"]),
                });
            }
            return nonPerishableProducts;
        }

        public NonPerishableProductModel GetByProduct(string productId)
        {
            NonPerishableProductModel nonPerishableProducts = new NonPerishableProductModel();
            string query = $"SELECT Stock FROM dbo.NonPerishableProducts" +
                           $" WHERE ProductID = '{productId}'";
            DataTable tableResult = CreateQueryTable(query);
            DataRow row = tableResult.Rows[0];

            nonPerishableProducts = new NonPerishableProductModel
            {
                Amount = Convert.ToInt32(row["Amount"]),
            };
            return nonPerishableProducts;
        }
    }
}
