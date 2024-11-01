using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingIsDeletedProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("65bac172-f782-479a-ba18-712cf9054219"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("760e114b-7d73-4502-8eb2-3646880d0880"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8c8fe92e-e4c6-4da9-b2ce-c5520b4cb65a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a6e40379-1c31-48a4-8dae-86114ee22f73"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aa8e05b7-d338-4b96-ba4d-e08a9be3a00d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ced8808d-ba43-4dcf-a502-756872b8ee0a"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Restaurants",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Shows wether the restaurant is deleted or not");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("307e9a0a-748d-4ee3-997f-49e059a07128"), "Fast Food" },
                    { new Guid("4b92bddf-5476-43c7-b52f-0b5d9b6be3f3"), "Bistro" },
                    { new Guid("814e91bf-b972-4632-b090-8e0211b248c2"), "Restaurant" },
                    { new Guid("b119193a-a564-41ef-b3ee-e07df4136bed"), "Cafe" },
                    { new Guid("e8187d20-b9bc-406e-b528-7ede3a35f61c"), "Bakery" },
                    { new Guid("f03556d1-ae25-464d-b611-4e1ae2b6b537"), "Bar & Dinner" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("307e9a0a-748d-4ee3-997f-49e059a07128"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4b92bddf-5476-43c7-b52f-0b5d9b6be3f3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("814e91bf-b972-4632-b090-8e0211b248c2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b119193a-a564-41ef-b3ee-e07df4136bed"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e8187d20-b9bc-406e-b528-7ede3a35f61c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f03556d1-ae25-464d-b611-4e1ae2b6b537"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Restaurants");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("65bac172-f782-479a-ba18-712cf9054219"), "Cafe" },
                    { new Guid("760e114b-7d73-4502-8eb2-3646880d0880"), "Bistro" },
                    { new Guid("8c8fe92e-e4c6-4da9-b2ce-c5520b4cb65a"), "Restaurant" },
                    { new Guid("a6e40379-1c31-48a4-8dae-86114ee22f73"), "Bar & Dinner" },
                    { new Guid("aa8e05b7-d338-4b96-ba4d-e08a9be3a00d"), "Bakery" },
                    { new Guid("ced8808d-ba43-4dcf-a502-756872b8ee0a"), "Fast Food" }
                });
        }
    }
}
