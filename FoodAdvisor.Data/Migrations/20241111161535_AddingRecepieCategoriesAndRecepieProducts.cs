using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingRecepieCategoriesAndRecepieProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0469830e-21fb-4e3e-96e2-a60dc8ba54e9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("27d45d05-f19c-44b9-9bcb-11b24fe0b089"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3e36e78d-474b-4ebf-b343-3ae799e6e68b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("85df763a-3a28-40d2-ad7b-90df4588dd11"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c4b544c8-2a59-4c44-82c8-c352c9c84b9e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ced3a94a-69d0-47b9-ba4a-f1c104725b28"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("47fec972-f573-4bf8-bc00-468d8869f9f0"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("99efb2c7-9875-4ad1-a3b6-f9944346b511"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("9bdf20a3-9b13-4a4d-80bc-cf79869be15b"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d4e65226-b6ff-4220-99fa-56d03b8fd9cb"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e5ce230c-eaf4-40d4-bf60-7e28e8b11775"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("eebb18ac-5a0f-4746-b4be-0a91758248a9"));

            migrationBuilder.AddColumn<string>(
                name: "Products",
                table: "Recepies",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                comment: "Needed products for the Recepie.");

            migrationBuilder.AddColumn<Guid>(
                name: "RecepieCategoryId",
                table: "Recepies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "RecepiesCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The idemtifier of the Recepie category."),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The name of the Recepie category.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecepiesCategories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("123d169c-e243-4012-b666-faef5fee8439"), "Fast Food" },
                    { new Guid("2556275d-5e84-429b-99f4-081b2ed9b8f6"), "Bistro" },
                    { new Guid("39d92e48-7523-4a78-84e7-2736c32b4f7a"), "Cafe" },
                    { new Guid("587a7e3a-9c10-4925-a584-dce38c85c0e6"), "Bakery" },
                    { new Guid("62594d86-d80a-4677-a086-bf9199ba41c5"), "Bar & Dinner" },
                    { new Guid("b8e6e8f6-afc6-4c62-b918-7994133cc0cc"), "Restaurant" }
                });

            migrationBuilder.InsertData(
                table: "RecepiesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("235d232e-a059-4814-a1a9-db416005d93e"), "Lunch" },
                    { new Guid("268f35e2-b833-4bd9-b177-9bc39453f926"), "Starter" },
                    { new Guid("294750b8-5c20-4223-8d18-d0412a87fbc9"), "Side dish" },
                    { new Guid("3f817a5f-40a4-41bd-a252-3191ffb4a2c7"), "Breakfast" },
                    { new Guid("a8f16f5e-b4bf-4c65-96ef-c0651e9d3561"), "Dessert" },
                    { new Guid("abfbaba2-21ad-4dae-a3af-4c255d79d876"), "Dinner" },
                    { new Guid("f5837b63-74bf-4c4c-8ca5-3b3383e6327c"), "Snack" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recepies_RecepieCategoryId",
                table: "Recepies",
                column: "RecepieCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recepies_RecepiesCategories_RecepieCategoryId",
                table: "Recepies",
                column: "RecepieCategoryId",
                principalTable: "RecepiesCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recepies_RecepiesCategories_RecepieCategoryId",
                table: "Recepies");

            migrationBuilder.DropTable(
                name: "RecepiesCategories");

            migrationBuilder.DropIndex(
                name: "IX_Recepies_RecepieCategoryId",
                table: "Recepies");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("123d169c-e243-4012-b666-faef5fee8439"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2556275d-5e84-429b-99f4-081b2ed9b8f6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("39d92e48-7523-4a78-84e7-2736c32b4f7a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("587a7e3a-9c10-4925-a584-dce38c85c0e6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("62594d86-d80a-4677-a086-bf9199ba41c5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b8e6e8f6-afc6-4c62-b918-7994133cc0cc"));

            migrationBuilder.DropColumn(
                name: "Products",
                table: "Recepies");

            migrationBuilder.DropColumn(
                name: "RecepieCategoryId",
                table: "Recepies");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0469830e-21fb-4e3e-96e2-a60dc8ba54e9"), "Restaurant" },
                    { new Guid("27d45d05-f19c-44b9-9bcb-11b24fe0b089"), "Bakery" },
                    { new Guid("3e36e78d-474b-4ebf-b343-3ae799e6e68b"), "Bar & Dinner" },
                    { new Guid("85df763a-3a28-40d2-ad7b-90df4588dd11"), "Cafe" },
                    { new Guid("c4b544c8-2a59-4c44-82c8-c352c9c84b9e"), "Fast Food" },
                    { new Guid("ced3a94a-69d0-47b9-ba4a-f1c104725b28"), "Bistro" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("47fec972-f573-4bf8-bc00-468d8869f9f0"), "Varna" },
                    { new Guid("99efb2c7-9875-4ad1-a3b6-f9944346b511"), "Ruse" },
                    { new Guid("9bdf20a3-9b13-4a4d-80bc-cf79869be15b"), "Sofia" },
                    { new Guid("d4e65226-b6ff-4220-99fa-56d03b8fd9cb"), "Burgas" },
                    { new Guid("e5ce230c-eaf4-40d4-bf60-7e28e8b11775"), "Stara Zagora" },
                    { new Guid("eebb18ac-5a0f-4746-b4be-0a91758248a9"), "Plovdiv" }
                });
        }
    }
}
