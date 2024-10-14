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






        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var user = await _userService.GetUserByIdAsync(id);

                var UserEditViewModel = new UserEditViewModel
                {
                    Id = user.Id,
                    Name = user.UserName,
                    Email = user.Email,
                    UserPictureUrl = user.UserPictureUrl,
                    PhoneNumber = user.PhoneNumber
                };
                return View(UserEditViewModel);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewModel model)
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

            if (ModelState.IsValid)
            {
                await _userService.UpdateUserAsync(user);
                return RedirectToAction("profile", "account");
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
        public async Task<IActionResult> ListContracts(int pageNumber = 1, int pageSize = 5)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!Guid.TryParse(userIdString, out Guid userId))
            {
                return BadRequest("Invalid user ID.");
            }

            var (contracts, totalItems) = await _userService.GetUserContractsAsync(userId, pageNumber, pageSize);

            var pagedListViewModel = new PagedListViewModel<ContractDTO>
            {
                Items = contracts,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalItems,
            };

            return View(pagedListViewModel);
        }


        public async Task<IActionResult> ListProperties(int pageNumber = 1, int pageSize = 5)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!Guid.TryParse(userIdString, out Guid userId))
            {
                return BadRequest("Invalid user ID.");
            }

            var (properties, totalItems) = await _userService.GetUserPropertiesAsync(userId, pageNumber, pageSize);

            var pagedListViewModel = new PagedListViewModel<PropertyDTO>
            {
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

            if (propertyDto.PropertyPicture != null)
            {

                var fileName = UploadFile.UploadImage("PropertyPicture", propertyDto.PropertyPicture);
                propertyDto.PropertyPictureUrl = fileName;
            }

            if (ModelState.IsValid)
            {
                await _propertyService.CreatePropertyAsync(propertyDto);
                return RedirectToAction("profile", "account");
            }
            return View(propertyDto);
        }

    }
}