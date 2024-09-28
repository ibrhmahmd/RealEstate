using BusinessLayer.DTOModels;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class ContractController : Controller
    {
        private readonly ContractService _contractService;

        public ContractController(ContractService contractService)
        {
            _contractService = contractService;
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




        // GET: Contracts/Create
        public IActionResult Create()
        {
            return View();
        }




        // POST: Contracts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PropertyID,UserID,StartDate,MonthlyRent,SecurityDeposit")] ContractDTO contractDto)
        {
            if (ModelState.IsValid)
            {
                var createdContract = await _contractService.CreateContractAsync(contractDto);
                return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Edit(Guid id, [Bind("PropertyID,UserID,StartDate,MonthlyRent,SecurityDeposit")] ContractDTO contractDto)
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
                    return RedirectToAction(nameof(Index));
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
            }
            return View(contractDto);
        }

        // this method should be end cotract not delete it 
        // GET: Contracts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
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

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                await _contractService.SoftDeleteContractAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}