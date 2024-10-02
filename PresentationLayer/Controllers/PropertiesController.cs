using BusinessLayer.DTOModels;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace PresentationLayer.Controllers 
{
    [Route("Properties")]
    public class PropertiesController : Controller
    {
        private readonly PropertyService _propertyService;

        public PropertiesController(PropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        
        [HttpGet]
        [Route("Index")] 
        public async Task<IActionResult> Index()
        {
            var properties = await _propertyService.GetAllPropertiesAsync();
            return View("Index", properties.ToList()); 
        }

        // Render a single property details page
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var property = await _propertyService.GetPropertyByIdAsync(id);
                return View("~/Views/Home/PropertySingle.cshtml", property);


            }
            catch (KeyNotFoundException e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View("NotFound");
            }
        }

        [HttpGet("api/all")]
        public async Task<ActionResult<IQueryable<PropertyDTO>>> GetAllProperties()
        {
            var properties = await _propertyService.GetAllPropertiesAsync();
            return Ok(properties);
        }



        // Render the Create property view
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View("Create"); 
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
            // Here to send  request for offring the user`s Property
            return RedirectToAction("Index"); 
        }







        [HttpPost]
        [Route("Edit/{id}")]
        public async Task<IActionResult> UpdatePropertyListRequest(Guid id, [FromForm] PropertyDTO propertyDto)
        {
            if (id != propertyDto.Id || !ModelState.IsValid)
            {
                return View("Edit", propertyDto);
            }
                // here to add the updated user`s property
            return RedirectToAction("Index"); 
        }




        // Render the Delete property listing request confirmation view
        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteListingRequset(Guid id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);
            return View("Delete", property);
        }

        // DELETE: Soft delete a  property listing request 
        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteListingRequset(Guid id, [FromForm] bool confirm = true)
        {
            if (!confirm)
            {
                return RedirectToAction("Index");
            }
            // Add implementation here 
            return RedirectToAction("Index"); 
        }
    }
}
