using findit_backend.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace findit_backend.Handlers
{
    public class PerishableProductHandler : BaseHandler
    {
        public List<PerishableProductModel> GetPerishableProducts()
        {
            List<PerishableProductModel> perishableProducts = new List<PerishableProductModel>();
            string query = "SELECT Lifespan FROM dbo.PerishableProducts";
            DataTable tableResult = CreateQueryTable(query);
            foreach (DataRow row in tableResult.Rows)
            {
                perishableProducts.Add(
                new PerishableProductModel
                {
                    Lifespan = Convert.ToString(row["Lifespan"]),
                });
            }
            return perishableProducts;
        }

        public PerishableProductModel GetByProduct(string productId)
        {
            PerishableProductModel perishableProduct = new PerishableProductModel();
            string query = $"SELECT Lifespan FROM dbo.PerishableProducts" +
                           $" WHERE ProductID = '{productId}'";
            DataTable tableResult = CreateQueryTable(query);
            DataRow row = tableResult.Rows[0];

            perishableProduct = new PerishableProductModel
            {
                Lifespan = Convert.ToString(row["Lifespan"]),
            };
            return perishableProduct;
        }
    }
}
