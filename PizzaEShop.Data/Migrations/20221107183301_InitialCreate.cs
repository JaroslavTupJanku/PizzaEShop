using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaEShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PizzaEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    PizzaType = table.Column<int>(type: "INTEGER", nullable: false),
                    PizzaCost = table.Column<double>(type: "REAL", nullable: false),
                    Mozzarela = table.Column<int>(type: "INTEGER", nullable: false),
                    Gorgonzola = table.Column<int>(type: "INTEGER", nullable: false),
                    Hermelin = table.Column<int>(type: "INTEGER", nullable: false),
                    Vejce = table.Column<int>(type: "INTEGER", nullable: false),
                    Kukurice = table.Column<int>(type: "INTEGER", nullable: false),
                    Rukola = table.Column<int>(type: "INTEGER", nullable: false),
                    Salam = table.Column<int>(type: "INTEGER", nullable: false),
                    Losos = table.Column<int>(type: "INTEGER", nullable: false),
                    Zizaly = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaEntity_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaEntity_OrderId",
                table: "PizzaEntity",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaEntity");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
