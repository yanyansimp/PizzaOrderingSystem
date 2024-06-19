using MediatR;
using POS.Models;

namespace POS.API.Features.OrderDetails
{
    public class CreateOrderDetailCommand : IRequest<OrderDetail>
    {
        public int OrderId { get; set; }
        public string PizzaId { get; set; }
        public int Quantity { get; set; }
    }
}
