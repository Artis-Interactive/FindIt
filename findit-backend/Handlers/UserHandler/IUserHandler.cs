using findit_backend.Models;

namespace findit_backend.Handlers.UserHandler
{
    public interface IUserHandler
    {
        Task<string> GetUserID(string email);
    }
}
