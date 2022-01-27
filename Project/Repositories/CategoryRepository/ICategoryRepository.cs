using Project.Models;
using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
      
        Task<List<Category>> GetAllCategoryWithProducts();
        Task<List<Category>> GetAllCategories();
    }
}
