using fredperry.Core.Entities.Business;
using fredperry.Core.Entities.General;
using fredperry.Core.Interfaces.IServices;
using fredperry.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace fredperry.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IProductCategoryService _productCategoryService;

        public ProductController(ILogger<ProductController> logger, IProductService productService, ICategoryService categoryService, IProductCategoryService productCategoryService)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
            _productCategoryService = productCategoryService;
        }

        public async Task<IActionResult> Search(string searchTerm)
        {
            var products = await _productService.Search(searchTerm);
            return View(products);
        }


        // GET: ProductController
        public async Task<IActionResult> Index(int? page)
        {
            try
            {
                // Set the page size and page number
                int pageSize = 15;
                int pageNumber = page ?? 1;

                // Retrieve paginated products from the ProductService
                var products = await _productService.GetPaginatedProducts(pageNumber, pageSize);

                // Convert the list of products to a StaticPagedList
                var pagedProducts = new StaticPagedList<ProductViewModel>(products.Data, pageNumber, pageSize, products.TotalCount);

                return View(pagedProducts);
            }
            catch (Exception ex)
            {
                // Log any errors that occur during product retrieval
                _logger.LogError(ex, "An error occurred while retrieving products");
                // Return a status code 500 and display the error message
                return StatusCode(500, ex.Message);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var product = await _productService.GetProduct(id);

                // Fetch categories associated with the product
                var productCategories = await _productCategoryService.GetCategoriesByProductId(id);

                // Extract category IDs
                var categoryIds = productCategories.Select(pc => pc.CategoryId).ToList();

                // Fetch category details using the category IDs
                var categories = await _categoryService.GetCategoriesByIds(categoryIds);

                // Pass the product and its categories to the view
                var viewModel = new ProductDetailViewModel
                {
                    Product = product,
                    Categories = categories
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving the product");
                return StatusCode(500, ex.Message);
            }
        }

        // GET: ProductController/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                ProductViewModel viewModel = await GetAllCategories();

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving categories for product creation");
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Check if the product name or code already exists
                    if (await _productService.IsExists("Name", model.Name))
                    {
                        ModelState.AddModelError("Name", $"The product name '{model.Name}' already exists.");
                    }

                    if (await _productService.IsExists("Code", model.Code))
                    {
                        ModelState.AddModelError("Code", $"The product code '{model.Code}' already exists.");
                    }

                    // If there are no model state errors, proceed to create the product
                    if (ModelState.IsValid)
                    {
                        // Create the product and get the product ID
                        var productId = await _productService.Create(model);

                        // Associate selected categories with the product
                        var selectedCategoryIds = model.SelectedCategoryIds ?? new List<int>();
                        await _productCategoryService.AddProductCategories(productId.Id, selectedCategoryIds);

                        // Redirect to the index page after successful creation
                        return RedirectToAction("Index");
                    }
                }

                // If there are model state errors or other issues, return to the create view with the model
                var viewModel = await GetAllCategories();

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a product");
                return View("Error");
            }
        }

        // GET: ProductController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var viewModel = await GetProductCategories(id);

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the product for editing");
                return View("Error");
            }
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductViewModel model)
        {
            try
            {
                if (id != model.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    // Update the product
                    await _productService.Update(model);

                    // Update product categories
                    await _productCategoryService.UpdateProductCategories(model.Id, model.SelectedCategoryIds);

                    return RedirectToAction("Index");
                }

                // If there are model state errors, return to the edit view with the model
                var viewModel = await GetProductCategories(id);
                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while editing the product");
                return View("Error");
            }
        }



        // GET: ProductController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await _productService.GetProduct(id);

                // Fetch categories associated with the product
                var productCategories = await _productCategoryService.GetCategoriesByProductId(id);

                // Extract category IDs
                var categoryIds = productCategories.Select(pc => pc.CategoryId).ToList();

                // Fetch category details using the category IDs
                var categories = await _categoryService.GetCategoriesByIds(categoryIds);

                // Pass the product and its categories to the view
                var viewModel = new ProductDetailViewModel
                {
                    Product = product,
                    Categories = categories
                };
                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the product");
                return View("Error");
            }
        }

        // GET: ProductController/DeleteConfirmed/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _productCategoryService.DeleteProductCategoriesByProductId(id);
                // Call your service method to delete the product
                await _productService.Delete(id);

                // Redirect to a suitable action after successful deletion
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log any errors that occur during deletion
                _logger.LogError(ex, "An error occurred while deleting the product");
                return View("Error");
            }
        }

        private async Task<ProductViewModel> GetAllCategories()
        {
            try
            {
                var categories = await _categoryService.GetCategories();
                var viewModel = new ProductViewModel
                {
                    Categories = categories.Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToList()
                };

                return viewModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving categories");
                throw; // Rethrow the exception to be handled by the caller
            }
        }

        // Helper method to fetch categories associated with a product
        private async Task<ProductViewModel> GetProductCategories(int productId)
        {
            try
            {
                // Retrieve the product by its ID
                var product = await _productService.GetProduct(productId);

                // Retrieve categories to populate the dropdown list
                var categories = await _categoryService.GetCategories();

                // Get the selected category IDs for the product
                var selectedCategoryIds = (await _productCategoryService.GetCategoryIdsByProductId(productId)).ToList();

                // Create a view model for the edit form
                var viewModel = new ProductViewModel
                {
                    Id = product.Id,
                    Code = product.Code,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    IsActive = product.IsActive,
                    IsNewRelease = product.IsNewRelease,
                    // Populate the Categories dropdown list
                    Categories = categories.Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name,
                        Selected = selectedCategoryIds.Contains(c.Id) // Set selected for categories associated with the product
                    }).ToList(),
                    // Set the selected category IDs
                    SelectedCategoryIds = selectedCategoryIds
                };
                return viewModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving product categories");
                throw; // Rethrow the exception to be handled by the caller
            }
        }
    }
}
