using ASP_Project.Models;
using ASP_Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Repositories
{
    public class WishListRepository : IWishListRepository
    {
        readonly AppDbContext _context;

        public WishListRepository(AppDbContext context)
        {
            _context = context;
        }

        public void ToggleWishListItem(int userId, int productId)
        {
            string wishListId = GetWishListId(userId);
            WishListItems existingWishListItem = _context.WishListItems.FirstOrDefault(x => x.ProductId == productId && x.WishListId == wishListId);

            if (existingWishListItem != null)
            {
                _context.WishListItems.Remove(existingWishListItem);
                _context.SaveChanges();
            }
            else
            {
                WishListItems wishListItem = new WishListItems
                {
                    WishListId = wishListId,
                    ProductId = productId,
                };
                _context.WishListItems.Add(wishListItem);
                _context.SaveChanges();
            }
        }

        public int ClearWishList(int userId)
        {
            try
            {
                string wishListId = GetWishListId(userId);
                List<WishListItems> wishListItem = _context.WishListItems.Where(x => x.WishListId == wishListId).ToList();

                if (!string.IsNullOrEmpty(wishListId))
                {
                    foreach (WishListItems item in wishListItem)
                    {
                        _context.WishListItems.Remove(item);
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

        public string GetWishListId(int userId)
        {
            try
            {
                WishList wishList = _context.WishList.FirstOrDefault(x => x.UserId == userId);

                if (wishList != null)
                {
                    return wishList.WishListId;
                }
                else
                {
                    return CreateWishList(userId);
                }

            }
            catch
            {
                throw;
            }
        }

        string CreateWishList(int userId)
        {
            try
            {
                WishList wishList = new WishList
                {
                    WishListId = Guid.NewGuid().ToString(),
                    UserId = userId,
                    DateCreated = DateTime.Now.Date
                };

                _context.WishList.Add(wishList);
                _context.SaveChanges();

                return wishList.WishListId;
            }
            catch
            {
                throw;
            }
        }
    }
}
