using fredperry.Core.Interfaces.IServices;
using fredperry.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace fredperry.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        //public async Task<IActionResult> Search(string searchTerm)
        //{
        //    try
        //    {
        //        ViewBag.SearchTerm = searchTerm;

        //        var products = await _productService.Search(searchTerm);

        //        return View(products);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log any errors that occur during product retrieval
        //        _logger.LogError(ex, "An error occurred while retrieving products");
        //        // Return a status code 500 and display the error message
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
