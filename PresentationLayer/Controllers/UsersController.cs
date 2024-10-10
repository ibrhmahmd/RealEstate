﻿using System;
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


        //// GET: Users
        //public async Task<IActionResult> Index()
        //{
        //    var users = await _userService.GetAllUsersAsync();
        //    return View(users);
        //}


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

            // Ensure the user ID is parsed to Guid
            if (!Guid.TryParse(userIdString, out Guid userId))
            {
                return BadRequest("Invalid user ID.");
            }

            // Query contracts with user-specific filtering
            var contractsQuery = _context.Contracts
                .Where(c => c.OccupantId == userId) // Filter contracts by the given userId
                .Include(c => c.Agent)               // Include agent details
                .AsQueryable();

            // Get total item count for pagination
            var totalItems = await contractsQuery.CountAsync();

            // Apply pagination using Skip and Take
            var contracts = await contractsQuery
                .Skip((pageNumber - 1) * pageSize) // Skip the previous pages
                .Take(pageSize)                    // Take only the current page size
                .ToListAsync();

            // Map the contracts to ContractDTO
            var contractDTOs = contracts.Select(c => new ContractDTO
            {
                Id = c.Id,
                ContractType = c.ContractType,
                AgentId = c.AgentId,
                EndDate = c.EndDate,
                TotalAmount = c.TotalAmount,
                PropertyLocation = c.PropertyLocation,
            }).ToList();

            // Create a PagedListViewModel to pass data and pagination metadata to the view
            var pagedListViewModel = new PagedListViewModel<ContractDTO>
            {
                Items = contractDTOs,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalItems,
            };

            // Return the view with the paginated list of contracts
            return View(pagedListViewModel);
        }


        public async Task<IActionResult> ListProperties(int pageNumber = 1, int pageSize = 5)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Ensure the user ID is parsed to Guid
            if (!Guid.TryParse(userIdString, out Guid userId))
            {
                return BadRequest("Invalid user ID.");
            }

            // Query properties with user-specific filtering
            var propertiesQuery = _context.Contracts
                .Where(c => c.OccupantId == userId)     // Filter contracts by the given userId
                .Join(_context.Properties,               // Join Contracts with Properties
                      contract => contract.PropertyId,  // Match on PropertyId
                      property => property.Id,          // The Id in the Properties table
                      (contract, property) => property) // Select the property
                .AsQueryable();

            // Get total item count for pagination
            var totalItems = await propertiesQuery.CountAsync();

            // Apply pagination using Skip and Take
            var properties = await propertiesQuery
                .Skip((pageNumber - 1) * pageSize) // Skip the previous pages
                .Take(pageSize)                    // Take only the current page size
                .ToListAsync();

            // Map the properties to PropertyDTO
            var propertyDTOs = properties.Select(p => new PropertyDTO
            {
                Id = p.Id,
                Name = p.Name,
                PropertyPictureUrl = p.PropertyPictureUrl,
                Location = p.Location,
                Description = p.Description,
                Area = p.Area,
                Price = p.Price,
                Type = p.Type,
            }).ToList();

            // Create a PagedListViewModel to pass data and pagination metadata to the view
            var pagedListViewModel = new PagedListViewModel<PropertyDTO>
            {
                Items = propertyDTOs,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRecords = totalItems,
            };

            // Return the view with the paginated list of properties
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
