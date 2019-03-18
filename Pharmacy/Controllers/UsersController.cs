using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Infrastructure.DTO;
using Pharmacy.Infrastructure.Services;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.BrowseAsync();

            return Ok(users);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetAsync(email);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegisterUserDto user)
        {
            await _userService.RegisterAsync(user);

            return Created($"api/users/{user.Email}", null);
        }
    }
}