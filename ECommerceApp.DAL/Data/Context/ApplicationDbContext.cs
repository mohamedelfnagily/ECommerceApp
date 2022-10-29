using ECommerceApp.DAL.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DAL.Data.Context
{
    public class ApplicationDbContext:IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Order>().Property(p => p.Date).HasDefaultValueSql("GETDATE()");

            builder.Entity<CartProduct>().HasKey(e => new { e.productId, e.CartId });
            builder.Entity<ChatMapper>().HasKey(d => new { d.UserId, d.ConnectionId });
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<CartProduct> CartProducts => Set<CartProduct>();
        public DbSet<ChatMapper> chatMapper { get; set; }
    }
}
