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
            base.OnModelCreating(modelBuilder);

            // Define relationships and constraints
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Pizza)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.PizzaId);

            modelBuilder.Entity<Pizza>()
                .HasIndex(p => p.PizzaId)
                .IsUnique();

            modelBuilder.Entity<Pizza>()
                .HasOne(p => p.PizzaType)
                .WithMany(pt => pt.Pizzas)
                .HasForeignKey(p => p.PizzaTypeId);
        }
    }
}
