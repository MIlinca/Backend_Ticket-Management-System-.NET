using Microsoft.AspNetCore.Mvc;
using TicketManagementSystem.BusinessLogic;
using TicketManagementSystem.Models.Dto;


namespace TicketManagementSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderServices _orderServices;
        public OrderController(OrderServices orderServices)
        {
            _orderServices = orderServices;

        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderDto>> GetAll()
        {
            var orders = _orderServices.GetAllOrders();
            return Ok(orders);
        }
        [HttpGet]
        public async Task<ActionResult<OrderDto>> GetById(int id)
        {
            var orderId = await _orderServices.GetOrderById(id);
            return Ok(orderId);
        }

        [HttpPatch]
        public async Task<ActionResult<OrderPatchDto>> EntityUpdate(OrderPatchDto orderPatch)
        {
            var orderEntity = await _orderServices.UpdateOrder(orderPatch);
            return Ok(orderEntity);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _orderServices.Delete(id));
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> AddOrder(OrderDto orderAdd)
        {
            var newOrder = await _orderServices.AddOrder(orderAdd);
            return Ok(newOrder);
        }
    }
}