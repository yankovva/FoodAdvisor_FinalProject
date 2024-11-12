using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingNewPropertiesToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("123d169c-e243-4012-b666-faef5fee8439"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2556275d-5e84-429b-99f4-081b2ed9b8f6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("39d92e48-7523-4a78-84e7-2736c32b4f7a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("587a7e3a-9c10-4925-a584-dce38c85c0e6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("62594d86-d80a-4677-a086-bf9199ba41c5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b8e6e8f6-afc6-4c62-b918-7994133cc0cc"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("235d232e-a059-4814-a1a9-db416005d93e"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("268f35e2-b833-4bd9-b177-9bc39453f926"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("294750b8-5c20-4223-8d18-d0412a87fbc9"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("3f817a5f-40a4-41bd-a252-3191ffb4a2c7"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("a8f16f5e-b4bf-4c65-96ef-c0651e9d3561"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("abfbaba2-21ad-4dae-a3af-4c255d79d876"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("f5837b63-74bf-4c4c-8ca5-3b3383e6327c"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 12, 14, 14, 5, 238, DateTimeKind.Local).AddTicks(5791));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePricture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2bcb63bc-2474-47f1-936e-201c94681936"), "Cafe" },
                    { new Guid("38b93f20-86da-4bb3-9160-7d0d4aaa6ab1"), "Fast Food" },
                    { new Guid("4b1c0eaf-e4a7-4bc1-a73a-ce25652d0aa2"), "Bistro" },
                    { new Guid("62c9175d-f0e6-46df-aa7d-0b701c9275ce"), "Bar & Dinner" },
                    { new Guid("b2581625-8c45-4aed-a1c7-06b78ebb0dd6"), "Bakery" },
                    { new Guid("c7cb3ea5-6076-4083-9eb2-ea0ad569a4f5"), "Restaurant" }
                });

            migrationBuilder.InsertData(
                table: "RecepiesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("237e112a-0af5-4aeb-8c6f-4dc8a862e8aa"), "Lunch" },
                    { new Guid("239a540a-8d22-4fde-b5d1-db3199732c5b"), "Starter" },
                    { new Guid("48771705-8879-452a-8af6-9978f7f01c9f"), "Breakfast" },
                    { new Guid("628754ec-6cac-4331-8567-a3424169f559"), "Dessert" },
                    { new Guid("690ff0ec-8180-4669-ba0a-2639ac3ba3fb"), "Snack" },
                    { new Guid("9700bde0-14ff-406f-a0fc-bff698ce50c3"), "Side dish" },
                    { new Guid("db7fe669-8cbb-41fe-801c-66f548e39320"), "Dinner" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2bcb63bc-2474-47f1-936e-201c94681936"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("38b93f20-86da-4bb3-9160-7d0d4aaa6ab1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4b1c0eaf-e4a7-4bc1-a73a-ce25652d0aa2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("62c9175d-f0e6-46df-aa7d-0b701c9275ce"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b2581625-8c45-4aed-a1c7-06b78ebb0dd6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c7cb3ea5-6076-4083-9eb2-ea0ad569a4f5"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("237e112a-0af5-4aeb-8c6f-4dc8a862e8aa"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("239a540a-8d22-4fde-b5d1-db3199732c5b"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("48771705-8879-452a-8af6-9978f7f01c9f"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("628754ec-6cac-4331-8567-a3424169f559"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("690ff0ec-8180-4669-ba0a-2639ac3ba3fb"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("9700bde0-14ff-406f-a0fc-bff698ce50c3"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("db7fe669-8cbb-41fe-801c-66f548e39320"));

            migrationBuilder.DropColumn(
                name: "Createdon",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePricture",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("123d169c-e243-4012-b666-faef5fee8439"), "Fast Food" },
                    { new Guid("2556275d-5e84-429b-99f4-081b2ed9b8f6"), "Bistro" },
                    { new Guid("39d92e48-7523-4a78-84e7-2736c32b4f7a"), "Cafe" },
                    { new Guid("587a7e3a-9c10-4925-a584-dce38c85c0e6"), "Bakery" },
                    { new Guid("62594d86-d80a-4677-a086-bf9199ba41c5"), "Bar & Dinner" },
                    { new Guid("b8e6e8f6-afc6-4c62-b918-7994133cc0cc"), "Restaurant" }
                });

            migrationBuilder.InsertData(
                table: "RecepiesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("235d232e-a059-4814-a1a9-db416005d93e"), "Lunch" },
                    { new Guid("268f35e2-b833-4bd9-b177-9bc39453f926"), "Starter" },
                    { new Guid("294750b8-5c20-4223-8d18-d0412a87fbc9"), "Side dish" },
                    { new Guid("3f817a5f-40a4-41bd-a252-3191ffb4a2c7"), "Breakfast" },
                    { new Guid("a8f16f5e-b4bf-4c65-96ef-c0651e9d3561"), "Dessert" },
                    { new Guid("abfbaba2-21ad-4dae-a3af-4c255d79d876"), "Dinner" },
                    { new Guid("f5837b63-74bf-4c4c-8ca5-3b3383e6327c"), "Snack" }
                });
        }
    }
}
