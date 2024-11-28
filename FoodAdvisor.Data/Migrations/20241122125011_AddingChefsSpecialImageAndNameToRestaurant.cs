using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingChefsSpecialImageAndNameToRestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1913b6b8-db18-4279-998f-337157d2f85c"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1bd63956-cb1d-44f4-9cc7-bd131ca1fe20"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("25a0426a-3a14-49dc-8cb4-2bb849563b9a"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("df084d0a-3446-4926-9667-73e2b39c190c"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("eb6bedda-1322-4a65-980a-4eff58e7e908"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f7a0ef65-99cf-4e4e-8d17-70e49cd05eb1"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("0b86fcb2-7707-4d24-b3cb-bf9a3867c6cc"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("29c276cc-5376-44d9-85e8-03667fa5bffa"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("3d3de1a5-701c-4b68-9d73-f4f918921349"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("5fe57bfe-aa35-4b03-969c-4fb8f27d77d4"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("72ff81e8-7ff4-48b9-810f-570a72015f13"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("80849883-1b1d-497a-a117-d8b8aa08345f"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("a7b38d4d-bc94-4f32-8f74-53d37f07933b"));

            migrationBuilder.AlterColumn<string>(
                name: "MenuDescription",
                table: "Restaurants",
                type: "nvarchar(700)",
                maxLength: 700,
                nullable: false,
                comment: "The Menu Description of the Restaurant.",
                oldClrType: typeof(string),
                oldType: "nvarchar(700)",
                oldMaxLength: 700,
                oldComment: "The Description of the Restaurant.");

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true,
                comment: "An Image Path of the Restaurant.",
                oldClrType: typeof(string),
                oldType: "nvarchar(2083)",
                oldMaxLength: 2083,
                oldNullable: true,
                oldComment: "An Image Url of the Restaurant.");

            migrationBuilder.AlterColumn<string>(
                name: "AtmosphereDescription",
                table: "Restaurants",
                type: "nvarchar(700)",
                maxLength: 700,
                nullable: false,
                comment: "The Atmosphere Description of the Restaurant.",
                oldClrType: typeof(string),
                oldType: "nvarchar(700)",
                oldMaxLength: 700,
                oldComment: "The Description of the Restaurant.");

            migrationBuilder.AddColumn<string>(
                name: "ChefsSpecial",
                table: "Restaurants",
                type: "nvarchar(700)",
                maxLength: 700,
                nullable: false,
                defaultValue: "",
                comment: "The Chefs special dish of the Restaurant.");

            migrationBuilder.AddColumn<string>(
                name: "ChefsSpecialImage",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true,
                comment: "An Image Path of the Chefs special dish of the  Restaurant.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 22, 14, 50, 8, 435, DateTimeKind.Local).AddTicks(684),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 22, 14, 38, 32, 709, DateTimeKind.Local).AddTicks(2159),
                oldComment: "Date of creation of the User.");

            //migrationBuilder.InsertData(
            //    table: "Categories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("142e2129-8542-4b09-8336-56e6fe2a61f6"), "Bar & Dinner" },
            //        { new Guid("6147b19b-5e6a-42e8-9850-ba151d4c3df8"), "Restaurant" },
            //        { new Guid("b2852bcb-acb9-4354-a805-05ece8cb9ad1"), "Fast Food" },
            //        { new Guid("c21d9e5c-5a3d-440e-ba44-702d93251121"), "Cafe" },
            //        { new Guid("df58c59e-20eb-44e9-a242-eb26afead207"), "Bakery" },
            //        { new Guid("f5d626e8-b6f4-45f3-a99c-190d49d67caf"), "Bistro" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "RecepiesCategories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("33241044-63b4-4bfc-b221-96f89803de48"), "Dinner" },
            //        { new Guid("47a60f2c-b432-4621-b4b0-47ca61967c92"), "Starter" },
            //        { new Guid("6e98ad6a-c161-465f-8db1-98112553ea9b"), "Dessert" },
            //        { new Guid("7c77d9dc-a92a-48b4-9ae3-32a5c3074e8e"), "Side dish" },
            //        { new Guid("a45c8c5f-283a-47b7-a8e4-43f80a1928e4"), "Breakfast" },
            //        { new Guid("cdd38766-828f-41f4-a3f9-b95ae3d65d7f"), "Snack" },
            //        { new Guid("d6b020cd-0bcb-4eca-8eee-f3af8c61b08b"), "Lunch" }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("142e2129-8542-4b09-8336-56e6fe2a61f6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6147b19b-5e6a-42e8-9850-ba151d4c3df8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b2852bcb-acb9-4354-a805-05ece8cb9ad1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c21d9e5c-5a3d-440e-ba44-702d93251121"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("df58c59e-20eb-44e9-a242-eb26afead207"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f5d626e8-b6f4-45f3-a99c-190d49d67caf"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("33241044-63b4-4bfc-b221-96f89803de48"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("47a60f2c-b432-4621-b4b0-47ca61967c92"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("6e98ad6a-c161-465f-8db1-98112553ea9b"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("7c77d9dc-a92a-48b4-9ae3-32a5c3074e8e"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("a45c8c5f-283a-47b7-a8e4-43f80a1928e4"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("cdd38766-828f-41f4-a3f9-b95ae3d65d7f"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("d6b020cd-0bcb-4eca-8eee-f3af8c61b08b"));

            migrationBuilder.DropColumn(
                name: "ChefsSpecial",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "ChefsSpecialImage",
                table: "Restaurants");

            migrationBuilder.AlterColumn<string>(
                name: "MenuDescription",
                table: "Restaurants",
                type: "nvarchar(700)",
                maxLength: 700,
                nullable: false,
                comment: "The Description of the Restaurant.",
                oldClrType: typeof(string),
                oldType: "nvarchar(700)",
                oldMaxLength: 700,
                oldComment: "The Menu Description of the Restaurant.");

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Restaurants",
                type: "nvarchar(2083)",
                maxLength: 2083,
                nullable: true,
                comment: "An Image Url of the Restaurant.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "An Image Path of the Restaurant.");

            migrationBuilder.AlterColumn<string>(
                name: "AtmosphereDescription",
                table: "Restaurants",
                type: "nvarchar(700)",
                maxLength: 700,
                nullable: false,
                comment: "The Description of the Restaurant.",
                oldClrType: typeof(string),
                oldType: "nvarchar(700)",
                oldMaxLength: 700,
                oldComment: "The Atmosphere Description of the Restaurant.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 22, 14, 38, 32, 709, DateTimeKind.Local).AddTicks(2159),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 22, 14, 50, 8, 435, DateTimeKind.Local).AddTicks(684),
                oldComment: "Date of creation of the User.");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1913b6b8-db18-4279-998f-337157d2f85c"), "Fast Food" },
                    { new Guid("1bd63956-cb1d-44f4-9cc7-bd131ca1fe20"), "Cafe" },
                    { new Guid("25a0426a-3a14-49dc-8cb4-2bb849563b9a"), "Bistro" },
                    { new Guid("df084d0a-3446-4926-9667-73e2b39c190c"), "Restaurant" },
                    { new Guid("eb6bedda-1322-4a65-980a-4eff58e7e908"), "Bar & Dinner" },
                    { new Guid("f7a0ef65-99cf-4e4e-8d17-70e49cd05eb1"), "Bakery" }
                });

            migrationBuilder.InsertData(
                table: "RecepiesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0b86fcb2-7707-4d24-b3cb-bf9a3867c6cc"), "Side dish" },
                    { new Guid("29c276cc-5376-44d9-85e8-03667fa5bffa"), "Breakfast" },
                    { new Guid("3d3de1a5-701c-4b68-9d73-f4f918921349"), "Dessert" },
                    { new Guid("5fe57bfe-aa35-4b03-969c-4fb8f27d77d4"), "Starter" },
                    { new Guid("72ff81e8-7ff4-48b9-810f-570a72015f13"), "Snack" },
                    { new Guid("80849883-1b1d-497a-a117-d8b8aa08345f"), "Dinner" },
                    { new Guid("a7b38d4d-bc94-4f32-8f74-53d37f07933b"), "Lunch" }
                });
        }
    }
}
