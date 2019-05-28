using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Infrastructure.DTO;
using Pharmacy.Infrastructure.Services;
using Pharmacy.Infrastructure.Services.Interfaces;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentsController : ControllerBase
    {
        private readonly IMedicamentService _medicamentService;

        public MedicamentsController(IMedicamentService medicamentService)
        {
            _medicamentService = medicamentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var medicaments = await _medicamentService.GetAllAsync();

            return Ok(medicaments);
        }

        [HttpGet("{ean}")]
        public async Task<IActionResult> Get(string ean)
        {
            var medicament = await _medicamentService.GetAsync(ean);

            return Ok(medicament);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MedicamentDto medicament)
        {
            //TODO Add validation
            var result = await _medicamentService.AddAsync(medicament);

            return Created($"api/medicaments/{result.EanCode}", result);
        }

        [HttpPut("{ean}")]
        public async Task<IActionResult> Update(string ean, MedicamentDto medicament)
        {
            if (ean != medicament.EanCode)
            {
                return BadRequest();
            }
            await _medicamentService.UpdateAsync(medicament);

            return Ok();
        }
    }
}