using BusinessLayer.DTOModels;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace PresentationLayer.Controllers // Updated namespace for Web Application
{
    [Route("[controller]")]
    public class PropertiyController : Controller
    {
        private readonly PropertyService _propertyService;

        public PropertiyController(PropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        [Route("Index")] // Set route to /Properties/Index
        public async Task<IActionResult> Index()
        {
            var properties = await _propertyService.GetAllPropertiesAsync();
            return View("Index", properties.ToList()); // Return the Index.cshtml view
        }


        // Render a single property details page
        [HttpGet]
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var property = await _propertyService.GetPropertyByIdAsync(id);
                return View("Home/PropertySingle", property); 
            }
            catch (KeyNotFoundException e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View("NotFound");
            }
        }

        // GET: api/Property
        [HttpGet("api/all")]
        public async Task<ActionResult<IQueryable<PropertyDTO>>> GetAllProperties()
        {
            var properties = await _propertyService.GetAllPropertiesAsync();
            return Ok(properties);
        }

        // GET: api/Property/{id}
        [HttpGet("api/{id}")]
        public async Task<ActionResult<PropertyDTO>> GetPropertyById(Guid id)
        {
            try
            {
                var property = await _propertyService.GetPropertyByIdAsync(id);
                return Ok(property);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        // Render the Create property view
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View("Create"); // Render Create.cshtml view for adding a new property
        }




        // POST: Create a new property and redirect to the Index view
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateProperty([FromForm] PropertyDTO propertyDto)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", propertyDto);
            }

            var createdProperty = await _propertyService.CreatePropertyAsync(propertyDto);
            return CreatedAtAction(nameof(GetPropertyById), new { id = createdProperty.Id }, createdProperty); // Returns 201 status with location header
        }







        // Render the Edit property view
        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);
            return View("Edit", property); // Render Edit.cshtml view with existing property data
        }




        // PUT: Update an existing property and redirect to Index view
        [HttpPost]
        [Route("Edit/{id}")]
        public async Task<IActionResult> UpdateProperty(Guid id, [FromForm] PropertyDTO propertyDto)
        {
            if (id != propertyDto.Id || !ModelState.IsValid)
            {
                return View("Edit", propertyDto);
            }

            await _propertyService.UpdatePropertyAsync(propertyDto);
            return RedirectToAction("Index"); // Redirect to Index view after updating
        }

        // Render the Delete property confirmation view
        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);
            return View("Delete", property); // Render Delete.cshtml view with property data
        }

        // DELETE: Soft delete a property and redirect to the Index view
        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> SoftDeleteProperty(Guid id, [FromForm] bool confirm = true)
        {
            if (!confirm)
            {
                return RedirectToAction("Index");
            }

            await _propertyService.SoftDeletePropertyAsync(id);
            return RedirectToAction("Index"); // Redirect to Index view after soft delete
        }
    }
}
