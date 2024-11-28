using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingMenuAndAtmoshepreDescriptionToRestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("157fb428-9f1d-49fd-9cbf-554082a30e81"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("25585781-10a8-4992-a90a-ec5a49e54308"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("72372d8f-ff63-4dce-aa9e-4ca3b3379fc1"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("725fe8d4-461d-4e21-a68e-f8bfcdad64f1"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("8c34688f-4466-4362-b3b2-a519956de9a7"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("aeb92030-45eb-4349-b021-52500b8bb2e9"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("117b209d-a1b0-49f2-b000-33df41b40d0f"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("40840926-40a1-4f72-b29e-9b86965b5544"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("4578f1d1-aa40-40af-9b10-35c35e2435a7"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("62348333-d500-443d-b888-433cb3ecdd6a"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("7b8bd343-a481-4756-bc97-3c3b67ff2063"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("ba1ee526-a12a-4c60-80c0-5c74914cff51"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("c0d17a4d-14da-416a-9936-7891bdb36346"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Restaurants",
                type: "nvarchar(700)",
                maxLength: 700,
                nullable: false,
                comment: "The Description of the Restaurant.",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldComment: "The Description of the Restaurant.");

            migrationBuilder.AddColumn<string>(
                name: "AtmosphereDescription",
                table: "Restaurants",
                type: "nvarchar(700)",
                maxLength: 700,
                nullable: false,
                defaultValue: "",
                comment: "The Description of the Restaurant.");

            migrationBuilder.AddColumn<string>(
                name: "MenuDescription",
                table: "Restaurants",
                type: "nvarchar(700)",
                maxLength: 700,
                nullable: false,
                defaultValue: "",
                comment: "The Description of the Restaurant.");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Recepies",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Name of the Recepie.",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "Name of the Recepie.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 22, 14, 38, 32, 709, DateTimeKind.Local).AddTicks(2159),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 21, 15, 53, 47, 566, DateTimeKind.Local).AddTicks(4345),
                oldComment: "Date of creation of the User.");

            //migrationBuilder.InsertData(
            //    table: "Categories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("1913b6b8-db18-4279-998f-337157d2f85c"), "Fast Food" },
            //        { new Guid("1bd63956-cb1d-44f4-9cc7-bd131ca1fe20"), "Cafe" },
            //        { new Guid("25a0426a-3a14-49dc-8cb4-2bb849563b9a"), "Bistro" },
            //        { new Guid("df084d0a-3446-4926-9667-73e2b39c190c"), "Restaurant" },
            //        { new Guid("eb6bedda-1322-4a65-980a-4eff58e7e908"), "Bar & Dinner" },
            //        { new Guid("f7a0ef65-99cf-4e4e-8d17-70e49cd05eb1"), "Bakery" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "RecepiesCategories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("0b86fcb2-7707-4d24-b3cb-bf9a3867c6cc"), "Side dish" },
            //        { new Guid("29c276cc-5376-44d9-85e8-03667fa5bffa"), "Breakfast" },
            //        { new Guid("3d3de1a5-701c-4b68-9d73-f4f918921349"), "Dessert" },
            //        { new Guid("5fe57bfe-aa35-4b03-969c-4fb8f27d77d4"), "Starter" },
            //        { new Guid("72ff81e8-7ff4-48b9-810f-570a72015f13"), "Snack" },
            //        { new Guid("80849883-1b1d-497a-a117-d8b8aa08345f"), "Dinner" },
            //        { new Guid("a7b38d4d-bc94-4f32-8f74-53d37f07933b"), "Lunch" }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1913b6b8-db18-4279-998f-337157d2f85c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1bd63956-cb1d-44f4-9cc7-bd131ca1fe20"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("25a0426a-3a14-49dc-8cb4-2bb849563b9a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("df084d0a-3446-4926-9667-73e2b39c190c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eb6bedda-1322-4a65-980a-4eff58e7e908"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f7a0ef65-99cf-4e4e-8d17-70e49cd05eb1"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("0b86fcb2-7707-4d24-b3cb-bf9a3867c6cc"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("29c276cc-5376-44d9-85e8-03667fa5bffa"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("3d3de1a5-701c-4b68-9d73-f4f918921349"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("5fe57bfe-aa35-4b03-969c-4fb8f27d77d4"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("72ff81e8-7ff4-48b9-810f-570a72015f13"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("80849883-1b1d-497a-a117-d8b8aa08345f"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("a7b38d4d-bc94-4f32-8f74-53d37f07933b"));

            migrationBuilder.DropColumn(
                name: "AtmosphereDescription",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "MenuDescription",
                table: "Restaurants");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Restaurants",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                comment: "The Description of the Restaurant.",
                oldClrType: typeof(string),
                oldType: "nvarchar(700)",
                oldMaxLength: 700,
                oldComment: "The Description of the Restaurant.");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Recepies",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "Name of the Recepie.",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Name of the Recepie.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 21, 15, 53, 47, 566, DateTimeKind.Local).AddTicks(4345),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 22, 14, 38, 32, 709, DateTimeKind.Local).AddTicks(2159),
                oldComment: "Date of creation of the User.");

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
    }
}
