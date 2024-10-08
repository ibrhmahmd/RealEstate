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
using DataAccessLayer.Entities;
namespace PresentationLayer.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly PropertyService _propertyService;
        private readonly UserService _userService;
        private readonly ContractService _contractService;
        private readonly PaymentService _paymentService;
        private readonly DeveloperCompanyService _developerCompanyService;
        private readonly ProjectService _projectService;
        private readonly MyDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(PropertyService propertyService, UserService userService,
            ContractService contractService, PaymentService paymentService,
            DeveloperCompanyService developerCompanyService,ProjectService projectService,
            MyDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _propertyService = propertyService;
            _userService = userService;
            _contractService = contractService;
            _paymentService = paymentService;
            _projectService = projectService;
            _developerCompanyService = developerCompanyService;
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

        //Developer
        public async Task<IActionResult> DeveloperList(int pageNumber = 1, int pageSize = 5)
        {

            if (User.IsInRole("Admin"))
            {

            }
            var PagedDeveloper = await _developerCompanyService.GetAllDeveloperCompaniesAsync(pageNumber, pageSize);

            // Pass the paginated result to the view model
            var viewModel = new PagedListViewModel<DeveloperCompanyDTO>
            {
                Items = PagedDeveloper.Items,
                PageNumber = PagedDeveloper.CurrentPage,
                PageSize = PagedDeveloper.PageSize,
                TotalRecords = PagedDeveloper.TotalRecords
            };
            return View(viewModel);
            return Unauthorized();
        }
        public async Task<IActionResult> DeveloperDetails(Guid id)
        {
            var Developer = await _developerCompanyService.GetDeveloperCompanyByIdAsync(id);
            if (Developer == null)
            {
                return NotFound();
            }
            return View(Developer);

        }

        public async Task<IActionResult> CreateDeveloper(DeveloperCompanyDTO developer)
        {
            if (ModelState.IsValid)
            {
                await _developerCompanyService.CreateDeveloperCompanyAsync(developer);
                return RedirectToAction("DeveloperList");
            }
            return View(developer);
        }
        public async Task<IActionResult> DeleteDeveloper(Guid id)
        {
            var developer = await _developerCompanyService.GetDeveloperCompanyByIdAsync(id);
            return View(developer);
        }
        [HttpPost, ActionName("DeleteDeveloper")]
        public async Task<IActionResult> DeleteDeveloperCompany(Guid id)
        {
            await _developerCompanyService.SoftDeleteDeveloperCompanyAsync(id);
            return RedirectToAction("DeveloperList");
        }
        public async Task<IActionResult> EditDeveloper(Guid id)
        {
            var developer = await _developerCompanyService.GetDeveloperCompanyByIdAsync(id);
            if (developer == null)
            {
                return NotFound();
            }
            return View(developer);
        }
        [HttpPost]
       public async Task<IActionResult> EditDeveloper(DeveloperCompanyDTO developer)
        {
            if (ModelState.IsValid)
            {
                await _developerCompanyService.UpdateDeveloperCompanyAsync(developer);
                return RedirectToAction("DeveloperList");
            }
            return View(developer);
        }





        //Project
        public async Task<IActionResult> ProjectList(int pageNumber = 1, int pageSize = 5)
        {

            if (User.IsInRole("Admin"))
            {

            }
            var PagedProject = await _projectService.GetAllProjectsAsync(pageNumber, pageSize);

            // Pass the paginated result to the view model
            var viewModel = new PagedListViewModel<ProjectDTO>
            {
                Items = PagedProject.Items,
                PageNumber = PagedProject.CurrentPage,
                PageSize = PagedProject.PageSize,
                TotalRecords = PagedProject.TotalRecords
            };
            return View(viewModel);
            return Unauthorized();
        }
        public async Task<IActionResult> ProjectDetails(Guid id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
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