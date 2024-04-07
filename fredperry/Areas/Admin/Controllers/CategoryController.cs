using fredperry.Core.Entities.Business;
using fredperry.Core.Entities.General;
using fredperry.Core.Interfaces.IServices;
using fredperry.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace fredperry.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductService _productService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService, IProductCategoryService productCategoryService, IProductService productService)
        {
            _logger = logger;
            _categoryService = categoryService;
            _productCategoryService = productCategoryService;
            _productService = productService;
        }

        public async Task<IActionResult> Search(string searchTerm)
        {
            try
            {
                ViewBag.SearchTerm = searchTerm;

                var categories = await _categoryService.Search(searchTerm);

                return View(categories);
            }
            catch (Exception ex)
            {
                // Log any errors that occur during product retrieval
                _logger.LogError(ex, "An error occurred while retrieving products");
                // Return a status code 500 and display the error message
                return StatusCode(500, ex.Message);
            }
        }

        // GET: Category/Index
        public async Task<IActionResult> Index(int? page)
        {
            try
            {
                // Set the page size and page number
                int pageSize = 20;
                int pageNumber = page ?? 1;

                // Retrieve paginated categories from the CategoryService
                var categories = await _categoryService.GetPaginatedCategories(pageNumber, pageSize);

                // Convert the list of categories to a StaticPagedList
                var pagedCategories = new StaticPagedList<CategoryViewModel>(categories.Data, pageNumber, pageSize, categories.TotalCount);

                return View(pagedCategories);
            }
            catch (Exception ex)
            {
                // Log any errors that occur during category retrieval
                _logger.LogError(ex, "An error occurred while retrieving categories");
                // Return a status code 500 and display the error message
                return StatusCode(500, ex.Message);
            }
        }


        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Call the service method to create the category
                    await _categoryService.Create(model);

                    // Redirect to the index page after successful creation
                    return RedirectToAction("Index");
                }

                // If there are model state errors, return to the create view with the model
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a category");
                return View("Error");
            }
        }


        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var category = await _categoryService.GetCategory(id);
                if (category == null)
                {
                    return NotFound();
                }

                var viewModel = new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the category for editing");
                return View("Error");
            }
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryViewModel model)
        {
            try
            {
                if (id != model.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    // Call the service method to update the category
                    await _categoryService.Update(model);

                    // Redirect to the index page after successful update
                    return RedirectToAction("Index");
                }

                // If there are model state errors, return to the edit view with the model
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while editing the category");
                return View("Error");
            }
        }


        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var category = await _categoryService.GetCategory(id);
                if (category == null)
                {
                    return NotFound();
                }

                var viewModel = new CategoryDeleteConfirmationViewModel
                {
                    Categories = await _categoryService.GetCategories(),
                    Category = category,
                    Products = new List<ProductViewModel>(),
                };

                // Check if any product has this category
                var productsWithCategory = await _productCategoryService.GetProductsByCategoryId(id);
                if (productsWithCategory.Any())
                {
                    // Extract product IDs
                    var productIds = productsWithCategory.Select(pc => pc.ProductId).ToList();

                    // Fetch product details using the product IDs
                    var products = await _productService.GetProductsByIds(productIds);

                    // If products are associated with this category, pass them to the view
                    viewModel.Products = products;

                    return View(viewModel);
                }

                // If no products are associated with this category, proceed with direct deletion
                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the category");
                return View("Error");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int categoryId, int newCategoryId)
        {
            try
            {
                // Ensure both category IDs are provided
                if (categoryId == 0 || newCategoryId == 0)
                {
                    return BadRequest("Invalid category IDs.");
                }

                // Get the category to be deleted
                var categoryToDelete = await _categoryService.GetCategory(categoryId);
                if (categoryToDelete == null)
                {
                    return NotFound("Category not found.");
                }

                // Get the new category
                var newCategory = await _categoryService.GetCategory(newCategoryId);
                if (newCategory == null)
                {
                    return NotFound("New category not found.");
                }

                // Update products associated with the category to be deleted
                var productsToUpdate = await _productCategoryService.GetProductsByCategoryId(categoryId);
                foreach (var product in productsToUpdate)
                {
                    // Replace the category to be deleted with the new category

                    await _productCategoryService.DeleteProductandCategoryByIds(product.ProductId, categoryId);
                    await _productCategoryService.AddProductCategory(product.ProductId, newCategory.Id);
                }

                // Delete the category
                await _categoryService.Delete(categoryId);

                // Redirect to the category index page after successful deletion
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log any errors that occur during deletion
                _logger.LogError(ex, "An error occurred while deleting the category");
                return View("Error");
            }
        }

        [HttpPost, ActionName("SafeDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed2(int id)
        {
            try
            {
                // Delete the category
                await _categoryService.Delete(id);

                // Redirect to the category index page after successful deletion
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log any errors that occur during deletion
                _logger.LogError(ex, "An error occurred while deleting the category");
                return View("Error");
            }
        }
    }
}
