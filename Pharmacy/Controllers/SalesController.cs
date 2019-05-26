using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Infrastructure.DTO;
using Pharmacy.Infrastructure.Services.Interfaces;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _saleService.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _saleService.GetAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SaleDto sale)
        {
            sale.PharmacistId = new Guid(User.Identity.Name);
            var result = await _saleService.AddAsync(sale);

            return Created($"api/sales/{result.Id}", result);
        }
    }
}