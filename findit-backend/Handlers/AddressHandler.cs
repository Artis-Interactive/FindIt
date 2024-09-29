using findit_backend.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace findit_backend.Handlers
{
  public class AddressHandler : BaseHandler
  {
    public List<AddressModel> GetAddresses()
    {
      List<AddressModel> addresses = new List<AddressModel>();
      string query = "SELECT Province, Canton, District, Details FROM dbo.Address";
      DataTable tableResult = CreateQueryTable(query);
      foreach (DataRow row in tableResult.Rows)
      {
        addresses.Add(
        new AddressModel
        { 
          Province = Convert.ToString(row["Province"]),
          Canton = Convert.ToString(row["Canton"]),
          District = Convert.ToString(row["District"]),
          Details = Convert.ToString(row["Details"]),
        });
      }
      return addresses;
    }

    public AddressModel GetByCompany(string companyId)
    {
      AddressModel address = new AddressModel();
      string query = $"SELECT Province, Canton, District, Details FROM dbo.Address" +
                     $" WHERE CompanyID = '{companyId}'";
      DataTable tableResult = CreateQueryTable(query);
      DataRow row = tableResult.Rows[0];

      address = new AddressModel
      {
        Province = Convert.ToString(row["Province"]),
        Canton = Convert.ToString(row["Canton"]),
        District = Convert.ToString(row["District"]),
        Details = Convert.ToString(row["Details"]),
      }; 
      return address;
    }
  }
}
