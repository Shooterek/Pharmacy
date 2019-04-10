﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pharmacy.Infrastructure.DTO;

namespace Pharmacy.Infrastructure.Services.Interfaces
{
    public interface IOrderService : IService
    {
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task<OrderDto> AddAsync(OrderDto order);
        Task<OrderDto> GetAsync(Guid id);
    }
}