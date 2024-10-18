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
using System.Security.Claims;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Globalization;
namespace PresentationLayer.Controllers
{
    [Authorize(Roles = "Admin")]
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
        private readonly ILogger<ContractController> _logger;

        public AdminController(
            PropertyService propertyService,
            UserService userService,
            ContractService contractService,
            PaymentService paymentService,
            DeveloperCompanyService developerCompanyService,
            ProjectService projectService,
            MyDbContext context,
            IWebHostEnvironment webHostEnvironment,
            ILogger<ContractController> logger)
        {
            _propertyService = propertyService;
            _userService = userService;
            _contractService = contractService;
            _paymentService = paymentService;
            _projectService = projectService;
            _developerCompanyService = developerCompanyService;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }
        public IActionResult GeneratePaymentPDF(PaymentDTO payment)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

                // Add PDF title with styling
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20, BaseColor.DarkGray);
                pdfDoc.Add(new Paragraph("Invoice", titleFont));
                pdfDoc.Add(new Paragraph("\n")); // Add space

                // Add company information (optional)
                var companyFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.Black);
                pdfDoc.Add(new Paragraph("Estate Agency", companyFont));
                pdfDoc.Add(new Paragraph("123 Real Estate St.", companyFont));
                pdfDoc.Add(new Paragraph("City, Country", companyFont));
                pdfDoc.Add(new Paragraph("Phone: +123 456 7890", companyFont));
                pdfDoc.Add(new Paragraph("Email: info@estateagency.com", companyFont));
                pdfDoc.Add(new Paragraph("\n")); // Add space

                // Add Payment Details Table
                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 1, 2 });

                // Add table headers
                AddCellToTable(table, "Payment Method:", true);
                AddCellToTable(table, payment.PaymentMethod);
                AddCellToTable(table, "Reference Number:", true);
                AddCellToTable(table, payment.ReferenceNumber);
                AddCellToTable(table, "Late Fee:", true);
                AddCellToTable(table, payment.LateFee?.ToString("C", new CultureInfo("en-EG")));
                AddCellToTable(table, "Total Amount:", true);
                AddCellToTable(table, payment.Amount.ToString("C", new CultureInfo("en-EG")));
                AddCellToTable(table, "Payment Date:", true);
                AddCellToTable(table, payment.PaymentDate.ToShortDateString());

                pdfDoc.Add(table); // Add table to the PDF

                // Add footer
                pdfDoc.Add(new Paragraph("\nThank you for your business!", companyFont));

                pdfDoc.Close();

                return File(stream.ToArray(), "application/pdf", "PaymentDetails.pdf");
            }
        }

        private void AddCellToTable(PdfPTable table, string text, bool isHeader = false)
        {
            var font = isHeader ? FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.White) : FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.Black);
            var cell = new PdfPCell(new Phrase(text, font))
            {
                BackgroundColor = isHeader ? BaseColor.Gray : BaseColor.White,
                Padding = 5,
                Border = Rectangle.BOX
            };
            table.AddCell(cell);
        }

        // Property CRUD Operations
        public async Task<IActionResult> ListProperties(int pageNumber = 1, int pageSize = 10)
        {
            if (User.IsInRole("Admin"))
            {
                var pagedProperties = await _propertyService.GetAllPropertiesAsync(pageNumber, pageSize);
                var pagedListViewModel = new PagedListViewModel<PropertyDTO>
                {
                    Items = pagedProperties.Items,
                    PageNumber = pagedProperties.CurrentPage,
                    PageSize = pagedProperties.PageSize,
                    TotalRecords = pagedProperties.TotalRecords
                };

                return View(pagedListViewModel);
            }
            return Unauthorized();
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



        // User Listing
        public async Task<IActionResult> ListUsers(int pageNumber = 1, int pageSize = 10)
        {
            if (User.IsInRole("Admin"))
            {
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
            }

            return Unauthorized();
        }

        [HttpGet]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> ListOwners(int pageNumber = 1, int pageSize = 10)
        {
            if (User.IsInRole("Admin"))
            {
                var pagedUsers = await _userService.GetOwners(pageNumber, pageSize);

                // Pass the paginated result to the view model
                var viewModel = new PagedListViewModel<UserDTO>
                {
                    Items = pagedUsers.Items,
                    PageNumber = pagedUsers.CurrentPage,
                    PageSize = pagedUsers.PageSize,
                    TotalRecords = pagedUsers.TotalRecords

                };
                return View("ListUsers",viewModel);
            }
            return Unauthorized();
        }

        [HttpGet]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> ListRenters(int pageNumber = 1, int pageSize = 10)
        {
            if (User.IsInRole("Admin"))
            {
                var pagedUsers = await _userService.GetRenters(pageNumber, pageSize);

                // Pass the paginated result to the view model
                var viewModel = new PagedListViewModel<UserDTO>
                {
                    Items = pagedUsers.Items,
                    PageNumber = pagedUsers.CurrentPage,
                    PageSize = pagedUsers.PageSize,
                    TotalRecords = pagedUsers.TotalRecords

                };
                return View("ListUsers", viewModel);
            }
            return Unauthorized();
        }

        public async Task<IActionResult> ListContracts(int pageNumber = 1, int pageSize = 10)
        {
            if (User.IsInRole("Admin"))
            {
                var Pagedcontracts = await _contractService.GetAllContractsAsync(pageNumber, pageSize);

                // Pass the paginated result to the view model
                var viewModel = new PagedListViewModel<ContractDTO>
                {
                    Items = Pagedcontracts.Items,
                    PageNumber = Pagedcontracts.CurrentPage,
                    PageSize = Pagedcontracts.PageSize,
                    TotalRecords = Pagedcontracts.TotalRecords
                };
                return View("~/Views/Admin/Contracts/ListContracts.cshtml", viewModel);
            }
            return Unauthorized();
        }


        // Archive a contract by ID
        public async Task<IActionResult> ArchivedContracts(Guid id)
        {
            try
            {
                await _contractService.ArchiveContract(id);

                return RedirectToAction("ArchivedContractsList");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        public async Task<IActionResult> ArchivedContractsList(int pageNumber = 1, int pageSize = 5)
        {
            if (User.IsInRole("Admin"))
            {
                var Pagedcontracts = await _contractService.GetArchivedContractsAsync(pageNumber, pageSize);

                // Pass the paginated result to the view model
                var viewModel = new PagedListViewModel<ContractDTO>
                {
                    Items = Pagedcontracts.Items,
                    PageNumber = Pagedcontracts.CurrentPage,
                    PageSize = Pagedcontracts.PageSize,
                    TotalRecords = Pagedcontracts.TotalRecords
                };
                return View("~/Views/Admin/Contracts/ArchivedContractsList.cshtml", viewModel);
            }
            return Unauthorized();
        }



        public async Task<IActionResult> AcceptedContractsList(int pageNumber = 1, int pageSize = 5)
        {
            if (User.IsInRole("Admin"))
            {
                var Pagedcontracts = await _contractService.AcceptedContractsAsync(pageNumber, pageSize);

                // Pass the paginated result to the view model
                var viewModel = new PagedListViewModel<ContractDTO>
                {
                    Items = Pagedcontracts.Items,
                    PageNumber = Pagedcontracts.CurrentPage,
                    PageSize = Pagedcontracts.PageSize,
                    TotalRecords = Pagedcontracts.TotalRecords
                };
                return View("~/Views/Admin/Contracts/GenericContractList.cshtml", viewModel);
            }
            return Unauthorized();
        }

        public async Task<IActionResult> TerminatedContractsList(int pageNumber = 1, int pageSize = 5)
        {
            if (User.IsInRole("Admin"))
            {
                var Pagedcontracts = await _contractService.TerminatedContractsAsync(pageNumber, pageSize);

                var viewModel = new PagedListViewModel<ContractDTO>
                {
                    Items = Pagedcontracts.Items,
                    PageNumber = Pagedcontracts.CurrentPage,
                    PageSize = Pagedcontracts.PageSize,
                    TotalRecords = Pagedcontracts.TotalRecords
                };
                return View("~/Views/Admin/Contracts/GenericContractList.cshtml", viewModel);
            }
            return Unauthorized();
        }

        public async Task<IActionResult> UnArchivedContracts(Guid id)
        {
            try
            {
                await _contractService.UnArchiveContract(id);

                return RedirectToAction("ListContracts");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
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
                return RedirectToAction("ListProperties");
            }

            // Reload lists for the form in case of validation failure.
            propertyDto.Projects = await _context.Projects.ToListAsync();
            propertyDto.Locations = await _context.Addresses.ToListAsync();
            return View(propertyDto);
        }




        public async Task<IActionResult> EditProperty(Guid id)
        {
            if (User.IsInRole("Admin"))
            {
                var property = await _propertyService.GetPropertyByIdAsync(id);

                if (property == null)
                {
                    return NotFound();
                }

                // Load all locations for the dropdown
                property.Locations = await _context.Addresses.ToListAsync();
                property.Projects = await _context.Projects.ToListAsync();
                return View(property);
            }
            return Unauthorized();
        }

        [HttpPost]
        public async Task<IActionResult> EditProperty(PropertyDTO propertyDto)
        {
            if (propertyDto.PropertyPicture != null)
            {
                var fileName = UploadFile.UploadImage("PropertyPicture", propertyDto.PropertyPicture);
                propertyDto.PropertyPictureUrl = fileName;
            }
       
            else
            {
                // If no new picture is uploaded, keep the existing URL
                var existingProperty = await _propertyService.GetPropertyByIdAsync(propertyDto.Id);
                propertyDto.PropertyPictureUrl = existingProperty.PropertyPictureUrl;
            }
            if (propertyDto.AddressId.HasValue)
            {
                var selectedAddress = await _context.Addresses.FindAsync(propertyDto.AddressId.Value);
                propertyDto.Location = selectedAddress != null ? $"{selectedAddress.City}, {selectedAddress.State}" : "Location not specified";
            }
            if (propertyDto.ProjectId.HasValue)
            {
                var selectedproject = await _context.Projects.FindAsync(propertyDto.ProjectId.Value);
                propertyDto.PropertyProject = selectedproject != null ? $"{selectedproject.ProjectName}" : "project not specified";
            }


            if (ModelState.IsValid)
            {
                await _propertyService.UpdatePropertyAsync(propertyDto);
                return RedirectToAction("ListProperties");
            }

            propertyDto.Projects = await _context.Projects.ToListAsync();
            propertyDto.Locations = await _context.Addresses.ToListAsync();
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
            if (id == null)
            { 
                return NotFound();
            }
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                var UserDto = new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    UserPictureUrl = user.UserPictureUrl,
                    PhoneNumber = user.PhoneNumber,
                    Role = user.Role,
                    IsVerified = user.IsVerified,
                };
                return View("~/Views/Admin/UserDetails.cshtml", UserDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> VerifyUser(Guid id)
        {
            try
            {
                var verify = await _userService.VerifyUser(id);
                if (verify)
                {
                    TempData["SuccessMessage"] = "User verified successfully.";
                    return RedirectToAction("Details", new { id = id });
                }
                else
                {
                    TempData["ErrorMessage"] = "User verification failed.";
                    return RedirectToAction("ListUsers");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error in VerifyUser: {ex.Message}");
                TempData["ErrorMessage"] = "An error occurred while verifying the user.";
                return RedirectToAction("ListUsers");
            }
        }


        public async Task<IActionResult> ListPayments(int pageNumber = 1, int pageSize = 5)
        {
            if (User.IsInRole("Admin"))
            {
                var Pagedpayments = await _paymentService.GetAllPaymentsAsync(pageNumber, pageSize);

                // Pass the paginated result to the view model
                var viewModel = new PagedListViewModel<PaymentDTO>
                {
                    Items = Pagedpayments.Items,
                    PageNumber = Pagedpayments.CurrentPage,
                    PageSize = Pagedpayments.PageSize,
                    TotalRecords = Pagedpayments.TotalRecords
                };
                return View(viewModel);

            }
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
                await _contractService.TerminateAsync(id);

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


        public async Task<IActionResult> Accept(Guid id)
        {
            try
            {
                await _contractService.AcceptContract(id);

                TempData["SuccessMessage"] = "Contract Accepted successfully.";
            }
            catch (KeyNotFoundException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while Accepting the contract.";
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("ListContracts");
        }

        //Developer
        public async Task<IActionResult> DeveloperList(int pageNumber = 1, int pageSize = 5)
        {
            if (User.IsInRole("Admin"))
            {
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
            }

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
            ViewBag.depts = _context.DeveloperCompanies.Where(d => d.IsDeleted == false).ToList();
            if (User.IsInRole("Admin"))
            {
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
            }
            return Unauthorized();
        }
        public async Task<IActionResult> ProjectDetails(Guid id)
        {
            ViewBag.depts = _context.DeveloperCompanies.Where(d => d.IsDeleted == false).ToList();
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }
        public async Task<IActionResult> CreateProject(ProjectDTO projectdto)
        {
            ViewBag.depts = _context.DeveloperCompanies.Where(d => d.IsDeleted == false).ToList();
            //ViewBag.depts = await _developerCompanyService.GetAllDeveloperCompaniesAsync();
            if (ModelState.IsValid)
            {
                await _projectService.CreateProjectAsync(projectdto);
                return RedirectToAction("ProjectList");
            }
            return View(projectdto);
        }





        public async Task<IActionResult> EditProject(Guid id)
        {
            ViewBag.depts = _context.DeveloperCompanies.Where(d => d.IsDeleted == false).ToList();
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }




        [HttpPost]
        public async Task<IActionResult> EditProject(ProjectDTO project)
        {
            if (ModelState.IsValid)
            {
                await _projectService.UpdateProjectAsync(project);
                return RedirectToAction("ProjectList");
            }
            return View(project);
        }



        public async Task<IActionResult> DeleteProject(Guid id)
        {
            ViewBag.depts = _context.DeveloperCompanies.Where(d => d.IsDeleted == false).ToList();
            var project = await _projectService.GetProjectByIdAsync(id);
            return View(project);
        }


        [HttpPost, ActionName("DeleteProject")]
        public async Task<IActionResult> ConfirmDeleteProject(Guid id)
        {
            await _projectService.SoftDeleteProjectAsync(id);
            return RedirectToAction("ProjectList");
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