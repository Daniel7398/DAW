using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Repositories
{
    public interface IWishListRepository
    {
        void ToggleWishListItem(int userId, int productId);
        int ClearWishList(int userId);
        string GetWishListId(int userId);
    }
}
