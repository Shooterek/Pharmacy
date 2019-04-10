using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Models;
using Pharmacy.Core.Repositories;
using Pharmacy.Infrastructure.EF;

namespace Pharmacy.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PharmacyContext _pharmacyContext;

        public OrderRepository(PharmacyContext pharmacyContext)
        {
            _pharmacyContext = pharmacyContext;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
            => await _pharmacyContext.Orders.Include(o => o.Elements).ToListAsync();

        public Order Add(Order order)
        {
            var result = _pharmacyContext.Orders.Add(order);

            return result.Entity;
        }

        public async Task<Order> GetAsync(Guid id)
            => await _pharmacyContext.Orders.Include(o => o.Elements).SingleOrDefaultAsync(o => o.Id == id);
    }
}
