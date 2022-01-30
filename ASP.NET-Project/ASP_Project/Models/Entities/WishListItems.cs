using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Models.Entities
{
    public class WishListItems
    {
        public int WishlistItemId { get; set; }
        public string WishListId { get; set; }
        public int ProductId { get; set; }
    }
}
