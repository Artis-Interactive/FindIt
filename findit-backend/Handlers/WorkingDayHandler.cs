using findit_backend.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace findit_backend.Handlers
{
  public class WorkingDayHandler : BaseHandler
  {
    public List<WorkingDayModel> GetWorkingDays()
    {
      List<WorkingDayModel> workingDays = new List<WorkingDayModel>();
      string query = "SELECT * FROM dbo.WorkingDays";
      DataTable tableResult = CreateQueryTable(query);
      foreach (DataRow row in tableResult.Rows)
      {
        workingDays.Add(
        new WorkingDayModel
        {
          Day = Convert.ToString(row["Day"]),
          StartTime = TimeSpan.Parse(Convert.ToString(row["StartTime"])),
          EndTime = TimeSpan.Parse(Convert.ToString(row["EndTime"])),
        });
      }
      return workingDays;
    }

    public List<WorkingDayModel> GetByCompany(string companyId)
    {
      List<WorkingDayModel> workingDays = new List<WorkingDayModel>();
      string query = $"SELECT * FROM dbo.WorkingDays WHERE CompanyId = '{companyId}'";
      DataTable tableResult = CreateQueryTable(query);
      foreach (DataRow row in tableResult.Rows)
      {
        workingDays.Add(
        new WorkingDayModel
        {
          Day = Convert.ToString(row["Day"]),
          StartTime = TimeSpan.Parse(Convert.ToString(row["StartTime"])),
          EndTime = TimeSpan.Parse(Convert.ToString(row["EndTime"])),
        });
      }
      return workingDays;
    }
  }
}
