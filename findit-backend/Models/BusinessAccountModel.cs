namespace findit_backend.Models;

public class BusinessAccountModel
{
    public string CompanyName {  get; set; }
    public string CompanyEmail { get; set; }
    public string OwnerName { get; set; }
    public string OwnerLastNames { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime ScheduleStart { get; set; }
    public DateTime ScheduleEnd { get; set; }
    public string IdNumber { get; set; }
    public string OfferedProducts { get; set; }
    public string AddressType { get; set; }
    public string AddressProvince { get; set; }
    public string AddressCanton { get; set; }
    public string AddressDistrict { get; set; }
    public string AddressAdditionalDetails { get; set; }
}
