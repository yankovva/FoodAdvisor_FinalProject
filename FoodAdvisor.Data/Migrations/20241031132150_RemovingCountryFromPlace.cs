using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovingCountryFromPlace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Countries_ConutryId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_ConutryId",
                table: "Places");

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("073d9d04-bbaf-4b28-a2b6-9a512c091103"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("74914725-016f-46e4-9125-028a9e2164e2"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("9807e338-d261-45bb-8259-c87defa289ab"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("bdba7005-4063-4814-8279-7b1f767677e3"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("e5884382-4b5a-4abf-bf4e-c01ff88dedb2"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f7997730-4fa6-49c5-8056-d7f6d8313c76"));

            //migrationBuilder.DropColumn(
            //    name: "ConutryId",
            //    table: "Places");

            //migrationBuilder.InsertData(
            //    table: "Categories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("16bae119-1c02-4df7-bfd5-a70e48202e2a"), "Restaurant" },
            //        { new Guid("1bab5412-87c7-4e87-b654-cb4e226684a9"), "Bar & Dinner" },
            //        { new Guid("1c7001a4-491c-4614-91b1-03143b585199"), "Cafe" },
            //        { new Guid("a14d425e-7fbf-41c2-bc71-a97f9aded01b"), "Bistro" },
            //        { new Guid("cd4e4887-817f-4603-b820-14681499d61b"), "Fast Food" },
            //        { new Guid("f88a935c-f67a-4af5-8876-befe3565c768"), "Bakery" }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("16bae119-1c02-4df7-bfd5-a70e48202e2a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1bab5412-87c7-4e87-b654-cb4e226684a9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1c7001a4-491c-4614-91b1-03143b585199"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a14d425e-7fbf-41c2-bc71-a97f9aded01b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cd4e4887-817f-4603-b820-14681499d61b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f88a935c-f67a-4af5-8876-befe3565c768"));

            migrationBuilder.AddColumn<Guid>(
                name: "ConutryId",
                table: "Places",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "The Country Id.");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("073d9d04-bbaf-4b28-a2b6-9a512c091103"), "Bakery" },
                    { new Guid("74914725-016f-46e4-9125-028a9e2164e2"), "Bar & Dinner" },
                    { new Guid("9807e338-d261-45bb-8259-c87defa289ab"), "Restaurant" },
                    { new Guid("bdba7005-4063-4814-8279-7b1f767677e3"), "Bistro" },
                    { new Guid("e5884382-4b5a-4abf-bf4e-c01ff88dedb2"), "Cafe" },
                    { new Guid("f7997730-4fa6-49c5-8056-d7f6d8313c76"), "Fast Food" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Places_ConutryId",
                table: "Places",
                column: "ConutryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Countries_ConutryId",
                table: "Places",
                column: "ConutryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
