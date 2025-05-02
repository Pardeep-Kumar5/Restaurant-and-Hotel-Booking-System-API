using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantHotelBookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addforeignkeyinRestaurantTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodTypeId",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 4);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_FoodTypeId",
                table: "Restaurants",
                column: "FoodTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_FoodTypes_FoodTypeId",
                table: "Restaurants",
                column: "FoodTypeId",
                principalTable: "FoodTypes",
                principalColumn: "FoodTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_FoodTypes_FoodTypeId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_FoodTypeId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "FoodTypeId",
                table: "Restaurants");
        }
    }
}
