using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakingCountryNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePricturePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "/assets/img/no-image-account.jfif",
                comment: "Path for the Profile picture of the User.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "/assets/img/no-image-account.jfif",
                oldComment: "Path for the Profile picture of the User.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 21, 15, 53, 47, 566, DateTimeKind.Local).AddTicks(4345),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 21, 15, 46, 59, 988, DateTimeKind.Local).AddTicks(5339),
                oldComment: "Date of creation of the User.");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(56)",
                maxLength: 56,
                nullable: true,
                comment: "User Country",
                oldClrType: typeof(string),
                oldType: "nvarchar(56)",
                oldMaxLength: 56,
                oldComment: "User Country");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("157fb428-9f1d-49fd-9cbf-554082a30e81"), "Bistro" },
                    { new Guid("25585781-10a8-4992-a90a-ec5a49e54308"), "Fast Food" },
                    { new Guid("72372d8f-ff63-4dce-aa9e-4ca3b3379fc1"), "Cafe" },
                    { new Guid("725fe8d4-461d-4e21-a68e-f8bfcdad64f1"), "Bar & Dinner" },
                    { new Guid("8c34688f-4466-4362-b3b2-a519956de9a7"), "Bakery" },
                    { new Guid("aeb92030-45eb-4349-b021-52500b8bb2e9"), "Restaurant" }
                });

            migrationBuilder.InsertData(
                table: "RecepiesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("117b209d-a1b0-49f2-b000-33df41b40d0f"), "Breakfast" },
                    { new Guid("40840926-40a1-4f72-b29e-9b86965b5544"), "Side dish" },
                    { new Guid("4578f1d1-aa40-40af-9b10-35c35e2435a7"), "Dinner" },
                    { new Guid("62348333-d500-443d-b888-433cb3ecdd6a"), "Snack" },
                    { new Guid("7b8bd343-a481-4756-bc97-3c3b67ff2063"), "Starter" },
                    { new Guid("ba1ee526-a12a-4c60-80c0-5c74914cff51"), "Dessert" },
                    { new Guid("c0d17a4d-14da-416a-9936-7891bdb36346"), "Lunch" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("157fb428-9f1d-49fd-9cbf-554082a30e81"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("25585781-10a8-4992-a90a-ec5a49e54308"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("72372d8f-ff63-4dce-aa9e-4ca3b3379fc1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("725fe8d4-461d-4e21-a68e-f8bfcdad64f1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8c34688f-4466-4362-b3b2-a519956de9a7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aeb92030-45eb-4349-b021-52500b8bb2e9"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("117b209d-a1b0-49f2-b000-33df41b40d0f"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("40840926-40a1-4f72-b29e-9b86965b5544"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("4578f1d1-aa40-40af-9b10-35c35e2435a7"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("62348333-d500-443d-b888-433cb3ecdd6a"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("7b8bd343-a481-4756-bc97-3c3b67ff2063"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("ba1ee526-a12a-4c60-80c0-5c74914cff51"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("c0d17a4d-14da-416a-9936-7891bdb36346"));

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePricturePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "/assets/img/no-image-account.jfif",
                comment: "Path for the Profile picture of the User.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "/assets/img/no-image-account.jfif",
                oldComment: "Path for the Profile picture of the User.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 21, 15, 46, 59, 988, DateTimeKind.Local).AddTicks(5339),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 21, 15, 53, 47, 566, DateTimeKind.Local).AddTicks(4345),
                oldComment: "Date of creation of the User.");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(56)",
                maxLength: 56,
                nullable: false,
                defaultValue: "",
                comment: "User Country",
                oldClrType: typeof(string),
                oldType: "nvarchar(56)",
                oldMaxLength: 56,
                oldNullable: true,
                oldComment: "User Country");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0c1aac07-e079-4ada-aceb-9c74c70682cb"), "Bar & Dinner" },
                    { new Guid("3353b187-6153-4a42-8560-102225bded63"), "Bakery" },
                    { new Guid("655b5b2a-428d-478d-a13e-e0bf4f02bf57"), "Fast Food" },
                    { new Guid("73c3f87d-f760-45ac-9b8c-3006a0cb6987"), "Restaurant" },
                    { new Guid("8e62f64e-d020-4e9e-98b2-da7a4c2b69bc"), "Cafe" },
                    { new Guid("ea76da0b-6948-4f28-9343-94a5188838d4"), "Bistro" }
                });

            migrationBuilder.InsertData(
                table: "RecepiesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("15ec9feb-cbc6-41f3-9260-f13055cc8d29"), "Dessert" },
                    { new Guid("3f279511-14b1-48a5-b2be-f2c6adc25713"), "Snack" },
                    { new Guid("4634d8e0-500a-4a3a-abba-6ccb0c3c4904"), "Breakfast" },
                    { new Guid("62e0ad96-b913-4f95-9b02-284f451d54d6"), "Side dish" },
                    { new Guid("ba36675f-809c-4611-870e-c87ed9236dda"), "Lunch" },
                    { new Guid("babd586c-1207-4b6c-9bab-c2687d4f36d3"), "Dinner" },
                    { new Guid("ccfa101a-8b84-4efd-96ed-309701672836"), "Starter" }
                });
        }
    }
}
