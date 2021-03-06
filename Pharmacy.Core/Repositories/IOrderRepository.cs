﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pharmacy.Core.Models;

namespace Pharmacy.Core.Repositories
{
    public interface IOrderRepository : IRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Order Add(Order order);
        Task<Order> GetAsync(Guid id);
        Task<bool> CancelAsync(Guid id);
        Task<bool> UpdateAsync(Order order);
        Task<bool> FinalizeAsync(Order order);
    }
}