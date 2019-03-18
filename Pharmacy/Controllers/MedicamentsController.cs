﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Infrastructure.Services;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentsController : ControllerBase
    {
        private IMedicamentService _medicamentService;

        public MedicamentsController(IMedicamentService medicamentService)
        {
            _medicamentService = medicamentService;
        }

        public async Task<IActionResult> Get()
        {
            var medicaments = await _medicamentService.GetAllAsync();

            return Ok(medicaments);
        }
    }
}