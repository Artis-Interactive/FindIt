using findit_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
      string categoryId;
      string companyId;
      string productId;
      foreach (DataRow column in tableResult.Rows)
      {
        categoryId = Convert.ToString(column["CategoryID"]);
        companyId = Convert.ToString(column["CompanyID"]);
        productId = Convert.ToString(column["ProductID"]);
        ProductModel product = new ProductModel
        {
          ProductID = Convert.ToString(column["ProductID"]),
          CategoryID = Convert.ToString(column["CategoryID"]),
          CompanyID = Convert.ToString(column["CompanyID"]),
          Name = Convert.ToString(column["ProductName"]),
          Description = Convert.ToString(column["Description"]),
          Image = Convert.ToString(column["Image"]),
          Price = Convert.ToDecimal(column["Price"])
        };
        
        query = $"SELECT Name FROM dbo.Companies WHERE CompanyID = '{companyId}'";
        DataTable companyTableResult = CreateQueryTable(query);
        DataRow row = companyTableResult.Rows[0];
        product.CompanyName = Convert.ToString(row["Name"]);

        CategoryHandler _categoryHandler = new CategoryHandler();
        product.category = _categoryHandler.GetByCategory(categoryId);

        product.productionBatch = new ProductionBatchModel();
        product.perishableProducts = new List<PerishableProductModel>();
        product.nonPerishableProduct = new NonPerishableProductModel();
        if(isPerishable(productId)) {
          product.Type = "Perecedero";
          ProductionBatchHandler _productionBatchHandler = new ProductionBatchHandler();
          product.productionBatch = _productionBatchHandler.GetByProduct(productId);
          PerishableProductHandler _perishableProductHandler = new PerishableProductHandler();
          product.perishableProducts = _perishableProductHandler.GetByProduct(productId);
          product.nonPerishableProduct.Amount = 0;
        } else{
          product.Type = "No perecedero";
          NonPerishableProductHandler _nonPerishableProductHandler = new NonPerishableProductHandler();
          product.nonPerishableProduct = _nonPerishableProductHandler.GetByProduct(productId);
          product.productionBatch.Amount = 0;
        }
        products.Add(product);
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

    public List<ProductModel> ObtainProductsByEmail(string email)
    {
      string query = $"SELECT UserID FROM dbo.Users WHERE Email = '{email}'";
      DataTable tableResult = CreateQueryTable(query);
      DataRow userRow = tableResult.Rows[0];
      string userId = Convert.ToString(userRow["UserID"]);
      
      query = $"SELECT CompanyID FROM dbo.UsersCompany WHERE UserID = '{userId}'";
      tableResult = CreateQueryTable(query);
      DataRow userCompanyRow = tableResult.Rows[0];
      string companyId = Convert.ToString(userCompanyRow["CompanyID"]);
      
      List<ProductModel> products = new List<ProductModel>();
      query = $"SELECT * FROM dbo.Products WHERE CompanyID = '{companyId}'";
      tableResult = CreateQueryTable(query);
      string categoryId;
      string productId;
      foreach (DataRow column in tableResult.Rows)
      {
        categoryId = Convert.ToString(column["CategoryID"]);
        productId = Convert.ToString(column["ProductID"]);
        ProductModel product = new ProductModel
        {
          ProductID = Convert.ToString(column["ProductID"]),
          CategoryID = Convert.ToString(column["CategoryID"]),
          CompanyID = Convert.ToString(column["CompanyID"]),
          Name = Convert.ToString(column["ProductName"]),
          Description = Convert.ToString(column["Description"]),
          Image = Convert.ToString(column["Image"]),
          Price = Convert.ToDecimal(column["Price"])
        };
        
        query = $"SELECT Name FROM dbo.Companies WHERE CompanyID = '{companyId}'";
        DataTable companyTableResult = CreateQueryTable(query);
        DataRow row = companyTableResult.Rows[0];
        product.CompanyName = Convert.ToString(row["Name"]);

        CategoryHandler _categoryHandler = new CategoryHandler();
        product.category = _categoryHandler.GetByCategory(categoryId);

        product.productionBatch = new ProductionBatchModel();
        product.perishableProducts = new List<PerishableProductModel>();
        product.nonPerishableProduct = new NonPerishableProductModel();
        if(isPerishable(productId)) {
          product.Type = "Perecedero";
          ProductionBatchHandler _productionBatchHandler = new ProductionBatchHandler();
          product.productionBatch = _productionBatchHandler.GetByProduct(productId);
          PerishableProductHandler _perishableProductHandler = new PerishableProductHandler();
          product.perishableProducts = _perishableProductHandler.GetByProduct(productId);
          product.nonPerishableProduct.Amount = 0;
        } else{
          product.Type = "No perecedero";
          NonPerishableProductHandler _nonPerishableProductHandler = new NonPerishableProductHandler();
          product.nonPerishableProduct = _nonPerishableProductHandler.GetByProduct(productId);
          product.productionBatch.Amount = 0;
        }
        products.Add(product);
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

            queryCommand.Parameters.AddWithValue("@CompanyID", Guid.Parse(companyId));
            queryCommand.Parameters.AddWithValue("@CategoryID", Guid.Parse(categoryId));
            queryCommand.Parameters.AddWithValue("@Name", name);
            queryCommand.Parameters.AddWithValue("@Description", description);
            queryCommand.Parameters.AddWithValue("@Image", img);
            queryCommand.Parameters.AddWithValue("@Price", price);

            return ExecuteNonQuery(queryCommand);
        }

        // TO BE REFACTORED
        public async Task<string> UpdateProductImage(string productId, IFormFile image)
        {
            ImageHandler imgHandler = new ImageHandler();
            string response = imgHandler.isImageValid(image);
            if (response != null)
            {
                System.Diagnostics.Debug.WriteLine("Test");
                return response;
            }

            string imagePath = Path.Combine("Assets", "ProductImages", productId);

            var query = $"UPDATE dbo.Products SET Image = '{imagePath}' WHERE ProductID = '{productId}'";
            var queryCommand = new SqlCommand(query, _connection);

            if (ExecuteNonQuery(queryCommand))
            {
                await imgHandler.saveProductImage(productId, image); // Await the save method
                return null;
            }
            return "Error";
        }


        public IActionResult LoadProductImage(string productId)
        {
            ImageHandler imgHandler = new ImageHandler();
            return imgHandler.loadProductImage(productId);
        }

        // TO BE REFACTORED
        public string CreateNonPerishableProduct(FullNonPerishableProductModel product)
        {
            System.Diagnostics.Debug.WriteLine("Test 1: " );
            bool query1Value = CreateProduct(product.Product.CompanyID, product.Product.CategoryID, product.Product.Name, product.Product.Description, product.Product.Image, product.Product.Price);
            System.Diagnostics.Debug.WriteLine("Test 2");
            string productId = ObtainProductID(product.Product.CompanyID, product.Product.CategoryID, product.Product.Name, product.Product.Description, product.Product.Image, product.Product.Price);
            System.Diagnostics.Debug.WriteLine("Test 3");
            var query2 = @"INSERT INTO [dbo].[NonPerishableProducts] ([ProductID], [Amount])
                        VALUES (@ProductID, @Stock)";

            var queryCommand = new SqlCommand(query2, _connection);

            queryCommand.Parameters.AddWithValue("@ProductID", Guid.Parse(productId));
            queryCommand.Parameters.AddWithValue("@Stock", product.Stock);

            System.Diagnostics.Debug.WriteLine("Test 4");
            bool query2Value = ExecuteNonQuery(queryCommand);
            System.Diagnostics.Debug.WriteLine("Test 5");

            return productId;
        }


        // TO BE REFACTORED
        public string CreatePerishableProduct(FullPerishableProductModel product)
        {
            System.Diagnostics.Debug.WriteLine("Test 1: ");
            bool query1Value = CreateProduct(product.Product.CompanyID, product.Product.CategoryID, product.Product.Name, product.Product.Description, product.Product.Image, product.Product.Price);
            System.Diagnostics.Debug.WriteLine("Test 2");
            string productId = ObtainProductID(product.Product.CompanyID, product.Product.CategoryID, product.Product.Name, product.Product.Description, product.Product.Image, product.Product.Price);
            System.Diagnostics.Debug.WriteLine("Test 3");

            product.productionBatch.ProductID = productId;
            ProductionBatchHandler _productionBatchHandler = new ProductionBatchHandler();
            _productionBatchHandler.AddProductionBatch(product.productionBatch);
            System.Diagnostics.Debug.WriteLine("Test 4");
            foreach (string Day in product.ProductionDays)
            {
                var query = $"INSERT INTO dbo.PerishableProducts (ProductID, Lifespan, ProductionDay) VALUES ('{productId}', '{product.Lifespan}', '{Day}')";
                var newQueryCommand = new SqlCommand(query, _connection);
                ExecuteNonQuery(newQueryCommand);
                System.Diagnostics.Debug.WriteLine("Test 5");
            }

            return productId;
        }

        public BaseProductModel ObtainBaseProductByProductId(string productId)
        {
            BaseProductModel product;
            string query = $"SELECT * FROM dbo.Products WHERE ProductID = '{productId}'";
            DataTable tableResult = CreateQueryTable(query);

            if (tableResult.Rows.Count == 0)
            {
                return null;
            }

            var productColumn = tableResult.Rows[0];

            product = new BaseProductModel
            {
                ProductID = Convert.ToString(productColumn["ProductID"]),
                CategoryID = Convert.ToString(productColumn["CategoryID"]),
                CompanyID = Convert.ToString(productColumn["CompanyID"]),
                Name = Convert.ToString(productColumn["ProductName"]),
                Description = Convert.ToString(productColumn["Description"]),
                Image = Convert.ToString(productColumn["Image"]),
                Price = Convert.ToDecimal(productColumn["Price"])
            };

            return product;
        }
        public bool isPerishable(string productId)
        {
            string query = $"SELECT * FROM dbo.PerishableProducts WHERE ProductID = '{productId}'";
            DataTable tableResult = CreateQueryTable(query);
            return tableResult.Rows.Count != 0;
        }
    }
}