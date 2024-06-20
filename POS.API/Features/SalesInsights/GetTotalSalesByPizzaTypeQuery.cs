using MediatR;
using System.Collections.Generic;

namespace POS.API.Features.SalesInsights
{
    public class GetTotalSalesByPizzaTypeQuery : IRequest<IEnumerable<PizzaTypeSalesDto>>
    {
    }
}
