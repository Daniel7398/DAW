using ASP_Project.Models;
using ASP_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AppDbContext _context;
        private IUserRepository _user;
        private ISessionTokenRepository _sessionToken;
        private ICartRepository _cart;
        private IOrderRepository _order;
        private IProductRepository _product;
        private IWishListRepository _wishList;
        public RepositoryWrapper(AppDbContext context)
        {
            _context = context;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null) _user = new UserRepository(_context);
                return _user;
            }
        }

        public ISessionTokenRepository SessionToken
        {
            get
            {
                if (_sessionToken == null) _sessionToken = new SessionTokenRepository(_context);
                return _sessionToken;
            }
        }
        public ICartRepository Cart
        {
            get
            {
                if (_cart == null) _cart = new CartRepository(_context);
                return _cart;
            }
        }

        public IOrderRepository Order
        {
            get
            {
                if (_order == null) _order = new OrderRepository(_context);
                return _order;
            }
        }

        public IProductRepository Product
        {
            get
            {
                if (_product == null) _product = new ProductRepository(_context);
                return _product;
            }
        }

        public IWishListRepository WishList
        {
            get
            {
                if (_wishList == null) _wishList = new WishListRepository(_context);
                return _wishList;
            }
        }


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
