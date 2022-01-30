using ASP_Project.Models.DTOs;
using ASP_Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Repositories
{
    public interface ICartRepository
    {
        void AddProductToCart(int userId, int productId);
        void RemoveCartItem(int userId, int productId);
        void DeleteOneCartItem(int userId, int productId);
        int GetCartItemCount(int userId);

        void CombineCarts(int userId1, int userId2);
        int ClearCart(int userId);
        string GetCartId(int userId);
    }
}
