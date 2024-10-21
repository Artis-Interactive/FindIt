using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using findit_backend.Models;
using findit_backend.Handlers;
using System.Linq.Expressions;

namespace findit_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerishableProductController : ControllerBase
    {
        private readonly PerishableProductHandler _perishableProductHandler;

        public PerishableProductController()
        {
            _perishableProductHandler = new PerishableProductHandler();
        }

        [HttpGet]
        public List<PerishableProductModel> Get()
        {
            var perishableProduct = _perishableProductHandler.GetPerishableProducts();
            return perishableProduct;
        }

        [HttpGet("ProductID/{ProductId}")]
        public ActionResult GetPerishableProductById(string ProductId)
        {
            var perishableProduct = _perishableProductHandler.GetByProduct(ProductId);
            if (perishableProduct == null)
            {
                return BadRequest();
            }
            return Ok(perishableProduct);
        }

        [HttpGet("GetFullProduct")]
        public ActionResult GetFullProductById(string productId)
        {
            var perishableProduct = _perishableProductHandler.GetFullByProductID(productId);
            if (perishableProduct == null)
            {
                return BadRequest();
            }
            return Ok(perishableProduct);
        }
    }
}

