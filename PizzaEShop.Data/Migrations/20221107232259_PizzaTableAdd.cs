using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaEShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class PizzaTableAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaEntity_Orders_OrderId",
                table: "PizzaEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PizzaEntity",
                table: "PizzaEntity");

            migrationBuilder.RenameTable(
                name: "PizzaEntity",
                newName: "Pizzas");

            migrationBuilder.RenameIndex(
                name: "IX_PizzaEntity_OrderId",
                table: "Pizzas",
                newName: "IX_Pizzas_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Orders_OrderId",
                table: "Pizzas",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Orders_OrderId",
                table: "Pizzas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas");

            migrationBuilder.RenameTable(
                name: "Pizzas",
                newName: "PizzaEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_OrderId",
                table: "PizzaEntity",
                newName: "IX_PizzaEntity_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PizzaEntity",
                table: "PizzaEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaEntity_Orders_OrderId",
                table: "PizzaEntity",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
