using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecepiesComments");

            migrationBuilder.DropTable(
                name: "RestaurantsComments");

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("05a8a037-96fc-4a0a-b853-ed2effc2162a"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("3694e1a5-52e2-4f23-80a1-13da0424f8cf"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("6b335efc-4fb5-4c78-8ce1-09d77b8b5e37"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("c0aadf51-0269-4b6c-8439-c443648e95e2"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("d566e6a9-6e2f-424c-b0b6-59ca50a0084f"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f5b261b1-01fd-40f7-8525-758ab533e818"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("0feeacfd-7a42-4606-b1cd-177d33d613ed"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("26866f8d-429c-4566-8aa7-19d3d91b88f4"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("583e5718-3d5f-4d45-9fed-c04240820ce2"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("90651a6a-9510-4475-a834-0b1c32a2147f"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("99611ced-f7d9-41bf-b19f-1077302dfd5e"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("c11673fe-1ab6-430f-ac88-20f1a6c766be"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("d15c0065-044a-4337-a5d1-d6db8877f102"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("e6f3ccdc-91c9-41da-9322-3a32caeb362e"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1c13c3bd-b7f1-40b6-a282-0ec9067cd704"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("741a91ef-6247-4034-92c1-49cb790fed77"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("79bc2ae1-07e0-4fc2-9c58-44d44b21363b"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("970455dc-c91f-4875-b65b-3ef5f82f07af"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("eef40639-83b8-4eeb-9cc8-c1ba3de320b6"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f7dc93cb-533c-46d8-bc16-8c2ec3578f79"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("fd6af8db-e397-4f6c-b946-5cc5aff9e5be"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 27, 17, 50, 45, 914, DateTimeKind.Local).AddTicks(656),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 27, 11, 39, 37, 781, DateTimeKind.Local).AddTicks(9118),
                oldComment: "Date of creation of the User.");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the Recepie."),
                    Message = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "The message of the Recepie."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecepieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of creation of the Comment.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Recepies_RecepieId",
                        column: x => x.RecepieId,
                        principalTable: "Recepies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id");
                });

            //migrationBuilder.InsertData(
            //    table: "Categories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("1057a42f-b075-4baf-bcdf-73b2ae42f4c8"), "Fast Food" },
            //        { new Guid("4f4f18d1-3a6f-4614-9883-97b334ec6ad6"), "Bar & Dinner" },
            //        { new Guid("5280549d-79f3-47f1-b34a-25bcb744d5d1"), "Restaurant" },
            //        { new Guid("9255a5f6-b20c-45dd-a051-6323b5b5f5bf"), "Bistro" },
            //        { new Guid("cf98436f-a045-4e36-93f6-7179f7a0cb38"), "Bakery" },
            //        { new Guid("e258a1cc-cc67-438d-879a-5eb483b1133c"), "Cafe" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Cuisines",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("04294818-9494-4758-ac34-4f64024f5f98"), "Mediteranean" },
            //        { new Guid("0c071f12-4c8a-4c2b-811a-c7b8dbd108ca"), "Japanese" },
            //        { new Guid("1074cc8f-b58e-4d66-a3f5-dfcf8c4fb0c3"), "Chinease" },
            //        { new Guid("26c985cd-6166-4e98-8f5c-a03289e999e6"), "Italian" },
            //        { new Guid("3728fa62-7100-4fb3-88e2-f8f385d7f534"), "French" },
            //        { new Guid("87118c24-5289-4be3-9d81-05220cb7939c"), "Bulgarian" },
            //        { new Guid("9285413b-996b-40e2-b608-70252516bcaa"), "Mexican" },
            //        { new Guid("cf8940a5-923a-4ee5-813d-9b03b59f095d"), "Only drinks" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "RecepiesCategories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("03be71d0-2eef-4acb-8e56-21f7e765aed8"), "Dinner" },
            //        { new Guid("107db987-5813-41ce-b667-a4e2b1464fa1"), "Lunch" },
            //        { new Guid("13fceb91-fb5a-4377-b934-be52f81d2b09"), "Dessert" },
            //        { new Guid("7d53bd12-93fd-4a7a-9e93-4dc8afd49fa6"), "Starter" },
            //        { new Guid("9a749145-00cb-4e13-8b2f-0a5b8eabdd87"), "Side dish" },
            //        { new Guid("a800f2b2-da00-4438-9585-dbbcc68c1e4d"), "Snack" },
            //        { new Guid("e1420367-8849-4ad1-9887-f71f42719091"), "Breakfast" }
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RecepieId",
                table: "Comments",
                column: "RecepieId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RestaurantId",
                table: "Comments",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1057a42f-b075-4baf-bcdf-73b2ae42f4c8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4f4f18d1-3a6f-4614-9883-97b334ec6ad6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5280549d-79f3-47f1-b34a-25bcb744d5d1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9255a5f6-b20c-45dd-a051-6323b5b5f5bf"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cf98436f-a045-4e36-93f6-7179f7a0cb38"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e258a1cc-cc67-438d-879a-5eb483b1133c"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("04294818-9494-4758-ac34-4f64024f5f98"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("0c071f12-4c8a-4c2b-811a-c7b8dbd108ca"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("1074cc8f-b58e-4d66-a3f5-dfcf8c4fb0c3"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("26c985cd-6166-4e98-8f5c-a03289e999e6"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("3728fa62-7100-4fb3-88e2-f8f385d7f534"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("87118c24-5289-4be3-9d81-05220cb7939c"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("9285413b-996b-40e2-b608-70252516bcaa"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("cf8940a5-923a-4ee5-813d-9b03b59f095d"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("03be71d0-2eef-4acb-8e56-21f7e765aed8"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("107db987-5813-41ce-b667-a4e2b1464fa1"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("13fceb91-fb5a-4377-b934-be52f81d2b09"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("7d53bd12-93fd-4a7a-9e93-4dc8afd49fa6"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("9a749145-00cb-4e13-8b2f-0a5b8eabdd87"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("a800f2b2-da00-4438-9585-dbbcc68c1e4d"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("e1420367-8849-4ad1-9887-f71f42719091"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 27, 11, 39, 37, 781, DateTimeKind.Local).AddTicks(9118),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 27, 17, 50, 45, 914, DateTimeKind.Local).AddTicks(656),
                oldComment: "Date of creation of the User.");

            migrationBuilder.CreateTable(
                name: "RecepiesComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the Recepie."),
                    RecepieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of creation of the Comment."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "The message of the Recepie.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecepiesComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecepiesComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecepiesComments_Recepies_RecepieId",
                        column: x => x.RecepieId,
                        principalTable: "Recepies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantsComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the Comment."),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of creation of the Comment."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "The message of the Comment.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantsComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantsComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantsComments_Restaurants_RestaurantId",
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
                    { new Guid("05a8a037-96fc-4a0a-b853-ed2effc2162a"), "Bar & Dinner" },
                    { new Guid("3694e1a5-52e2-4f23-80a1-13da0424f8cf"), "Restaurant" },
                    { new Guid("6b335efc-4fb5-4c78-8ce1-09d77b8b5e37"), "Bistro" },
                    { new Guid("c0aadf51-0269-4b6c-8439-c443648e95e2"), "Bakery" },
                    { new Guid("d566e6a9-6e2f-424c-b0b6-59ca50a0084f"), "Cafe" },
                    { new Guid("f5b261b1-01fd-40f7-8525-758ab533e818"), "Fast Food" }
                });

            migrationBuilder.InsertData(
                table: "Cuisines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0feeacfd-7a42-4606-b1cd-177d33d613ed"), "Italian" },
                    { new Guid("26866f8d-429c-4566-8aa7-19d3d91b88f4"), "French" },
                    { new Guid("583e5718-3d5f-4d45-9fed-c04240820ce2"), "Japanese" },
                    { new Guid("90651a6a-9510-4475-a834-0b1c32a2147f"), "Only drinks" },
                    { new Guid("99611ced-f7d9-41bf-b19f-1077302dfd5e"), "Mexican" },
                    { new Guid("c11673fe-1ab6-430f-ac88-20f1a6c766be"), "Bulgarian" },
                    { new Guid("d15c0065-044a-4337-a5d1-d6db8877f102"), "Chinease" },
                    { new Guid("e6f3ccdc-91c9-41da-9322-3a32caeb362e"), "Mediteranean" }
                });

            migrationBuilder.InsertData(
                table: "RecepiesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1c13c3bd-b7f1-40b6-a282-0ec9067cd704"), "Dinner" },
                    { new Guid("741a91ef-6247-4034-92c1-49cb790fed77"), "Side dish" },
                    { new Guid("79bc2ae1-07e0-4fc2-9c58-44d44b21363b"), "Lunch" },
                    { new Guid("970455dc-c91f-4875-b65b-3ef5f82f07af"), "Snack" },
                    { new Guid("eef40639-83b8-4eeb-9cc8-c1ba3de320b6"), "Breakfast" },
                    { new Guid("f7dc93cb-533c-46d8-bc16-8c2ec3578f79"), "Starter" },
                    { new Guid("fd6af8db-e397-4f6c-b946-5cc5aff9e5be"), "Dessert" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecepiesComments_RecepieId",
                table: "RecepiesComments",
                column: "RecepieId");

            migrationBuilder.CreateIndex(
                name: "IX_RecepiesComments_UserId",
                table: "RecepiesComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantsComments_RestaurantId",
                table: "RestaurantsComments",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantsComments_UserId",
                table: "RestaurantsComments",
                column: "UserId");
        }
    }
}
