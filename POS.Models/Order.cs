using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
