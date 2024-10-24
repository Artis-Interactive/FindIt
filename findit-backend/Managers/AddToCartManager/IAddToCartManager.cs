namespace findit_backend.Managers.AddToCartManager
{
    public interface IAddToCartManager
    {
        Task<string> AddProductToCart(string email, string productId, int quantity);
    }
}
