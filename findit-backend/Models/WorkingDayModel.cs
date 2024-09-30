namespace findit_backend.Models
{
  public class WorkingDayModel
  {
    public string Day { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    }
}
