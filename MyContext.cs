using eCommerce.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace eCommerce
{
    public class MyContext : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-SDKBNOG;Database=ProjectDB;Trusted_Connection=True;Encrypt=false");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryId)
                .ValueGeneratedOnAdd();
            base.OnModelCreating(modelBuilder);
            /*-----------------------------------------------------*/
            // Seeding
            var _Categories = new List<Category>
            {
                new Category { CategoryId = 1, Name = "Clothes", Description = "Elegant Pieces" },
                new Category { CategoryId = 2, Name = "Bags", Description = "Elegant Bags" },
                new Category { CategoryId = 3, Name = "MakeUp", Description = "All you need" },
                new Category { CategoryId = 4, Name = "Skin Care", Description = "Get that skin" }
            };

            var _Products = new List<Product>
            {
            new Product { ProductId = 1, Title = "Shirt", Price = 500.00m, CategoryId = 1, Description = "Practical shirt", ImagePath = "/images/products/shirt.jpg", Quantity = 10   },
            new Product { ProductId = 2, Title = "Skirt", Price = 400.00m, CategoryId = 1, Description = "Cute & Beautiful Skirt", ImagePath = "/images/products/shirt.jpg", Quantity = 12 },
            new Product { ProductId = 3, Title = "Hand Bag", Price = 40.00m, CategoryId = 2, Description = "Small bag for daily use", ImagePath = "/images/products/handbag.jpg", Quantity = 8 },
            new Product { ProductId = 4, Title = "Dress", Price = 900.00m, CategoryId = 1, Description = "Classy dress for Women", ImagePath = "/images/products/dress.jpg", Quantity = 6 },
            new Product { ProductId = 5, Title = "Tote Bag", Price = 300.00m, CategoryId = 2, Description = "Bag for College", ImagePath = "/images/products/totebag.jpg", Quantity = 4 },
            new Product { ProductId = 6, Title = "Back Bag", Price = 450.00m, CategoryId = 2, Description = "Perfect For Over-Packers", ImagePath = "/images/products/backbag.jpg", Quantity = 5 },
            new Product { ProductId = 7, Title = "Lipstick", Price = 500.00m, CategoryId = 3, Description = "Long-lasting lipstick", ImagePath = "/images/products/lipstick.jpg", Quantity = 15 },
            new Product { ProductId = 8, Title = "Eyeliner", Price = 20.00m, CategoryId = 3, Description = "Waterproof eyeliner", ImagePath = "/images/products/eyeliner.jpg", Quantity = 20 },
            new Product { ProductId = 9, Title = "Foundation", Price = 30.00m, CategoryId = 3, Description = "Natural-looking foundation", ImagePath = "/images/products/foundation.jpg", Quantity = 18 },
            new Product { ProductId = 10, Title = "Moisturizer", Price = 800.00m, CategoryId = 4, Description = "Hydrating moisturizer", ImagePath = "/images/products/moisturizer.jpg", Quantity = 12 },
            new Product { ProductId = 11, Title = "Sunscreen", Price = 40.00m, CategoryId = 4, Description = "Broad-spectrum sunscreen", ImagePath = "/images/products/sunscreen.jpg", Quantity = 15 },
            };

            //var _Users = new List<User>
            //{
            //    new User { UserId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Password = "password123" },
            //    new User { UserId = 2, FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com", Password = "password456" },
            //    new User { UserId = 3, FirstName = "Bob", LastName = "Smith", Email = "bob.smith@example.com", Password = "password789" },
            //    // ...
            //};

            modelBuilder.Entity<Category>().HasData(_Categories);
            modelBuilder.Entity<Product>().HasData(_Products);
            //modelBuilder.Entity<User>().HasData(_Users);
            /*-----------------------------------------------------*/
            
        }
        /*---------------------------------------------------------*/
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        /*---------------------------------------------------------*/
    }

}

