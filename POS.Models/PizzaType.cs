﻿using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Models
{
    public class PizzaType
    {
        public string PizzaTypeId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Ingredients { get; set; }

        public ICollection<Pizza> Pizzas { get; set; }
    }

}
