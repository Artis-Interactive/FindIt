using findit_backend.Models;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
namespace findit_backend.Handlers
{
  public class ProductHandler : BaseHandler
  {
    public List<ProductModel> ObtainProducts()
    {
      List<ProductModel> products = new List<ProductModel>();
      string query = "SELECT * FROM dbo.Products";
      DataTable tableResult = CreateQueryTable(query);
      foreach (DataRow column in tableResult.Rows)
      {
        products.Add(
        new ProductModel
        {
          ProductID = Convert.ToString(column["ProductID"]),
          CategoryID = Convert.ToString(column["CategoryID"]),
          CompanyID = Convert.ToString(column["CompanyID"]),
          Name = Convert.ToString(column["ProductName"]),
          Description = Convert.ToString(column["Description"]),
          Image = Convert.ToString(column["Image"]),
          Price = Convert.ToDecimal(column["Price"])
        });
      }
      return products;
    }

    public List<ProductModel> ObtainProductsByProductId(string productId)
    {
      List<ProductModel> products = new List<ProductModel>();
      string query = $"SELECT * FROM dbo.Products WHERE ProductID = '{productId}'";
      DataTable tableResult = CreateQueryTable(query);

      if (tableResult.Rows.Count == 0)
      {
        return null;
      }

      foreach (DataRow column in tableResult.Rows)
      {
        products.Add(
        new ProductModel
        {
          ProductID = Convert.ToString(column["ProductID"]),
          CategoryID = Convert.ToString(column["CategoryID"]),
          CompanyID = Convert.ToString(column["CompanyID"]),
          Name = Convert.ToString(column["ProductName"]),
          Description = Convert.ToString(column["Description"]),
          Image = Convert.ToString(column["Image"]),
          Price = Convert.ToDecimal(column["Price"])
        });
      }
      return products;
    }

    public List<ProductModel> ObtainProductsByCategoryId(string categoryId)
    {
      List<ProductModel> products = new List<ProductModel>();
      string query = $"SELECT * FROM dbo.Products WHERE CategoryID = '{categoryId}'";
      DataTable tableResult = CreateQueryTable(query);

      if (tableResult.Rows.Count == 0)
      {
        return null;
      }

      foreach (DataRow column in tableResult.Rows)
      {
        products.Add(
        new ProductModel
        {
          ProductID = Convert.ToString(column["ProductID"]),
          CategoryID = Convert.ToString(column["CategoryID"]),
          CompanyID = Convert.ToString(column["CompanyID"]),
          Name = Convert.ToString(column["ProductName"]),
          Description = Convert.ToString(column["Description"]),
          Image = Convert.ToString(column["Image"]),
          Price = Convert.ToDecimal(column["Price"])
        });
      }
      return products;
    }

    public List<ProductModel> ObtainProductsByCompanyId(string companyId)
    {
      List<ProductModel> products = new List<ProductModel>();
      string query = $"SELECT * FROM dbo.Products WHERE CompanyID = '{companyId}'";
      DataTable tableResult = CreateQueryTable(query);

      if (tableResult.Rows.Count == 0)
      {
        return null;
      }

      foreach (DataRow column in tableResult.Rows)
      {
        products.Add(
        new ProductModel
        {
          ProductID = Convert.ToString(column["ProductID"]),
          CategoryID = Convert.ToString(column["CategoryID"]),
          CompanyID = Convert.ToString(column["CompanyID"]),
          Name = Convert.ToString(column["ProductName"]),
          Description = Convert.ToString(column["Description"]),
          Image = Convert.ToString(column["Image"]),
          Price = Convert.ToDecimal(column["Price"])
        });
      }
      return products;
    }

        public string ObtainProductID(string companyId, string categoryId, string name, string description, string img, decimal price)
        {
            string productId = "";
            string query = $"SELECT * FROM dbo.Products WHERE CompanyID = '{companyId}' AND CategoryID = '{categoryId}' AND ProductName = '{name}' AND Description = '{description}' AND Image = '{img}' AND Price = {price}";
            DataTable tableResult = CreateQueryTable(query);

            foreach (DataRow column in tableResult.Rows)
            {
                productId = Convert.ToString(column["ProductID"]);
            }
            return productId;
        }

        public bool CreateProduct(string companyId, string categoryId, string name, string description, string img, decimal price)
        {
            var query = @"INSERT INTO [dbo].[Products] ([CategoryID], [CompanyID], [ProductName], [Description], [Image], 
                                                      [Price])
                        VALUES (@CategoryID, @CompanyID, @Name, @Description, @Image, @Price)";

            var queryCommand = new SqlCommand(query, _connection);

            queryCommand.Parameters.AddWithValue("@CategoryID", companyId);
            queryCommand.Parameters.AddWithValue("@CompanyID", categoryId);
            queryCommand.Parameters.AddWithValue("@Name", name);
            queryCommand.Parameters.AddWithValue("@Description", description);
            queryCommand.Parameters.AddWithValue("@Image", img);
            queryCommand.Parameters.AddWithValue("@Price", price);

            return ExecuteNonQuery(queryCommand);
        }
        public string UpdateProductImage(string productId, IFormFile image)
        {
            ImageHandler imgHandler = new ImageHandler();
            string response = imgHandler.isImageValid(image);
            if (response != null)
            {
                System.Diagnostics.Debug.WriteLine("Test");
                return response;
            }

            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "ProductImages", productId, image.FileName);

            var query = @"UPDATE [dbo].[Products] SET [Image] = @NewImage WHERE ProductID = @ProductID";

            var queryCommand = new SqlCommand(query, _connection);

            queryCommand.Parameters.AddWithValue("@ProductID", productId);
            queryCommand.Parameters.AddWithValue("@NewImage", imagePath);

            if (ExecuteNonQuery(queryCommand))
            {
                imgHandler.saveProductImage(productId, image);
                return null;
            }
            return "Error";
        }

        public bool CreateNonPerishableProduct(NonPerishableProductModel product)
        {
            bool query1Value = CreateProduct(product.Product.CompanyID, product.Product.CompanyID, product.Product.Name, product.Product.Description, product.Product.Image, product.Product.Price);
            string productId = ObtainProductID(product.Product.CompanyID, product.Product.CompanyID, product.Product.Name, product.Product.Description, product.Product.Image, product.Product.Price);

            var query2 = @"INSERT INTO [dbo].[NonPerishableProducts] ([ProductID], [Amount])
                        VALUES (@ProductID, @Stock)";

            var queryCommand = new SqlCommand(query2, _connection);

            queryCommand.Parameters.AddWithValue("@ProductID", productId);
            queryCommand.Parameters.AddWithValue("@Stock", product.Stock);

            bool query2Value = ExecuteNonQuery(queryCommand);

            return query1Value && query2Value;
        }
    }
}