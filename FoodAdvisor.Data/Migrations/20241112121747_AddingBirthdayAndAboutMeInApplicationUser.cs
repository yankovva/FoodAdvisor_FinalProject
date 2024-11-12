using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingBirthdayAndAboutMeInApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 12, 14, 17, 45, 650, DateTimeKind.Local).AddTicks(3398),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 12, 14, 14, 5, 238, DateTimeKind.Local).AddTicks(5791));

            migrationBuilder.AddColumn<string>(
                name: "AboutMe",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "AboutMe",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 12, 14, 14, 5, 238, DateTimeKind.Local).AddTicks(5791),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 12, 14, 17, 45, 650, DateTimeKind.Local).AddTicks(3398));

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
    }
}
