﻿using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Models
{
    public class Pizza
    {
        public string PizzaId { get; set; }
        public string PizzaTypeId { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }

        public PizzaType PizzaType { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }

}
