using MediatR;
using Microsoft.AspNetCore.Mvc;
using POS.API.Features.SalesInsights;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesInsightsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SalesInsightsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet("totalsalesbypizzatype")]
        //public async Task<ActionResult<IEnumerable<PizzaTypeSalesDto>>> GetTotalSalesByPizzaType()
        //{
        //    var result = await _mediator.Send(new GetTotalSalesByPizzaTypeQuery());
        //    return Ok(result);
        //}
    }
}
