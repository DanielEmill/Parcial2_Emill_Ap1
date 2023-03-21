﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Parcial2_Emill.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20230320233008_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("Productos", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Costo")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Existencia")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            ProductoId = 1,
                            Costo = 100.0,
                            Descripcion = "Maní",
                            Existencia = 15,
                            Precio = 25.0
                        },
                        new
                        {
                            ProductoId = 2,
                            Costo = 30.0,
                            Descripcion = "Pistachos",
                            Existencia = 20,
                            Precio = 15.0
                        },
                        new
                        {
                            ProductoId = 3,
                            Costo = 25.0,
                            Descripcion = "Ciruelas",
                            Existencia = 30,
                            Precio = 5.0
                        },
                        new
                        {
                            ProductoId = 4,
                            Costo = 50.0,
                            Descripcion = "Pasas",
                            Existencia = 50,
                            Precio = 10.0
                        },
                        new
                        {
                            ProductoId = 5,
                            Costo = 200.0,
                            Descripcion = "Arándanos",
                            Existencia = 50,
                            Precio = 100.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}