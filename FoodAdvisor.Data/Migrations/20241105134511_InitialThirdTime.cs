using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialThirdTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryId",
                table: "Cities");

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("669c3527-ade7-4dda-872e-c96e8cabf9a1"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("75a969ad-9ab0-4778-9801-41ff6dbf3081"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("76b67744-f579-4c47-a13c-b1fd238373b8"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("814b05c9-b967-47d3-a3b1-be699223b16f"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("899ec41b-b57f-4bd1-8008-c1e64ad2e4aa"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("b53bae73-88b2-4a1a-9649-228e5b8ae617"));

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Cities");

            migrationBuilder.CreateTable(
                name: "RestaurantsComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the Comment."),
                    Message = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "The message of the Comment."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of creation of the Comment.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantsComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantsComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RestaurantsComments_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            //migrationBuilder.InsertData(
            //    table: "Categories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("36a7f3e3-3a37-48fa-8e19-97d8bd59858e"), "Fast Food" },
            //        { new Guid("47c6f1b1-89c6-458e-8951-e04989a6d251"), "Cafe" },
            //        { new Guid("48e9b14c-e849-4f4a-9c9c-64485ac331a9"), "Bar & Dinner" },
            //        { new Guid("5c8f1a6c-4a97-4288-be83-98d889c9727f"), "Restaurant" },
            //        { new Guid("85b7e7f1-3df2-481d-8faa-8159d754794f"), "Bistro" },
            //        { new Guid("b1eae2a3-5504-4243-94b5-e255ab5dcd01"), "Bakery" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Cities",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("26cb9f8c-a5e8-4e2c-a3a1-85c48fdfb9df"), "Sofia" },
            //        { new Guid("353e3d1e-4917-4330-9747-c7d7c63ffd78"), "Varna" },
            //        { new Guid("410cd642-86d5-4c26-97e0-d37a0645defa"), "Plovdiv" },
            //        { new Guid("df0aceaa-da1d-45c5-9dcc-6d86c531ca2d"), "Ruse" },
            //        { new Guid("e27162c4-326f-4b39-8c89-37c0ed102e36"), "Burgas" },
            //        { new Guid("e79f5d13-0c34-42a1-a171-7836db553770"), "Stara Zagora" }
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantsComments_RestaurantId",
                table: "RestaurantsComments",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantsComments_UserId",
                table: "RestaurantsComments",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestaurantsComments");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("36a7f3e3-3a37-48fa-8e19-97d8bd59858e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("47c6f1b1-89c6-458e-8951-e04989a6d251"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("48e9b14c-e849-4f4a-9c9c-64485ac331a9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5c8f1a6c-4a97-4288-be83-98d889c9727f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("85b7e7f1-3df2-481d-8faa-8159d754794f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b1eae2a3-5504-4243-94b5-e255ab5dcd01"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("26cb9f8c-a5e8-4e2c-a3a1-85c48fdfb9df"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("353e3d1e-4917-4330-9747-c7d7c63ffd78"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("410cd642-86d5-4c26-97e0-d37a0645defa"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("df0aceaa-da1d-45c5-9dcc-6d86c531ca2d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e27162c4-326f-4b39-8c89-37c0ed102e36"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e79f5d13-0c34-42a1-a171-7836db553770"));

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Cities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Identifier of the Country.");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the Country"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("669c3527-ade7-4dda-872e-c96e8cabf9a1"), "Fast Food" },
                    { new Guid("75a969ad-9ab0-4778-9801-41ff6dbf3081"), "Bar & Dinner" },
                    { new Guid("76b67744-f579-4c47-a13c-b1fd238373b8"), "Cafe" },
                    { new Guid("814b05c9-b967-47d3-a3b1-be699223b16f"), "Bakery" },
                    { new Guid("899ec41b-b57f-4bd1-8008-c1e64ad2e4aa"), "Restaurant" },
                    { new Guid("b53bae73-88b2-4a1a-9649-228e5b8ae617"), "Bistro" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
