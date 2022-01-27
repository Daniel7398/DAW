using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AppDbContext _context;

        private IUserRepository _user;

        private ISessionTokenRepository _sessionToken;

        private ICartRepository _cart;

        private ICategoryRepository _category;

        private IProductRepository _product;

        private IQuantityRepository _quantity;

        private IReviewRepository _review;


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

        public ICategoryRepository Category
        {
            get
            {
                if (_category == null) _category = new CategoryRepository(_context);
                return _category;
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

        public IQuantityRepository Quantity
        {
            get
            {
                if (_quantity == null) _quantity = new QuantityRepository(_context);
                return _quantity;
            }
        }

        public IReviewRepository Review
        {
            get
            {
                if (_review == null) _review = new ReviewRepository(_context);
                return _review;
            }
        }


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }



    }
}
