using Project.Entities;
using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories 
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<Cart> GetByUser(User user);
    }
}
