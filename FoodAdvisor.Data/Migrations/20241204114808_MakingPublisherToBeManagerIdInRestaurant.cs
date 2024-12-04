using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakingPublisherToBeManagerIdInRestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_AspNetUsers_PublisherId",
                table: "Restaurants");

            migrationBuilder.AlterColumn<Guid>(
                name: "RestaurantId",
                table: "UsersRestaurants",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Identifier of the Recepie",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Identifier of the Restaurant");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 4, 13, 48, 6, 577, DateTimeKind.Local).AddTicks(7218),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 4, 13, 30, 45, 22, DateTimeKind.Local).AddTicks(1274),
                oldComment: "Date of creation of the User.");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Managers_PublisherId",
                table: "Restaurants",
                column: "PublisherId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Managers_PublisherId",
                table: "Restaurants");

            migrationBuilder.AlterColumn<Guid>(
                name: "RestaurantId",
                table: "UsersRestaurants",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Identifier of the Restaurant",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Identifier of the Recepie");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 4, 13, 30, 45, 22, DateTimeKind.Local).AddTicks(1274),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 4, 13, 48, 6, 577, DateTimeKind.Local).AddTicks(7218),
                oldComment: "Date of creation of the User.");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_AspNetUsers_PublisherId",
                table: "Restaurants",
                column: "PublisherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
