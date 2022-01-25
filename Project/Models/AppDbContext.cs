using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Models.Entities;

namespace Project.Models
{
    public class AppDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<SessionToken> SessionTokens { get; set; }

        public DbSet<Cart> Carts { get; set;}
        public DbSet<Category> Caregories { get; set;}
        public DbSet<Product> Products { get; set;}
        public DbSet<Quantity> Quantities { get; set;}
        public DbSet<Review> Reviews { get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });

                ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
                ur.HasOne(ur => ur.User).WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);
            });


            builder.Entity<User>( u =>
            {
                u.HasOne(u => u.Cart).WithOne(c => c.User).HasForeignKey<Cart>(u => u.UserForeignKey); 
                u.HasMany(u => u.Products).WithOne(u => u.User);
                u.HasMany(u => u.Reviews).WithOne(r => r.User);
            });


            builder.Entity<Cart>( c =>
            {
                c.HasMany(c => c.Quantities).WithOne(q => q.Cart);

            });

            builder.Entity<Category>( cat =>
            {
                cat.HasMany(cat => cat.Products).WithOne(p => p.Category);
            });

            builder.Entity<Product>(p =>
            {
                p.HasMany(p => p.Quantities).WithOne(q => q.Product);
            });



            builder.Entity<ProductReview>().HasKey(pr => new { pr.ProductId, pr.ReviewId });

            builder.Entity<ProductReview>()
                .HasOne(pr => pr.Product)
                .WithMany(p => p.ProductReviews)
                .HasForeignKey(pr => pr.ProductId);

            builder.Entity<ProductReview>()
            .HasOne(pr => pr.Review)
            .WithMany(r => r.ProductReviews)
            .HasForeignKey(pr => pr.ReviewId);

        }
    }
}
