using MediatR;
using POS.Models;
using POS.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace POS.API.Features.OrderDetails
{
    public class CreateOrderDetailHandler : IRequestHandler<CreateOrderDetailCommand, OrderDetail>
    {
        private readonly ApplicationDbContext _context;

        public CreateOrderDetailHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OrderDetail> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var orderDetail = new OrderDetail
            {
                OrderId = request.OrderId,
                //PizzaId = request.PizzaId,
                Quantity = request.Quantity
            };

            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();

            return orderDetail;
        }
    }
}
