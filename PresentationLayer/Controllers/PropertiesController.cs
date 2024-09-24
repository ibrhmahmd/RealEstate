using Microsoft.AspNetCore.Mvc;
using BusinessLayer.DTOModels;
using DataAccessLayer.Repositories.Interface;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IRepository<PropertyDTO> _propertyRepo;

        public PropertyController(IRepository<PropertyDTO> propertyRepo)
        {
            _propertyRepo = propertyRepo;
        }

        // GET: Property
        public async Task<IActionResult> Index(int page = 1)
        {
            var properties = await _propertyRepo.GetAllAsync();
            var paginatedProperties = properties.Skip((page - 1) * 10).Take(10);
            return View(paginatedProperties.ToList());
        }

        // GET: Property/Create
        public IActionResult Create()
        {
            return PartialView("_CreateOrEdit", new PropertyDTO());
        }

        // POST: Property/Create
        [HttpPost]
        public async Task<IActionResult> Create(PropertyDTO property)
        {
            if (ModelState.IsValid)
            {
                await _propertyRepo.InsertAsync(property);
                return RedirectToAction(nameof(Index));
            }
            return PartialView("_CreateOrEdit", property);
        }

        // GET: Property/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var property = await _propertyRepo.GetByIdAsync(id);
            if (property == null)
            {
                return NotFound();
            }
            return PartialView("_CreateOrEdit", property);
        }

        // POST: Property/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(PropertyDTO property)
        {
            if (ModelState.IsValid)
            {
                await _propertyRepo.UpdateAsync(property);
                return RedirectToAction(nameof(Index));
            }
            return PartialView("_CreateOrEdit", property);
        }

        // POST: Property/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _propertyRepo.SoftDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
