using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Interface;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Controllers
{
    
        [ApiController]
        [Route("api/drugs")]
        public class DrugsController : ControllerBase
        {
            private readonly IDrug _drugRepository;

            public DrugsController(IDrug drugRepository)
            {
                _drugRepository = drugRepository;
            }

            [HttpGet]
            public async Task<ActionResult<List<Drug>>> GetAllDrugs()
            {
                var drugs = await _drugRepository.GetAllDrug();
                return drugs;
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Drug>> GetDrugById(int id)
            {
                var drug = await _drugRepository.GetDrugById(id);
                if (drug == null)
                    return NotFound();

                return drug;
            }

        [HttpPost]
        public async Task<ActionResult<Drug>> PostDrug(DrugDto drug)
        {
            if (drug == null)
            {
                return BadRequest();
            }

            var addedDrug = await _drugRepository.PostDrug(drug);

            if (addedDrug == null)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetAllDrugs", new { id = addedDrug.DrugId }, addedDrug);
        }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutDrug(int id, DrugDto drug)
            {
                var success = await _drugRepository.PutDrugById(id, drug);
                if (!success)
                    return NotFound();

                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteDrug(int id)
            {
                var result = await _drugRepository.DeleteDrugById(id);
                if (result==null)
                    return NotFound("Couln't find the Drug");

                return Ok();
            }
        }
    }
