﻿using System;
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
        private readonly PharmacyContext _context;

        public MedicamentRepository(PharmacyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medicament>> GetAllAsync()
            => await _context.Medicaments.ToListAsync();

        public async Task<Medicament> GetAsync(string ean)
            => await _context.Medicaments.SingleOrDefaultAsync(m => m.EanCode.Equals(ean));

        public Medicament Add(Medicament medicament)
        {
            var result = _context.Medicaments.Add(medicament);

            return result.Entity;
        }

        public void Update(Medicament medicament)
        {
            _context.Update(medicament);
        }
    }
}