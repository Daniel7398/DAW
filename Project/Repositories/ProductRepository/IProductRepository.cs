using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories.ProductRepository
{
    interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<SelectListItem> GetAllCategories();
        float CalculateRating(Product product);
    }
}
