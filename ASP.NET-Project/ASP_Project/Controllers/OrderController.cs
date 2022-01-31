using ASP_Project.Models.DTOs;
using ASP_Project.Repositories;
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
    public class OrderController : ControllerBase
    {
        readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("{userId}")]
        public async Task<List<OrdersDTO>> Get(int userId)
        {
            return await Task.FromResult(_orderRepository.GetOrderList(userId)).ConfigureAwait(true);
        }
    }
}
