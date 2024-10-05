using BusinessLayer.DTOModels;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using System.Diagnostics;
using System.Drawing.Printing;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PropertyService _propertyService;
        public HomeController(ILogger<HomeController> logger, PropertyService propertyService)
        {
            _logger = logger;
            _propertyService = propertyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }



        public async Task<IActionResult> Properties(int pageNumber = 1, int pageSize = 8)
        {
            var pagedProperties = await _propertyService.GetAllPropertiesAsync(pageNumber, pageSize);

            // Pass the paginated result to the view model
            var viewModel = new PagedListViewModel<PropertyDTO>
            {
                Items = pagedProperties.Items,
                PageNumber = pagedProperties.CurrentPage,
                PageSize = pagedProperties.PageSize,
                TotalRecords = pagedProperties.TotalRecords
            };

            return View("Properties", viewModel);
        }



        public IActionResult Agents()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}