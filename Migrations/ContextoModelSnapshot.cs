﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Parcial2_Emill.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("EmpacadoDetalle", b =>
                {
                    b.Property<int>("EmpacadoDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("EmpacadoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EmpacadoDetalleId");

                    b.HasIndex("EmpacadoId");

                    b.ToTable("EmpacadosD");
                });

            modelBuilder.Entity("Empacados", b =>
                {
                    b.Property<int>("EmpacadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.HasKey("EmpacadoId");

                    b.ToTable("Empacados");
                });

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

                    b.ToTable("productos");

                    b.HasData(
                        new
                        {
                            ProductoId = 1,
                            Costo = 100.0,
                            Descripcion = "Maní",
                            Existencia = 225,
                            Precio = 25.0
                        },
                        new
                        {
                            ProductoId = 2,
                            Costo = 30.0,
                            Descripcion = "Pistachos",
                            Existencia = 225,
                            Precio = 15.0
                        },
                        new
                        {
                            ProductoId = 3,
                            Costo = 25.0,
                            Descripcion = "Ciruelas",
                            Existencia = 225,
                            Precio = 5.0
                        },
                        new
                        {
                            ProductoId = 4,
                            Costo = 50.0,
                            Descripcion = "Pasas",
                            Existencia = 225,
                            Precio = 10.0
                        },
                        new
                        {
                            ProductoId = 5,
                            Costo = 200.0,
                            Descripcion = "Arándanos",
                            Existencia = 225,
                            Precio = 100.0
                        },
                        new
                        {
                            ProductoId = 6,
                            Costo = 100.0,
                            Descripcion = "Producto Mixto",
                            Existencia = 0,
                            Precio = 300.0
                        });
                });

            modelBuilder.Entity("EmpacadoDetalle", b =>
                {
                    b.HasOne("Empacados", null)
                        .WithMany("EmpacadoDetalle")
                        .HasForeignKey("EmpacadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Empacados", b =>
                {
                    b.Navigation("EmpacadoDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
