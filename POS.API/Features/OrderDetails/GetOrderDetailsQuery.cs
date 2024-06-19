using MediatR;
using POS.Models;
using System.Collections.Generic;

namespace POS.API.Features.OrderDetails
{
    public class GetOrderDetailsQuery : IRequest<IEnumerable<OrderDetail>>
    {
        public int OrderId { get; set; }

        public GetOrderDetailsQuery(int orderId)
        {
            OrderId = orderId;
        }
    }
}
