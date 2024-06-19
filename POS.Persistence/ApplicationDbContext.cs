using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using POS.Models;

namespace POS.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaType> PizzaTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>()
                .HasOne(p => p.PizzaType)
                .WithMany(pt => pt.Pizzas)
                .HasForeignKey(p => p.PizzaTypeId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Pizza)
                .WithMany()
                .HasForeignKey(od => od.PizzaId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Pizza)
                .WithMany()
                .HasForeignKey(o => o.PizzaId);
        }
    }
}
