using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.DTOModels;
using BusinessLayer.Services;
using DataAccessLayer.Entities;
using PresentationLayer.helper;
using PresentationLayer.Models;
using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace PresentationLayer.Controllers
{

    public class UsersController : Controller
    {
        private readonly UserService _userService;
        private readonly ContractService _contractService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly PropertyService _propertyService;
        private readonly MyDbContext _context;

        public UsersController(UserService userService,ContractService contractService, IWebHostEnvironment webHostEnvironment, MyDbContext context, PropertyService propertyService)
        {
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _propertyService = propertyService;
            _contractService = contractService;
        }



        // GET: Users/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var user = await _userService.GetUserByIdAsync(id.Value);
                return View(user);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
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
        public async Task<IActionResult> ContractDetails(Guid id)
        {

            var contract = await _contractService.GetContractByIdAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
            return View(contract);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,Email,PasswordHash,PhoneNumber")] User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var createdUser = await _userService.CreateUserAsync(user);
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("Email", ex.Message);
                }
            }
            return View(user);
        }






        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);

                var userEditViewModel = new UserEditViewModel
                {
                    Id = user.Id,
                    Name = user.UserName,
                    Email = user.Email,
                    UserPictureUrl = user.UserPictureUrl,
                    PhoneNumber = user.PhoneNumber
                };
                return View(userEditViewModel);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("User not found.");
            }
            catch (Exception ex)
            {
                // Log the error for troubleshooting
                // _logger.LogError(ex, "Failed to retrieve user data.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserPicture != null)
                {
                    var fileName = UploadFile.UploadImage("userpicture", model.UserPicture);
                    model.UserPictureUrl = fileName;
                }

                var user = new User
                {
                    Id = model.Id,
                    UserName = model.Name,
                    Email = model.Email,
                    UserPictureUrl = model.UserPictureUrl,
                    PhoneNumber = model.PhoneNumber,
                };

                await _userService.UpdateUserAsync(user);
                return RedirectToAction("Profile", "Account");
            }
            return View(model);
        }


        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var user = await _userService.GetUserByIdAsync(id.Value);
                return View(user);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }


        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _userService.HardDeleteUserAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        private Guid? GetUserIdFromClaims()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.TryParse(userIdString, out Guid userId) ? userId : (Guid?)null;
        }

        public async Task<IActionResult> ListContracts(Guid Id, int pageNumber = 1, int pageSize = 10)
        {
            if (Id == null)
            {
                return BadRequest("Invalid user ID.");
            }

            var (contracts, totalItems) = await _userService.GetUserContractsAsync(Id, pageNumber, pageSize);

            var pagedListViewModel = new PagedListViewModel<ContractDTO>
            {
                UserId = Id,
                Items = contracts,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalItems,
            };

            return View(pagedListViewModel);
        }

        public async Task<IActionResult> ListProperties(Guid Id, int pageNumber = 1, int pageSize = 10)
        {
            if (Id == null)
            {
                return BadRequest("Invalid user ID.");
            }
            var (properties, totalItems) = await _userService.GetUserPropertiesAsync(Id, pageNumber, pageSize);
            var pagedListViewModel = new PagedListViewModel<PropertyDTO>
            {
                UserId = Id,
                Items = properties,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalItems,
            };
            return View(pagedListViewModel);
        }



        public async Task<IActionResult> ListPropertiesOWNED(int pageNumber = 1, int pageSize = 5)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }


            var pagedProperties = await _propertyService.GetAvailblePropertiesAsync(pageNumber, pageSize);
            var pagedListViewModel = new PagedListViewModel<PropertyDTO>
            {
                Items = pagedProperties.Items.Where(o => o.Status == PropertStatus.Ownership).ToList(),
                PageNumber = pagedProperties.CurrentPage,
                PageSize = pagedProperties.PageSize,
                TotalRecords = pagedProperties.TotalRecords
            };

            return View(pagedListViewModel);
        }

        public async Task<IActionResult> ListPropertiesLease(int pageNumber = 1, int pageSize = 5)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }


            var pagedProperties = await _propertyService.GetAvailblePropertiesAsync(pageNumber, pageSize);
            var pagedListViewModel = new PagedListViewModel<PropertyDTO>
            {
                Items = pagedProperties.Items.Where(p => p.Status == PropertStatus.Lease).ToList(),
                PageNumber = pagedProperties.CurrentPage,
                PageSize = pagedProperties.PageSize,
                TotalRecords = pagedProperties.TotalRecords
            };

            return View(pagedListViewModel);
        }


        public async Task<IActionResult> CreateProperty(PropertyDTO propertyDto)
        {
            // Fixed "Other" project ID.
            var otherProjectId = Guid.Parse("11111111-1111-1111-1111-111111111111");

            // If "Other" is selected, use the fixed ID.
            if (propertyDto.ProjectId == otherProjectId)
            {
                propertyDto.PropertyProject = "Other";  // Set display value as "Other".
            }

            // Handle property image upload.
            if (propertyDto.PropertyPicture != null)
            {
                var fileName = UploadFile.UploadImage("PropertyPicture", propertyDto.PropertyPicture);
                propertyDto.PropertyPictureUrl = fileName;
            }

            // Map AddressId to Location if available.
            if (propertyDto.AddressId.HasValue)
            {
                var selectedAddress = await _context.Addresses.FindAsync(propertyDto.AddressId.Value);
                propertyDto.Location = selectedAddress != null
                    ? $"{selectedAddress.City}, {selectedAddress.State}"
                    : "Location not specified";
            }

            // Map ProjectId to ProjectName if available.
            if (propertyDto.ProjectId.HasValue && propertyDto.ProjectId != otherProjectId)
            {
                var selectedProject = await _context.Projects.FindAsync(propertyDto.ProjectId.Value);
                propertyDto.PropertyProject = selectedProject != null
                    ? selectedProject.ProjectName
                    : "Project not specified";
            }

            // Validate and save the property.
            if (ModelState.IsValid)
            {
                await _propertyService.CreatePropertyAsync(propertyDto);
                return RedirectToAction("Index" ,  "Home");
            }

            // Reload lists for the form in case of validation failure.
            propertyDto.Projects = await _context.Projects.ToListAsync();
            propertyDto.Locations = await _context.Addresses.ToListAsync();
            return View(propertyDto);
        }
        public async Task<IActionResult> UserPayments(Guid Id, int pageNumber = 1, int pageSize =1)
        {
            if (Id == Guid.Empty)  // Adjusted to check for an empty Guid
            {
                return BadRequest("Invalid user ID.");
            }

            // Retrieve the payments and total item count for the user
            var (payments, totalItems) = await _userService.GetUserPaymentsAsync(Id, pageNumber, pageSize);

            // Create a PagedListViewModel for PaymentDTOs
            var pagedListViewModel = new PagedListViewModel<PaymentDTO>
            {
                UserId = Id,
                Items = payments,   // Use payments instead of properties
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalItems,
            };

            return View(pagedListViewModel);
        }






    }
}