using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Pharmacy.Infrastructure.DTO;
using Pharmacy.Infrastructure.Extensions;
using Pharmacy.Infrastructure.Services;
using Pharmacy.Infrastructure.Services.Interfaces;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;

        public LoginController(IJwtHandler jwtHandler, IUserService userService)
        {
            _jwtHandler = jwtHandler;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]LoginDto loginDto)
        {
            await _userService.LoginAsync(loginDto.Email, loginDto.Password);
            var user = await _userService.GetAsync(loginDto.Email);
            
            var jwt = _jwtHandler.CreateToken(user.Id, user.Role);
            return Ok(jwt);
        }
    }
}