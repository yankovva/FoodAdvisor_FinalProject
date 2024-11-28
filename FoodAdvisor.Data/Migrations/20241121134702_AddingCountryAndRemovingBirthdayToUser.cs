using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingCountryAndRemovingBirthdayToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("3a5bf7fc-46ed-4422-b796-a59723e02f41"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("82cc1297-067d-47b8-9b24-94c6e053f47f"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("ad356863-8d68-4547-9e32-520cdb70f4df"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("b045704e-c2b8-454d-9c99-685ac433987e"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("cf25751a-2b2a-48c3-b843-2b3b4dc52713"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("d7865ada-356f-4013-acac-d2629ba435b5"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("0eff72cd-31b0-41a2-b42c-6eef76cfbe2d"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("23c043ee-4782-4f62-b539-55a4176e9cc4"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("287ae511-4280-451e-b606-f1d4894fc218"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("4c253d56-75fc-4963-a5c0-d4c66f05cf1b"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("74725d8e-47c4-40f1-a6af-2c361607dfec"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("b8da3c2e-ef2a-484c-a29e-16c9877ef41f"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("c91cfc5d-0fbf-401b-aa27-16e4367ab33a"));

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Last name of the User.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Last name of the User.");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "First name of the User.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "First name of the User.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 21, 15, 46, 59, 988, DateTimeKind.Local).AddTicks(5339),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 20, 17, 13, 11, 532, DateTimeKind.Local).AddTicks(3406),
                oldComment: "Date of creation of the User.");

            migrationBuilder.AlterColumn<string>(
                name: "AboutMe",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "Short descripton of the User.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Short descripton of the User.");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(56)",
                maxLength: 56,
                nullable: false,
                defaultValue: "",
                comment: "User Country");

            //migrationBuilder.InsertData(
            //    table: "Categories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("0c1aac07-e079-4ada-aceb-9c74c70682cb"), "Bar & Dinner" },
            //        { new Guid("3353b187-6153-4a42-8560-102225bded63"), "Bakery" },
            //        { new Guid("655b5b2a-428d-478d-a13e-e0bf4f02bf57"), "Fast Food" },
            //        { new Guid("73c3f87d-f760-45ac-9b8c-3006a0cb6987"), "Restaurant" },
            //        { new Guid("8e62f64e-d020-4e9e-98b2-da7a4c2b69bc"), "Cafe" },
            //        { new Guid("ea76da0b-6948-4f28-9343-94a5188838d4"), "Bistro" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "RecepiesCategories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("15ec9feb-cbc6-41f3-9260-f13055cc8d29"), "Dessert" },
            //        { new Guid("3f279511-14b1-48a5-b2be-f2c6adc25713"), "Snack" },
            //        { new Guid("4634d8e0-500a-4a3a-abba-6ccb0c3c4904"), "Breakfast" },
            //        { new Guid("62e0ad96-b913-4f95-9b02-284f451d54d6"), "Side dish" },
            //        { new Guid("ba36675f-809c-4611-870e-c87ed9236dda"), "Lunch" },
            //        { new Guid("babd586c-1207-4b6c-9bab-c2687d4f36d3"), "Dinner" },
            //        { new Guid("ccfa101a-8b84-4efd-96ed-309701672836"), "Starter" }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0c1aac07-e079-4ada-aceb-9c74c70682cb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3353b187-6153-4a42-8560-102225bded63"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("655b5b2a-428d-478d-a13e-e0bf4f02bf57"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("73c3f87d-f760-45ac-9b8c-3006a0cb6987"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8e62f64e-d020-4e9e-98b2-da7a4c2b69bc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ea76da0b-6948-4f28-9343-94a5188838d4"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("15ec9feb-cbc6-41f3-9260-f13055cc8d29"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("3f279511-14b1-48a5-b2be-f2c6adc25713"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("4634d8e0-500a-4a3a-abba-6ccb0c3c4904"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("62e0ad96-b913-4f95-9b02-284f451d54d6"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("ba36675f-809c-4611-870e-c87ed9236dda"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("babd586c-1207-4b6c-9bab-c2687d4f36d3"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("ccfa101a-8b84-4efd-96ed-309701672836"));

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Last name of the User.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Last name of the User.");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "First name of the User.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "First name of the User.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 20, 17, 13, 11, 532, DateTimeKind.Local).AddTicks(3406),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 21, 15, 46, 59, 988, DateTimeKind.Local).AddTicks(5339),
                oldComment: "Date of creation of the User.");

            migrationBuilder.AlterColumn<string>(
                name: "AboutMe",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Short descripton of the User.",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true,
                oldComment: "Short descripton of the User.");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                comment: "Birthday of the User.");

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
        }
    }
}
