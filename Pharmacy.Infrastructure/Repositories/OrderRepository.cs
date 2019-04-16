using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Update(Order order)
        {
            var existingOrder = await _pharmacyContext.Orders.Include(o => o.Elements).AsNoTracking().SingleAsync(o => o.Id == order.Id);

            if (existingOrder != null)
            {
                var exOrder = await _pharmacyContext.Orders.FirstAsync(x => x.Id == order.Id);
                exOrder.Status = order.Status;
                exOrder.DateOfFinalization = order.DateOfFinalization;
                // Delete elements
                foreach (var item in existingOrder.Elements)
                {
                    if(order.Elements.All(o => o.MedicamentId != item.MedicamentId))
                    {
                        var element = await _pharmacyContext.OrderElements.FirstAsync(x =>
                            x.MedicamentId == item.MedicamentId && x.OrderId == item.OrderId);
                        _pharmacyContext.OrderElements.Remove(element);
                    }
                }

                // Add or update new elements
                foreach (var item in order.Elements)
                {
                    var existingElement = existingOrder.Elements.SingleOrDefault(e => e.MedicamentId == item.MedicamentId);

                    if(existingElement != null)
                    {
                        item.OrderId = order.Id;
                        _pharmacyContext.Update(item);
                    }
                    else
                    {
                        item.OrderId = order.Id;
                        _pharmacyContext.OrderElements.Add(item);
                    }
                }
            }
        }
    }
}
