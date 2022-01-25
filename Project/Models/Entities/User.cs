using Microsoft.AspNetCore.Identity;
using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Entities
{
    public class User : IdentityUser<int>
    {
        public User() : base() { }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }



    }
}
