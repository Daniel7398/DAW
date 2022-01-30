using ASP_Project.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Repositories
{
    public interface IOrderRepository
    {
        void CreateOrder(int userId, OrdersDTO orderDetails);
        List<OrdersDTO> GetOrderList(int userId);
    }
}
