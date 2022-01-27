using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories.ReviewRepository
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Task<List<Review>> GetAllReviews();
    }
}
