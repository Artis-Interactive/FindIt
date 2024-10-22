namespace findit_backend.Managers.AddToCartManager
{
    public interface IAddToCartManager
    {
        string AddProductToCart(string productId, int quantity);
    }
}
