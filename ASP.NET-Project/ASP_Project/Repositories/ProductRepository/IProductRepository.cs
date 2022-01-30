using ASP_Project.Models.DTOs;
using ASP_Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        int AddProduct(Product product);
        int UpdateProduct(Product product);
        Product GetProductData(int productId);
        string DeleteProduct(int productId);
        List<Categories> GetCategories();
        List<Product> GetSimilarProducts(int productId);
        List<CartItemDTO> GetProductsAvailableInCart(string cartId);
        List<Product> GetProductsAvailableInWishList(string wishlistID);
    }
}
