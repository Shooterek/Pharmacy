using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pharmacy.Infrastructure.DTO;

namespace Pharmacy.Infrastructure.Services
{
    public interface IPrescriptionService : IService
    {
        Task<PrescriptionDto> AddAsync(PrescriptionDto prescription);
        Task<IEnumerable<PrescriptionDto>> GetAllAsync();
        Task<PrescriptionDto> GetAsync(Guid id);
    }
}