using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories.QuantityRepository
{
    public interface IQuantityRepository : IGenericRepository<Quantity>
    {
        Task<List<Quantity>> GetAllQuantities();
    }
}
