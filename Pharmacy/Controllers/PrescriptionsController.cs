using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Core.Repositories;
using Pharmacy.Infrastructure.DTO;
using Pharmacy.Infrastructure.Services;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionsController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _prescriptionService.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _prescriptionService.GetAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PrescriptionDto prescription)
        {
            prescription.PharmacistId = new Guid(User.Identity.Name);
            var result = await _prescriptionService.AddAsync(prescription);

            return Created($"api/prescriptions/{result.Id}", result);
        }
    }
}