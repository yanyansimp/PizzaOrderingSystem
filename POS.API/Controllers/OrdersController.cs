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
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders(int pageNumber = 1, int pageSize = 10)
        {
            var query = new GetOrdersQuery(pageNumber, pageSize);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<Order> Post(CreateOrderCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
