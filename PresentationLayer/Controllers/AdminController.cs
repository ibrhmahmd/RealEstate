using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using BusinessLayer.Services;
using BusinessLayer.DTOModels;
using Microsoft.AspNetCore.Http;
using PresentationLayer.helper;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PresentationLayer.Models;
using System.Drawing.Printing;
namespace PresentationLayer.Controllers
{
    
    public class AdminController : Controller
    {
        private readonly PropertyService _propertyService;
        private readonly UserService _userService;
        private readonly ContractService _contractService;
        private readonly PaymentService _paymentService;
        private readonly MyDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(PropertyService propertyService, UserService userService,
            ContractService contractService, PaymentService paymentService, MyDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _propertyService = propertyService;
            _userService = userService;
            _contractService = contractService;
            _paymentService = paymentService;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }




        // Property CRUD Operations
        public async Task<IActionResult> ListProperties(int pageNumber = 1, int pageSize = 5)
        {
            if (User.IsInRole("Admin"))
            {

            }
            var pagedProperties = await _propertyService.GetAllPropertiesAsync(pageNumber, pageSize);
            var pagedListViewModel = new PagedListViewModel<PropertyDTO>
            {
                Items = pagedProperties.Items,
                PageNumber = pagedProperties.CurrentPage,
                PageSize = pagedProperties.PageSize,
                TotalRecords = pagedProperties.TotalRecords
            };

            return View(pagedListViewModel);
            return Unauthorized();
        }





        // User Listing
        public async Task<IActionResult> ListUsers(int pageNumber = 1, int pageSize = 5)
        {
            if (User.IsInRole("Admin"))
            {

            }
            var pagedUsers = await _userService.GetAllUsersAsync(pageNumber, pageSize);

            // Pass the paginated result to the view model
            var viewModel = new PagedListViewModel<UserDTO>
            {
                Items = pagedUsers.Items,
                PageNumber = pagedUsers.CurrentPage,
                PageSize = pagedUsers.PageSize,
                TotalRecords = pagedUsers.TotalRecords
            };
            return View(viewModel);
            return Unauthorized();
        }


        public async Task<IActionResult> ListContracts(int pageNumber = 1, int pageSize = 5)
        {

            if (User.IsInRole("Admin"))
            {

            }
            var Pagedcontracts = await _contractService.GetAllContractsAsync(pageNumber, pageSize);

            // Pass the paginated result to the view model
            var viewModel = new PagedListViewModel<ContractDTO>
            {
                Items = Pagedcontracts.Items,
                PageNumber = Pagedcontracts.CurrentPage,
                PageSize = Pagedcontracts.PageSize,
                TotalRecords = Pagedcontracts.TotalRecords
            };
            return View(viewModel);
            return Unauthorized();
        }


        public async Task<IActionResult> CreateProperty(PropertyDTO propertyDto)
        {

            if (propertyDto.PropertyPicture != null)
            {

                var fileName = UploadFile.UploadImage("PropertyPicture", propertyDto.PropertyPicture);
                propertyDto.PropertyPictureUrl = fileName;
            }

            if (ModelState.IsValid)
            {
                await _propertyService.CreatePropertyAsync(propertyDto);
                return RedirectToAction("ListProperties");
            }
            return View(propertyDto);
        }


        public async Task<IActionResult> EditProperty(Guid id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);

            if (property == null)
            {
                return NotFound();
            }
            return View(property);
        }

        [HttpPost]
        public async Task<IActionResult> EditProperty(PropertyDTO propertyDto)
        {
            if (propertyDto.PropertyPicture != null)
            {

                var fileName = UploadFile.UploadImage("PropertyPicture", propertyDto.PropertyPicture);
                propertyDto.PropertyPictureUrl = fileName;
            }
            if (ModelState.IsValid)
            {
                await _propertyService.UpdatePropertyAsync(propertyDto);
                return RedirectToAction("ListProperties");
            }
            return View(propertyDto);
        }


        public async Task<IActionResult> SoftDeleteProperty(Guid id)
        {
            await _propertyService.SoftDeletePropertyAsync(id);
            return RedirectToAction("ListProperties");
        }

        public async Task<IActionResult> ShowProperty(Guid id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);
            if (property == null)
            {
                return NotFound();
            }
            return View(property);
        }
        // Soft Delete User
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _userService.SoftDeleteUserAsync(id);
            return RedirectToAction("ListUsers");
        }


        // User Details
        public async Task<IActionResult> Details(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public async Task<IActionResult> ContractDetails(Guid id)
        {

            var contract = await _contractService.GetContractByIdAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
            return View(contract);
        }
        public async Task<IActionResult> ListPayments(int pageNumber = 1, int pageSize = 5)
        {
            if (User.IsInRole("Admin"))
            {

            }
            var Pagedpayment = await _paymentService.GetAllPaymentsAsync(pageNumber, pageSize);

            // Pass the paginated result to the view model
            var viewModel = new PagedListViewModel<PaymentDTO>
            {
                Items = Pagedpayment.Items,
                PageNumber = Pagedpayment.CurrentPage,
                PageSize = Pagedpayment.PageSize,
                TotalRecords = Pagedpayment.TotalRecords
            };
            return View(viewModel);
            return Unauthorized();
        }
        public async Task<IActionResult> PaymentDetails(Guid id)
        {
            var pay = await _paymentService.GetPaymenttByIdAsync(id);
            if (pay == null)
            {
                return NotFound();
            }
            return View(pay);
        }
        public async Task<IActionResult> Terminate(Guid id)
        {
            try
            {
                var contract = await _context.Contracts.FindAsync(id);

                if (contract == null)
                {
                    throw new KeyNotFoundException("Contract not found.");
                }

                contract.IsTerminated = true;
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Contract terminated successfully.";
            }
            catch (KeyNotFoundException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while terminating the contract.";
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("ListContracts");
        }



        public async Task<IActionResult> DownloadFile()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "properties", "Residential Lease Agreement.pdf");
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            var contentType = "application/pdf";
            var fileName = Path.GetFileName(path);
            return File(memory, contentType, fileName);
        }
    }
}