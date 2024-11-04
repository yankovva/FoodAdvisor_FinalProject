using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingRestaurantComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "RestaurantsComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identifier of the Comment.")
                        .Annotation("SqlServer:Identity", "1, 1"),
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("007ed785-222e-469f-b44e-c97b528f7865"), "Bakery" },
                    { new Guid("157be899-8a49-4113-a083-190b8071855c"), "Restaurant" },
                    { new Guid("3623d70a-01d2-4d0d-b42c-86023356b76f"), "Fast Food" },
                    { new Guid("5c72a95d-aaa7-43a1-9d1b-73737edba986"), "Bar & Dinner" },
                    { new Guid("af24d032-e95f-46be-8135-b393cfd50b3b"), "Bistro" },
                    { new Guid("f6d383d7-df26-4bdd-a071-7cdfe29c020e"), "Cafe" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1fa7690a-40e7-41f2-9063-a8e0d0aecf84"), "Ruse" },
                    { new Guid("38ddeafe-4b7d-4f8f-88b4-f0747c14a52c"), "Burgas" },
                    { new Guid("3eacbca8-2fa3-4e93-a8c2-f809e6baa22d"), "Varna" },
                    { new Guid("59302d13-3153-401d-8a81-9bee97efac69"), "Sofia" },
                    { new Guid("cece4785-6925-4f9c-8a5b-b924928d7454"), "Plovdiv" },
                    { new Guid("d227a09e-5c1f-42ba-b4ee-8f1c8ae1b634"), "Stara Zagora" }
                });

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
                keyValue: new Guid("007ed785-222e-469f-b44e-c97b528f7865"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("157be899-8a49-4113-a083-190b8071855c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3623d70a-01d2-4d0d-b42c-86023356b76f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5c72a95d-aaa7-43a1-9d1b-73737edba986"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("af24d032-e95f-46be-8135-b393cfd50b3b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f6d383d7-df26-4bdd-a071-7cdfe29c020e"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("1fa7690a-40e7-41f2-9063-a8e0d0aecf84"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("38ddeafe-4b7d-4f8f-88b4-f0747c14a52c"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("3eacbca8-2fa3-4e93-a8c2-f809e6baa22d"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("59302d13-3153-401d-8a81-9bee97efac69"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("cece4785-6925-4f9c-8a5b-b924928d7454"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d227a09e-5c1f-42ba-b4ee-8f1c8ae1b634"));

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
    }
}
