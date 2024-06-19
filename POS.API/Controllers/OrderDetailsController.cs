using MediatR;
using Microsoft.AspNetCore.Mvc;
using POS.API.Features.OrderDetails;
using POS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{orderId}")]
        public async Task<IEnumerable<OrderDetail>> Get(int orderId)
        {
            return await _mediator.Send(new GetOrderDetailsQuery(orderId));
        }

        //[HttpPost]
        //public async Task<OrderDetail> Post(CreateOrderDetailCommand command)
        //{
        //    return await _mediator.Send(command);
        //}
    }
}
