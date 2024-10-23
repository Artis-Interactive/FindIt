using findit_backend.Handlers.ProductHandler;

namespace findit_backend.Helpers.ProductValidationHelper
{
    public class ProductValidationHelper : IProductValidationHelper
    {
        private readonly IProductHandler _productHandler;

        public ProductValidationHelper(IProductHandler productHandler)
        {
            _productHandler = productHandler;
        }
        public string ValidateProductAddition(string productId, int quantity)
        {
            string result = "valid";
            if(!_productHandler.checkProductExistence(productId))
            {
                result = "noProduct";
            }
            else
            {
                if(!_productHandler.isPerishable(productId))
                {
                    if (_productHandler.getProductStock(productId) < quantity) 
                    {
                        result = "noStock";
                    }
                }
            }
            return result;
        }
    }
}
