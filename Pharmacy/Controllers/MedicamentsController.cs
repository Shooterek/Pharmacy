
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
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
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var medicaments = await _medicamentService.GetAllAsync();

            return Ok(medicaments);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MedicamentDto medicament)
        {
            //TODO Add validation
            var result = await _medicamentService.AddAsync(medicament);

            return Created($"api/medicaments/{result.Id}", result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, MedicamentDto medicament)
        {
            if (id != medicament.Id)
            {
                return BadRequest();
            }
            await _medicamentService.UpdateAsync(medicament);

            return Ok();
        }
    }
}