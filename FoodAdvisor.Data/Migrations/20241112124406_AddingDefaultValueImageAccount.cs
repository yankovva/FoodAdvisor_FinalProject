using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingDefaultValueImageAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("070cafab-b66f-4e07-98f8-a801b673b073"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("08f5b1f0-4648-4b78-8859-7f8832ac06e2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("148183fd-c46f-4fa9-b639-1e98048de1e4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("acbabe28-5a87-496a-b89d-0181df7832ab"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ee76812b-71c8-4da5-8011-6b0e9be7ea9d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f4d24a5a-ef07-44a7-97df-bb468e9c29c2"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("2bd6f404-1b58-4279-b62b-102962e8c95f"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("3c23a033-9592-4835-b9db-4a186fd192fb"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("44c9775c-58e4-40a4-aa3e-cc47bb1a513f"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("5d4c539e-b75b-47ac-a83e-c3a39302661f"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("8a780959-1b3c-4fd3-8fe6-656c1b7c5c07"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("b4fc6c1c-365e-4500-b86c-d985403e8564"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("d7cb51df-adcd-42f9-8656-71f1d10ba0c5"));

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePricture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "/assets/img/no-image-account.jfif",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 12, 14, 44, 3, 160, DateTimeKind.Local).AddTicks(6861),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 12, 14, 17, 45, 650, DateTimeKind.Local).AddTicks(3398));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0fe09dbe-da31-4866-81e1-8a003e697526"), "Restaurant" },
                    { new Guid("4c8eef3e-2c48-4d72-8d10-f455bd9cede3"), "Bakery" },
                    { new Guid("60dfb753-e592-4c15-ae16-6e3893103535"), "Bar & Dinner" },
                    { new Guid("d17b9250-cc16-4379-905f-83a7a205d89a"), "Fast Food" },
                    { new Guid("e0e77684-07a6-41ca-931e-53ec26cfc1a8"), "Bistro" },
                    { new Guid("efa6b877-fc0a-41e9-9074-8ff440bfe535"), "Cafe" }
                });

            migrationBuilder.InsertData(
                table: "RecepiesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("388fc9f4-97d4-4f98-b783-fb8d4a82d27b"), "Starter" },
                    { new Guid("3aac5bbf-f974-4379-9c6f-06a8ad3af0df"), "Lunch" },
                    { new Guid("4af2afd1-45ad-480a-acfc-411edda055bf"), "Dessert" },
                    { new Guid("cc0f5a71-e6c4-466a-a19b-79761de400cb"), "Snack" },
                    { new Guid("e9d02fe4-c0ae-468b-90f4-d0476a37d4e9"), "Dinner" },
                    { new Guid("f0a25165-a0db-4665-89c3-dd8f0003bc4c"), "Side dish" },
                    { new Guid("faccfcd7-3928-4bfb-86a6-064e5637d7fa"), "Breakfast" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0fe09dbe-da31-4866-81e1-8a003e697526"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4c8eef3e-2c48-4d72-8d10-f455bd9cede3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("60dfb753-e592-4c15-ae16-6e3893103535"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d17b9250-cc16-4379-905f-83a7a205d89a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e0e77684-07a6-41ca-931e-53ec26cfc1a8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("efa6b877-fc0a-41e9-9074-8ff440bfe535"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("388fc9f4-97d4-4f98-b783-fb8d4a82d27b"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("3aac5bbf-f974-4379-9c6f-06a8ad3af0df"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("4af2afd1-45ad-480a-acfc-411edda055bf"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("cc0f5a71-e6c4-466a-a19b-79761de400cb"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("e9d02fe4-c0ae-468b-90f4-d0476a37d4e9"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("f0a25165-a0db-4665-89c3-dd8f0003bc4c"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("faccfcd7-3928-4bfb-86a6-064e5637d7fa"));

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePricture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "/assets/img/no-image-account.jfif");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 12, 14, 17, 45, 650, DateTimeKind.Local).AddTicks(3398),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 12, 14, 44, 3, 160, DateTimeKind.Local).AddTicks(6861));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("070cafab-b66f-4e07-98f8-a801b673b073"), "Restaurant" },
                    { new Guid("08f5b1f0-4648-4b78-8859-7f8832ac06e2"), "Bistro" },
                    { new Guid("148183fd-c46f-4fa9-b639-1e98048de1e4"), "Bar & Dinner" },
                    { new Guid("acbabe28-5a87-496a-b89d-0181df7832ab"), "Cafe" },
                    { new Guid("ee76812b-71c8-4da5-8011-6b0e9be7ea9d"), "Bakery" },
                    { new Guid("f4d24a5a-ef07-44a7-97df-bb468e9c29c2"), "Fast Food" }
                });

            migrationBuilder.InsertData(
                table: "RecepiesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2bd6f404-1b58-4279-b62b-102962e8c95f"), "Lunch" },
                    { new Guid("3c23a033-9592-4835-b9db-4a186fd192fb"), "Dessert" },
                    { new Guid("44c9775c-58e4-40a4-aa3e-cc47bb1a513f"), "Breakfast" },
                    { new Guid("5d4c539e-b75b-47ac-a83e-c3a39302661f"), "Side dish" },
                    { new Guid("8a780959-1b3c-4fd3-8fe6-656c1b7c5c07"), "Dinner" },
                    { new Guid("b4fc6c1c-365e-4500-b86c-d985403e8564"), "Starter" },
                    { new Guid("d7cb51df-adcd-42f9-8656-71f1d10ba0c5"), "Snack" }
                });
        }
    }
}
