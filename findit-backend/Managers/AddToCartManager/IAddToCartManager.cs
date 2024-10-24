namespace findit_backend.Managers.AddToCartManager
{
    public interface IAddToCartManager
    {
        string AddProductToCart(string email, string productId, int quantity);
    }
}
