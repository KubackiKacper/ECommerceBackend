using Microsoft.EntityFrameworkCore;
using ECommerceApp.Models;
namespace ECommerceApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        //this is testing

        //this is another tessting

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi=>oi.Product)
                .WithMany(p=>p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);
            modelBuilder.Entity<Product>()
                .HasOne(p=>p.Category)
                .WithMany(c=>c.Products)
                .HasForeignKey(p=>p.CategoryId);
            modelBuilder.Entity<Review>()
                .HasOne(r=>r.User)
                .WithMany(u=>u.Reviews)
                .HasForeignKey(r=>r.UserId);
            modelBuilder.Entity<Review>()
                .HasOne(r=>r.Product)
                .WithMany(p=>p.Reviews)
                .HasForeignKey(r=>r.ProductId);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Payment>(p => p.OrderId);

            modelBuilder.Entity<Product>()
                .HasData(
                new Product { Id = 1,Name = "PlayStation 5", Description = "Gaming Console", Price = 430.99m, StockQuantity = 2, CategoryId = 1, ImageURL = "https://localhost:7161/images/PS5console.png" },
                new Product { Id = 2, Name = "DualSense 5", Description = "Gaming Controller", Price = 50.25m, StockQuantity = 7, CategoryId = 1, ImageURL = "https://localhost:7161/images/pad-dualsense5-thumbnail.png" },
                new Product { Id = 3, Name = "Apple", Description = "Something you can eat", Price = 1.12m, StockQuantity = 200, CategoryId =2, ImageURL = "https://localhost:7161/images/fruit-thumbnail.png" },
                new Product { Id = 4, Name = "Office Chair", Description = "Something you can sit on", Price = 25.61m, StockQuantity = 30, CategoryId = 3, ImageURL = "https://localhost:7161/images/officechai-thumbnail.png" }
                );
            modelBuilder.Entity<Category>()
                .HasData(
                new Category {Id=1,Name="Electronics"},
                new Category { Id = 2, Name = "Food" },
                new Category { Id = 3, Name = "Office" }
                );
        }
    }
}
