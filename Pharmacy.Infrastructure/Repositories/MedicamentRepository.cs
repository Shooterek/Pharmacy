using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Models;
using Pharmacy.Core.Repositories;
using Pharmacy.Infrastructure.EF;

namespace Pharmacy.Infrastructure.Repositories
{
    public class MedicamentRepository : IMedicamentRepository
    {
        private PharmacyContext _context;

        public MedicamentRepository(PharmacyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medicament>> GetAllAsync()
            => await _context.Medicaments.ToListAsync();
    }
}