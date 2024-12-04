using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class SetingOnlyMaxLenghtsToEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "RestaurantId",
                table: "UsersRestaurants",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Identifier of the Restaurant",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Identifier of the Recepie");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecepieId",
                table: "UsersRecepies",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Identifier of the Recepie",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Identifier of the Restaurant");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Comments",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                comment: "The message of the Comment.",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldComment: "The message of the Recepie.");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Identifier of the Comment.",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Identifier of the Recepie.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 4, 13, 30, 45, 22, DateTimeKind.Local).AddTicks(1274),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 2, 18, 33, 50, 968, DateTimeKind.Local).AddTicks(2210),
                oldComment: "Date of creation of the User.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "RestaurantId",
                table: "UsersRestaurants",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Identifier of the Recepie",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Identifier of the Restaurant");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecepieId",
                table: "UsersRecepies",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Identifier of the Restaurant",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Identifier of the Recepie");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Comments",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                comment: "The message of the Recepie.",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldComment: "The message of the Comment.");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Identifier of the Recepie.",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Identifier of the Comment.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 2, 18, 33, 50, 968, DateTimeKind.Local).AddTicks(2210),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 4, 13, 30, 45, 22, DateTimeKind.Local).AddTicks(1274),
                oldComment: "Date of creation of the User.");
        }
    }
}
