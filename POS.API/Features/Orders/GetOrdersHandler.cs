﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using POS.Models;
using POS.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace POS.API.Features.Orders
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, IEnumerable<Order>>
    {
        private readonly ApplicationDbContext _context;

        public GetOrdersHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Orders.Include(o => o.Pizza).ToListAsync();
        }
    }
}
