using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using BusinessLayer.Services;
using BusinessLayer.DTOModels;

namespace PresentationLayer.Controllers
{
    //[Authorize(Roles = "Admin")] // Ensure only Admin role users can access this controller
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


        // User Listing
        public async Task<IActionResult> ListUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return View("UsersOperation/ListUsers", users);
        }

        // User Details
        public async Task<IActionResult> UserDetails(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // Property CRUD Operations
        public async Task<IActionResult> ListProperties()
        {
            var properties = await _propertyService.GetAllPropertiesAsync();
            return View("Properties/AdminListProperties", properties);
        }




        public async Task<IActionResult> CreateProperty(PropertyDTO propertyDto)
        {
            if (ModelState.IsValid)
            {
                propertyDto.ID = Guid.NewGuid();
                await _propertyService.CreatePropertyAsync(propertyDto);
                return RedirectToAction("ListProperties");
            }

            return View("Properties/AdminListProperties");
        }

        [HttpGet]
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
            return View("Properties/AdminListProperties");
        }

        public async Task<IActionResult> SoftDeleteProperty(Guid id)
        {
            await _propertyService.SoftDeletePropertyAsync(id);
            return RedirectToAction("ListProperties");
        }


        // Soft Delete User
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return View("UsersOperation/Delete", user);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _userService.SoftDeleteUserAsync(id);
            return RedirectToAction("AdminListUsers");
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

//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Threading.Tasks;
//using BusinessLayer.Services;
//using BusinessLayer.DTOModels;

//namespace PresentationLayer.Controllers
//{
//    //[Authorize]
//    public class AdminController : Controller
//    {
//        private readonly PropertyService _propertyService;
//        private readonly UserService _userService;
//        private readonly ContractService _contractService;
//        private readonly AddressService _addressService;
//        private readonly PaymentService _paymentService;

//        public AdminController(
//            PropertyService propertyService,
//            UserService userService,
//            ContractService contractService,
//            AddressService addressService,
//            PaymentService paymentService)
//        {
//            _propertyService = propertyService;
//            _userService = userService;
//            _contractService = contractService;
//            _addressService = addressService;
//            _paymentService = paymentService;
//        }

//        private bool IsAdmin()
//        {
//            return User.IsInRole("Admin");
//        }

//        private IActionResult CheckAdminAndExecute(Func<IActionResult> action)
//        {
//            if (!IsAdmin())
//            {
//                return RedirectToAction("AccessDenied", "Account");
//            }
//            return action();
//        }

//        private async Task<IActionResult> CheckAdminAndExecuteAsync(Func<Task<IActionResult>> action)
//        {
//            if (!IsAdmin())
//            {
//                return RedirectToAction("AccessDenied", "Account");
//            }
//            return await action();
//        }

//        // Property CRUD Operations
//        public Task<IActionResult> ListProperties()
//        {
//            return CheckAdminAndExecuteAsync(async () =>
//            {
//                var properties = await _propertyService.GetAllPropertiesAsync();
//                return View("AdminListProperties", properties);
//            });
//        }

//        public Task<IActionResult> CreateProperty(PropertyDTO propertyDto)
//        {
//            return CheckAdminAndExecuteAsync(async () =>
//            {
//                if (ModelState.IsValid)
//                {
//                    propertyDto.ID = Guid.NewGuid();
//                    await _propertyService.CreatePropertyAsync(propertyDto);
//                    return RedirectToAction("ListProperties");
//                }
//                return View("AdminListProperties");
//            });
//        }

//        [HttpGet]
//        public Task<IActionResult> EditProperty(Guid id)
//        {
//            return CheckAdminAndExecuteAsync(async () =>
//            {
//                var property = await _propertyService.GetPropertyByIdAsync(id);
//                if (property == null)
//                {
//                    return NotFound();
//                }
//                return View(property);
//            });
//        }

//        [HttpPost]
//        public Task<IActionResult> EditProperty(PropertyDTO propertyDto)
//        {
//            return CheckAdminAndExecuteAsync(async () =>
//            {
//                if (ModelState.IsValid)
//                {
//                    await _propertyService.UpdatePropertyAsync(propertyDto);
//                    return RedirectToAction("ListProperties");
//                }
//                return View("AdminListProperties");
//            });
//        }

//        public Task<IActionResult> SoftDeleteProperty(Guid id)
//        {
//            return CheckAdminAndExecuteAsync(async () =>
//            {
//                await _propertyService.SoftDeletePropertyAsync(id);
//                return RedirectToAction("ListProperties");
//            });
//        }

//        // Soft Delete User
//        public Task<IActionResult> Delete(Guid id)
//        {
//            return CheckAdminAndExecuteAsync(async () =>
//            {
//                var user = await _userService.GetUserByIdAsync(id);
//                return View(user);
//            });
//        }

//        [HttpPost, ActionName("Delete")]
//        public Task<IActionResult> DeleteConfirmed(Guid id)
//        {
//            return CheckAdminAndExecuteAsync(async () =>
//            {
//                await _userService.SoftDeleteUserAsync(id);
//                return RedirectToAction("AdminListUsers");
//            });
//        }

//        // Hard Delete User
//        [HttpPost, ActionName("HardDelete")]
//        public Task<IActionResult> HardDeleteConfirmed(Guid id)
//        {
//            return CheckAdminAndExecuteAsync(async () =>
//            {
//                await _userService.HardDeleteUserAsync(id);
//                return RedirectToAction("ListUsers");
//            });
//        }

//        public Task<IActionResult> ShowProperty(Guid id)
//        {
//            return CheckAdminAndExecuteAsync(async () =>
//            {
//                var property = await _propertyService.GetPropertyByIdAsync(id);
//                if (property == null)
//                {
//                    return NotFound();
//                }
//                return View(property);
//            });
//        }

//        // User Listing
//        public Task<IActionResult> ListUsers()
//        {
//            return CheckAdminAndExecuteAsync(async () =>
//            {
//                var users = await _userService.GetAllUsersAsync();
//                return View("AdminListUsers.cshtml", users);
//            });
//        }

//        // Contract Listing
//        public Task<IActionResult> ListContracts()
//        {
//            return CheckAdminAndExecuteAsync(async () =>
//            {
//                var contracts = await _contractService.GetAllContractsAsync();
//                return View(contracts);
//            });
//        }

//        // Address Listing
//        public Task<IActionResult> ListAddresses()
//        {
//            return CheckAdminAndExecuteAsync(async () =>
//            {
//                var addresses = await _addressService.GetAllAddressesAsync();
//                return View(addresses);
//            });
//        }

//        // Payment Listing
//        public Task<IActionResult> ListPayments()
//        {
//            return CheckAdminAndExecuteAsync(async () =>
//            {
//                var payments = await _paymentService.GetAllPaymentsAsync();
//                return View(payments);
//            });
//        }
//    }
//}