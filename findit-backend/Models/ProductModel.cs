namespace findit_backend.Models
{
  public class ProductModel
  {
    public string ProductID { get; set; }
    public string CategoryID { get; set; }
    public string CompanyID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public decimal Price { get; set; }
  }

  public class PerishableProductModel
  {
    public ProductModel Product { get; set; }
    public ProductionBatchModel productionBatch { get; set; }
    public int Lifespan { get; set; }
    public List<string> ProductionDays { get; set; }
    }

  public class NonPerishableProductModel
  {
    public ProductModel Product { get; set; }
    public int Stock { get; set; }
  }
}
