using eShopWebApplication.Models;
using eShopWebApplication.Services;
using eShopWebApplication.Services.IServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace eShopWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }




        [HttpPost("Create")]
        public void CreateOrder(OrderModel orderData)
        {
            _orderService.CreateOrder(orderData);
        }
    }
}
