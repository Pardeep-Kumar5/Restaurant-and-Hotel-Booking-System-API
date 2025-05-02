using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantHotelBookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class testsss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantsRestaurantId",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_RestaurantsRestaurantId",
                table: "Foods",
                column: "RestaurantsRestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Restaurants_RestaurantsRestaurantId",
                table: "Foods",
                column: "RestaurantsRestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Restaurants_RestaurantsRestaurantId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_RestaurantsRestaurantId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "RestaurantsRestaurantId",
                table: "Foods");
        }
    }
}
