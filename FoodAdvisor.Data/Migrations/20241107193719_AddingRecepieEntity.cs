using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingRecepieEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("18b56dcf-0ff5-48a9-9437-994eee10e7c9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9bf56b79-048b-459e-a458-95a72d03a804"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a87ac91f-2f93-4895-bf08-ff4a4fcb9a0d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ac41037d-e2f5-411d-a992-be7459e0acd4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cb4b28cf-0dde-4366-bb59-c9c04a33bd3a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d5a950dc-e072-4320-ab47-f8ede132d940"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("1f2eefb1-f9bb-408f-90f4-f742769b7334"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("26b3c690-6d43-4f62-9f8a-71a60de6658d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b70e57a2-77a2-4db8-b86e-e480ea35a0d7"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("ca161a4a-a5dc-4796-88d9-975966212416"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e7f6636d-d862-491d-8aca-8555b6e9e489"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f7907d24-6c96-4ded-9d41-298ad8d26dd7"));

            migrationBuilder.AlterColumn<Guid>(
                name: "RestaurantId",
                table: "UsersRestaurants",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Identifier of the Recepie",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Identifier of the Restaurant");

            migrationBuilder.CreateTable(
                name: "Recepies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Name of the Recepie."),
                    CookingTime = table.Column<int>(type: "int", nullable: false, comment: "Cooking time of the Recepie."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of creation of the Recepie."),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false, comment: "Description of the Recepie."),
                    ImageURL = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: true),
                    PublisherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recepies_AspNetUsers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersRecepies",
                columns: table => new
                {
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the ApplicationUser"),
                    RecepieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the Restaurant")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRecepies", x => new { x.ApplicationUserId, x.RecepieId });
                    table.ForeignKey(
                        name: "FK_UsersRecepies_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UsersRecepies_Recepies_RecepieId",
                        column: x => x.RecepieId,
                        principalTable: "Recepies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("449dc8df-fdc9-4ed6-ae02-86b60dbf215a"), "Restaurant" },
                    { new Guid("486a8ac8-0b43-402b-b349-ad2db960159a"), "Bakery" },
                    { new Guid("b64b5383-9c5e-4eba-9d6a-cacdec6bbd62"), "Bar & Dinner" },
                    { new Guid("ba63d928-a7d0-45eb-b96a-b177c49c1569"), "Fast Food" },
                    { new Guid("d10139dc-ccbb-4568-a178-ebf94c5d0a22"), "Cafe" },
                    { new Guid("d6e3b070-df79-4d2f-8808-9fa911916403"), "Bistro" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1c4559e7-b628-4128-9d56-056545f9298f"), "Stara Zagora" },
                    { new Guid("5c4e3a44-1a9a-4a08-9222-baabde3daa04"), "Sofia" },
                    { new Guid("8fe38a56-bf64-44f0-a4ab-5d6a9bf9fdf7"), "Plovdiv" },
                    { new Guid("973e5ba0-9b84-4602-8bad-96285b2e143a"), "Burgas" },
                    { new Guid("98ec19d3-3bb0-482b-b7e0-a429fadb0a2b"), "Ruse" },
                    { new Guid("f2bccdb9-6927-4ec4-a500-38f093d53910"), "Varna" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recepies_PublisherId",
                table: "Recepies",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRecepies_RecepieId",
                table: "UsersRecepies",
                column: "RecepieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersRecepies");

            migrationBuilder.DropTable(
                name: "Recepies");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("449dc8df-fdc9-4ed6-ae02-86b60dbf215a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("486a8ac8-0b43-402b-b349-ad2db960159a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b64b5383-9c5e-4eba-9d6a-cacdec6bbd62"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ba63d928-a7d0-45eb-b96a-b177c49c1569"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d10139dc-ccbb-4568-a178-ebf94c5d0a22"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d6e3b070-df79-4d2f-8808-9fa911916403"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("1c4559e7-b628-4128-9d56-056545f9298f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("5c4e3a44-1a9a-4a08-9222-baabde3daa04"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8fe38a56-bf64-44f0-a4ab-5d6a9bf9fdf7"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("973e5ba0-9b84-4602-8bad-96285b2e143a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("98ec19d3-3bb0-482b-b7e0-a429fadb0a2b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f2bccdb9-6927-4ec4-a500-38f093d53910"));

            migrationBuilder.AlterColumn<Guid>(
                name: "RestaurantId",
                table: "UsersRestaurants",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Identifier of the Restaurant",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Identifier of the Recepie");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("18b56dcf-0ff5-48a9-9437-994eee10e7c9"), "Cafe" },
                    { new Guid("9bf56b79-048b-459e-a458-95a72d03a804"), "Bakery" },
                    { new Guid("a87ac91f-2f93-4895-bf08-ff4a4fcb9a0d"), "Bar & Dinner" },
                    { new Guid("ac41037d-e2f5-411d-a992-be7459e0acd4"), "Bistro" },
                    { new Guid("cb4b28cf-0dde-4366-bb59-c9c04a33bd3a"), "Restaurant" },
                    { new Guid("d5a950dc-e072-4320-ab47-f8ede132d940"), "Fast Food" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1f2eefb1-f9bb-408f-90f4-f742769b7334"), "Ruse" },
                    { new Guid("26b3c690-6d43-4f62-9f8a-71a60de6658d"), "Sofia" },
                    { new Guid("b70e57a2-77a2-4db8-b86e-e480ea35a0d7"), "Stara Zagora" },
                    { new Guid("ca161a4a-a5dc-4796-88d9-975966212416"), "Burgas" },
                    { new Guid("e7f6636d-d862-491d-8aca-8555b6e9e489"), "Plovdiv" },
                    { new Guid("f7907d24-6c96-4ded-9d41-298ad8d26dd7"), "Varna" }
                });
        }
    }
}
