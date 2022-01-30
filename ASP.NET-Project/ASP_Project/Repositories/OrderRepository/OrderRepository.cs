using ASP_Project.Models;
using ASP_Project.Models.DTOs;
using ASP_Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        readonly AppDbContext _context;
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public void CreateOrder(int userId, OrdersDTO orderDetails)
        {
            try
            {
                StringBuilder orderid = new StringBuilder();
                orderid.Append(CreateRandomNumber(3));
                orderid.Append('-');
                orderid.Append(CreateRandomNumber(6));

                CustomerOrders customerOrder = new CustomerOrders
                {
                    OrderId = orderid.ToString(),
                    UserId = userId,
                    DateCreated = DateTime.Now.Date,
                    CartTotal = orderDetails.CartTotal
                };
                _context.CustomerOrders.Add(customerOrder);
                _context.SaveChanges();

                foreach (CartItemDTO order in orderDetails.OrderDetails)
                {
                    CustomerOrderDetails productDetails = new CustomerOrderDetails
                    {
                        OrderId = orderid.ToString(),
                        ProductId = order.Product.ProductId,
                        Quantity = order.Quantity,
                        Price = order.Product.Price
                    };
                    _context.CustomerOrderDetails.Add(productDetails);
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        public List<OrdersDTO> GetOrderList(int userId)
        {
            List<OrdersDTO> userOrders = new List<OrdersDTO>();
            List<string> userOrderId = new List<string>();

            userOrderId = _context.CustomerOrders.Where(x => x.UserId == userId)
                .Select(x => x.OrderId).ToList();

            foreach (string orderid in userOrderId)
            {
                OrdersDTO order = new OrdersDTO
                {
                    OrderId = orderid,
                    CartTotal = _context.CustomerOrders.FirstOrDefault(x => x.OrderId == orderid).CartTotal,
                    OrderDate = _context.CustomerOrders.FirstOrDefault(x => x.OrderId == orderid).DateCreated
                };

                List<CustomerOrderDetails> orderDetail = _context.CustomerOrderDetails.Where(x => x.OrderId == orderid).ToList();

                order.OrderDetails = new List<CartItemDTO>();

                foreach (CustomerOrderDetails customerOrder in orderDetail)
                {
                    CartItemDTO item = new CartItemDTO();

                    Product product = new Product
                    {
                        ProductId = customerOrder.ProductId,
                        Manufacturer = _context.Product.FirstOrDefault(x => x.ProductId == customerOrder.ProductId && customerOrder.OrderId == orderid).Manufacturer,
                        Price = _context.CustomerOrderDetails.FirstOrDefault(x => x.ProductId == customerOrder.ProductId && customerOrder.OrderId == orderid).Price
                    };

                    item.Product = product;
                    item.Quantity = _context.CustomerOrderDetails.FirstOrDefault(x => x.ProductId == customerOrder.ProductId && x.OrderId == orderid).Quantity;

                    order.OrderDetails.Add(item);
                }
                userOrders.Add(order);
            }
            return userOrders.OrderByDescending(x => x.OrderDate).ToList();
        }

        int CreateRandomNumber(int length)
        {
            Random rnd = new Random();
            return rnd.Next(Convert.ToInt32(Math.Pow(10, length - 1)), Convert.ToInt32(Math.Pow(10, length)));
        }
    }
}

