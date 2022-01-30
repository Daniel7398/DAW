using ASP_Project.Models;
using ASP_Project.Models.Entities;
using ASP_Project.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Repositories
{
    public class CartRepository : ICartRepository
    {
        readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddProductToCart(int userId, int productId)
    {
        string cartId = GetCartId(userId);
        int quantity = 1;

        CartItems existingCartItem = _context.CartItems.FirstOrDefault(x => x.ProductId == productId && x.CartId == cartId);

        if (existingCartItem != null)
        {
            existingCartItem.Quantity += 1;
            _context.Entry(existingCartItem).State = EntityState.Modified;
            _context.SaveChanges();
        }
        else
        {
            CartItems cartItems = new CartItems
            {
                CartId = cartId,
                ProductId = productId,
                Quantity = quantity
            };
            _context.CartItems.Add(cartItems);
            _context.SaveChanges();
        }
    }

    public string GetCartId(int userId)
    {
        try
        {
            Cart cart = _context.Cart.FirstOrDefault(x => x.UserId == userId);

            if (cart != null)
            {
                return cart.CartId;
            }
            else
            {
                return CreateCart(userId);
            }

        }
        catch
        {
            throw;
        }
    }

    string CreateCart(int userId)
    {
        try
        {
            Cart shoppingCart = new Cart
            {
                CartId = Guid.NewGuid().ToString(),
                UserId = userId,
                DateCreated = DateTime.Now.Date
            };

            _context.Cart.Add(shoppingCart);
            _context.SaveChanges();

            return shoppingCart.CartId;
        }
        catch
        {
            throw;
        }
    }

    public void RemoveCartItem(int userId, int productId)
    {
        try
        {
            string cartId = GetCartId(userId);
            CartItems cartItem = _context.CartItems.FirstOrDefault(x => x.ProductId == productId && x.CartId == cartId);

            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }

    public void DeleteOneCartItem(int userId, int productId)
    {
        try
        {
            string cartId = GetCartId(userId);
            CartItems cartItem = _context.CartItems.FirstOrDefault(x => x.ProductId == productId && x.CartId == cartId);

            cartItem.Quantity -= 1;
            _context.Entry(cartItem).State = EntityState.Modified;
            _context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }

    public int GetCartItemCount(int userId)
    {
        string cartId = GetCartId(userId);

        if (!string.IsNullOrEmpty(cartId))
        {
            int cartItemCount = _context.CartItems.Where(x => x.CartId == cartId).Sum(x => x.Quantity);

            return cartItemCount;
        }
        else
        {
            return 0;
        }
    }

  
    public int ClearCart(int userId)
    {
        try
        {
            string cartId = GetCartId(userId);
            List<CartItems> cartItem = _context.CartItems.Where(x => x.CartId == cartId).ToList();

            if (!string.IsNullOrEmpty(cartId))
            {
                foreach (CartItems item in cartItem)
                {
                    _context.CartItems.Remove(item);
                    _context.SaveChanges();
                }
            }
            return 0;
        }
        catch
        {
            throw;
        }
    }

    void DeleteCart(string cartId)
    {
        Cart cart = _context.Cart.Find(cartId);
        _context.Cart.Remove(cart);
        _context.SaveChanges();
    }

        public void CombineCarts(int userId1, int userId2)
        {
            try
            {
                if (userId1 != userId2 && userId1 > 0 && userId2 > 0)
                {
                    string cartId1 = GetCartId(userId1);
                    string cartId2 = GetCartId(userId2);

                    List<CartItems> cartItems1 = _context.CartItems.Where(x => x.CartId == cartId1).ToList();

                    foreach (CartItems item in cartItems1)
                    {
                        CartItems cartItem = _context.CartItems.FirstOrDefault(x => x.ProductId == item.ProductId && x.CartId == cartId1);

                        if (cartItem != null)
                        {
                            cartItem.Quantity += item.Quantity;
                            _context.Entry(cartItem).State = EntityState.Modified;
                        }
                        else
                        {
                            CartItems newCartItem = new CartItems
                            {
                                CartId = cartId1,
                                ProductId = item.ProductId,
                                Quantity = item.Quantity
                            };
                            _context.CartItems.Add(newCartItem);
                        }
                        _context.CartItems.Remove(item);
                        _context.SaveChanges();
                    }
                    DeleteCart(cartId1);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
