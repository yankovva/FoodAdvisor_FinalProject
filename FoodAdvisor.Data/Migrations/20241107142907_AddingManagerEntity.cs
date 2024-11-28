using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingManagerEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("36a7f3e3-3a37-48fa-8e19-97d8bd59858e"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("47c6f1b1-89c6-458e-8951-e04989a6d251"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("48e9b14c-e849-4f4a-9c9c-64485ac331a9"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("5c8f1a6c-4a97-4288-be83-98d889c9727f"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("85b7e7f1-3df2-481d-8faa-8159d754794f"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("b1eae2a3-5504-4243-94b5-e255ab5dcd01"));

            //migrationBuilder.DeleteData(
            //    table: "Cities",
            //    keyColumn: "Id",
            //    keyValue: new Guid("26cb9f8c-a5e8-4e2c-a3a1-85c48fdfb9df"));

            //migrationBuilder.DeleteData(
            //    table: "Cities",
            //    keyColumn: "Id",
            //    keyValue: new Guid("353e3d1e-4917-4330-9747-c7d7c63ffd78"));

            //migrationBuilder.DeleteData(
            //    table: "Cities",
            //    keyColumn: "Id",
            //    keyValue: new Guid("410cd642-86d5-4c26-97e0-d37a0645defa"));

            //migrationBuilder.DeleteData(
            //    table: "Cities",
            //    keyColumn: "Id",
            //    keyValue: new Guid("df0aceaa-da1d-45c5-9dcc-6d86c531ca2d"));

            //migrationBuilder.DeleteData(
            //    table: "Cities",
            //    keyColumn: "Id",
            //    keyValue: new Guid("e27162c4-326f-4b39-8c89-37c0ed102e36"));

            //migrationBuilder.DeleteData(
            //    table: "Cities",
            //    keyColumn: "Id",
            //    keyValue: new Guid("e79f5d13-0c34-42a1-a171-7836db553770"));

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The unique identifier of the manager."),
                    WorkPhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Work phone number of the manager."),
                    Address = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Address of the manager."),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.InsertData(
            //    table: "Categories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("18b56dcf-0ff5-48a9-9437-994eee10e7c9"), "Cafe" },
            //        { new Guid("9bf56b79-048b-459e-a458-95a72d03a804"), "Bakery" },
            //        { new Guid("a87ac91f-2f93-4895-bf08-ff4a4fcb9a0d"), "Bar & Dinner" },
            //        { new Guid("ac41037d-e2f5-411d-a992-be7459e0acd4"), "Bistro" },
            //        { new Guid("cb4b28cf-0dde-4366-bb59-c9c04a33bd3a"), "Restaurant" },
            //        { new Guid("d5a950dc-e072-4320-ab47-f8ede132d940"), "Fast Food" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Cities",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("1f2eefb1-f9bb-408f-90f4-f742769b7334"), "Ruse" },
            //        { new Guid("26b3c690-6d43-4f62-9f8a-71a60de6658d"), "Sofia" },
            //        { new Guid("b70e57a2-77a2-4db8-b86e-e480ea35a0d7"), "Stara Zagora" },
            //        { new Guid("ca161a4a-a5dc-4796-88d9-975966212416"), "Burgas" },
            //        { new Guid("e7f6636d-d862-491d-8aca-8555b6e9e489"), "Plovdiv" },
            //        { new Guid("f7907d24-6c96-4ded-9d41-298ad8d26dd7"), "Varna" }
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_Managers_UserId",
                table: "Managers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Managers");

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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("36a7f3e3-3a37-48fa-8e19-97d8bd59858e"), "Fast Food" },
                    { new Guid("47c6f1b1-89c6-458e-8951-e04989a6d251"), "Cafe" },
                    { new Guid("48e9b14c-e849-4f4a-9c9c-64485ac331a9"), "Bar & Dinner" },
                    { new Guid("5c8f1a6c-4a97-4288-be83-98d889c9727f"), "Restaurant" },
                    { new Guid("85b7e7f1-3df2-481d-8faa-8159d754794f"), "Bistro" },
                    { new Guid("b1eae2a3-5504-4243-94b5-e255ab5dcd01"), "Bakery" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("26cb9f8c-a5e8-4e2c-a3a1-85c48fdfb9df"), "Sofia" },
                    { new Guid("353e3d1e-4917-4330-9747-c7d7c63ffd78"), "Varna" },
                    { new Guid("410cd642-86d5-4c26-97e0-d37a0645defa"), "Plovdiv" },
                    { new Guid("df0aceaa-da1d-45c5-9dcc-6d86c531ca2d"), "Ruse" },
                    { new Guid("e27162c4-326f-4b39-8c89-37c0ed102e36"), "Burgas" },
                    { new Guid("e79f5d13-0c34-42a1-a171-7836db553770"), "Stara Zagora" }
                });
        }
    }
}
