using ASP_Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Models.DTOs
{
    public class CartItemDTO
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
