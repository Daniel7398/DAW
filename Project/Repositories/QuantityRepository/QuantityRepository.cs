using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Entities;
using Project.Models;
using Project.Models.Entities;
using Project.Repositories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories.QuantityRepository 
{
    public class QuantityRepository : GenericRepository<Quantity>, IQuantityRepository
    {
  
        public QuantityRepository(AppDbContext context) : base(context) { }

        public async Task<List<Quantity>> GetAllQuantities()
        {
            return await _context.Quantities.ToListAsync(); ;
        }
    }
}
