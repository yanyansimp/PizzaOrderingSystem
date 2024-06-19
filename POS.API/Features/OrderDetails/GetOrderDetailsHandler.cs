using MediatR;
using Microsoft.EntityFrameworkCore;
using POS.Models;
using POS.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POS.API.Features.OrderDetails
{
    public class GetOrderDetailsHandler : IRequestHandler<GetOrderDetailsQuery, IEnumerable<OrderDetail>>
    {
        private readonly ApplicationDbContext _context;

        public GetOrderDetailsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderDetail>> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _context.OrderDetails
                .Include(od => od.Pizza)
                .Where(od => od.OrderId == request.OrderId)
                .ToListAsync();
        }
    }
}
