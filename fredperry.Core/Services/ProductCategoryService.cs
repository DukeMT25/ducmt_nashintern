using fredperry.Core.Entities.Business;
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
        private readonly IProductService _productService;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IProductService productService)
        {
            _productCategoryRepository = productCategoryRepository;
            _productService = productService;
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

        public async Task<IEnumerable<ProductViewModel>> GetProductsByCategoryIds(IEnumerable<int> categoryIds)
        {
            var productViewModels = new List<ProductViewModel>();

            // Retrieve products associated with the first category
            var firstCategoryProducts = await _productCategoryRepository.GetProductsByCategoryId(categoryIds.First());

            // Retrieve products associated with the second category
            var secondCategoryProducts = await _productCategoryRepository.GetProductsByCategoryId(categoryIds.Last());

            // Find products that belong to both categories
            var productsInBothCategories = firstCategoryProducts
                .Where(pc1 => secondCategoryProducts.Any(pc2 => pc1.ProductId == pc2.ProductId));

            var pid = new List<int>();

            foreach (var ponc in  productsInBothCategories)
            {
                pid.Add(ponc.ProductId);
            }

            var targetProducts = await _productService.GetProductsByIds(pid);

            // Convert products to view models
            foreach (var product in targetProducts)
            {
                var productViewModel = new ProductViewModel
                {
                    Id = product.Id,
                    Code = product.Code,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    IsActive = product.IsActive,
                    IsNewRelease = product.IsNewRelease,
                    PictureUrl = product.PictureUrl
                    // Add other properties as needed
                };

                productViewModels.Add(productViewModel);
            }

            return productViewModels;
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
