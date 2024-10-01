namespace findit_backend.Models
{
  public class ProductionBatchModel
  {
    public string ProductID { get; set; }
    public int Amount { get; set; }
    public TimeSpan OrderDeadline { get; set; }
    public DateTime ProductionDate { get; set; }
  }
}
