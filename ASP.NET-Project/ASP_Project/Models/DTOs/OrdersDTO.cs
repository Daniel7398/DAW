using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Models.DTOs
{
    public class OrdersDTO
    {
        public string OrderId { get; set; }
        public List<CartItemDTO> OrderDetails { get; set; }
        public decimal CartTotal { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
