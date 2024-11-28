using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangingPLaceToRestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersPlaces_Places_PlaceId",
                table: "UsersPlaces");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersPlaces",
                table: "UsersPlaces");

            migrationBuilder.DropIndex(
                name: "IX_UsersPlaces_PlaceId",
                table: "UsersPlaces");

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("16bae119-1c02-4df7-bfd5-a70e48202e2a"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1bab5412-87c7-4e87-b654-cb4e226684a9"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1c7001a4-491c-4614-91b1-03143b585199"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("a14d425e-7fbf-41c2-bc71-a97f9aded01b"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("cd4e4887-817f-4603-b820-14681499d61b"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f88a935c-f67a-4af5-8876-befe3565c768"));

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "UsersPlaces");

            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantId",
                table: "UsersPlaces",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Identifier of the Restaurant");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersPlaces",
                table: "UsersPlaces",
                columns: new[] { "ApplicationUserId", "RestaurantId" });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The Unique Identifier of the Restaurant."),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The Name of the Restaurant."),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "The Description of the Restaurant."),
                    Address = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false, comment: "The Address of the Restaurant."),
                    ImageURL = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: true, comment: "An Image Url of the Restaurant."),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The City Id."),
                    PublisherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The Publisher Id."),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The Category Id.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_AspNetUsers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Restaurants_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Restaurants_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.InsertData(
            //    table: "Categories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("11350cf3-2e37-40fd-a2c2-a42ada1702fe"), "Restaurant" },
            //        { new Guid("4046bec5-efd6-4408-ad21-88db2952508c"), "Fast Food" },
            //        { new Guid("5e3b7a9c-d54a-48b5-80a7-af35d4565df0"), "Bakery" },
            //        { new Guid("7b1e8c61-0247-4d55-810a-00aacb2ff4e4"), "Bar & Dinner" },
            //        { new Guid("db9b2ed9-5de8-40ba-882a-10ba4c2736eb"), "Bistro" },
            //        { new Guid("f5322b6d-0f12-49b1-b60e-28129519676d"), "Cafe" }
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_UsersPlaces_RestaurantId",
                table: "UsersPlaces",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CategoryId",
                table: "Restaurants",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CityId",
                table: "Restaurants",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_PublisherId",
                table: "Restaurants",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersPlaces_Restaurants_RestaurantId",
                table: "UsersPlaces",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersPlaces_Restaurants_RestaurantId",
                table: "UsersPlaces");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersPlaces",
                table: "UsersPlaces");

            migrationBuilder.DropIndex(
                name: "IX_UsersPlaces_RestaurantId",
                table: "UsersPlaces");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11350cf3-2e37-40fd-a2c2-a42ada1702fe"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4046bec5-efd6-4408-ad21-88db2952508c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5e3b7a9c-d54a-48b5-80a7-af35d4565df0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7b1e8c61-0247-4d55-810a-00aacb2ff4e4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("db9b2ed9-5de8-40ba-882a-10ba4c2736eb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f5322b6d-0f12-49b1-b60e-28129519676d"));

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "UsersPlaces");

            migrationBuilder.AddColumn<Guid>(
                name: "PlaceId",
                table: "UsersPlaces",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Identifier of the Place");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersPlaces",
                table: "UsersPlaces",
                columns: new[] { "ApplicationUserId", "PlaceId" });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The Unique Identifier of the Place."),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The Category Id."),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The City Id."),
                    PublisherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The Publisher Id."),
                    Address = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false, comment: "The Address of the Place."),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "The Description of the Place."),
                    ImageURL = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: true, comment: "An Image Url of the Place."),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The Name of the Place.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Places_AspNetUsers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Places_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Places_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("16bae119-1c02-4df7-bfd5-a70e48202e2a"), "Restaurant" },
                    { new Guid("1bab5412-87c7-4e87-b654-cb4e226684a9"), "Bar & Dinner" },
                    { new Guid("1c7001a4-491c-4614-91b1-03143b585199"), "Cafe" },
                    { new Guid("a14d425e-7fbf-41c2-bc71-a97f9aded01b"), "Bistro" },
                    { new Guid("cd4e4887-817f-4603-b820-14681499d61b"), "Fast Food" },
                    { new Guid("f88a935c-f67a-4af5-8876-befe3565c768"), "Bakery" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersPlaces_PlaceId",
                table: "UsersPlaces",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_CategoryId",
                table: "Places",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_CityId",
                table: "Places",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_PublisherId",
                table: "Places",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersPlaces_Places_PlaceId",
                table: "UsersPlaces",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
