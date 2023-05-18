using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Interface;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplier _supplierRepository;

        public SuppliersController(ISupplier supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Supplier>>> GetAllSuppliers()
        {
            var suppliers = await _supplierRepository.GetAllSupplier();
            return suppliers;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplierById(int id)
        {
            var supplier = await _supplierRepository.GetSupplierById(id);
            if (supplier == null)
                return NotFound();

            return supplier;
        }

        [HttpPost]
        public async Task<ActionResult<Supplier>> PostSupplier(SupplierDto supplier)
        {
            if (supplier == null)
            {
                return BadRequest();
            }

            var addedSupplier = await _supplierRepository.PostSupplier(supplier);
            if (addedSupplier == null)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetAllSuppliers", new { id = addedSupplier.SupplierId }, addedSupplier);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier(int id, SupplierDto supplier)
        {
            var success = await _supplierRepository.PutSupplierById(id, supplier);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var result = await _supplierRepository.DeleteSupplierById(id);
            if (result == null)
                return NotFound("Couldn't find the supplier");

            return Ok();

        }
    }
}
