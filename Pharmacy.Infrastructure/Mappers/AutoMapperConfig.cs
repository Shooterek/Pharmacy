using AutoMapper;
using Pharmacy.Core.Models;
using Pharmacy.Infrastructure.DTO;

namespace Pharmacy.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserDto>();
                })
                .CreateMapper();
    }
}