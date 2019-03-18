using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pharmacy.Core.Models;

namespace Pharmacy.Core.Repositories
{
    public interface IMedicamentRepository : IRepository
    {
        Task<IEnumerable<Medicament>> GetAllAsync();
        Task<Medicament> AddAsync(Medicament medicament);
    }
}