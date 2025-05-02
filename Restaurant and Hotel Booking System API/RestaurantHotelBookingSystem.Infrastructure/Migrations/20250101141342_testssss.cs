using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantHotelBookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class testssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Restaurants_RestaurantsRestaurantId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_RestaurantsRestaurantId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "RestaurantsRestaurantId",
                table: "Foods");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_RestaurantId",
                table: "Foods",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Restaurants_RestaurantId",
                table: "Foods",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Restaurants_RestaurantId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_RestaurantId",
                table: "Foods");

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
    }
}
