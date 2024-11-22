using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakingUplodaingImagesNonNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "An Image Path of the Restaurant.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "An Image Path of the Restaurant.");

            migrationBuilder.AlterColumn<string>(
                name: "ChefsSpecialImage",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "An Image Path of the Chefs special dish of the  Restaurant.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "An Image Path of the Chefs special dish of the  Restaurant.");

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Recepies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2083)",
                oldMaxLength: 2083,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 22, 14, 54, 4, 694, DateTimeKind.Local).AddTicks(7233),
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
                    { new Guid("1106ab37-264e-4b39-8a15-4eaef9d22948"), "Restaurant" },
                    { new Guid("24ee65ee-8267-48a9-b2ff-419e320045fc"), "Bar & Dinner" },
                    { new Guid("300ab2f8-86dc-40ec-a853-785a7424d291"), "Cafe" },
                    { new Guid("babb3713-13a1-46c2-a677-5b58ac0959c1"), "Bistro" },
                    { new Guid("e8b65baf-9871-4781-bf3e-dcf9388d2d89"), "Bakery" },
                    { new Guid("fb4fa57b-9a21-4c5c-a95f-a83aeb736c24"), "Fast Food" }
                });

            migrationBuilder.InsertData(
                table: "RecepiesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1727c611-8413-46f8-8edd-e18af9b0eee4"), "Dessert" },
                    { new Guid("2de7d11a-514b-496d-acb9-4c2628cc88bf"), "Lunch" },
                    { new Guid("787d7046-6f17-468c-8006-c7cf7b4bfcc0"), "Dinner" },
                    { new Guid("8007d0d0-20fe-443a-b2e8-736751044fbf"), "Breakfast" },
                    { new Guid("ae70a0ee-f99f-41fd-8cbf-ea8161c1e1a2"), "Side dish" },
                    { new Guid("b0ade557-602d-4be4-8440-3dd4078e7e37"), "Snack" },
                    { new Guid("f56357ac-b0a2-4761-9fd8-70b4effd7e9d"), "Starter" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1106ab37-264e-4b39-8a15-4eaef9d22948"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("24ee65ee-8267-48a9-b2ff-419e320045fc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("300ab2f8-86dc-40ec-a853-785a7424d291"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("babb3713-13a1-46c2-a677-5b58ac0959c1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e8b65baf-9871-4781-bf3e-dcf9388d2d89"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fb4fa57b-9a21-4c5c-a95f-a83aeb736c24"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("1727c611-8413-46f8-8edd-e18af9b0eee4"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("2de7d11a-514b-496d-acb9-4c2628cc88bf"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("787d7046-6f17-468c-8006-c7cf7b4bfcc0"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("8007d0d0-20fe-443a-b2e8-736751044fbf"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("ae70a0ee-f99f-41fd-8cbf-ea8161c1e1a2"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("b0ade557-602d-4be4-8440-3dd4078e7e37"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("f56357ac-b0a2-4761-9fd8-70b4effd7e9d"));

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true,
                comment: "An Image Path of the Restaurant.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "An Image Path of the Restaurant.");

            migrationBuilder.AlterColumn<string>(
                name: "ChefsSpecialImage",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true,
                comment: "An Image Path of the Chefs special dish of the  Restaurant.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "An Image Path of the Chefs special dish of the  Restaurant.");

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Recepies",
                type: "nvarchar(2083)",
                maxLength: 2083,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 22, 14, 50, 8, 435, DateTimeKind.Local).AddTicks(684),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 22, 14, 54, 4, 694, DateTimeKind.Local).AddTicks(7233),
                oldComment: "Date of creation of the User.");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("142e2129-8542-4b09-8336-56e6fe2a61f6"), "Bar & Dinner" },
                    { new Guid("6147b19b-5e6a-42e8-9850-ba151d4c3df8"), "Restaurant" },
                    { new Guid("b2852bcb-acb9-4354-a805-05ece8cb9ad1"), "Fast Food" },
                    { new Guid("c21d9e5c-5a3d-440e-ba44-702d93251121"), "Cafe" },
                    { new Guid("df58c59e-20eb-44e9-a242-eb26afead207"), "Bakery" },
                    { new Guid("f5d626e8-b6f4-45f3-a99c-190d49d67caf"), "Bistro" }
                });

            migrationBuilder.InsertData(
                table: "RecepiesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("33241044-63b4-4bfc-b221-96f89803de48"), "Dinner" },
                    { new Guid("47a60f2c-b432-4621-b4b0-47ca61967c92"), "Starter" },
                    { new Guid("6e98ad6a-c161-465f-8db1-98112553ea9b"), "Dessert" },
                    { new Guid("7c77d9dc-a92a-48b4-9ae3-32a5c3074e8e"), "Side dish" },
                    { new Guid("a45c8c5f-283a-47b7-a8e4-43f80a1928e4"), "Breakfast" },
                    { new Guid("cdd38766-828f-41f4-a3f9-b95ae3d65d7f"), "Snack" },
                    { new Guid("d6b020cd-0bcb-4eca-8eee-f3af8c61b08b"), "Lunch" }
                });
        }
    }
}
