using ASP_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ASP_Project.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        ISessionTokenRepository SessionToken { get; }
        ICartRepository Cart {get; }

        IOrderRepository Order{ get; }

        IProductRepository Product { get; }

        IWishListRepository WishList { get; }




        Task SaveAsync();
    }
}
