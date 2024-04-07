using fredperry.Core.Entities.Business;
using fredperry.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace fredperry.UI.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class WomenController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly ICategoryService _categoryService;

        public WomenController(IProductService productService, IProductCategoryService productCategoryService, ICategoryService categoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IEnumerable<ProductViewModel>> GetProduct(IEnumerable<int> categoryIds)
        {
            var productViewModels = await _productCategoryService.GetProductsByCategoryIds(categoryIds);

            // You can pass the retrieved products to the view
            return productViewModels;
        }

        public async Task<IActionResult> CateProduct(IEnumerable<int> categoryIds)
        {
            var products = await GetProduct(categoryIds);

            return View(products);
        }

        // Action method to display product details
        public async Task<IActionResult> ProductDetail(int productId)
        {
            // Retrieve the product details from the repository
            var product = await _productService.GetProduct(productId);

            if (product == null)
            {
                return NotFound(); // Return a 404 Not Found if the product is not found
            }

            return View(product); // Pass the product details to the view
        }
    }
}
