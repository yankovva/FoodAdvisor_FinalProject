using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingRecepiesComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("449dc8df-fdc9-4ed6-ae02-86b60dbf215a"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("486a8ac8-0b43-402b-b349-ad2db960159a"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("b64b5383-9c5e-4eba-9d6a-cacdec6bbd62"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("ba63d928-a7d0-45eb-b96a-b177c49c1569"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("d10139dc-ccbb-4568-a178-ebf94c5d0a22"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("d6e3b070-df79-4d2f-8808-9fa911916403"));

            //migrationBuilder.DeleteData(
            //    table: "Cities",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1c4559e7-b628-4128-9d56-056545f9298f"));

            //migrationBuilder.DeleteData(
            //    table: "Cities",
            //    keyColumn: "Id",
            //    keyValue: new Guid("5c4e3a44-1a9a-4a08-9222-baabde3daa04"));

            //migrationBuilder.DeleteData(
            //    table: "Cities",
            //    keyColumn: "Id",
            //    keyValue: new Guid("8fe38a56-bf64-44f0-a4ab-5d6a9bf9fdf7"));

            //migrationBuilder.DeleteData(
            //    table: "Cities",
            //    keyColumn: "Id",
            //    keyValue: new Guid("973e5ba0-9b84-4602-8bad-96285b2e143a"));

            //migrationBuilder.DeleteData(
            //    table: "Cities",
            //    keyColumn: "Id",
            //    keyValue: new Guid("98ec19d3-3bb0-482b-b7e0-a429fadb0a2b"));

            //migrationBuilder.DeleteData(
            //    table: "Cities",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f2bccdb9-6927-4ec4-a500-38f093d53910"));

            migrationBuilder.CreateTable(
                name: "RecepiesComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the Recepie."),
                    Message = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "The message of the Recepie."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecepieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of creation of the Comment.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecepiesComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecepiesComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RecepiesComments_Recepies_RecepieId",
                        column: x => x.RecepieId,
                        principalTable: "Recepies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            //migrationBuilder.InsertData(
            //    table: "Categories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("0469830e-21fb-4e3e-96e2-a60dc8ba54e9"), "Restaurant" },
            //        { new Guid("27d45d05-f19c-44b9-9bcb-11b24fe0b089"), "Bakery" },
            //        { new Guid("3e36e78d-474b-4ebf-b343-3ae799e6e68b"), "Bar & Dinner" },
            //        { new Guid("85df763a-3a28-40d2-ad7b-90df4588dd11"), "Cafe" },
            //        { new Guid("c4b544c8-2a59-4c44-82c8-c352c9c84b9e"), "Fast Food" },
            //        { new Guid("ced3a94a-69d0-47b9-ba4a-f1c104725b28"), "Bistro" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Cities",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("47fec972-f573-4bf8-bc00-468d8869f9f0"), "Varna" },
            //        { new Guid("99efb2c7-9875-4ad1-a3b6-f9944346b511"), "Ruse" },
            //        { new Guid("9bdf20a3-9b13-4a4d-80bc-cf79869be15b"), "Sofia" },
            //        { new Guid("d4e65226-b6ff-4220-99fa-56d03b8fd9cb"), "Burgas" },
            //        { new Guid("e5ce230c-eaf4-40d4-bf60-7e28e8b11775"), "Stara Zagora" },
            //        { new Guid("eebb18ac-5a0f-4746-b4be-0a91758248a9"), "Plovdiv" }
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_RecepiesComments_RecepieId",
                table: "RecepiesComments",
                column: "RecepieId");

            migrationBuilder.CreateIndex(
                name: "IX_RecepiesComments_UserId",
                table: "RecepiesComments",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecepiesComments");

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
        }
    }
}
