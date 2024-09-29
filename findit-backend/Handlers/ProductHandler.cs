using findit_backend.Models;
using System.Data;
using System.Data.SqlClient;
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
  }
}