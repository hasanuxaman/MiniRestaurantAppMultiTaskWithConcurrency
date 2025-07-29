using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniRestaurantAppMultiTaskWithConcurrency.Model;
using MiniRestaurantAppMultiTaskWithConcurrency.Services;

namespace MiniRestaurantAppMultiTaskWithConcurrency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantService _service;

        public RestaurantController(RestaurantService service)
        {
            _service = service;
        }

        [HttpPost("multi-order")]
        public async Task<IActionResult> PlaceMultipleOrders([FromBody] List<OrderRequest> orders, CancellationToken cancellationToken)
        {
            var results = await _service.ProcessMultipleOrdersAsync(orders, cancellationToken);
            return Ok(new
            {
                Message = "Orders processed successfully.",
                Results = results
            });
        }
        [HttpPost("order")]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderRequest request)
        {
            await _service.HandleOrderAsync(request);
            return Ok($"Order for table {request.TableNumber} processed.");
        }
    }
}

