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

    [HttpGet("CompanyID/{companyId}")]
    public ActionResult GetProductsByCompanyId(string companyId)
    {
      var products = _productHandler.ObtainProductsByCompanyId(companyId);
      if (products == null)
      {
        return BadRequest();
      }
      return Ok(products);
    }

    // [HttpPost("CompanyID/{companyId}")]
    // public string GetTest()
    // {
    //   System.Diagnostics.Debug.WriteLine("Test");
    //   return "Hello world";
    //   var products = _productHandler.ObtainProductsByCompanyId(companyId);
    //   if (products == null)
    //   {
    //     return BadRequest();
    //   }
    //   return Ok(products);
    // }

    [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadImage(string productId, [FromForm] IFormFile image)
        {
          ImageHandler imgHandler = new ImageHandler();
            string response = imgHandler.isImageValid(image);
            if (response != null) {
                System.Diagnostics.Debug.WriteLine("Test");
                return BadRequest(response);
            }

            imgHandler.saveProductImage(productId, image);

            return Ok(new { fileName = image.FileName, fileSize = image.Length });
        }
  }
}
