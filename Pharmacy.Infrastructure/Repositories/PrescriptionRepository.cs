using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Models;
using Pharmacy.Core.Repositories;
using Pharmacy.Infrastructure.EF;

namespace Pharmacy.Infrastructure.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly PharmacyContext _context;

        public PrescriptionRepository(PharmacyContext context)
        {
            _context = context;
        }

        public async Task<Prescription> AddAsync(Prescription prescription)
        {
            var result = _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<Prescription>> GetAllAsync()
            => await _context.Prescriptions.Include(p => p.Elements).ToListAsync();

        public async Task<Prescription> GetAsync(Guid id)
            => await _context.Prescriptions.Include(p => p.Elements).SingleOrDefaultAsync(p => p.Id.Equals(id));
    }
}