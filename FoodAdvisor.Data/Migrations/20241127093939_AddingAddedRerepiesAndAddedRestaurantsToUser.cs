using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingAddedRerepiesAndAddedRestaurantsToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4a49f2a3-1c52-449d-9967-262f40fd7163"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6cd241ef-f942-4d17-b298-77a183c1f6c9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7d44f2f1-99f9-428c-ac6b-92e8161f921b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a070a259-a932-40d7-b0f6-92283ca78336"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ce8723ac-34c9-42f5-81b6-ae8893093366"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d200d27b-2dac-4767-ba68-b4dfe518db3f"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("22ed1454-5f7b-40ef-9639-429c70a5a910"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("56f58d97-fc0f-418e-85fb-df46877817e8"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("65cf7813-9d3f-4f96-b2a1-a1e9b6060e09"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("8ceb2ede-5c13-43ac-bd91-1bc38c575e5c"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("8e5f4b2d-6643-4e5a-af35-ac097620b470"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("938737e2-4e4d-470b-a3d6-3fcca86e4bea"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("c790dd04-f306-493e-b774-3dbc5c272663"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("dd550d26-12c6-400a-b2e0-4b302ac690c5"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("19011b10-5315-4f82-a487-28bed8fe6e4b"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("3181a53a-2faa-4758-9b4d-b166189a48b4"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("51e185d3-7c81-4188-8fbd-08e4fc552767"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("68bcd038-aef8-4618-be05-ea32309126a4"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("7798f180-ffc4-4ee0-a649-15797318834e"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("7d08d52a-6e0c-4aa2-8131-bf3acc08ffd0"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("935e38b1-4af6-4ec2-ad5f-a505f59e5358"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 27, 11, 39, 37, 781, DateTimeKind.Local).AddTicks(9118),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 22, 18, 22, 40, 523, DateTimeKind.Local).AddTicks(8566),
                oldComment: "Date of creation of the User.");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("05a8a037-96fc-4a0a-b853-ed2effc2162a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3694e1a5-52e2-4f23-80a1-13da0424f8cf"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6b335efc-4fb5-4c78-8ce1-09d77b8b5e37"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c0aadf51-0269-4b6c-8439-c443648e95e2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d566e6a9-6e2f-424c-b0b6-59ca50a0084f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f5b261b1-01fd-40f7-8525-758ab533e818"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("0feeacfd-7a42-4606-b1cd-177d33d613ed"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("26866f8d-429c-4566-8aa7-19d3d91b88f4"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("583e5718-3d5f-4d45-9fed-c04240820ce2"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("90651a6a-9510-4475-a834-0b1c32a2147f"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("99611ced-f7d9-41bf-b19f-1077302dfd5e"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("c11673fe-1ab6-430f-ac88-20f1a6c766be"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("d15c0065-044a-4337-a5d1-d6db8877f102"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("e6f3ccdc-91c9-41da-9322-3a32caeb362e"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("1c13c3bd-b7f1-40b6-a282-0ec9067cd704"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("741a91ef-6247-4034-92c1-49cb790fed77"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("79bc2ae1-07e0-4fc2-9c58-44d44b21363b"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("970455dc-c91f-4875-b65b-3ef5f82f07af"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("eef40639-83b8-4eeb-9cc8-c1ba3de320b6"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("f7dc93cb-533c-46d8-bc16-8c2ec3578f79"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("fd6af8db-e397-4f6c-b946-5cc5aff9e5be"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 22, 18, 22, 40, 523, DateTimeKind.Local).AddTicks(8566),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 27, 11, 39, 37, 781, DateTimeKind.Local).AddTicks(9118),
                oldComment: "Date of creation of the User.");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4a49f2a3-1c52-449d-9967-262f40fd7163"), "Bakery" },
                    { new Guid("6cd241ef-f942-4d17-b298-77a183c1f6c9"), "Restaurant" },
                    { new Guid("7d44f2f1-99f9-428c-ac6b-92e8161f921b"), "Bistro" },
                    { new Guid("a070a259-a932-40d7-b0f6-92283ca78336"), "Cafe" },
                    { new Guid("ce8723ac-34c9-42f5-81b6-ae8893093366"), "Fast Food" },
                    { new Guid("d200d27b-2dac-4767-ba68-b4dfe518db3f"), "Bar & Dinner" }
                });

            migrationBuilder.InsertData(
                table: "Cuisines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("22ed1454-5f7b-40ef-9639-429c70a5a910"), "Mediteranean" },
                    { new Guid("56f58d97-fc0f-418e-85fb-df46877817e8"), "Mexican" },
                    { new Guid("65cf7813-9d3f-4f96-b2a1-a1e9b6060e09"), "Japanese" },
                    { new Guid("8ceb2ede-5c13-43ac-bd91-1bc38c575e5c"), "Bulgarian" },
                    { new Guid("8e5f4b2d-6643-4e5a-af35-ac097620b470"), "French" },
                    { new Guid("938737e2-4e4d-470b-a3d6-3fcca86e4bea"), "Only drinks" },
                    { new Guid("c790dd04-f306-493e-b774-3dbc5c272663"), "Chinease" },
                    { new Guid("dd550d26-12c6-400a-b2e0-4b302ac690c5"), "Italian" }
                });

            migrationBuilder.InsertData(
                table: "RecepiesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("19011b10-5315-4f82-a487-28bed8fe6e4b"), "Dinner" },
                    { new Guid("3181a53a-2faa-4758-9b4d-b166189a48b4"), "Starter" },
                    { new Guid("51e185d3-7c81-4188-8fbd-08e4fc552767"), "Dessert" },
                    { new Guid("68bcd038-aef8-4618-be05-ea32309126a4"), "Breakfast" },
                    { new Guid("7798f180-ffc4-4ee0-a649-15797318834e"), "Lunch" },
                    { new Guid("7d08d52a-6e0c-4aa2-8131-bf3acc08ffd0"), "Side dish" },
                    { new Guid("935e38b1-4af6-4ec2-ad5f-a505f59e5358"), "Snack" }
                });
        }
    }
}
