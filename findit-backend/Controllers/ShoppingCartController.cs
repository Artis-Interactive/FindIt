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

        [HttpGet("AddToCart/{productId}")]
        public ActionResult AddProductToCart(string productId, int quantity)
        {
            string result = this._addToCartManager.AddProductToCart(productId, quantity);
            Console.WriteLine(result);
            if (result != "valid")
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
