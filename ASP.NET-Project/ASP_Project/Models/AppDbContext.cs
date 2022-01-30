using ASP_Project.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Project.Models
{

    public class AppDbContext : IdentityDbContext<User, Role, int,
       IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
       IdentityRoleClaim<int>, IdentityUserToken<int>>
        {
             public AppDbContext(DbContextOptions options) : base(options) { }

             public DbSet<SessionToken> SessionTokens { get; set; }
             public virtual DbSet<Product> Product { get; set; }
             public virtual DbSet<Cart> Cart { get; set; }
             public virtual DbSet<CartItems> CartItems { get; set; }
             public virtual DbSet<Categories> Categories { get; set; }
             public virtual DbSet<CustomerOrderDetails> CustomerOrderDetails { get; set; }
             public virtual DbSet<CustomerOrders> CustomerOrders { get; set; }
             public virtual DbSet<WishList> WishList { get; set; }
             public virtual DbSet<WishListItems> WishListItems { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);

                builder.Entity<UserRole>(ur =>
                {
                    ur.HasKey(ur => new { ur.UserId, ur.RoleId });

                    ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);
                    ur.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);

                });
            }
        }
    }

