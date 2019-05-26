using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pharmacy.Core.Models;

namespace Pharmacy.Core.Repositories
{
    public interface ISaleRepository : IRepository
    {
        Sale Add(Sale sale);
        Task<IEnumerable<Sale>> GetAllAsync();
        Task<Sale> GetAsync(Guid id);
    }
}