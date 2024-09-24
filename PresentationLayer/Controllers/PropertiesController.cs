using BusinessLayer.DTOModels;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly PropertyService _propertyService;

        public PropertyController(PropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        // GET: api/Property
        [HttpGet]
        public async Task<ActionResult<IQueryable<PropertyDTO>>> GetAllProperties()
        {
            var properties = await _propertyService.GetAllPropertiesAsync();
            return Ok(properties);
        }

        // GET: api/Property/deleted
        [HttpGet("deleted")]
        public async Task<ActionResult<IQueryable<PropertyDTO>>> GetAllPropertiesIncludingDeleted()
        {
            var properties = await _propertyService.GetAllPropertiesIncludingDeletedAsync();
            return Ok(properties);
        }

        // GET: api/Property/{id}
        [HttpGet("{id}")]
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

        // POST: api/Property
        [HttpPost]
        public async Task<ActionResult<PropertyDTO>> CreateProperty([FromBody] PropertyDTO propertyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdProperty = await _propertyService.CreatePropertyAsync(propertyDto);
            return CreatedAtAction(nameof(GetPropertyById), new { id = createdProperty.ID }, createdProperty); // Returns 201 status with location header
        }

        // PUT: api/Property/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<PropertyDTO>> UpdateProperty(Guid id, [FromBody] PropertyDTO propertyDto)
        {
            if (id != propertyDto.ID)
            {
                return BadRequest("Property ID mismatch.");
            }

            try
            {
                var updatedProperty = await _propertyService.UpdatePropertyAsync(propertyDto);
                return Ok(updatedProperty);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        // DELETE: api/Property/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> SoftDeleteProperty(Guid id)
        {
            try
            {
                await _propertyService.SoftDeletePropertyAsync(id);
                return NoContent(); // Returns 204 status
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        // DELETE: api/Property/hard/{id}
        [HttpDelete("hard/{id}")]
        public async Task<ActionResult> HardDeleteProperty(Guid id)
        {
            try
            {
                await _propertyService.HardDeletePropertyAsync(id);
                return NoContent(); // Returns 204 status
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        // POST: api/Property/restore/{id}
        [HttpPost("restore/{id}")]
        public async Task<ActionResult> RestoreProperty(Guid id)
        {
            try
            {
                await _propertyService.RestorePropertyAsync(id);
                return NoContent(); // Returns 204 status
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}
