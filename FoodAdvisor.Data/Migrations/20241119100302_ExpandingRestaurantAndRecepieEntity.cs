using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExpandingRestaurantAndRecepieEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("0d0790ba-953b-44ca-9c97-832b222dd72d"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("29390044-a69d-4c6b-b316-729f4ca49e67"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("34fa4bb4-efdd-41dc-af03-63c5221399e2"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("4686b8dc-aeeb-4e81-8f62-9ac09d6c9147"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("9d691468-02a2-42b2-9f03-fe5588ac2976"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("ce3d84e7-f800-4131-b7b3-fbe41a52899a"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("176219c4-d214-4b74-8d63-004621e8c6d6"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("207dcd9c-0e09-4dee-8a3e-6d03853e9a52"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("7ae85499-616e-47a5-bdb0-fc4edf1be7ec"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("7c9a73e1-2ec9-4d50-bda8-b97660b0c0ce"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("a8ff2539-28a5-45e4-b7be-93ca5200ccbb"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("aba04395-528b-4e00-ae52-c72451f4493b"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f29fe147-0b65-4efe-aba6-82b28da75f2f"));

            migrationBuilder.AddColumn<string>(
                name: "PricaRange",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "$",
                comment: "Shows the price range of the restaurant.");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfServing",
                table: "Recepies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Number of servings for the Recepie");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 19, 12, 2, 59, 868, DateTimeKind.Local).AddTicks(8488),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 12, 19, 21, 7, 950, DateTimeKind.Local).AddTicks(5646),
                oldComment: "Date of creation of the User.");

            //migrationBuilder.InsertData(
            //    table: "Categories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("289750e0-17cb-4681-a3ba-2057dc0e86d2"), "Restaurant" },
            //        { new Guid("41213f4b-e9c9-45ee-ac37-6a47dc4dc8a0"), "Fast Food" },
            //        { new Guid("4869320a-bb30-43fa-baf8-e71f013978ca"), "Bar & Dinner" },
            //        { new Guid("6da74f82-3448-4d7b-8457-816853e2b666"), "Cafe" },
            //        { new Guid("acdfab1e-9197-4c3a-a301-b8dcf4ce3e75"), "Bistro" },
            //        { new Guid("b61dd991-b59d-4173-b4c0-5adc4cf597d6"), "Bakery" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "RecepiesCategories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("23bb004f-4f23-493c-9b0c-6dd69bcdae3f"), "Dinner" },
            //        { new Guid("2655a31f-33f8-4852-8694-83d158acd6e8"), "Snack" },
            //        { new Guid("28c79765-468f-4be6-94f4-f85bf52fa725"), "Side dish" },
            //        { new Guid("298ff35e-a4a3-4f04-b9ca-777e8eb4a6d7"), "Starter" },
            //        { new Guid("3ee613a2-d0f2-47e4-9abc-ce4d4be546d9"), "Dessert" },
            //        { new Guid("87801996-60f9-4ddc-9fe7-5e48cb10283d"), "Breakfast" },
            //        { new Guid("ef806b71-2b9e-494d-a8ff-26df6fb7a8e5"), "Lunch" }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("289750e0-17cb-4681-a3ba-2057dc0e86d2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("41213f4b-e9c9-45ee-ac37-6a47dc4dc8a0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4869320a-bb30-43fa-baf8-e71f013978ca"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6da74f82-3448-4d7b-8457-816853e2b666"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("acdfab1e-9197-4c3a-a301-b8dcf4ce3e75"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b61dd991-b59d-4173-b4c0-5adc4cf597d6"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("23bb004f-4f23-493c-9b0c-6dd69bcdae3f"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("2655a31f-33f8-4852-8694-83d158acd6e8"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("28c79765-468f-4be6-94f4-f85bf52fa725"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("298ff35e-a4a3-4f04-b9ca-777e8eb4a6d7"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("3ee613a2-d0f2-47e4-9abc-ce4d4be546d9"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("87801996-60f9-4ddc-9fe7-5e48cb10283d"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("ef806b71-2b9e-494d-a8ff-26df6fb7a8e5"));

            migrationBuilder.DropColumn(
                name: "PricaRange",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "NumberOfServing",
                table: "Recepies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 12, 19, 21, 7, 950, DateTimeKind.Local).AddTicks(5646),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 19, 12, 2, 59, 868, DateTimeKind.Local).AddTicks(8488),
                oldComment: "Date of creation of the User.");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0d0790ba-953b-44ca-9c97-832b222dd72d"), "Bistro" },
                    { new Guid("29390044-a69d-4c6b-b316-729f4ca49e67"), "Bar & Dinner" },
                    { new Guid("34fa4bb4-efdd-41dc-af03-63c5221399e2"), "Cafe" },
                    { new Guid("4686b8dc-aeeb-4e81-8f62-9ac09d6c9147"), "Fast Food" },
                    { new Guid("9d691468-02a2-42b2-9f03-fe5588ac2976"), "Bakery" },
                    { new Guid("ce3d84e7-f800-4131-b7b3-fbe41a52899a"), "Restaurant" }
                });

            migrationBuilder.InsertData(
                table: "RecepiesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("176219c4-d214-4b74-8d63-004621e8c6d6"), "Dessert" },
                    { new Guid("207dcd9c-0e09-4dee-8a3e-6d03853e9a52"), "Dinner" },
                    { new Guid("7ae85499-616e-47a5-bdb0-fc4edf1be7ec"), "Side dish" },
                    { new Guid("7c9a73e1-2ec9-4d50-bda8-b97660b0c0ce"), "Lunch" },
                    { new Guid("a8ff2539-28a5-45e4-b7be-93ca5200ccbb"), "Starter" },
                    { new Guid("aba04395-528b-4e00-ae52-c72451f4493b"), "Breakfast" },
                    { new Guid("f29fe147-0b65-4efe-aba6-82b28da75f2f"), "Snack" }
                });
        }
    }
}
