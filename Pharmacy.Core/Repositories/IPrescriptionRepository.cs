using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pharmacy.Core.Models;

namespace Pharmacy.Core.Repositories
{
    public interface IPrescriptionRepository : IRepository
    {
        Prescription Add(Prescription prescription);
        Task<IEnumerable<Prescription>> GetAllAsync();
        Task<Prescription> GetAsync(Guid id);
    }
}