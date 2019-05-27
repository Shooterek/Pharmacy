﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Pharmacy.Core.Models;
using Pharmacy.Core.Repositories;
using Pharmacy.Infrastructure.DTO;
using Pharmacy.Infrastructure.Exceptions;
using Pharmacy.Infrastructure.Repositories;
using Pharmacy.Infrastructure.Services.Interfaces;
using ErrorCodes = Pharmacy.Infrastructure.Exceptions.ErrorCodes;

namespace Pharmacy.Infrastructure.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMedicamentRepository _medicamentRepository;
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, UnitOfWork unitOfWork, IMapper mapper, IMedicamentRepository medicamentRepository)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _medicamentRepository = medicamentRepository;
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto> AddAsync(OrderDto order)
        {
            order.Status = OrderStatus.Created;
            var result = _orderRepository.Add(_mapper.Map<OrderDto, Order>(order));
            await _unitOfWork.Commit();

            return _mapper.Map<Order, OrderDto>(result);
        }

        public async Task<OrderDto> GetAsync(Guid id)
        {
            var result = await _orderRepository.GetAsync(id);

            if (result == null)
            {
                throw new ServiceException(ErrorCodes.ResourceNotFound);
            }
            return _mapper.Map<Order, OrderDto>(result);
        }

        public async Task UpdateAsync(OrderDto order)
        {
            if (order.Status.Equals(OrderStatus.Completed) && order.DateOfFinalization == null)
            {
                await _orderRepository.FinalizeAsync(_mapper.Map<OrderDto, Order>(order));
            }
            else
            {
                await _orderRepository.UpdateAsync(_mapper.Map<OrderDto, Order>(order));
            }

            await _unitOfWork.Commit();
        }

        public async Task<OrderDto> PrepareNewOrder()
        {
            var medicaments = await _medicamentRepository.GetAllAsync();
            var medicamentsWithNegativeQuantity = medicaments.Where(m => m.Quantity < 0);

            var orderElements = new List<OrderElementDto>();

            foreach (var medicament in medicamentsWithNegativeQuantity)
            {
                orderElements.Add(new OrderElementDto()
                {
                    EanCode = medicament.EanCode,
                    Quantity = 0 - medicament.Quantity
                });
            }

            var newOrder = new OrderDto()
            {
                Elements = orderElements
            };

            return newOrder;
        }
    }
}
