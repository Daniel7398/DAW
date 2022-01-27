using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories.ProductRepository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }
        public float CalculateRating(Product product)
        {
            float rating_val = 0;
            int nr_reviews = 0;
            var reviews = _context.Reviews.Where(a => a.ProductId == product.Id);
            foreach (var rev in reviews)
            {
                rating_val = rating_val + rev.Rating;
                nr_reviews++;
            }
            rating_val = rating_val / nr_reviews;

            return  rating_val;
        }


        public async Task<List<Product>> GetAllProducts() 
        {
            return await _context.Products.ToListAsync();
        }
    }
}
