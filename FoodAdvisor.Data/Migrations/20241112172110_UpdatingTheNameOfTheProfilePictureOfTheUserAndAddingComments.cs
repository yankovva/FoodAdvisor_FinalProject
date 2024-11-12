using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingTheNameOfTheProfilePictureOfTheUserAndAddingComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ProfilePricture",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Last name of the User.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "First name of the User.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 12, 19, 21, 7, 950, DateTimeKind.Local).AddTicks(5646),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 12, 14, 44, 3, 160, DateTimeKind.Local).AddTicks(6861));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                comment: "Birthday of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AboutMe",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Short descripton of the User.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePricturePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "/assets/img/no-image-account.jfif",
                comment: "Path for the Profile picture of the User.");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0d0790ba-953b-44ca-9c97-832b222dd72d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("29390044-a69d-4c6b-b316-729f4ca49e67"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("34fa4bb4-efdd-41dc-af03-63c5221399e2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4686b8dc-aeeb-4e81-8f62-9ac09d6c9147"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9d691468-02a2-42b2-9f03-fe5588ac2976"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ce3d84e7-f800-4131-b7b3-fbe41a52899a"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("176219c4-d214-4b74-8d63-004621e8c6d6"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("207dcd9c-0e09-4dee-8a3e-6d03853e9a52"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("7ae85499-616e-47a5-bdb0-fc4edf1be7ec"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("7c9a73e1-2ec9-4d50-bda8-b97660b0c0ce"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("a8ff2539-28a5-45e4-b7be-93ca5200ccbb"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("aba04395-528b-4e00-ae52-c72451f4493b"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("f29fe147-0b65-4efe-aba6-82b28da75f2f"));

            migrationBuilder.DropColumn(
                name: "ProfilePricturePath",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Last name of the User.");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "First name of the User.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 12, 14, 44, 3, 160, DateTimeKind.Local).AddTicks(6861),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 12, 19, 21, 7, 950, DateTimeKind.Local).AddTicks(5646),
                oldComment: "Date of creation of the User.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Birthday of the User.");

            migrationBuilder.AlterColumn<string>(
                name: "AboutMe",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Short descripton of the User.");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePricture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "/assets/img/no-image-account.jfif");

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
    }
}
