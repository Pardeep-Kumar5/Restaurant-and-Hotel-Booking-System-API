using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantHotelBookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addFoodTypeImageURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "FoodTypes",
                newName: "ImageUrl");

            migrationBuilder.DropColumn(
            name: "ImageString",
            table: "FoodTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "FoodTypes",
                newName: "Image");

            migrationBuilder.DropColumn(
            name: "ImageString",
            table: "FoodTypes");
        }
    }
}
