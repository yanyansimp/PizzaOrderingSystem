using MediatR;
using Microsoft.EntityFrameworkCore;
using POS.Models;
using POS.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POS.API.Features.SalesInsights
{
    public class GetTotalSalesByPizzaTypeHandler : IRequestHandler<GetTotalSalesByPizzaTypeQuery, IEnumerable<PizzaTypeSalesDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetTotalSalesByPizzaTypeHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PizzaTypeSalesDto>> Handle(GetTotalSalesByPizzaTypeQuery request, CancellationToken cancellationToken)
        {
            var salesData = await _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Pizza)
                .ThenInclude(p => p.PizzaType)
                .GroupBy(o => o.OrderDetails.FirstOrDefault().Pizza.PizzaType.Name)
                .Select(g => new PizzaTypeSalesDto
                {
                    PizzaTypeName = g.Key,
                    TotalSales = g.Sum(o => o.OrderDetails.Sum(od => od.Quantity * od.Pizza.Price))
                })
                .ToListAsync(cancellationToken);

            return salesData;
        }
    }
}
