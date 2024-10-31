using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingCountryToPlace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("6d25b351-7673-4bbb-b19d-28c1c598256b"), "Fast Food" },
                    { new Guid("9a57877e-7066-4107-802c-d82604d51257"), "Cafe" },
                    { new Guid("a71ed52b-20c0-49ba-9dde-3078f439096b"), "Bakery" },
                    { new Guid("b165837b-b714-468f-abd7-7c7c127efec4"), "Bar & Dinner" },
                    { new Guid("cd97169f-1a58-43bb-94d4-545b916b26e2"), "Bistro" },
                    { new Guid("dce529cd-6539-4581-ba9e-87a7836a34ad"), "Restaurant" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Countries_CityId",
                table: "Places",
                column: "CityId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Countries_CityId",
                table: "Places");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6d25b351-7673-4bbb-b19d-28c1c598256b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9a57877e-7066-4107-802c-d82604d51257"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a71ed52b-20c0-49ba-9dde-3078f439096b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b165837b-b714-468f-abd7-7c7c127efec4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cd97169f-1a58-43bb-94d4-545b916b26e2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dce529cd-6539-4581-ba9e-87a7836a34ad"));

            migrationBuilder.DropColumn(
                name: "ConutryId",
                table: "Places");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0866e9b8-e9f2-47bc-b89a-91e6b344cb96"), "Fast Food" },
                    { new Guid("616b185e-f85f-4cce-9cf7-d7c48292cd61"), "Bistro" },
                    { new Guid("7839c3c9-4dd8-412c-ac08-cd705563a165"), "Restaurant" },
                    { new Guid("929c1910-0aab-417e-aa11-14bc567d1896"), "Cafe" },
                    { new Guid("9a8cd056-b1bf-428e-863c-62249403c63b"), "Bar & Dinner" },
                    { new Guid("ca02c771-9810-455d-b5c2-3d0ae14a0ab8"), "Bakery" }
                });
        }
    }
}
