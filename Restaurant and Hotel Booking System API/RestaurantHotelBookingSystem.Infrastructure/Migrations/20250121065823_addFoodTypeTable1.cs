using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantHotelBookingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addFoodTypeTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_FoodType_FoodTypeId",
                table: "Foods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodType",
                table: "FoodType");

            migrationBuilder.RenameTable(
                name: "FoodType",
                newName: "FoodTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodTypes",
                table: "FoodTypes",
                column: "FoodTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FoodTypes_FoodTypeId",
                table: "Foods",
                column: "FoodTypeId",
                principalTable: "FoodTypes",
                principalColumn: "FoodTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_FoodTypes_FoodTypeId",
                table: "Foods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodTypes",
                table: "FoodTypes");

            migrationBuilder.RenameTable(
                name: "FoodTypes",
                newName: "FoodType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodType",
                table: "FoodType",
                column: "FoodTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FoodType_FoodTypeId",
                table: "Foods",
                column: "FoodTypeId",
                principalTable: "FoodType",
                principalColumn: "FoodTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
