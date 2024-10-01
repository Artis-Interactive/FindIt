using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using findit_backend.Models;
using findit_backend.Handlers;
using System.Linq.Expressions;

namespace findit_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionBatchController : ControllerBase
    {
        private readonly ProductionBatchHandler _productionBatchHandler;

        public ProductionBatchController()
        {
            _productionBatchHandler = new ProductionBatchHandler();
        }

        [HttpGet]
        public List<ProductionBatchModel> Get()
        {
            var productionBatches = _productionBatchHandler.GetProductionBatches();
            return productionBatches;
        }

        [HttpGet("ProductID/{productId}")]
        public ActionResult GetBatchByProduct(string productId)
        {
            var productionBatch = _productionBatchHandler.GetByProduct(productId);
            if (productionBatch == null)
            {
                return BadRequest();
            }
            return Ok(productionBatch);
        }
    }
}

