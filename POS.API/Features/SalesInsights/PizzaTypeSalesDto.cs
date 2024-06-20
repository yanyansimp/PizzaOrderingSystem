using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.API.Features.SalesInsights
{
    public class PizzaTypeSalesDto
    {
        public string PizzaTypeName { get; set; }
        public decimal TotalSales { get; set; }
    }
}
