using System.Collections.Generic;
using System.Threading.Tasks;
using Pharmacy.Infrastructure.DTO;

namespace Pharmacy.Infrastructure.Services.Interfaces
{
    public interface IMedicamentService : IService
    {
        Task<IEnumerable<MedicamentDto>> GetAllAsync();
        Task<MedicamentDto> AddAsync(MedicamentDto medicament);
        Task UpdateAsync(MedicamentDto medicament);
    }
}