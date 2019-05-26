using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Models;
using Pharmacy.Core.Repositories;
using Pharmacy.Infrastructure.EF;

namespace Pharmacy.Infrastructure.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly PharmacyContext _context;

        public SaleRepository(PharmacyContext context)
        {
            _context = context;
        }

        public Sale Add(Sale sale)
        {
            var result = _context.Sales.Add(sale);
            _context.SaleElements.AddRange(sale.MedicamentsSoldWithoutPrescription);
            return result.Entity;
        }

        public async Task<IEnumerable<Sale>> GetAllAsync()
            => await _context.Sales.Include(s => s.Prescriptions)
                .ThenInclude(s => s.Elements)
                .Include(s => s.MedicamentsSoldWithoutPrescription)
                .ToListAsync();

        public async Task<Sale> GetAsync(Guid id)
            => await _context.Sales.Include(s => s.Prescriptions)
                .ThenInclude(s => s.Elements)
                .Include(s => s.MedicamentsSoldWithoutPrescription)
                .SingleOrDefaultAsync(s => s.Id.Equals(id));
    }
}