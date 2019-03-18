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

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;

        public LoginController(IMemoryCache cache, IJwtHandler jwtHandler, IUserService userService)
        {
            _cache = cache;
            _jwtHandler = jwtHandler;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]LoginDto loginDto)
        {
            loginDto.TokenId = Guid.NewGuid();

            await _userService.LoginAsync(loginDto.Email, loginDto.Password);
            var user = await _userService.GetAsync(loginDto.Email);
            
            var jwt = _jwtHandler.CreateToken(user.Id, user.Role);
            _cache.SetJwt(loginDto.TokenId, jwt);

            jwt = _cache.GetJwt(loginDto.TokenId);
            return Ok(jwt);
        }
    }
}