using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Parcial2_Emill.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empacados",
                columns: table => new
                {
                    EmpacadoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Concepto = table.Column<string>(type: "TEXT", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empacados", x => x.EmpacadoId);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Costo = table.Column<double>(type: "REAL", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    Existencia = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "EmpacadosD",
                columns: table => new
                {
                    EmpacadoDetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpacadoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpacadosD", x => x.EmpacadoDetalleId);
                    table.ForeignKey(
                        name: "FK_EmpacadosD_Empacados_EmpacadoId",
                        column: x => x.EmpacadoId,
                        principalTable: "Empacados",
                        principalColumn: "EmpacadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "productos",
                columns: new[] { "ProductoId", "Costo", "Descripcion", "Existencia", "Precio" },
                values: new object[,]
                {
                    { 1, 100.0, "Maní", 225, 25.0 },
                    { 2, 30.0, "Pistachos", 225, 15.0 },
                    { 3, 25.0, "Ciruelas", 225, 5.0 },
                    { 4, 50.0, "Pasas", 225, 10.0 },
                    { 5, 200.0, "Arándanos", 225, 100.0 },
                    { 6, 100.0, "Producto Mixto", 0, 300.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpacadosD_EmpacadoId",
                table: "EmpacadosD",
                column: "EmpacadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpacadosD");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "Empacados");
        }
    }
}
