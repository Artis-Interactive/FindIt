using findit_backend.Models;
using System.Data;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Data.SqlClient;

namespace findit_backend.Handlers
{
    public class CategoryHandler : BaseHandler
    {
        public List<CategoryModel> GetCategories()
        {
            List<CategoryModel> categories = new List<CategoryModel>();
            string query = "SELECT CategoryName FROM dbo.Categories";
            DataTable tableResult = CreateQueryTable(query);
            foreach (DataRow row in tableResult.Rows)
            {
                categories.Add(
                new CategoryModel
                {
                    CategoryID = Convert.ToString(row["CategoryID"]),
                    CategoryName = Convert.ToString(row["CategoryName"])
                });
            }
            return categories;
        }

        public CategoryModel GetByCategory(string categoryId)
        {
            CategoryModel category = new CategoryModel();
            string query = $"SELECT CategoryName FROM dbo.Categories" +
                           $" WHERE CategoryID = '{categoryId}'";
            DataTable tableResult = CreateQueryTable(query);
            DataRow row = tableResult.Rows[0];

            category = new CategoryModel
            {
                CategoryName = Convert.ToString(row["CategoryName"]),
            };
            return category;
        }
    }
}
