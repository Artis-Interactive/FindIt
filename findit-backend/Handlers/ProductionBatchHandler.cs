using findit_backend.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace findit_backend.Handlers
{
    public class ProductionBatchHandler : BaseHandler
    {
        public List<ProductionBatchModel> GetProductionBatches()
        {
            List<ProductionBatchModel> productionBatches = new List<ProductionBatchModel>();
            string query = "SELECT Amount, OrderDeadline, ProductionDate FROM dbo.ProductionBatch";
            DataTable tableResult = CreateQueryTable(query);
            foreach (DataRow row in tableResult.Rows)
            {
                productionBatches.Add(
                new ProductionBatchModel
                {
                    Amount = Convert.ToInt32(row["Amount"]),
                    OrderDeadline = Convert.ToString(row["OrderDeadline"]),
                    ProductionDate= Convert.ToString(row["ProductionDate"]),
                });
            }
            return productionBatches;
        }

        public ProductionBatchModel GetByProduct(string productId)
        {
            ProductionBatchModel productionBatch = new ProductionBatchModel();
            string query = $"SELECT Amount, OrderDeadline, ProductionDate FROM dbo.ProductionBatch" +
                           $" WHERE ProductID = '{productId}'";
            DataTable tableResult = CreateQueryTable(query);
            DataRow row = tableResult.Rows[0];

            productionBatch = new ProductionBatchModel
            {
                Amount = Convert.ToInt32(row["Amount"]),
                OrderDeadline = Convert.ToString(row["OrderDeadline"]),
                ProductionDate = Convert.ToString(row["ProductionDate"]),
            };
            return productionBatch;
        }
    }
}
