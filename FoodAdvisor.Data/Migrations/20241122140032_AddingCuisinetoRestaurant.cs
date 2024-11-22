using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingCuisinetoRestaurant : Migration
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

            migrationBuilder.AddColumn<Guid>(
                name: "CuisineId",
                table: "Restaurants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "The Cuisine Id.");

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
                defaultValue: new DateTime(2024, 11, 22, 16, 0, 29, 869, DateTimeKind.Local).AddTicks(4214),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 22, 14, 50, 8, 435, DateTimeKind.Local).AddTicks(684),
                oldComment: "Date of creation of the User.");

            migrationBuilder.CreateTable(
                name: "Cuisines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "The name of the Cuisine type.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuisines", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("091ff470-c970-41ef-b368-b16b0aa4c959"), "Bistro" },
                    { new Guid("17b226b9-f4bc-4d8e-8b18-6bd9b2e7ab27"), "Bakery" },
                    { new Guid("45d8cb81-0ab7-45f2-8227-3255ec39a28c"), "Fast Food" },
                    { new Guid("75220d4b-0e83-4815-bec2-4b5778b8dc86"), "Bar & Dinner" },
                    { new Guid("bd7ca129-f37c-424a-85c2-8e0bc0858af1"), "Cafe" },
                    { new Guid("ee0a65df-54ac-4be5-ba3e-724348f8d76c"), "Restaurant" }
                });

            migrationBuilder.InsertData(
                table: "Cuisines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2a935cc1-6ecb-4515-890c-bd13f5c2d1a8"), "Mexican" },
                    { new Guid("364e6f4f-dcf4-49f0-a322-cbdba4758017"), "Japanese" },
                    { new Guid("48dbdc79-02e1-402e-86e1-725a81edabd2"), "Chinease" },
                    { new Guid("7baebda0-3bfe-48e3-8ea9-76defca6c512"), "Bulgarian" },
                    { new Guid("a5bb0368-f449-4a06-9fc4-8f45f951185f"), "Only drinks" },
                    { new Guid("c70e3310-90ea-49e8-b2eb-75825ad99612"), "Mediteranean" },
                    { new Guid("e1c21838-f415-42d3-8cdf-7ba6cbd2241e"), "Italian" },
                    { new Guid("ee8bab9e-9b45-4d76-a13e-13384b988078"), "French" }
                });

            migrationBuilder.InsertData(
                table: "RecepiesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4b6a29e6-81aa-4578-b5a9-d270cd25fdba"), "Side dish" },
                    { new Guid("5e1c73fd-fc63-4d88-9549-6aacf92e203c"), "Dinner" },
                    { new Guid("730a7a36-ac02-49e6-ba00-064c16def614"), "Snack" },
                    { new Guid("9338faa0-5dc7-4485-ae6d-73bf53a7e839"), "Starter" },
                    { new Guid("a01e44e4-a3c4-4c9a-aab1-0e0a0bc3728b"), "Breakfast" },
                    { new Guid("bbf31729-851f-46e4-a29b-5fb9f40bd589"), "Dessert" },
                    { new Guid("bf29ae9e-be81-4655-a829-0aab2bf7decf"), "Lunch" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CuisineId",
                table: "Restaurants",
                column: "CuisineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Cuisines_CuisineId",
                table: "Restaurants",
                column: "CuisineId",
                principalTable: "Cuisines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Cuisines_CuisineId",
                table: "Restaurants");

            migrationBuilder.DropTable(
                name: "Cuisines");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_CuisineId",
                table: "Restaurants");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("091ff470-c970-41ef-b368-b16b0aa4c959"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("17b226b9-f4bc-4d8e-8b18-6bd9b2e7ab27"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("45d8cb81-0ab7-45f2-8227-3255ec39a28c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("75220d4b-0e83-4815-bec2-4b5778b8dc86"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bd7ca129-f37c-424a-85c2-8e0bc0858af1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ee0a65df-54ac-4be5-ba3e-724348f8d76c"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("4b6a29e6-81aa-4578-b5a9-d270cd25fdba"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("5e1c73fd-fc63-4d88-9549-6aacf92e203c"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("730a7a36-ac02-49e6-ba00-064c16def614"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("9338faa0-5dc7-4485-ae6d-73bf53a7e839"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("a01e44e4-a3c4-4c9a-aab1-0e0a0bc3728b"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("bbf31729-851f-46e4-a29b-5fb9f40bd589"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("bf29ae9e-be81-4655-a829-0aab2bf7decf"));

            migrationBuilder.DropColumn(
                name: "CuisineId",
                table: "Restaurants");

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
                oldDefaultValue: new DateTime(2024, 11, 22, 16, 0, 29, 869, DateTimeKind.Local).AddTicks(4214),
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
