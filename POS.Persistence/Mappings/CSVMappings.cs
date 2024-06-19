using CsvHelper.Configuration;
using POS.Models;
using System;

namespace POS.Persistence.Mappings
{
    public class CSVMappings
    {
        public class PizzaMap : ClassMap<Pizza>
        {
            public PizzaMap()
            {
                Map(m => m.PizzaId).Name("pizza_id");
                Map(m => m.PizzaTypeId).Name("pizza_type_id");
                Map(m => m.Size).Name("size");
                Map(m => m.Price).Name("price");
            }
        }

        public class PizzaTypeMap : ClassMap<PizzaType>
        {
            public PizzaTypeMap()
            {
                Map(m => m.PizzaTypeId).Name("pizza_type_id");
                Map(m => m.Name).Name("name");
                Map(m => m.Category).Name("category");
                Map(m => m.Ingredients).Name("ingredients");
            }
        }

        public class OrderMap : ClassMap<Order>
        {
            public OrderMap()
            {
                Map(m => m.OrderId).Name("order_id");
                Map(m => m.Date).Name("date").TypeConverterOption.Format("yyyy-MM-dd"); // Specify the format here
                Map(m => m.Time).Name("time").TypeConverterOption.Format("hh\\:mm\\:ss");
            }
        }

        public class OrderDetailMap : ClassMap<OrderDetail>
        {
            public OrderDetailMap()
            {
                Map(m => m.OrderDetailId).Name("order_details_id");
                Map(m => m.OrderId).Name("order_id");
                Map(m => m.PizzaId).Name("pizza_id");
                Map(m => m.Quantity).Name("quantity");
            }
        }
    }
}
