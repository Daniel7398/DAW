using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories.DTOs
{
    public class CategoriesDTOs
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public virtual List<Product> Products { get; set; }

        public CategoriesDTOs(Category category)
        {
            this.CategoryId = category.CategoryId;
            this.CategoryName = category.CategoryName;
            this.Products = new List<Product>();
        }
    }
}
