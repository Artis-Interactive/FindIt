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

        private int GetLifespan(string productId)
        {
            string lifespanQuery = $"SELECT DISTINCT Lifespan FROM dbo.PerishableProducts WHERE ProductID = '{productId}'";
            DataTable lifespanTableResult = CreateQueryTable(lifespanQuery);
            if (lifespanTableResult.Rows.Count == 0)
            {
                return 0;
            }
            DataRow row = lifespanTableResult.Rows[0];
            return Convert.ToInt32(row["Lifespan"]);
        }

            private List<string> GetProductionDays(string productId)
        {
            List<string> productionDays = new List<string>();

            string productionDaysQuery = $"SELECT ProductionDay FROM dbo.PerishableProducts WHERE ProductID = '{productId}'";
            DataTable productionDaysTableResult = CreateQueryTable(productionDaysQuery);

            if (productionDaysTableResult.Rows.Count == 0)
            {
                return null;
            }

            foreach (DataRow row in productionDaysTableResult.Rows)
            {
                string prodDay = Convert.ToString(row["ProductionDay"]);
                productionDays.Add(prodDay);
            }

            return productionDays;
        }

        public FullPerishableProductModel GetFullByProductID(string productId)
        {
            ProductHandler productHandler = new ProductHandler();
            ProductionBatchHandler productionBatchHandler = new ProductionBatchHandler();
            FullPerishableProductModel fullPerishableProducts;
            BaseProductModel baseProductModel = productHandler.ObtainBaseProductByProductId(productId);
            ProductionBatchModel productionBatchModel = productionBatchHandler.GetByProduct(productId);
            int lifespan = GetLifespan(productId);
            List<string> productionDays = GetProductionDays(productId);


            if (productionBatchModel == null || lifespan == 0 || productionDays == null)
            {
                return null;
            }

            fullPerishableProducts = new FullPerishableProductModel
            {
                Product = baseProductModel,
                productionBatch = productionBatchModel,
                Lifespan = lifespan,
                ProductionDays = productionDays
            };
            return fullPerishableProducts;
        }
    }
}