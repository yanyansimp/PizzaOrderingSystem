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
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetOrdersQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
