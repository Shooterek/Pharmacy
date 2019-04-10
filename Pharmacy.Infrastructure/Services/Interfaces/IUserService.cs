using System.Collections.Generic;
using System.Threading.Tasks;
using Pharmacy.Infrastructure.DTO;

namespace Pharmacy.Infrastructure.Services.Interfaces
{
    public interface IUserService : IService
    {
        Task<UserDto> GetAsync(string email);
        Task<IEnumerable<UserDto>> BrowseAsync();
        Task RegisterAsync(RegisterUserDto registerUserDto);
        Task LoginAsync(string email, string password);
    }
}