using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatingDatabaseMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("10106632-2f0f-4ec7-b29b-9521d9cba9f1"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("3d0b20a2-049d-46af-a897-de3dbba7809b"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("81d62dce-5922-4866-b7cc-4c4d5854ebe8"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("8903e714-a848-4c64-ac4b-658461b38544"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("d958082f-243e-4e33-b45f-262d6c295df1"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("dfb75771-7184-44f5-b9a7-e9214f8af213"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("4e2454ca-ae06-4b53-a4a2-c28ebc5e1566"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("51d0135b-a1b3-46f7-8d76-2ee5fa7fcbe3"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("69acc24f-9355-4f6e-b4eb-5caab28d8544"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("886a7994-0958-4bda-aa78-4f0f7593ad9b"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("a9242618-d16e-4594-9c84-0da89deadcd9"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("cdd393d7-4602-4364-ad02-948a239708b1"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("e8ecd154-5021-4b45-8580-7560e9e80b1f"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f83747f7-9359-4699-b1b4-0a9ee1d04f23"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("00228338-6981-4005-b0ad-33ba661f8670"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("0f0a6e0f-a98a-448c-9cdd-fef143a62b09"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("2e86bac3-2114-47dd-bab8-e230c17a9486"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("306e8753-1ba0-43d0-bb71-71d6eee7d65c"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("b7c8991f-d102-48f7-bd45-b85038df09e0"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("d111a9ef-fae6-474b-b7d1-7035ef98ac4c"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("ec56ebc3-1d69-4f78-929a-c1b935bc0474"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesDificulties",
            //    keyColumn: "Id",
            //    keyValue: 1);

            //migrationBuilder.DeleteData(
            //    table: "RecepiesDificulties",
            //    keyColumn: "Id",
            //    keyValue: 2);

            //migrationBuilder.DeleteData(
            //    table: "RecepiesDificulties",
            //    keyColumn: "Id",
            //    keyValue: 3);

            //migrationBuilder.DeleteData(
            //    table: "RecepiesDificulties",
            //    keyColumn: "Id",
            //    keyValue: 4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 28, 11, 52, 23, 497, DateTimeKind.Local).AddTicks(4139),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 28, 11, 24, 57, 902, DateTimeKind.Local).AddTicks(8497),
                oldComment: "Date of creation of the User.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 28, 11, 24, 57, 902, DateTimeKind.Local).AddTicks(8497),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 28, 11, 52, 23, 497, DateTimeKind.Local).AddTicks(4139),
                oldComment: "Date of creation of the User.");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("10106632-2f0f-4ec7-b29b-9521d9cba9f1"), "Restaurant" },
                    { new Guid("3d0b20a2-049d-46af-a897-de3dbba7809b"), "Cafe" },
                    { new Guid("81d62dce-5922-4866-b7cc-4c4d5854ebe8"), "Bistro" },
                    { new Guid("8903e714-a848-4c64-ac4b-658461b38544"), "Fast Food" },
                    { new Guid("d958082f-243e-4e33-b45f-262d6c295df1"), "Bar & Dinner" },
                    { new Guid("dfb75771-7184-44f5-b9a7-e9214f8af213"), "Bakery" }
                });

            migrationBuilder.InsertData(
                table: "Cuisines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4e2454ca-ae06-4b53-a4a2-c28ebc5e1566"), "French" },
                    { new Guid("51d0135b-a1b3-46f7-8d76-2ee5fa7fcbe3"), "Chinease" },
                    { new Guid("69acc24f-9355-4f6e-b4eb-5caab28d8544"), "Mexican" },
                    { new Guid("886a7994-0958-4bda-aa78-4f0f7593ad9b"), "Japanese" },
                    { new Guid("a9242618-d16e-4594-9c84-0da89deadcd9"), "Only drinks" },
                    { new Guid("cdd393d7-4602-4364-ad02-948a239708b1"), "Bulgarian" },
                    { new Guid("e8ecd154-5021-4b45-8580-7560e9e80b1f"), "Italian" },
                    { new Guid("f83747f7-9359-4699-b1b4-0a9ee1d04f23"), "Mediteranean" }
                });

            migrationBuilder.InsertData(
                table: "RecepiesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00228338-6981-4005-b0ad-33ba661f8670"), "Starter" },
                    { new Guid("0f0a6e0f-a98a-448c-9cdd-fef143a62b09"), "Dessert" },
                    { new Guid("2e86bac3-2114-47dd-bab8-e230c17a9486"), "Snack" },
                    { new Guid("306e8753-1ba0-43d0-bb71-71d6eee7d65c"), "Lunch" },
                    { new Guid("b7c8991f-d102-48f7-bd45-b85038df09e0"), "Side dish" },
                    { new Guid("d111a9ef-fae6-474b-b7d1-7035ef98ac4c"), "Breakfast" },
                    { new Guid("ec56ebc3-1d69-4f78-929a-c1b935bc0474"), "Dinner" }
                });

            migrationBuilder.InsertData(
                table: "RecepiesDificulties",
                columns: new[] { "Id", "DificultyName" },
                values: new object[,]
                {
                    { 1, "Easy" },
                    { 2, "Medium" },
                    { 3, "Hard" },
                    { 4, "Expert" }
                });
        }
    }
}
