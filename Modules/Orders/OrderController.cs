using ApiStore.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ApiStore.Modules.Orders
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController (IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost("create")]
        async public Task<IActionResult> CreateOrder([FromBody] CreateFullOrderDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            { 
                var newOrderId = await _orderRepository.CreateFullOrderItems(dto);

                return Ok(new { message = "Order created", data = newOrderId });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest( new {
                    error = "Error de servidor"
                });
            }
        }
    }
}
