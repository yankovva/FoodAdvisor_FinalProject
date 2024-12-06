using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakingPublisherInRestaurantApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Managers_PublisherId",
                table: "Restaurants");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 6, 12, 4, 27, 670, DateTimeKind.Local).AddTicks(8606),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 5, 16, 59, 48, 218, DateTimeKind.Local).AddTicks(2685),
                oldComment: "Date of creation of the User.");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_AspNetUsers_PublisherId",
                table: "Restaurants",
                column: "PublisherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_AspNetUsers_PublisherId",
                table: "Restaurants");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 5, 16, 59, 48, 218, DateTimeKind.Local).AddTicks(2685),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 6, 12, 4, 27, 670, DateTimeKind.Local).AddTicks(8606),
                oldComment: "Date of creation of the User.");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Managers_PublisherId",
                table: "Restaurants",
                column: "PublisherId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
