using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class INItialThirdtime : Migration
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

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("669c3527-ade7-4dda-872e-c96e8cabf9a1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("75a969ad-9ab0-4778-9801-41ff6dbf3081"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("76b67744-f579-4c47-a13c-b1fd238373b8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("814b05c9-b967-47d3-a3b1-be699223b16f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("899ec41b-b57f-4bd1-8008-c1e64ad2e4aa"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b53bae73-88b2-4a1a-9649-228e5b8ae617"));

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Cities");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1ce623a4-f1e2-4965-9054-edaaaa9b5c9e"), "Bakery" },
                    { new Guid("3466d791-d55d-4ce7-9b12-056744670fcb"), "Bistro" },
                    { new Guid("55d244b7-0c7a-48a1-a64c-45f3c490e3af"), "Restaurant" },
                    { new Guid("e4f28892-bff9-46b0-b5aa-9ff5351cf9cb"), "Cafe" },
                    { new Guid("e6be95e2-53b7-4c60-912d-35f4c00be63e"), "Bar & Dinner" },
                    { new Guid("f9e9fc0c-12a4-4ffb-954e-a059ffe6574e"), "Fast Food" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2a02cf74-7f55-491a-9ecb-7b854510e6b9"), "Varna" },
                    { new Guid("407e3d89-8ab6-4ecf-a304-3cf516c67d71"), "Stara Zagora" },
                    { new Guid("8e704fdb-679d-45ed-97fd-5f89a1cd1b4f"), "Sofia" },
                    { new Guid("902d135c-87c4-4e3e-a991-bab284950732"), "Plovdiv" },
                    { new Guid("be3299fe-d5e1-47bd-a064-aa8fa2fee408"), "Ruse" },
                    { new Guid("cc019c80-6767-4d0f-8637-ad53ad77e707"), "Burgas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1ce623a4-f1e2-4965-9054-edaaaa9b5c9e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3466d791-d55d-4ce7-9b12-056744670fcb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("55d244b7-0c7a-48a1-a64c-45f3c490e3af"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e4f28892-bff9-46b0-b5aa-9ff5351cf9cb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e6be95e2-53b7-4c60-912d-35f4c00be63e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f9e9fc0c-12a4-4ffb-954e-a059ffe6574e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("2a02cf74-7f55-491a-9ecb-7b854510e6b9"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("407e3d89-8ab6-4ecf-a304-3cf516c67d71"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("8e704fdb-679d-45ed-97fd-5f89a1cd1b4f"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("902d135c-87c4-4e3e-a991-bab284950732"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("be3299fe-d5e1-47bd-a064-aa8fa2fee408"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("cc019c80-6767-4d0f-8637-ad53ad77e707"));

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
