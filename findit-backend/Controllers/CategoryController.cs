using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using findit_backend.Models;
using findit_backend.Handlers;
using System.Linq.Expressions;

namespace findit_backend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoryController : ControllerBase
  {
    private readonly CategoryHandler _categoryHandler;

    public CategoryController()
    {
      _categoryHandler = new CategoryHandler();
    }

    [HttpGet]
    public List<CategoryModel> Get()
    {
      var category = _categoryHandler.GetCategories();
      return category;
    }

    [HttpGet("CategoryID/{categoryId}")]
    public ActionResult GetCategoryById(string categoryId)
    {
      var category = _categoryHandler.GetByCategory(categoryId);
      if (category == null)
      {
        return BadRequest();
      }
      return Ok(category);
    }
  }
}

