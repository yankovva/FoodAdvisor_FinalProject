using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangintTypeOfPriceRange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PricaRange",
                table: "Restaurants",
                type: "int",
                maxLength: 100000,
                nullable: false,
                comment: "Shows the price range of the restaurant.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "$",
                oldComment: "Shows the price range of the restaurant.");

            migrationBuilder.AlterColumn<string>(
                name: "Products",
                table: "Recepies",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                comment: "Needed products for the Recepie.",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "Needed products for the Recepie.");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Recepies",
                type: "nvarchar(700)",
                maxLength: 700,
                nullable: false,
                comment: "Description of the Recepie.",
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400,
                oldComment: "Description of the Recepie.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 18, 1, 6, 492, DateTimeKind.Local).AddTicks(1040),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 28, 16, 2, 36, 974, DateTimeKind.Local).AddTicks(2515),
                oldComment: "Date of creation of the User.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PricaRange",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "$",
                comment: "Shows the price range of the restaurant.",
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 100000,
                oldComment: "Shows the price range of the restaurant.");

            migrationBuilder.AlterColumn<string>(
                name: "Products",
                table: "Recepies",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "Needed products for the Recepie.",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldComment: "Needed products for the Recepie.");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Recepies",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                comment: "Description of the Recepie.",
                oldClrType: typeof(string),
                oldType: "nvarchar(700)",
                oldMaxLength: 700,
                oldComment: "Description of the Recepie.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 28, 16, 2, 36, 974, DateTimeKind.Local).AddTicks(2515),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 2, 18, 1, 6, 492, DateTimeKind.Local).AddTicks(1040),
                oldComment: "Date of creation of the User.");
        }
    }
}
