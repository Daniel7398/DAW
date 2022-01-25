using Project.Entities;
using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories.DTOs
{
    public class UsersDTOs
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<UserRole> UserRoles { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual List<Product> Products { get; set; }

        public virtual List<Review> Reviews { get; set; }

        public UsersDTOs(User user)
        {
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.UserRoles = new List<UserRole>();
            this.Cart = user.Cart;
            this.Products = new List<Product>();
            this.Reviews = new List<Review>();
        }
    }
}
