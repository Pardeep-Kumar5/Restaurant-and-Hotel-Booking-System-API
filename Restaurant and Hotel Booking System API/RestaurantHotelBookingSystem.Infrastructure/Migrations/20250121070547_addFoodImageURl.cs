using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantHotelBookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addFoodImageURl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Foods",
                newName: "ImageURL");

            migrationBuilder.DropColumn(
                 name: "ImageString",
                 table: "Foods");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Foods",
                newName: "Image");

            migrationBuilder.DropColumn(
            name: "ImageString",
            table: "Foods");
        }
    }
}
