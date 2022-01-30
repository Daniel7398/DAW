using ASP_Project.Models;
using ASP_Project.Models.DTOs;
using ASP_Project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            try
            {
                return _context.Product.AsNoTracking().ToList();
            }
            catch
            {
                throw;
            }
        }

        public int AddProduct(Product product)
        {
            try
            {
                _context.Product.Add(product);
                _context.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public int UpdateProduct(Product product)
        {
            try
            {
                Product oldProductData = GetProductData(product.ProductId);

                if (oldProductData.Cover != null)
                {
                    if (product.Cover == null)
                    {
                        product.Cover = oldProductData.Cover;
                    }
                }

                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public Product GetProductData(int productId)
        {
            try
            {
                Product product = _context.Product.FirstOrDefault(x => x.ProductId == productId);
                if (product != null)
                {
                    _context.Entry(product).State = EntityState.Detached;
                    return product;
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public string DeleteProduct(int productId)
        {
            try
            {
                Product product = _context.Product.Find(productId);
                _context.Product.Remove(product);
                _context.SaveChanges();

                return (product.Cover);
            }
            catch
            {
                throw;
            }
        }

        public List<Categories> GetCategories()
        {
            List<Categories> lstCategories = new List<Categories>();
            lstCategories = (from CategoriesList in _context.Categories select CategoriesList).ToList();

            return lstCategories;
        }

        public List<Product> GetSimilarProducts(int productId)
        {
            List<Product> lstProduct = new List<Product>();
            Product product = GetProductData(productId);

            lstProduct = _context.Product.Where(x => x.Category == product.Category && x.ProductId != product.ProductId)
                .OrderBy(u => Guid.NewGuid())
                .Take(5)
                .ToList();
            return lstProduct;
        }

        public List<CartItemDTO> GetProductsAvailableInCart(string cartId)
        {
            try
            {
                List<CartItemDTO> cartItemList = new List<CartItemDTO>();
                List<CartItems> cartItems = _context.CartItems.Where(x => x.CartId == cartId).ToList();

                foreach (CartItems item in cartItems)
                {
                    Product product = GetProductData(item.ProductId);
                    CartItemDTO objCartItem = new CartItemDTO
                    {
                        Product = product,
                        Quantity = item.Quantity
                    };

                    cartItemList.Add(objCartItem);
                }
                return cartItemList;
            }
            catch
            {
                throw;
            }
        }

        public List<Product> GetProductsAvailableInWishList(string wishListId)
        {
            try
            {
                List<Product> wishList = new List<Product>();
                List<WishListItems> cartItems = _context.WishListItems.Where(x => x.WishListId == wishListId).ToList();

                foreach (WishListItems item in cartItems)
                {
                    Product product = GetProductData(item.ProductId);
                    wishList.Add(product);
                }
                return wishList;
            }
            catch
            {
                throw;
            }
        }
    }
}
