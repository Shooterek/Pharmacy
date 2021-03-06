﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Infrastructure.DTO;
using Pharmacy.Infrastructure.Services.Interfaces;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderService _ordersService;

        public OrdersController(IOrderService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(bool? createNew)
        {
            if (createNew.GetValueOrDefault(false))
            {
                var newOrder = await _ordersService.PrepareNewOrder();

                return Ok(newOrder);
            }

            var orders = await _ordersService.GetAllAsync();

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _ordersService.GetAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderDto order)
        {
            order.PharmacistId = new Guid(User.Identity.Name);
            var result = await _ordersService.AddAsync(order);

            return Created($"api/orders/{result.Id}", result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, OrderDto order)
        {
            order.Id = id;
            bool wasOk = await _ordersService.UpdateAsync(order);

            if (wasOk)
                return Ok();
            else
                return StatusCode(403);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _ordersService.CancelAsync(id)) {
                return Ok();
            } else {
                return NotFound();
            }
        }
    }
}
