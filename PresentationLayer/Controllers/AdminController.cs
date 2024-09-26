using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using BusinessLayer.Services; 
using BusinessLayer.DTOModels;

namespace PresentationLayer.Controllers
{
    public class AdminController : Controller
    {
        private readonly PropertyService _propertyService;
        private readonly UserService _userService;
        private readonly ContractService _contractService;
        private readonly AddressService _addressService;
        private readonly PaymentService _paymentService;

        public AdminController(
            PropertyService propertyService,
            UserService userService,
            ContractService contractService,
            AddressService addressService,
            PaymentService paymentService)
        {
            _propertyService = propertyService;
            _userService = userService;
            _contractService = contractService;
            _addressService = addressService;
            _paymentService = paymentService;
        }




        // Property CRUD Operations
        public async Task<IActionResult> ListProperties()
        {
            var properties = await _propertyService.GetAllPropertiesAsync();
            return View("AdminListProperties", properties); // Ensures it returns the correct view
        }


        public async Task<IActionResult> CreateProperty(PropertyDTO propertyDto)
        {
            if (ModelState.IsValid)
            {
                await _propertyService.CreatePropertyAsync(propertyDto);
                return RedirectToAction("ListProperties");
            }
            return View("AdminListProperties");
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
            if (ModelState.IsValid)
            {
                await _propertyService.UpdatePropertyAsync(propertyDto);
                return RedirectToAction("ListProperties");
            }
            return View("AdminListProperties");
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


        // User Listing
        public async Task<IActionResult> ListUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return View(users);
        }

        // Contract Listing
        public async Task<IActionResult> ListContracts()
        {
            var contracts = await _contractService.GetAllContractsAsync();
            return View(contracts);
        }

        // Address Listing
        public async Task<IActionResult> ListAddresses()
        {
            var addresses = await _addressService.GetAllAddressesAsync();
            return View(addresses);
        }

        // Payment Listing
        public async Task<IActionResult> ListPayments()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            return View(payments);
        }
    }
}
