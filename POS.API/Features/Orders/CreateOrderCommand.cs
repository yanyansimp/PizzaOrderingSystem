using MediatR;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.API.Features.Orders
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public string PizzaId { get; set; }
    }
}
