using fredperry.Core.Entities.General;
using fredperry.Core.Interfaces.IRepositories;
using fredperry.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fredperry.Core.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<IEnumerable<ProductCategory>> GetCategoriesByProductId(int productId)
        {
            // Here you retrieve the product-category associations for the given product ID from the repository
            var productCategories = await _productCategoryRepository.GetCategoriesByProductId(productId);
            return productCategories;
        }

        public async Task<IEnumerable<ProductCategory>> GetProductsByCategoryId(int categoryId)
        {
            return await _productCategoryRepository.GetProductsByCategoryId(categoryId);
        }


        public async Task<List<int>> GetCategoryIdsByProductId(int productId)
        {
            // Here you should call the method from the repository to get category IDs by product ID
            var categoryIds = await _productCategoryRepository.GetCategoryIdsByProductId(productId);
            return categoryIds;
        }

        public async Task AddProductCategories(int productId, List<int> categoryIds)
        {
            // Implement logic to add product categories
            foreach (var categoryId in categoryIds)
            {
                await _productCategoryRepository.AddProductCategory(productId, categoryId);
            }
        }

        public async Task AddProductCategory(int productId, int categoryId)
        {
            await _productCategoryRepository.AddProductCategory(productId, categoryId);
        }

        public async Task UpdateProductCategories(int productId, List<int> categoryIds)
        {
            // Implement logic to update product categories
            // For example, you may first delete existing associations and then add new ones:
            await _productCategoryRepository.DeleteProductCategoriesByProductId(productId);
            foreach (var categoryId in categoryIds)
            {
                await _productCategoryRepository.AddProductCategory(productId, categoryId);
            }
        }

        public async Task DeleteProductCategoriesByProductId(int productId)
        {
            // Call the repository method to delete the product-category association
            await _productCategoryRepository.DeleteProductCategoriesByProductId(productId);
        }

        public async Task DeleteProductandCategoryByIds(int productId, int categoryId)
        {
            // Call the repository method to delete the product-category association
            await _productCategoryRepository.DeleteProductandCategoryByIds(productId, categoryId);
        }

    }
}
