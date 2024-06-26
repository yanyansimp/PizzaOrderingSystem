﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POS.Persistence;

namespace POS.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("POS.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("POS.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PizzaId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("POS.Models.Pizza", b =>
                {
                    b.Property<string>("PizzaId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PizzaTypeId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("Size")
                        .HasColumnType("TEXT");

                    b.HasKey("PizzaId");

                    b.HasIndex("PizzaId")
                        .IsUnique();

                    b.HasIndex("PizzaTypeId");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("POS.Models.PizzaType", b =>
                {
                    b.Property<string>("PizzaTypeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ingredients")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("PizzaTypeId");

                    b.ToTable("PizzaTypes");
                });

            modelBuilder.Entity("POS.Models.OrderDetail", b =>
                {
                    b.HasOne("POS.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS.Models.Pizza", "Pizza")
                        .WithMany("OrderDetails")
                        .HasForeignKey("PizzaId");
                });

            modelBuilder.Entity("POS.Models.Pizza", b =>
                {
                    b.HasOne("POS.Models.PizzaType", "PizzaType")
                        .WithMany("Pizzas")
                        .HasForeignKey("PizzaTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
