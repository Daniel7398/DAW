using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        ISessionTokenRepository SessionToken { get; }
        ICartRepository Cart { get;}

        ICategoryRepository Category { get; }

        IProductRepository Product { get; }

        IQuantityRepository Quantity { get; }

        IReviewRepository Review { get; }


        Task SaveAsync(); 

    }
}
