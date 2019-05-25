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
                    cfg.CreateMap<UserDto, User>()
                        .ForMember(x => x.Password, member => member.Ignore())
                        .ForMember(x => x.Salt, member => member.Ignore())
                        .ForMember(x => x.CreatedAt, member => member.Ignore())
                        .ForMember(x => x.UpdatedAt, member => member.Ignore());
                    cfg.CreateMap<Medicament, MedicamentDto>();
                    cfg.CreateMap<MedicamentDto, Medicament>()
                        .ForMember(x => x.PrescriptionElements, member => member.Ignore())
                        .ForMember(x => x.OrderElements, member => member.Ignore());
                    cfg.CreateMap<Prescription, PrescriptionDto>();
                    cfg.CreateMap<PrescriptionDto, Prescription>();
                    cfg.CreateMap<PrescriptionElement, PrescriptionElementDto>()
                        .ForMember(x => x.Prescription, member => member.Ignore());
                    cfg.CreateMap<PrescriptionElementDto, PrescriptionElement>()
                        .ForMember(x => x.Prescription, member => member.Ignore());
                    cfg.CreateMap<Order, OrderDto>();
                    cfg.CreateMap<OrderElement, OrderElementDto>()
                        .ForMember(x => x.Order, member => member.Ignore());
                    cfg.CreateMap<OrderElementDto, OrderElement>()
                        .ForMember(x => x.Order, member => member.Ignore());
                })
                .CreateMapper();
    }
}