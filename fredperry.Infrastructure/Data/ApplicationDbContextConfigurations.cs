using fredperry.Core.Entities.General;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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


            SeedUser(modelBuilder);
            SeedRole(modelBuilder);
            SeedUserRole(modelBuilder);
        }


        private static void SeedUser(ModelBuilder builder)
        {
            var admin1 = new IdentityUser
            {
                Id = "1",
                Email = "admin1@gmail.com",
                UserName = "admin1",
                NormalizedUserName = "admin1@gmail.com"
            };

            var admin2 = new IdentityUser
            {
                Id = "2",
                Email = "admin2@gmail.com",
                UserName = "admin2",
                NormalizedUserName = "admin2@gmail.com"
            };

            var admin3 = new IdentityUser
            {
                Id = "3",
                Email = "admin3@gmail.com",
                UserName = "admin3",
                NormalizedUserName = "admin3@gmail.com"
            };

            var customer1 = new IdentityUser
            {
                Id = "4",
                Email = "customer1@gmail.com",
                UserName = "customer1",
                NormalizedUserName = "customer1@gmail.com"
            };

            var customer2 = new IdentityUser
            {
                Id = "5",
                Email = "customer2@gmail.com",
                UserName = "customer2",
                NormalizedUserName = "customer2@gmail.com"
            };

            var customer3 = new IdentityUser
            {
                Id = "6",
                Email = "customer3@gmail.com",
                UserName = "customer3",
                NormalizedUserName = "customer3@gmail.com"
            };

            var hashed = new PasswordHasher<IdentityUser>();

            admin1.PasswordHash = hashed.HashPassword(admin1, "1234");
            admin2.PasswordHash = hashed.HashPassword(admin2, "1234");
            admin3.PasswordHash = hashed.HashPassword(admin3, "1234");
            customer1.PasswordHash = hashed.HashPassword(customer1, "1234");
            customer2.PasswordHash = hashed.HashPassword(customer2, "1234");
            customer3.PasswordHash = hashed.HashPassword(customer3, "1234");

            builder.Entity<IdentityUser>().HasData(admin1, admin2, admin3, customer1, customer2, customer3);
        }

        private static void SeedRole(ModelBuilder builder)
        {
            var ADMIN = new IdentityRole
            {
                Id = "1",
                Name = "Admin",
                NormalizedName = "Admin"
            };

            var CUSTOMER = new IdentityRole
            {
                Id = "2",
                Name = "Customer",
                NormalizedName = "Customer"
            };

            //Add role to Db
            builder.Entity<IdentityRole>().HasData(ADMIN, CUSTOMER);
        }

        // Assign account with role
        private static void SeedUserRole(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "1",
                    RoleId = "1"
                },
                new IdentityUserRole<string>
                {
                    UserId = "2",
                    RoleId = "1"
                },
                new IdentityUserRole<string>
                {
                    UserId = "3",
                    RoleId = "1"
                },
                new IdentityUserRole<string>
                {
                    UserId = "4",
                    RoleId = "2"
                },
                new IdentityUserRole<string>
                {
                    UserId = "5",
                    RoleId = "2"
                },
                new IdentityUserRole<string>
                {
                    UserId = "6",
                    RoleId = "2"
                }
             );
        }
    }
}
