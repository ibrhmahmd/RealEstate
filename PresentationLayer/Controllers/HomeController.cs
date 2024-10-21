using BusinessLayer.DTOModels;
using BusinessLayer.Services;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Net.Mail;
using System.Net;

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

        public async Task<IActionResult> Index()
        {
            var latestProperties = await _propertyService.GetLatestPropertiesAsync(3);

            var viewModel = new PagedListViewModel<PropertyDTO>
            {
                Items = latestProperties.Items,
                TotalRecords = latestProperties.TotalRecords
            };

            return View(viewModel);
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
            var pagedProperties = await _propertyService.GetAvailblePropertiesAsync(pageNumber, pageSize);

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
        [HttpGet]
        public IActionResult Contact()
        {
            return View(new ContactFormViewModel()); // Initialize the view model
        }
        [HttpPost]
        public async Task<IActionResult> Contact(ContactFormViewModel contact)
        {
            if (ModelState.IsValid)
            {
              
                var result = await contact.SendMailAsync("mariaammaagdy22@gmail.com", "2410203mm");
                if (result)
                {
                    // Optionally redirect or display a success message
                    ViewBag.Message = "Your message has been sent successfully.";
                }
                else
                {
                    ModelState.AddModelError("", "Unable to send email. Please try again.");
                }
            }

            return View(contact); // Return the view with the model to display validation errors
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}