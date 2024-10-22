using BusinessLayer.DTOModels;
using BusinessLayer.Services;
using DataAccessLayer.Entities;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.Extensions.Logging;
using PresentationLayer.helper;
using System.Globalization;
using System.Security.Claims;
using PresentationLayer.Helper;
using PresentationLayer.Views.Home;

namespace PresentationLayer.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class ContractController : Controller
    {
        private readonly ContractService _contractService;
        private readonly UserService _userService;
        private readonly PropertyService _propertyService;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<ContractController> _logger;
        private readonly PaymentService _paymentService;
        private ContractDTO? ContractDTO;
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
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
            {
                _logger.LogWarning("User ID claim not found or invalid. Claim: {UserIdClaim}", userIdClaim);
                return Unauthorized();
            }

            var userid = Guid.Parse(userIdClaim);
            var user = await _userService.GetUserByIdAsync(userid);
            var IsuserVerfied = await _userService.IsUserVerified(userid);
            if (IsuserVerfied)
            {
                if (propertyId == null)
                {
                    return NotFound();
                }
                try
                {
                    var contractModel = await _contractService.ProcessContractAsync(propertyId.Value);
                    contractModel.Occupantname = user.UserName;
                    contractModel.Id = Guid.NewGuid();
                    return View("~/Views/Contract/Create.cshtml", contractModel);
                }
                catch (KeyNotFoundException)
                {
                    _logger.LogWarning("Property with ID {PropertyId} not found.", propertyId);
                    return NotFound();
                }
            }
            return Unauthorized();
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
            var userid = Guid.Parse(userIdClaim);
            var IsuserVerfied = await _userService.IsUserVerified(userid);

            if (IsuserVerfied)
            {
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
                        contractDto.CreatedOn = DateTime.Now;
                        contractDto.CreatedBy = Guid.Parse(userIdClaim);
                        if (contractDto.ContractType == "Ownership") contractDto.EndDate = contractDto.StartDate.AddDays(contractDto.Period * 30);
                        ContractDTO = contractDto;
                        await _contractService.CreateContractAsync(contractDto);
                        var payments = await ProcessPayments(contractDto);

                        return View("ReviewContractPayments", payments);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error creating contract for user {UserId}.", contractDto.OccupantId);
                        ModelState.AddModelError("ContractCreationError", "An error occurred while creating the contract. Please try again later.");
                        return View(contractDto);
                    }
                }
                // If we get here, something went wrong
                return View(contractDto);
            }
            TempData["ErrorMessage"] = "You need to be Verified First";
            return View(TempData);
        }



        public async Task<List<PaymentDTO>> ProcessPayments(ContractDTO contractDto)
        {
            try
            {
                var payments = await _paymentService.CreatePaymentsFromContractAsync(contractDto);
                return payments;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing payments for contract {ContractId}.", contractDto.Id);
                throw new Exception("An error occurred while processing payments: " + ex.Message, ex);
            }
        }


        public async Task<IActionResult> DownloadContractFile()
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



        public async Task<IActionResult> PaymentDetails(Guid id)
        {
            var payment = await _paymentService.GetPaymenttByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            return View("~/Views/Contract/PaymentDetails.cshtml", payment);
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
                    var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                    if (string.IsNullOrEmpty(userIdClaim))
                    {
                        _logger.LogWarning("User ID claim not found or invalid. Claim: {UserIdClaim}", userIdClaim);
                        return Unauthorized();
                    }
                    contractDto.UpdatedBy = Guid.Parse(userIdClaim);
                    contractDto.UpdatedOn = DateTime.UtcNow;
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
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userIdClaim))
                {
                    _logger.LogWarning("User ID claim not found or invalid. Claim: {UserIdClaim}", userIdClaim);
                    return Unauthorized();
                }
                contract.UpdatedBy = Guid.Parse(userIdClaim);
                contract.UpdatedOn = DateTime.UtcNow;
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

        public async Task<IActionResult> GeneratePaymentPDF(Guid paymentId)
        {
            var payment = await _paymentService.GetPaymenttByIdAsync(paymentId);

            // Check if payment exists
            if (payment == null)
            {
                return NotFound("Payment not found");
            }

            // Call the helper method to generate the PDF
            byte[] pdfContent = PDFHelper.GeneratePaymentPDF(payment);

            // Return the PDF file as a response
            return File(pdfContent, "application/pdf", "PaymentDetails.pdf");
        }

        public async Task<IActionResult> GenerateInititalContractPDF(ContractDTO contract)
        {
            try
            {
                if (contract == null || string.IsNullOrEmpty(contract.Occupantname))
                {
                    return BadRequest("Invalid contract details provided.");
                }

                byte[] pdfContent = PDFHelper.GenerateInitialContractPDF(contract);

                // Check if the PDF content is successfully generated
                if (pdfContent == null || pdfContent.Length == 0)
                {
                    return StatusCode(500, "Failed to generate the PDF document.");
                }

                // Return the PDF file as a response
                return File(pdfContent, "application/pdf", "InitialContractDetails.pdf");
            }
            catch (Exception ex)
            {
                // Log the exception (assuming you have a logger set up)
                _logger.LogError(ex, "Error generating contract PDF");

                // Return a 500 Internal Server Error response with an error message
                return StatusCode(500, $"An error occurred while generating the contract PDF: {ex.Message}");
            }
        }

        public async Task<IActionResult> GenerateFinalContractPDF(ContractDTO contract)
        {
            try
            {
                if (contract == null || string.IsNullOrEmpty(contract.Occupantname))
                {
                    return BadRequest("Invalid contract details provided.");
                }

                byte[] pdfContent = PDFHelper.GenerateInitialContractPDF(contract);

                // Check if the PDF content is successfully generated
                if (pdfContent == null || pdfContent.Length == 0)
                {
                    return StatusCode(500, "Failed to generate the PDF document.");
                }

                // Return the PDF file as a response
                return File(pdfContent, "application/pdf", "InitialContractDetails.pdf");
            }
            catch (Exception ex)
            {
                // Log the exception (assuming you have a logger set up)
                _logger.LogError(ex, "Error generating contract PDF");

                // Return a 500 Internal Server Error response with an error message
                return StatusCode(500, $"An error occurred while generating the contract PDF: {ex.Message}");
            }
        }


    }
}
