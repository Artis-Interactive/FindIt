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
            string query = "SELECT Lifespan, ProductionDay FROM dbo.PerishableProducts";
            DataTable tableResult = CreateQueryTable(query);
            foreach (DataRow row in tableResult.Rows)
            {
                perishableProducts.Add(
                new PerishableProductModel
                {
                    Lifespan = Convert.ToString(row["Lifespan"]),
                    ProductionDay = Convert.ToString(row["ProductionDay"])
                });
            }
            return perishableProducts;
        }

        public List<PerishableProductModel> GetByProduct(string productId)
        {
            List<PerishableProductModel> perishableProducts = new List<PerishableProductModel>();
            string query = $"SELECT Lifespan, ProductionDay FROM dbo.PerishableProducts" +
                           $" WHERE ProductID = '{productId}'";
            DataTable tableResult = CreateQueryTable(query);
            foreach (DataRow row in tableResult.Rows)
            {
                perishableProducts.Add(
                new PerishableProductModel
                {
                    Lifespan = Convert.ToString(row["Lifespan"]),
                    ProductionDay = Convert.ToString(row["ProductionDay"])
                });
            }
            return perishableProducts;
        }
    }
}