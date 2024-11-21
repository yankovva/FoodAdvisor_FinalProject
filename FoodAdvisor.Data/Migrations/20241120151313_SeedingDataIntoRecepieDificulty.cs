using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataIntoRecepieDificulty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("43c7cd7f-d32c-452e-a932-78cc37cbdfcc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("73083fb7-455d-41b7-9c34-8fe87b92aa3f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7cc4a429-8997-4802-ba86-90d1c56ee771"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ad0e24a5-94e7-4a26-9ab9-36c1c5069cd1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f3cb1412-bc32-48a3-ac7e-2713120b103b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fecf9278-e9ed-449e-8f6e-9226a1ac7def"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("1c5356e9-42eb-448a-ae5a-b7ce030675cc"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("30fd10af-428a-424a-8a7e-89a4efe6ed75"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("82c03683-306f-44b8-b931-260c50da0932"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("b1e90944-8cbf-4041-8f93-eee9f74418c5"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("c18cf9b8-1aa4-4b9d-b625-be47e5d94b68"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("d0f083f1-1335-46f9-872c-c408edb4eb85"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("d6e411a3-33d7-4e81-b654-ae53602fe238"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 20, 17, 13, 11, 532, DateTimeKind.Local).AddTicks(3406),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 20, 17, 7, 0, 846, DateTimeKind.Local).AddTicks(5704),
                oldComment: "Date of creation of the User.");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3a5bf7fc-46ed-4422-b796-a59723e02f41"), "Restaurant" },
                    { new Guid("82cc1297-067d-47b8-9b24-94c6e053f47f"), "Bar & Dinner" },
                    { new Guid("ad356863-8d68-4547-9e32-520cdb70f4df"), "Bakery" },
                    { new Guid("b045704e-c2b8-454d-9c99-685ac433987e"), "Fast Food" },
                    { new Guid("cf25751a-2b2a-48c3-b843-2b3b4dc52713"), "Bistro" },
                    { new Guid("d7865ada-356f-4013-acac-d2629ba435b5"), "Cafe" }
                });

            migrationBuilder.InsertData(
                table: "RecepiesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0eff72cd-31b0-41a2-b42c-6eef76cfbe2d"), "Dinner" },
                    { new Guid("23c043ee-4782-4f62-b539-55a4176e9cc4"), "Breakfast" },
                    { new Guid("287ae511-4280-451e-b606-f1d4894fc218"), "Side dish" },
                    { new Guid("4c253d56-75fc-4963-a5c0-d4c66f05cf1b"), "Dessert" },
                    { new Guid("74725d8e-47c4-40f1-a6af-2c361607dfec"), "Lunch" },
                    { new Guid("b8da3c2e-ef2a-484c-a29e-16c9877ef41f"), "Starter" },
                    { new Guid("c91cfc5d-0fbf-401b-aa27-16e4367ab33a"), "Snack" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3a5bf7fc-46ed-4422-b796-a59723e02f41"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("82cc1297-067d-47b8-9b24-94c6e053f47f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ad356863-8d68-4547-9e32-520cdb70f4df"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b045704e-c2b8-454d-9c99-685ac433987e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cf25751a-2b2a-48c3-b843-2b3b4dc52713"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d7865ada-356f-4013-acac-d2629ba435b5"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("0eff72cd-31b0-41a2-b42c-6eef76cfbe2d"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("23c043ee-4782-4f62-b539-55a4176e9cc4"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("287ae511-4280-451e-b606-f1d4894fc218"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("4c253d56-75fc-4963-a5c0-d4c66f05cf1b"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("74725d8e-47c4-40f1-a6af-2c361607dfec"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("b8da3c2e-ef2a-484c-a29e-16c9877ef41f"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("c91cfc5d-0fbf-401b-aa27-16e4367ab33a"));

            migrationBuilder.DeleteData(
                table: "RecepiesDificulties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RecepiesDificulties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RecepiesDificulties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RecepiesDificulties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 20, 17, 7, 0, 846, DateTimeKind.Local).AddTicks(5704),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 20, 17, 13, 11, 532, DateTimeKind.Local).AddTicks(3406),
                oldComment: "Date of creation of the User.");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("43c7cd7f-d32c-452e-a932-78cc37cbdfcc"), "Bistro" },
                    { new Guid("73083fb7-455d-41b7-9c34-8fe87b92aa3f"), "Fast Food" },
                    { new Guid("7cc4a429-8997-4802-ba86-90d1c56ee771"), "Bar & Dinner" },
                    { new Guid("ad0e24a5-94e7-4a26-9ab9-36c1c5069cd1"), "Restaurant" },
                    { new Guid("f3cb1412-bc32-48a3-ac7e-2713120b103b"), "Cafe" },
                    { new Guid("fecf9278-e9ed-449e-8f6e-9226a1ac7def"), "Bakery" }
                });

            migrationBuilder.InsertData(
                table: "RecepiesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1c5356e9-42eb-448a-ae5a-b7ce030675cc"), "Lunch" },
                    { new Guid("30fd10af-428a-424a-8a7e-89a4efe6ed75"), "Breakfast" },
                    { new Guid("82c03683-306f-44b8-b931-260c50da0932"), "Snack" },
                    { new Guid("b1e90944-8cbf-4041-8f93-eee9f74418c5"), "Side dish" },
                    { new Guid("c18cf9b8-1aa4-4b9d-b625-be47e5d94b68"), "Dinner" },
                    { new Guid("d0f083f1-1335-46f9-872c-c408edb4eb85"), "Starter" },
                    { new Guid("d6e411a3-33d7-4e81-b654-ae53602fe238"), "Dessert" }
                });
        }
    }
}
