using Microsoft.EntityFrameworkCore;
using Project.Entities;
using Project.Models;
using Project.Models.Entities;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(AppDbContext context) : base(context) { }
        public async Task<Cart> GetByUser(User user)
        {
            return await _context.Carts.Where(c => c.User.Equals(user)).FirstOrDefaultAsync();
        }
    }
}
