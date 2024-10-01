using BusinessLayer.DTOModels;
using BusinessLayer.Services;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class ContractController : Controller
    {
        private readonly ContractService _contractService;
        private readonly PropertyService _propertyService;
        private readonly UserManager<UserDTO> _userManager;

        public ContractController(ContractService contractService, UserManager<UserDTO> userManager, PropertyService propertyService )
        {
            _contractService = contractService;
            _userManager = userManager;
            _propertyService = propertyService;
        }







        // GET: Contracts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var contract = await _contractService.GetContractByIdAsync(id.Value);
                return View(contract);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }


        // GET: Contracts/Create?propertyId=guid
        // GET: Contracts/Create?propertyId=guid
        public async Task<IActionResult> Create(Guid? propertyId)
        {
            if (propertyId == null)
            {
                return NotFound();
            }

            // Fetch the PropertyDTO using the propertyId
            var property = await _propertyService.GetPropertyByIdAsync(propertyId.Value);

            if (property == null)
            {
                return NotFound(); // Property not found
            }

            // Prepopulate the ContractDTO model with values from PropertyDTO
            var contractModel = new ContractDTO
            {
                PropertyId = property.Id,
                StartDate = DateTime.Now,
                IsFurnished = property.IsFUrnished, // Assuming PropertyDTO has an IsFurnished property
                Rooms = property.Rooms // Assuming PropertyDTO has a Rooms property
            };

            // Check if property.Status has a value
            if (property.Status.HasValue)
            {
                if (property.Status.Value == PropertStatus.Lease) // Compare with enum value
                {
                    contractModel.RecurringPaymentFrequency = "Monthly"; // Set rent payment frequency to monthly
                    contractModel.RecurringPaymentAmount = property.Price / 12; // Monthly rent based on annual price
                    contractModel.TotalAmount = property.Price; // Total amount is the annual price
                    contractModel.InitialPayment = (property.Price / 12) * 2; // Two months' rent upfront as initial payment
                }
                else if (property.Status.Value == PropertStatus.Ownership) // Compare with enum value
                {
                    contractModel.RecurringPaymentFrequency = "Quarterly"; // Assuming ownership is billed quarterly
                    contractModel.RecurringPaymentAmount = property.Price / 4; // Quarterly payment based on total price
                    contractModel.TotalAmount = property.Price; // Total amount is the price of the property
                    contractModel.InitialPayment = (property.Price / 4) * 3; // Three months' payment upfront as initial payment
                }
            }
            else
            {
                // Handle cases where property status is null
                ModelState.AddModelError("", "Property status is not defined.");
                return View("~/Views/Contract/Create.cshtml", contractModel);
            }

            return View("~/Views/Contract/Create.cshtml", contractModel);
        }


        // POST: Contracts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PropertyId,StartDate,MonthlyRent,SecurityDeposit,OccupantId,RecurringPaymentFrequency,IsFurnished,Rooms")] ContractDTO contractDto)
        {
            // Use UserManager to get the currently logged-in user
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized(); // User is not authenticated or not found
            }

            // Assign the user ID to OccupantId
            contractDto.OccupantId = user.Id;

            if (ModelState.IsValid)
            {
                try
                {
                    var createdContract = await _contractService.CreateContractAsync(contractDto);
                    return RedirectToAction(nameof(Details), new { id = createdContract.Id }); // Redirect to Details of created contract
                }
                catch (Exception ex) // Catch any exceptions during contract creation
                {
                    ModelState.AddModelError("", $"Error creating contract: {ex.Message}");
                }
            }

            return View(contractDto);
        }


        // GET: Contracts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var contract = await _contractService.GetContractByIdAsync(id.Value);

                // Optionally check if the current user is authorized to edit this contract
                var user = await _userManager.GetUserAsync(User);
                if (contract.OccupantId != user?.Id)
                {
                    return Forbid(); // User is not authorized to edit this contract
                }

                return View(contract);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: Contracts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PropertyId,OccupantId,StartDate,MonthlyRent,SecurityDeposit,RecurringPaymentFrequency,IsFurnished,Rooms")] ContractDTO contractDto)
        {
            if (id != contractDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _contractService.UpdateContractAsync(contractDto);
                    return RedirectToAction(nameof(Details), new { id = contractDto.Id });
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
                catch (Exception ex) // Catch any exceptions during contract update
                {
                    ModelState.AddModelError("", $"Error updating contract: {ex.Message}");
                }
            }

            return View(contractDto);
        }

        // GET: Contracts/EndContract/5
        public async Task<IActionResult> EndContract(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var contract = await _contractService.GetContractByIdAsync(id.Value);

                // Optionally check if the current user is authorized to end this contract
                var user = await _userManager.GetUserAsync(User);
                if (contract.OccupantId != user?.Id)
                {
                    return Forbid(); // User is not authorized to end this contract
                }

                return View(contract);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // POST: Contracts/EndContract/5
        [HttpPost, ActionName("EndContract")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EndContractConfirmed(Guid id)
        {
            try
            {
                await _contractService.EndContractAsync(id);
                return RedirectToAction(nameof(Index)); // Redirect to index or another appropriate action
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex) // Catch any exceptions during contract ending
            {
                ModelState.AddModelError("", $"Error ending contract: {ex.Message}");
                return View(); // Return the same view with the error
            }
        }

        // Optionally, add an Index action to list all contracts
        public async Task<IActionResult> Index()
        {
            var contracts = await _contractService.GetAllContractsAsync();
            return View(contracts);
        }
    }
}
