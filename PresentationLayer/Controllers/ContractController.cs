﻿using BusinessLayer.DTOModels;
using BusinessLayer.Services;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.Extensions.Logging;
using PresentationLayer.helper;
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
        private readonly PaymentService _paymentService;

        public ContractController(
            ContractService contractService,
            UserManager<User> userManager,
            PropertyService propertyService,
            PaymentService paymentService,
            ILogger<ContractController> logger,
            UserService userService)
        {
            _contractService = contractService;
            _userManager = userManager;
            _propertyService = propertyService;
            _paymentService = paymentService;
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

            try
            {
                var contractModel = await _contractService.ProcessContractAsync(propertyId.Value);
                return View("~/Views/Contract/Create.cshtml", contractModel);
            }
            catch (KeyNotFoundException)
            {
                _logger.LogWarning("Property with ID {PropertyId} not found.", propertyId);
                return NotFound();
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("~/Views/Contract/Create.cshtml", new ContractDTO { PropertyId = propertyId.Value });
            }
        }

       



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContractDTO contractDto)
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
                    if (contractDto.ContractDocument == null || contractDto.ContractDocument.Length == 0)
                    {
                        ModelState.AddModelError("ContractDocument", "Please upload a contract document.");
                        return View(contractDto);
                    }

                    var fileName = UploadFile.UploadImage("Contracts", contractDto.ContractDocument);
                    if (string.IsNullOrEmpty(fileName))
                    {
                        ModelState.AddModelError("ContractDocument", "Failed to upload the contract document. Please try again.");
                        return View(contractDto);
                    }

                    contractDto.Document = fileName;
                    var payments =  await ProcessPayments(contractDto);
                    await _contractService.CreateContractAsync(contractDto);

                    foreach (PaymentDTO paymentDto in payments)
                    {
                        await _paymentService.CreatePaymentAsync(paymentDto);
                    }
                    return RedirectToAction(nameof(ProcessPayments),new { ContractDTO = contractDto} );


                    //return RedirectToAction(nameof(Details), new { id = createdContract.Id });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error creating contract for user {UserId}.", contractDto.OccupantId);
                    ModelState.AddModelError("", "An error occurred while creating the contract. Please try again later.");
                    return View(contractDto);
                }
            }
            // If we get here, something went wrong
            return View(contractDto);
        }


        public async Task<List<PaymentDTO>> ProcessPayments(ContractDTO contractDto)
        {
                var payments = await _paymentService.CreatePaymentsFromContractAsync(contractDto);
                return payments;
            
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, "Error processing payments for contract {ContractId}.", contractDto.Id);
            //    ModelState.AddModelError("", "An error occurred while processing payments. Please try again later.");
                
            //}
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

        //public async Task<IActionResult> Index()
        //{
        //    var contracts = await _contractService.GetAllContractsAsync();
        //    return View(contracts);
        //}
    }

}