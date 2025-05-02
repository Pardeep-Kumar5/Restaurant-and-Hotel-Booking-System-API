using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantHotelBookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class editcolumntype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "People");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
