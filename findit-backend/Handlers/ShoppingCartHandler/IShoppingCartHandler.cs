namespace findit_backend.Handlers.CartHandler
{
    public interface IShoppingCartHandler
    {
        string getCartID(string userID);
        bool AddProductToCart(string userID, string productID, int quantity);
    }
}
