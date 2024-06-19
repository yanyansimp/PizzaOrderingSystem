using MediatR;
using Microsoft.AspNetCore.Mvc;
using POS.API.Features.Orders;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            return await _mediator.Send(new GetOrdersQuery());
        }

        [HttpPost]
        public async Task<Order> Post(CreateOrderCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
