using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Models;
using Pharmacy.Core.Repositories;
using Pharmacy.Infrastructure.DTO;
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

        public async Task<bool> CancelAsync(Guid id)
        {
            var order = await GetAsync(id);
            if (order != null) {
                if (order.Status == OrderStatus.Created) {
                    _pharmacyContext.Orders.Remove(order);
                    return true;
                } else {
                    // Forbidden to cancel an already completed order.
                    return false;
                }
            } else {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Order order)
        {
            var existingOrder = await _pharmacyContext.Orders.Include(o => o.Elements).AsNoTracking().SingleAsync(o => o.Id == order.Id);

            if (existingOrder != null)
            {
                var exOrder = await _pharmacyContext.Orders.FirstAsync(x => x.Id == order.Id);

                // If the order was already completed, we can't do anything more with it.
                if (exOrder.Status == OrderStatus.Completed) {
                    return false;
                }

                exOrder.Status = order.Status;
                exOrder.DateOfFinalization = order.DateOfFinalization;
                // Delete elements
                foreach (var item in existingOrder.Elements)
                {
                    if(!order.Elements.All(o => o.EanCode.Equals(item.EanCode)))
                    {
                        var element = await _pharmacyContext.OrderElements.FirstAsync(x =>
                            x.EanCode.Equals(item.EanCode) && x.OrderId == item.OrderId);
                        _pharmacyContext.OrderElements.Remove(element);
                    }
                }

                // Add or update new elements
                foreach (var item in order.Elements)
                {
                    var existingElement = existingOrder.Elements.SingleOrDefault(e => e.EanCode.Equals(item.EanCode));

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

                // Updated successfully.
                return true;
            } else {
                // Nothing to update. Error.
                return false;
            }
        }

        public async Task<bool> FinalizeAsync(Order order)
        {
            var existingOrder = await _pharmacyContext.Orders.SingleAsync(o => o.Id == order.Id);

            if (existingOrder != null)
            {
                // If the order was already completed, we can't do anything more with it.
                if (existingOrder.Status == OrderStatus.Completed) {
                    return false;
                }

                existingOrder.Status = order.Status;
                existingOrder.DateOfFinalization = DateTime.UtcNow;

                var orderElements = _pharmacyContext.OrderElements.Include(oe => oe.Medicament).Where(oe => oe.OrderId == order.Id);

                foreach (var orderElement in orderElements)
                {
                    orderElement.Medicament.Quantity += orderElement.Quantity;
                }

                // Finalization was successful.
                return true;
            } else {
                // This order doesn't exist. This means we can't finalize the order.
                return false;
            }
        }
    }
}
