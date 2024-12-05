using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingLargerMaxLengtToReipeCookingSteps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CookingSteps",
                table: "Recepies",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: false,
                comment: "CookingSteps of the Recepie.",
                oldClrType: typeof(string),
                oldType: "nvarchar(700)",
                oldMaxLength: 700,
                oldComment: "CookingSteps of the Recepie.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 5, 16, 59, 48, 218, DateTimeKind.Local).AddTicks(2685),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 5, 16, 37, 28, 354, DateTimeKind.Local).AddTicks(9867),
                oldComment: "Date of creation of the User.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CookingSteps",
                table: "Recepies",
                type: "nvarchar(700)",
                maxLength: 700,
                nullable: false,
                comment: "CookingSteps of the Recepie.",
                oldClrType: typeof(string),
                oldType: "nvarchar(3000)",
                oldMaxLength: 3000,
                oldComment: "CookingSteps of the Recepie.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 5, 16, 37, 28, 354, DateTimeKind.Local).AddTicks(9867),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 5, 16, 59, 48, 218, DateTimeKind.Local).AddTicks(2685),
                oldComment: "Date of creation of the User.");
        }
    }
}
