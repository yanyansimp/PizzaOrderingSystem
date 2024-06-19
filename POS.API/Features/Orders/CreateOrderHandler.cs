using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
                Date = DateTime.Now.Date,
                Time = DateTime.Now.TimeOfDay,
                OrderDetails = new List<OrderDetail>()
            };

            foreach (var detail in request.OrderDetails)
            {
                // Validate if PizzaId exists
                var pizzaExists = await _context.Pizzas.AnyAsync(p => p.PizzaId == detail.PizzaId, cancellationToken);
                if (!pizzaExists)
                {
                    throw new ArgumentException($"PizzaId {detail.PizzaId} does not exist.");
                }

                // Add each detail to the order
                order.OrderDetails.Add(new OrderDetail
                {
                    PizzaId = detail.PizzaId,
                    Quantity = detail.Quantity
                });
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);

            return order;
        }
    }

}
