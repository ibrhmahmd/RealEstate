using BusinessLayer.DTOModels;
using BusinessLayer.Services;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace PresentationLayer.Controllers
{
    //[Authorize(Roles = "User, Admin")]
    public class ContractController : Controller
    {
        private readonly ContractService _contractService;
        private readonly UserService _userService;
        private readonly PropertyService _propertyService;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<ContractController> _logger;

        public ContractController(
            ContractService contractService,
            UserManager<User> userManager,
            PropertyService propertyService,
            ILogger<ContractController> logger,
            UserService userService)
        {
            _contractService = contractService;
            _userManager = userManager;
            _propertyService = propertyService;
            _logger = logger;
            _userService = userService;
        }

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
                _logger.LogWarning("Contract with ID {Id} not found.", id);
                return NotFound();
            }
        }

        public async Task<IActionResult> Create(Guid? propertyId)
        {
            if (propertyId == null)
            {
                return NotFound();
            }

            var property = await _propertyService.GetPropertyByIdAsync(propertyId.Value);

            if (property == null)
            {
                return NotFound();
            }

            var contractModel = new ContractDTO
            {
                PropertyId = property.Id,
                StartDate = DateTime.Now,
                IsFurnished = property.IsFUrnished,
                Rooms = property.Rooms
            };

            if (property.Status.HasValue)
            {
                switch (property.Status.Value)
                {
                    case PropertStatus.Lease:
                        contractModel.RecurringPaymentFrequency = "Monthly";
                        contractModel.RecurringPaymentAmount = property.Price / 12;
                        contractModel.TotalAmount = property.Price;
                        contractModel.InitialPayment = (property.Price / 12) * 2;
                        break;

                    case PropertStatus.Ownership:
                        contractModel.RecurringPaymentFrequency = "Quarterly";
                        contractModel.RecurringPaymentAmount = property.Price / 4;
                        contractModel.TotalAmount = property.Price;
                        contractModel.InitialPayment = (property.Price / 4) * 3;
                        break;

                    default:
                        ModelState.AddModelError("", "Unknown property status.");
                        return View("~/Views/Contract/Create.cshtml", contractModel);
                }
            }
            else
            {
                ModelState.AddModelError("", "Property status is not defined.");
                return View("~/Views/Contract/Create.cshtml", contractModel);
            }

            return View("~/Views/Contract/Create.cshtml", contractModel);
        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ContractDTO contractDto)
        {
            if (contractDto == null)
            {
                return BadRequest("Contract data is required.");
            }

            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim))
            {
                _logger.LogWarning("User ID claim not found or invalid. Claim: {UserIdClaim}", userIdClaim);
                return Unauthorized();
            }

            contractDto.OccupantId = Guid.Parse(userIdClaim); // Use the claim's value for the OccupantId

            if (ModelState.IsValid)
            {
                try
                {
                    var createdContract = await _contractService.CreateContractAsync(contractDto);
                    return RedirectToAction(nameof(Details), new { id = createdContract.Id });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error creating contract.");
                    ModelState.AddModelError("", $"Error creating contract: {ex.Message}");
                }
            }

            return View("ContractSave");
        }



        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var contract = await _contractService.GetContractByIdAsync(id.Value);
                var user = await _userManager.GetUserAsync(User);
                if (contract.OccupantId != user?.Id)
                {
                    return Forbid();
                }

                return View(contract);
            }
            catch (KeyNotFoundException)
            {
                _logger.LogWarning("Contract with ID {Id} not found for editing.", id);
                return NotFound();
            }
        }

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
                    _logger.LogWarning("Contract with ID {Id} not found during edit.", id);
                    return NotFound();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error updating contract.");
                    ModelState.AddModelError("", $"Error updating contract: {ex.Message}");
                }
            }

            return View(contractDto);
        }

        public async Task<IActionResult> EndContract(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var contract = await _contractService.GetContractByIdAsync(id.Value);
                var user = await _userManager.GetUserAsync(User);
                if (contract.OccupantId != user?.Id)
                {
                    return Forbid();
                }

                return View(contract);
            }
            catch (KeyNotFoundException)
            {
                _logger.LogWarning("Contract with ID {Id} not found for ending.", id);
                return NotFound();
            }
        }

        //[HttpPost, ActionName("EndContract")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EndContractConfirmed(Guid id)
        //{
        //    try
        //    {
        //        await _contractService.EndContractAsync(id);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (KeyNotFoundException)
        //    {
        //        _logger.LogWarning("Contract with ID {Id} not found when attempting to end it.", id);
        //        return NotFound();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error ending contract.");
        //        ModelState.AddModelError("", $"Error ending contract: {ex.Message}");
        //        return View();
        //    }
        //}

        public async Task<IActionResult> Index()
        {
            var contracts = await _contractService.GetAllContractsAsync();
            return View(contracts);
        }
    }
}
