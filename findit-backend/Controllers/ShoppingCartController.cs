using findit_backend.Handlers;
using findit_backend.Managers.AddToCartManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace findit_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IAddToCartManager _addToCartManager;

        public ShoppingCartController(IAddToCartManager addToCartManager)
        {
            _addToCartManager = addToCartManager;
        }

        [HttpGet("AddToCart/{email}/{productId}")]
        public async Task<ActionResult> AddProductToCart(string email, string productId, int quantity)
        {
            string result = await this._addToCartManager.AddProductToCart(email, productId, quantity);
            if (result != "success")
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
