using findit_backend.Handlers;
using findit_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace findit_backend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductController : ControllerBase
  {
    private readonly ProductHandler _productHandler;

    public ProductController()
    {
      _productHandler = new ProductHandler();
    }

    [HttpGet]
    public List<ProductModel> Get()
    {
      var products = _productHandler.ObtainProducts();
      return products;
    }

    [HttpGet("ProductID/{productId}")]
    public ActionResult GetProductsByProductId(string productId)
    {
      var products = _productHandler.ObtainProductsByProductId(productId);
      if (products == null)
      {
        return BadRequest();
      }
      return Ok(products);
    }

    [HttpGet("CategoryID/{categoryId}")]
    public ActionResult GetProductsByCategoryId(string categoryId)
    {
      var products = _productHandler.ObtainProductsByCategoryId(categoryId);
      if (products == null)
      {
        return BadRequest();
      }
      return Ok(products);
    }

    [HttpGet("Email/{email}")]
    public ActionResult GetProductsByCompanyId(string email)
    {
      var products = _productHandler.ObtainProductsByEmail(email);
      if (products == null)
      {
        return BadRequest();
      }
      return Ok(products);
    }

        [HttpGet("ProductID")]
        public ActionResult GetProductID(string companyId, string categoryId, string name, string description, string img, decimal price)
        {
            var productId = _productHandler.ObtainProductID(companyId, categoryId, name, description, img, price);
            if (productId == null)
            {
                return BadRequest();
            }
            return Ok(productId);
        }

        [HttpPost("CreateNonPerishableProduct")]
        public async Task<ActionResult> CreateNonPerishableProduct(FullNonPerishableProductModel product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Invalid product");
                }

                var result = _productHandler.CreateNonPerishableProduct(product);
                return new JsonResult(result);
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "ERROR: Couldnt create product");
            }
        }

        [HttpPost("CreatePerishableProduct")]
        public async Task<ActionResult> CreatePerishableProduct(FullPerishableProductModel product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Invalid product");
                }

                var result = _productHandler.CreatePerishableProduct(product);
                return new JsonResult(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "ERROR: Couldnt create product");
            }
        }


        [HttpPost("UpdateImage")]
        public async Task<IActionResult> UpdateImage([FromForm] string productId, [FromForm] IFormFile image)
        {
            string response = await _productHandler.UpdateProductImage(productId, image);
            if (response != null)
            {
                return BadRequest(response);
            }

            return Ok(new { fileName = productId + image.FileName, fileSize = image.Length });
        }

        [HttpGet("LoadProductImage")]
        public IActionResult LoadProductImage(string productId)
        {
            var img = _productHandler.LoadProductImage(productId);
            if (img == null)
            {
                return BadRequest();
            }

            return img;
        }

        [HttpGet("IsProductPerishable/{productId}")]
        public ActionResult IsProductPerishable(string productId)
        {
            var perishable = _productHandler.isPerishable(productId);
            if (perishable == null)
            {
                return BadRequest();
            }
            return Ok(perishable);
        }
    }
}
