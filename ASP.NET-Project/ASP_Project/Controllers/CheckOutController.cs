using ASP_Project.Models.DTOs;
using ASP_Project.Repositories.OrderRepository;
using ASP_Project.Repositories.ProductRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckOutController : ControllerBase
    {
        readonly IOrderRepository _orderRepository;
        readonly ICartRepository _cartRepository;

        public CheckOutController(IOrderRepository orderRepository, ICartRepository cartRepository)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
        }

        [HttpPost("{userId}")]
        public int Post(int userId, [FromBody] OrdersDTO checkedOutItems)
        {
            _orderRepository.CreateOrder(userId, checkedOutItems);
            return _cartRepository.ClearCart(userId);
        }

    }
}
