using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using POS.Models;
using POS.Persistence;

namespace POS.API.Features.Orders
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly ApplicationDbContext _context;

        public CreateOrderHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                PizzaId = request.PizzaId,
                Date = DateTime.Now.Date,
                Time = DateTime.Now.TimeOfDay
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }
    }
}
