using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovingTheRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("4946e8b1-2794-4269-9850-91c9f28851ae"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("6feadeb8-e045-4f00-882f-fedae1309493"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("92d91be7-0c45-47db-acd7-030f1b5a92fb"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("a0dcbb34-cb71-4729-a867-db7a8066008b"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("c5c89c0e-76d7-4319-b2e4-628533b717c7"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("ea2ca70b-1c70-4cf4-9b0a-890b2089065e"));

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Places");

            //migrationBuilder.InsertData(
            //    table: "Categories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("0866e9b8-e9f2-47bc-b89a-91e6b344cb96"), "Fast Food" },
            //        { new Guid("616b185e-f85f-4cce-9cf7-d7c48292cd61"), "Bistro" },
            //        { new Guid("7839c3c9-4dd8-412c-ac08-cd705563a165"), "Restaurant" },
            //        { new Guid("929c1910-0aab-417e-aa11-14bc567d1896"), "Cafe" },
            //        { new Guid("9a8cd056-b1bf-428e-863c-62249403c63b"), "Bar & Dinner" },
            //        { new Guid("ca02c771-9810-455d-b5c2-3d0ae14a0ab8"), "Bakery" }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0866e9b8-e9f2-47bc-b89a-91e6b344cb96"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("616b185e-f85f-4cce-9cf7-d7c48292cd61"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7839c3c9-4dd8-412c-ac08-cd705563a165"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("929c1910-0aab-417e-aa11-14bc567d1896"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9a8cd056-b1bf-428e-863c-62249403c63b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ca02c771-9810-455d-b5c2-3d0ae14a0ab8"));

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Places",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "The Rating of the Place.");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4946e8b1-2794-4269-9850-91c9f28851ae"), "Bakery" },
                    { new Guid("6feadeb8-e045-4f00-882f-fedae1309493"), "Cafe" },
                    { new Guid("92d91be7-0c45-47db-acd7-030f1b5a92fb"), "Fast Food" },
                    { new Guid("a0dcbb34-cb71-4729-a867-db7a8066008b"), "Bistro" },
                    { new Guid("c5c89c0e-76d7-4319-b2e4-628533b717c7"), "Restaurant" },
                    { new Guid("ea2ca70b-1c70-4cf4-9b0a-890b2089065e"), "Bar & Dinner" }
                });
        }
    }
}
