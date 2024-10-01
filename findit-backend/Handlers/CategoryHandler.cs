using findit_backend.Models;
using System.Data;
using System.ComponentModel.Design;
using System.Data.SqlClient;

namespace findit_backend.Handlers
{
    public class CategoryHandler : BaseHandler
    {
        public List<CategoryModel> ObtainCategories()
        {
            List<CategoryModel> categories = new List<CategoryModel>();
            string query = $"SELECT * FROM dbo.Categories";
            DataTable tableResult = CreateQueryTable(query);

            if (tableResult.Rows.Count == 0)
            {
                return null;
            }

            foreach (DataRow column in tableResult.Rows)
            {
                categories.Add(
                new CategoryModel
                {
                    CategoryID = Convert.ToString(column["CategoryID"]),
                    Name = Convert.ToString(column["CategoryName"])
                });
            }
            return categories;
        }
    }
}
