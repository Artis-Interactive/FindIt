using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using findit_backend.Handlers;
using findit_backend.Models;

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
            var categories = _categoryHandler.ObtainCategories();
            return categories;
        }
    }
}
