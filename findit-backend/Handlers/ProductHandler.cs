﻿using findit_backend.Models;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.Design;
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
        if(isPerishable(productId)) {
          product.Type = "Perecedero";
        } else{
          product.Type = "No perecedero";
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

    public List<ProductModel> ObtainProductsByCompanyId(string companyId)
    {
      List<ProductModel> products = new List<ProductModel>();
      string query = $"SELECT * FROM dbo.Products WHERE CompanyID = '{companyId}'";
      DataTable tableResult = CreateQueryTable(query);
      string categoryId;
      foreach (DataRow column in tableResult.Rows)
      {
        categoryId = Convert.ToString(column["CategoryID"]);
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

        CategoryHandler _categoryHandler = new CategoryHandler();
        product.category = _categoryHandler.GetByCategory(categoryId);
        products.Add(product);
      }
      return products;
    }

    private bool isPerishable(string productId)
    {
      string query = $"SELECT * FROM dbo.PerishableProducts WHERE ProductID = '{productId}'";
      DataTable tableResult = CreateQueryTable(query);
      if (tableResult.Rows.Count == 0) {
        return false;
      } else {
        return true;
      }
    }
  }
}