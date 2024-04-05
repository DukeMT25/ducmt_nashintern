using fredperry.Core.Entities.General;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fredperry.Infrastructure.Data
{
    public class ApplicationDbContextConfigurations
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");

            // Add any additional entity configurations here
        }

        public static void SeedData(ModelBuilder modelBuilder)
        {
            // Add any seed data here
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Man" },
                new Category { Id = 2, Name = "Women" },
                new Category { Id = 3, Name = "The Fred Perry Shirt" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Code = "P001", Name = "Men's Polo Shirt", Price = 29.99f, IsActive = true, IsNewRelease = true },
                new Product { Id = 2, Code = "P002", Name = "Women's Polo Shirt", Price = 29.99f, IsActive = true, IsNewRelease = true },
                new Product { Id = 3, Code = "P003", Name = "Fred Perry Classic Shirt", Price = 39.99f, IsActive = true, IsNewRelease = true }
            );

            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { Id = 1, ProductId = 1, CategoryId = 1 },
                new ProductCategory { Id = 2, ProductId = 1, CategoryId = 3 },

                new ProductCategory { Id = 3, ProductId = 2, CategoryId = 2 },
                new ProductCategory { Id = 4, ProductId = 2, CategoryId = 3 },

                new ProductCategory { Id = 5, ProductId = 3, CategoryId = 1 },
                new ProductCategory { Id = 6, ProductId = 3, CategoryId = 2 },
                new ProductCategory { Id = 7, ProductId = 3, CategoryId = 3 }
            );

        }
    }
}
