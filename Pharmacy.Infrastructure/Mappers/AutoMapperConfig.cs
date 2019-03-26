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
                    cfg.CreateMap<Medicament, MedicamentDto>();
                    cfg.CreateMap<Prescription, PrescriptionDto>();
                    cfg.CreateMap<PrescriptionDto, Prescription>();
                    cfg.CreateMap<PrescriptionElement, PrescriptionElementDto>()
                        .ForMember(x => x.Prescription, member => member.Ignore());
                    cfg.CreateMap<PrescriptionElementDto, PrescriptionElement>()
                        .ForMember(x => x.Prescription, member => member.Ignore());
                })
                .CreateMapper();
    }
}