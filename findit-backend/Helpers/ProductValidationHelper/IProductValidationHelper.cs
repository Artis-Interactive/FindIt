namespace findit_backend.Helpers.ProductValidationHelper
{
    public interface IProductValidationHelper
    {
        string ValidateProductAddition(string productId, int quantity);
    }
}
