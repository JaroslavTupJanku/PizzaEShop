﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaEShop.Data;

#nullable disable

namespace PizzaEShop.Data.Migrations
{
    [DbContext(typeof(SqlEFDataContext))]
    [Migration("20221117155403_UpdateOrderEntity")]
    partial class UpdateOrderEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("PizzaEShop.Data.Entity.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsFavorit")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PSC")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaEShop.Data.Entity.PizzaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Gorgonzola")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Hermelin")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Kukurice")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Losos")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Mozzarela")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PizzaCost")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PizzaType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rukola")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Salam")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Vejce")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Zizaly")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("PizzaEShop.Data.Entity.PizzaEntity", b =>
                {
                    b.HasOne("PizzaEShop.Data.Entity.OrderEntity", "Order")
                        .WithMany("Pizzas")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("PizzaEShop.Data.Entity.OrderEntity", b =>
                {
                    b.Navigation("Pizzas");
                });
#pragma warning restore 612, 618
        }
    }
}