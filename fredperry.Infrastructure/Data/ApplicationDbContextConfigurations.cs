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
                new Category { Id = 3, Name = "The Fred Perry Shirt" },
                new Category { Id = 4, Name = "Coats & Jackets" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Code = "P001", Name = "M3600", Price = 75, IsActive = true, IsNewRelease = true, PictureUrl = "https://www.fredperry.com/media/catalog/product/cache/5df3cd12867f42fc0f0630ded205ccd9/M/3/M3600_V35_V2_Q224_MOD1_FRONT.JPG" },
                new Product { Id = 2, Code = "P002", Name = "M6000", Price = 75, IsActive = true, IsNewRelease = true, PictureUrl = "https://www.fredperry.com/media/catalog/product/cache/03133f2281aec8ae153eeb0f3a984db2/M/6/M6000_V08_V2_Q124_MOD1_FRONT.JPG" },
                new Product { Id = 3, Code = "P003", Name = "M12", Price = 100, IsActive = true, IsNewRelease = true, PictureUrl = "https://www.fredperry.com/media/catalog/product/cache/f07b9be9a45c76d3fe7a961404ccc563/M/1/M12_V46_V2_Q124_MOD1_FRONT.JPG" },
                new Product { Id = 4, Code = "P004", Name = "Osaka M12", Price = 120, IsActive = true, IsNewRelease = true, PictureUrl = "https://www.fredperry.com/media/catalog/product/cache/7cad0ca5918f66422087e7e308d335a6/M/7/M7731_V96_V2_Q323_FLATFRONT.JPG" },
                new Product { Id = 5, Code = "P005", Name = "Tokyo M12", Price = 120, IsActive = true, IsNewRelease = true, PictureUrl = "https://www.fredperry.com/media/catalog/product/cache/29d42814455ec359ef500d1a7ad11576/M/7/M7731_V95_V2_Q323_FLATFRONT.JPG" },
                new Product { Id = 6, Code = "P006", Name = "Shanghai M12", Price = 75, IsActive = true, IsNewRelease = true, PictureUrl = "https://www.fredperry.com/media/catalog/product/cache/1b0781da275362d653cecdd8081faaa3/M/7/M7731_V97_V2_Q323_FLATFRONT.JPG" },
                new Product { Id = 7, Code = "P007", Name = "Makati M12", Price = 75, IsActive = true, IsNewRelease = true, PictureUrl = "https://www.fredperry.com/media/catalog/product/cache/e3573bf7eceeff94844f3e3868878ca8/M/7/M7731_V98_V2_Q323_FLATFRONT.JPG" },

                new Product { Id = 8, Code = "P008", Name = "Brentham Jacket", Price = 160, IsActive = true, IsNewRelease = true, PictureUrl = "https://www.fredperry.com/media/catalog/product/cache/9767c4bb32c5ba031d4c817202f720e4/J/2/J2660_102_1.JPG" },
                new Product { Id = 9, Code = "P009", Name = "Harrington Jacket M", Price = 275, IsActive = true, IsNewRelease = true, PictureUrl = "https://www.fredperry.com/media/catalog/product/cache/f87c8868c51a0f5a50fcd1e2ac9f34d1/J/7/J7320_102_V2_Q323_MOD1_FRONT.JPG" },
                new Product { Id = 10, Code = "P010", Name = "Textured Zip-Through Overshirt", Price = 140, IsActive = true, IsNewRelease = true, PictureUrl = "https://www.fredperry.com/media/catalog/product/cache/9f25655e4e417091766f035488a014a4/M/5/M5684_608_V2_Q124_MOD1_FRONT.JPG" },
                new Product { Id = 11, Code = "P011", Name = "Shell Mac", Price = 250, IsActive = true, IsNewRelease = true, PictureUrl = "https://www.fredperry.com/media/catalog/product/cache/eacaf148ef918b278e70b12c65a357ea/J/7/J7811_638_V2_Q124_MOD1_FRONT.JPG" },
                new Product { Id = 12, Code = "P012", Name = "Insulated Gilet", Price = 140, IsActive = true, IsNewRelease = true, PictureUrl = "https://www.fredperry.com/media/catalog/product/cache/f2684b259bf5bd84e98b92febd804bbf/J/4/J4566_297_V2_Q124_MOD1_FRONT.JPG" },

                new Product { Id = 13, Code = "P013", Name = "G3600", Price = 75, IsActive = true, IsNewRelease = true, PictureUrl = "https://www.fredperry.com/media/catalog/product/cache/db241c40e38d9e113075984e50f341bb/G/3/G3600_R30_V2_Q224_MOD1_FRONT.JPG" },
                new Product { Id = 14, Code = "P014", Name = "G6000", Price = 75, IsActive = true, IsNewRelease = true, PictureUrl = "https://www.fredperry.com/media/catalog/product/cache/c684c76afbeec429a9b7f5deae566f0a/G/6/G6000_B34_V2_Q224_MOD1_FRONT.JPG" },
                new Product { Id = 15, Code = "P015", Name = "G3636", Price = 90, IsActive = true, IsNewRelease = true, PictureUrl = "https://www.fredperry.com/media/catalog/product/cache/943d29fb9141199f8ad71607593909c3/G/3/G3636_S51_V2_Q124_MOD1_FRONT.JPG" },
                new Product { Id = 16, Code = "P016", Name = "G12", Price = 100, IsActive = true, IsNewRelease = true, PictureUrl = "https://www.fredperry.com/media/catalog/product/cache/5c26e2b4d30bab0caebee4e8876d59fd/G/1/G12_301_1.JPG" },
                new Product { Id = 17, Code = "P017", Name = "G7200", Price = 65, IsActive = true, IsNewRelease = true, PictureUrl = "https://www.fredperry.com/media/catalog/product/cache/e88a0615aea85b799c321277b3042aa2/G/7/G7200_129_V2_Q224_ED2.JPG" },

                new Product { Id = 18, Code = "P018", Name = "Laurel Wreath Zip-Through Jacket", Price = 190, IsActive = true, IsNewRelease = true, PictureUrl = "https://www.fredperry.com/media/catalog/product/cache/5aa51f239f594747b4af572c697e331d/S/J/SJ7111_102_V2_Q124_MOD1_FRONT.JPG" },
                new Product { Id = 19, Code = "P019", Name = "Harrington Jacket G", Price = 275, IsActive = true, IsNewRelease = true, PictureUrl = "https://www.fredperry.com/media/catalog/product/cache/bb1d54160fa477a81956aceefcd03d16/J/7/J7412_102_1.JPG" },
                new Product { Id = 20, Code = "P020", Name = "Cropped Taped Track Jacket", Price = 100, IsActive = true, IsNewRelease = true, PictureUrl = "https://www.fredperry.com/media/catalog/product/cache/52cfad5dcd5998e8b333b2acef65bb7c/J/5/J5157_102_1.JPG" },
                new Product { Id = 21, Code = "P021", Name = "Sheer Overlay Jacket", Price = 200, IsActive = true, IsNewRelease = true, PictureUrl = "https://www.fredperry.com/media/catalog/product/cache/b70fc93a9fb1019080662b959b1ece58/J/7/J7118_102_V2_Q124_MOD1_FRONT.JPG" },
                new Product { Id = 22, Code = "P022", Name = "Metallic Knitted Bomber Jacket", Price = 175, IsActive = true, IsNewRelease = true, PictureUrl = "https://www.fredperry.com/media/catalog/product/cache/3bc570d7624851b832c2d24ccff944e7/S/K/SK6559_926_V2_Q423_MOD1_FRONT.JPG" },
                new Product { Id = 23, Code = "P023", Name = "Quilted Jacket", Price = 225, IsActive = true, IsNewRelease = true, PictureUrl = "https://www.fredperry.com/media/catalog/product/cache/cf54d35707f51b903032dd92405427c3/J/6/J6110_560_V2_Q423_MOD1_FRONT.JPG" }







            );

            modelBuilder.Entity<ProductCategory>().HasData(
                // 1 - 3
                new ProductCategory { Id = 1, ProductId = 1, CategoryId = 1 },
                new ProductCategory { Id = 2, ProductId = 1, CategoryId = 3 },

                new ProductCategory { Id = 3, ProductId = 2, CategoryId = 1 },
                new ProductCategory { Id = 4, ProductId = 2, CategoryId = 3 },

                new ProductCategory { Id = 5, ProductId = 3, CategoryId = 1 },
                new ProductCategory { Id = 6, ProductId = 3, CategoryId = 3 },

                new ProductCategory { Id = 7, ProductId = 4, CategoryId = 1 },
                new ProductCategory { Id = 8, ProductId = 4, CategoryId = 3 },

                new ProductCategory { Id = 9, ProductId = 5, CategoryId = 1 },
                new ProductCategory { Id = 10, ProductId = 5, CategoryId = 3 },

                new ProductCategory { Id = 11, ProductId = 6, CategoryId = 1 },
                new ProductCategory { Id = 12, ProductId = 6, CategoryId = 3 },

                new ProductCategory { Id = 13, ProductId = 7, CategoryId = 1 },
                new ProductCategory { Id = 14, ProductId = 7, CategoryId = 3 },

                // 1 - 4
                new ProductCategory { Id = 15, ProductId = 8, CategoryId = 1 },
                new ProductCategory { Id = 16, ProductId = 8, CategoryId = 4 },

                new ProductCategory { Id = 17, ProductId = 9, CategoryId = 1 },
                new ProductCategory { Id = 18, ProductId = 9, CategoryId = 4 },

                new ProductCategory { Id = 19, ProductId = 10, CategoryId = 1 },
                new ProductCategory { Id = 20, ProductId = 10, CategoryId = 4 },

                new ProductCategory { Id = 21, ProductId = 11, CategoryId = 1 },
                new ProductCategory { Id = 22, ProductId = 11, CategoryId = 4 },

                new ProductCategory { Id = 23, ProductId = 12, CategoryId = 1 },
                new ProductCategory { Id = 24, ProductId = 12, CategoryId = 4 },

                // 2 - 3
                new ProductCategory { Id = 25, ProductId = 13, CategoryId = 2 },
                new ProductCategory { Id = 26, ProductId = 13, CategoryId = 3 },

                new ProductCategory { Id = 27, ProductId = 14, CategoryId = 2 },
                new ProductCategory { Id = 28, ProductId = 14, CategoryId = 3 },

                new ProductCategory { Id = 29, ProductId = 15, CategoryId = 2 },
                new ProductCategory { Id = 30, ProductId = 15, CategoryId = 3 },

                new ProductCategory { Id = 31, ProductId = 16, CategoryId = 2 },
                new ProductCategory { Id = 32, ProductId = 16, CategoryId = 3 },

                new ProductCategory { Id = 33, ProductId = 17, CategoryId = 2 },
                new ProductCategory { Id = 34, ProductId = 17, CategoryId = 3 },

                // 2 - 4
                new ProductCategory { Id = 35, ProductId = 18, CategoryId = 2 },
                new ProductCategory { Id = 36, ProductId = 18, CategoryId = 4 },

                new ProductCategory { Id = 37, ProductId = 19, CategoryId = 2 },
                new ProductCategory { Id = 38, ProductId = 19, CategoryId = 4 },

                new ProductCategory { Id = 39, ProductId = 20, CategoryId = 2 },
                new ProductCategory { Id = 40, ProductId = 20, CategoryId = 4 },

                new ProductCategory { Id = 41, ProductId = 21, CategoryId = 2 },
                new ProductCategory { Id = 42, ProductId = 21, CategoryId = 4 },

                new ProductCategory { Id = 43, ProductId = 22, CategoryId = 2 },
                new ProductCategory { Id = 44, ProductId = 22, CategoryId = 4 },

                new ProductCategory { Id = 45, ProductId = 23, CategoryId = 2 },
                new ProductCategory { Id = 46, ProductId = 23, CategoryId = 4 }
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
