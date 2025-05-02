using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantHotelBookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addRestaurantTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Foods_FoodsFoodId",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "FoodsFoodId",
                table: "Restaurants",
                newName: "FoodsId");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurants_FoodsFoodId",
                table: "Restaurants",
                newName: "IX_Restaurants_FoodsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Foods_FoodsId",
                table: "Restaurants",
                column: "FoodsId",
                principalTable: "Foods",
                principalColumn: "FoodId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Foods_FoodsId",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "FoodsId",
                table: "Restaurants",
                newName: "FoodsFoodId");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurants_FoodsId",
                table: "Restaurants",
                newName: "IX_Restaurants_FoodsFoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Foods_FoodsFoodId",
                table: "Restaurants",
                column: "FoodsFoodId",
                principalTable: "Foods",
                principalColumn: "FoodId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
