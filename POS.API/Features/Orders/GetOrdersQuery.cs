using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using POS.Models;

namespace POS.API.Features.Orders
{
    public class GetOrdersQuery : IRequest<IEnumerable<Order>>
    {
    }
}
