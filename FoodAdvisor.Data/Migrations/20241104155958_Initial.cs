using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("307e9a0a-748d-4ee3-997f-49e059a07128"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("4b92bddf-5476-43c7-b52f-0b5d9b6be3f3"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("814e91bf-b972-4632-b090-8e0211b248c2"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("b119193a-a564-41ef-b3ee-e07df4136bed"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("e8187d20-b9bc-406e-b528-7ede3a35f61c"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f03556d1-ae25-464d-b611-4e1ae2b6b537"));

            //migrationBuilder.InsertData(
            //    table: "Categories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("669c3527-ade7-4dda-872e-c96e8cabf9a1"), "Fast Food" },
            //        { new Guid("75a969ad-9ab0-4778-9801-41ff6dbf3081"), "Bar & Dinner" },
            //        { new Guid("76b67744-f579-4c47-a13c-b1fd238373b8"), "Cafe" },
            //        { new Guid("814b05c9-b967-47d3-a3b1-be699223b16f"), "Bakery" },
            //        { new Guid("899ec41b-b57f-4bd1-8008-c1e64ad2e4aa"), "Restaurant" },
            //        { new Guid("b53bae73-88b2-4a1a-9649-228e5b8ae617"), "Bistro" }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("669c3527-ade7-4dda-872e-c96e8cabf9a1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("75a969ad-9ab0-4778-9801-41ff6dbf3081"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("76b67744-f579-4c47-a13c-b1fd238373b8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("814b05c9-b967-47d3-a3b1-be699223b16f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("899ec41b-b57f-4bd1-8008-c1e64ad2e4aa"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b53bae73-88b2-4a1a-9649-228e5b8ae617"));

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
    }
}
