using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Interface;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrder _orderRepository;

        public OrdersController(IOrder orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrder();
            return orders;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var order = await _orderRepository.GetOrderById(id);
            if (order == null)
                return NotFound();

            return order;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(OrderDto order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            var addedOrder = await _orderRepository.PostOrder(order);

            if (addedOrder == null)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetAllOrders", new { id = addedOrder.OrderId }, addedOrder);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, OrderDto order)
        {
            var success = await _orderRepository.PutOrderById(id, order);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderRepository.DeleteOrderById(id);
            if (result == null)
                return NotFound("Couldn't find the order");

            return Ok();
        }
    }
}
