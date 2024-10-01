using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using findit_backend.Models;
using findit_backend.Handlers;
using System.Linq.Expressions;

namespace findit_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NonPerishableProductController : ControllerBase
    {
        private readonly NonPerishableProductHandler _nonPerishableProductHandler;

        public NonPerishableProductController()
        {
            _nonPerishableProductHandler = new NonPerishableProductHandler();
        }

        [HttpGet]
        public List<NonPerishableProductModel> Get()
        {
            var nonPerishableProduct = _nonPerishableProductHandler.GetNonPerishableProducts();
            return nonPerishableProduct;
        }

        [HttpGet("ProductID/{ProductId}")]
        public ActionResult GetPerishableProductById(string ProductId)
        {
            var nonPerishableProduct = _nonPerishableProductHandler.GetByProduct(ProductId);
            if (nonPerishableProduct == null)
            {
                return BadRequest();
            }
            return Ok(nonPerishableProduct);
        }
    }
}

