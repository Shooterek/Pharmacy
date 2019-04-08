using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Infrastructure.DTO;
using Pharmacy.Infrastructure.Services;

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
        public async Task<IActionResult> Post([FromBody]MedicamentDto medicament)
        {
            //TODO Add validation
            var result = await _medicamentService.AddAsync(medicament);

            return Created($"api/medicaments/{result.Id}", result);
        }
    }
}