using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using POS.Models;
using POS.Persistence.Mappings;

namespace POS.Persistence
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Pizzas.Any())
                {
                    return;   // DB has been seeded
                }

                var pizzas = ReadCsv<Pizza, CSVMappings.PizzaMap>("../CSV/pizzas.csv");
                context.Pizzas.AddRange(pizzas);

                var pizzaTypes = ReadCsv<PizzaType, CSVMappings.PizzaTypeMap>("../CSV/pizza_types.csv");
                context.PizzaTypes.AddRange(pizzaTypes);

                var orders = ReadCsv<Order, CSVMappings.OrderMap>("../CSV/orders.csv");
                context.Orders.AddRange(orders);

                var orderDetails = ReadCsv<OrderDetail, CSVMappings.OrderDetailMap>("../CSV/order_details.csv");
                context.OrderDetails.AddRange(orderDetails);

                context.SaveChanges();
            }
        }

        private static List<T> ReadCsv<T, TMap>(string path) where TMap : ClassMap<T>
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<TMap>();
                return csv.GetRecords<T>().ToList();
            }
        }
    }
}
