using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Infrastructure.DTO;
using Pharmacy.Infrastructure.Services;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IMedicamentService _medicamentService;
        private IPrescriptionService _prescriptionService;

        public ValuesController(IMedicamentService medicamentService, IPrescriptionService prescriptionService)
        {
            _medicamentService = medicamentService;
            _prescriptionService = prescriptionService;
        }

        [Authorize(Policy = "Client")]
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
    }
}
