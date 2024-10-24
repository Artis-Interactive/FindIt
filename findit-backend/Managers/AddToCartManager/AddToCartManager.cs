using findit_backend.Handlers.CartHandler;
using findit_backend.Handlers.ProductHandler;
using findit_backend.Handlers.UserHandler;
using findit_backend.Helpers.ProductValidationHelper;
using findit_backend.Models;

namespace findit_backend.Managers.AddToCartManager
{
    public class AddToCartManager : IAddToCartManager
    {
        private readonly IProductValidationHelper _productValidationHelper;
        private readonly IShoppingCartHandler _shoppingCartHandler;
        private readonly IUserHandler _userHandler;
        public AddToCartManager(IProductValidationHelper productValidationHelper, IShoppingCartHandler shoppingCartHandler,
            IUserHandler userHandler)
        {
            this._productValidationHelper = productValidationHelper;
            this._userHandler = userHandler;
            this._shoppingCartHandler = shoppingCartHandler;
        }
        public async Task<string> AddProductToCart(string email, string productId, int quantity)
        {
            string result = "success";
            string validation = _productValidationHelper.ValidateProductAddition(productId, quantity);
            if (validation == "valid")
            {
                string userID = await this._userHandler.GetUserID(email);
                if (userID != "NoUser")
                {
                    if (!this._shoppingCartHandler.AddProductToCart(userID, productId, quantity))
                    {
                        result = "failed";
                    }
                }
                else
                {
                    result = userID;
                }
            }
            else
            {
                result = validation;
            }
            return result;
        }
    }
}
