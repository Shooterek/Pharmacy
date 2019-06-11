using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pharmacy.Infrastructure.DTO;

namespace Pharmacy.Infrastructure.Services.Interfaces
{
    public interface ISaleService : IService
    {
        Task<SaleDto> AddAsync(SaleDto sale);
        Task<IEnumerable<SaleDto>> GetAllAsync();
        Task<SaleDto> GetAsync(Guid id);
    }
}