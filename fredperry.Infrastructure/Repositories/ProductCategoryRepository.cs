using fredperry.Core.Entities.Business;
using fredperry.Core.Entities.General;
using fredperry.Core.Interfaces.IRepositories;
using fredperry.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fredperry.Infrastructure.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductCategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductCategory>> GetCategoriesByProductId(int productId)
        {
            // Query the ProductCategory table to get the product-category associations for the given product ID
            return await _dbContext.ProductCategories
                .Where(pc => pc.ProductId == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductCategory>> GetProductsByCategoryId(int categoryId)
        {
            // Query the ProductCategory table to get the products associated with the given category ID
            return await _dbContext.ProductCategories
                .Where(pc => pc.CategoryId == categoryId)
                .ToListAsync();
        }

        // Implement the GetCategoryIdsByProductId method from the interface
        public async Task<List<int>> GetCategoryIdsByProductId(int productId)
        {
            // Query the ProductCategory table to get the category IDs associated with the given product ID
            var categoryIds = await _dbContext.ProductCategories
                .Where(pc => pc.ProductId == productId)
                .Select(pc => pc.CategoryId)
                .ToListAsync();

            return categoryIds;
        }

        // Implement the AddProductCategory method from the interface
        public async Task AddProductCategory(int productId, int categoryId)
        {
            var productCategory = new ProductCategory { ProductId = productId, CategoryId = categoryId };
            await _dbContext.ProductCategories.AddAsync(productCategory);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProductCategories(int productId, List<int> categoryIds)
        {
            // First, delete existing product-category associations for the given product ID
            await DeleteProductCategoriesByProductId(productId);

            // Then, add new product-category associations
            foreach (var categoryId in categoryIds)
            {
                await AddProductCategory(productId, categoryId);
            }
        }

        public async Task DeleteProductCategoriesByProductId(int productId)
        {
            // Delete all product-category associations for the given product ID
            var productCategories = await _dbContext.ProductCategories
                .Where(pc => pc.ProductId == productId)
                .ToListAsync();

            _dbContext.ProductCategories.RemoveRange(productCategories);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductandCategoryByIds(int productId, int categoryId)
        {
            // Find the product-category association with the given product and category IDs
            var productCategory = await _dbContext.ProductCategories
                .FirstOrDefaultAsync(pc => pc.ProductId == productId && pc.CategoryId == categoryId);

            if (productCategory != null)
            {
                // Remove the product-category association from the context
                _dbContext.ProductCategories.Remove(productCategory);

                // Save changes to the database
                await _dbContext.SaveChangesAsync();
            }
        }

    }

}
