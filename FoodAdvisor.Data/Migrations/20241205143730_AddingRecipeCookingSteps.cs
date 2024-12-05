using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingRecipeCookingSteps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Recepies",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Description of the Recepie.",
                oldClrType: typeof(string),
                oldType: "nvarchar(700)",
                oldMaxLength: 700,
                oldComment: "Description of the Recepie.");

            migrationBuilder.AddColumn<string>(
                name: "CookingSteps",
                table: "Recepies",
                type: "nvarchar(700)",
                maxLength: 700,
                nullable: false,
                defaultValue: "",
                comment: "CookingSteps of the Recepie.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 5, 16, 37, 28, 354, DateTimeKind.Local).AddTicks(9867),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 5, 12, 49, 25, 894, DateTimeKind.Local).AddTicks(767),
                oldComment: "Date of creation of the User.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CookingSteps",
                table: "Recepies");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Recepies",
                type: "nvarchar(700)",
                maxLength: 700,
                nullable: false,
                comment: "Description of the Recepie.",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Description of the Recepie.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 5, 12, 49, 25, 894, DateTimeKind.Local).AddTicks(767),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 5, 16, 37, 28, 354, DateTimeKind.Local).AddTicks(9867),
                oldComment: "Date of creation of the User.");
        }
    }
}
