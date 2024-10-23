using findit_backend.Handlers.ProductHandler;
using findit_backend.Helpers.ProductValidationHelper;

namespace findit_backend.Managers.AddToCartManager
{
    public class AddToCartManager : IAddToCartManager
    {
        private readonly IProductValidationHelper _productValidationHelper;

        public AddToCartManager(IProductValidationHelper productValidationHelper)
        {
            this._productValidationHelper = productValidationHelper;
        }
        public string AddProductToCart(string email, string productId, int quantity)
        {
            string result = "success";
            string validation = _productValidationHelper.ValidateProductAddition(productId, quantity);
            if (validation == "valid")
            {
                // Addition logic
            }
            else
            {
                result = validation;
            }
            return result;
        }
    }
}
