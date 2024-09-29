namespace findit_backend.Models
{
  public class CompanyModel
  {
    public string CompanyID { get; set; }
    public string Name { get; set; }
    public string LegalID { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public int PhoneNumber { get; set; }
    public string Logo { get; set; }
    public string HeroImage { get; set; }
    public List<WorkingDayModel> workingDays { get; set; }
    public AddressModel Address { get; set; }
    }
}
