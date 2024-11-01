using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserPlaceToUserRestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersPlaces");

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

            migrationBuilder.CreateTable(
                name: "UsersRestaurants",
                columns: table => new
                {
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the ApplicationUser"),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the Restaurant")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRestaurants", x => new { x.ApplicationUserId, x.RestaurantId });
                    table.ForeignKey(
                        name: "FK_UsersRestaurants_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UsersRestaurants_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("65bac172-f782-479a-ba18-712cf9054219"), "Cafe" },
                    { new Guid("760e114b-7d73-4502-8eb2-3646880d0880"), "Bistro" },
                    { new Guid("8c8fe92e-e4c6-4da9-b2ce-c5520b4cb65a"), "Restaurant" },
                    { new Guid("a6e40379-1c31-48a4-8dae-86114ee22f73"), "Bar & Dinner" },
                    { new Guid("aa8e05b7-d338-4b96-ba4d-e08a9be3a00d"), "Bakery" },
                    { new Guid("ced8808d-ba43-4dcf-a502-756872b8ee0a"), "Fast Food" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersRestaurants_RestaurantId",
                table: "UsersRestaurants",
                column: "RestaurantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersRestaurants");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("65bac172-f782-479a-ba18-712cf9054219"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("760e114b-7d73-4502-8eb2-3646880d0880"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8c8fe92e-e4c6-4da9-b2ce-c5520b4cb65a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a6e40379-1c31-48a4-8dae-86114ee22f73"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aa8e05b7-d338-4b96-ba4d-e08a9be3a00d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ced8808d-ba43-4dcf-a502-756872b8ee0a"));

            migrationBuilder.CreateTable(
                name: "UsersPlaces",
                columns: table => new
                {
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the ApplicationUser"),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the Restaurant")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPlaces", x => new { x.ApplicationUserId, x.RestaurantId });
                    table.ForeignKey(
                        name: "FK_UsersPlaces_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersPlaces_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("11350cf3-2e37-40fd-a2c2-a42ada1702fe"), "Restaurant" },
                    { new Guid("4046bec5-efd6-4408-ad21-88db2952508c"), "Fast Food" },
                    { new Guid("5e3b7a9c-d54a-48b5-80a7-af35d4565df0"), "Bakery" },
                    { new Guid("7b1e8c61-0247-4d55-810a-00aacb2ff4e4"), "Bar & Dinner" },
                    { new Guid("db9b2ed9-5de8-40ba-882a-10ba4c2736eb"), "Bistro" },
                    { new Guid("f5322b6d-0f12-49b1-b60e-28129519676d"), "Cafe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersPlaces_RestaurantId",
                table: "UsersPlaces",
                column: "RestaurantId");
        }
    }
}
