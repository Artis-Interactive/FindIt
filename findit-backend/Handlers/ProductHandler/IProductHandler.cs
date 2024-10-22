namespace findit_backend.Handlers.ProductHandler
{
    public interface IProductHandler
    {
        bool checkProductExistance(string productId);
        bool isPerishable(string productId);
        int getProductStock(string productId);

    }
}
