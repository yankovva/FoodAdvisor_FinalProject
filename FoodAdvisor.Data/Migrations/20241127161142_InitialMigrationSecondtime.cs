using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationSecondtime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("2dc2e9f1-95af-43c1-8958-a903beb092a5"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("4cbe607a-df66-45f3-8c03-2767132282d7"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("50336104-b15d-41a9-91ca-f4fdcd7b5219"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("5768088c-2b30-456a-974f-2ae91db5370f"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("93e36610-87d4-4dd5-aa75-c62b591e6bdf"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("e7a8353d-3cb5-4edc-98c6-3a877e6ec165"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("3224871d-306a-4ced-aed2-47c93cdd213b"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("3d1390a6-f4f6-40ab-ae10-4fa4cc740ada"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("3e11fef3-dec2-46a8-9626-90ecee2b40c7"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("6e845001-ed0c-49cd-b3c4-9b4268b6e003"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("6f128966-f8fd-4aca-a8ec-297655c07232"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("8e234917-fac5-42f1-bee4-1585a370eaa4"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("bb984f6f-fd07-40f5-808c-29e2b62dde26"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f5aaef23-e1f1-4e90-846e-df9327ce2d03"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("321984a8-7c5f-4dc9-9be7-210341e7bb81"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("64b375f9-3027-4e5d-b6b4-79ad31def9aa"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("6e5ab054-0ac3-4a47-a1af-cc2e5c3855d2"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("b301a004-9548-4b59-a4e5-0054006c97be"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("dbe55f84-44db-485e-b44f-a7c53a6cba66"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("e8d3ad72-5f65-4130-9a6d-4315a88792a3"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f8f63f96-5b47-46e9-b8ed-685f028df269"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 27, 18, 11, 40, 150, DateTimeKind.Local).AddTicks(1892),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 27, 18, 2, 13, 884, DateTimeKind.Local).AddTicks(4031),
                oldComment: "Date of creation of the User.");

            //migrationBuilder.InsertData(
            //    table: "Categories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("0958bc87-5971-4637-b8dc-526eca676ca3"), "Cafe" },
            //        { new Guid("1c339593-b820-4f9f-af8a-63dd825e7ba8"), "Bistro" },
            //        { new Guid("1dbfde57-e106-47ad-9308-796905286284"), "Bar & Dinner" },
            //        { new Guid("3aecc994-908a-4eb6-9b07-0426bfdca82c"), "Restaurant" },
            //        { new Guid("5be98fc1-4b6c-4914-a8b0-495fe59a0aac"), "Fast Food" },
            //        { new Guid("dd9a1047-8d6c-43b4-b5e3-618feea36d2c"), "Bakery" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Cuisines",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("09211d2b-eefa-43b2-a1ec-d9c7b130e8fd"), "Mediteranean" },
            //        { new Guid("22ea26c3-d86e-40f2-acb7-6e3df34d1188"), "Italian" },
            //        { new Guid("35480bc6-20fe-43be-83bd-d3cf6fb988c7"), "Japanese" },
            //        { new Guid("4427cbdf-fdcd-4d6d-a3e2-8f3680a069b1"), "Only drinks" },
            //        { new Guid("4c41900f-54d6-4719-93ae-7bea7bf82c5f"), "French" },
            //        { new Guid("aaafce16-3805-4b41-871f-37720f897168"), "Bulgarian" },
            //        { new Guid("e76666a6-9f96-4514-825d-29ddc11d3168"), "Chinease" },
            //        { new Guid("ea8282cf-c315-4859-bba6-9884fd7320d1"), "Mexican" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "RecepiesCategories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("1cfbda7e-3876-4929-84f4-4a558ba28a26"), "Lunch" },
            //        { new Guid("25776863-a10a-4b05-90a5-7c2b5c12083e"), "Dessert" },
            //        { new Guid("34623df8-e251-4379-85bf-826c1285be72"), "Breakfast" },
            //        { new Guid("3dd42454-f617-4215-a385-55460dbe34f8"), "Snack" },
            //        { new Guid("48fd8143-018e-49b1-bf34-61b763e83aa6"), "Dinner" },
            //        { new Guid("7731ee90-1ebf-4ce1-a2e1-e5c7dd73c24b"), "Starter" },
            //        { new Guid("8efe17a0-f1dd-4503-9884-c238d6a94139"), "Side dish" }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0958bc87-5971-4637-b8dc-526eca676ca3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1c339593-b820-4f9f-af8a-63dd825e7ba8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1dbfde57-e106-47ad-9308-796905286284"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3aecc994-908a-4eb6-9b07-0426bfdca82c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5be98fc1-4b6c-4914-a8b0-495fe59a0aac"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dd9a1047-8d6c-43b4-b5e3-618feea36d2c"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("09211d2b-eefa-43b2-a1ec-d9c7b130e8fd"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("22ea26c3-d86e-40f2-acb7-6e3df34d1188"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("35480bc6-20fe-43be-83bd-d3cf6fb988c7"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("4427cbdf-fdcd-4d6d-a3e2-8f3680a069b1"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("4c41900f-54d6-4719-93ae-7bea7bf82c5f"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("aaafce16-3805-4b41-871f-37720f897168"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("e76666a6-9f96-4514-825d-29ddc11d3168"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("ea8282cf-c315-4859-bba6-9884fd7320d1"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("1cfbda7e-3876-4929-84f4-4a558ba28a26"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("25776863-a10a-4b05-90a5-7c2b5c12083e"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("34623df8-e251-4379-85bf-826c1285be72"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("3dd42454-f617-4215-a385-55460dbe34f8"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("48fd8143-018e-49b1-bf34-61b763e83aa6"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("7731ee90-1ebf-4ce1-a2e1-e5c7dd73c24b"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("8efe17a0-f1dd-4503-9884-c238d6a94139"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 27, 18, 2, 13, 884, DateTimeKind.Local).AddTicks(4031),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 27, 18, 11, 40, 150, DateTimeKind.Local).AddTicks(1892),
                oldComment: "Date of creation of the User.");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2dc2e9f1-95af-43c1-8958-a903beb092a5"), "Bar & Dinner" },
                    { new Guid("4cbe607a-df66-45f3-8c03-2767132282d7"), "Cafe" },
                    { new Guid("50336104-b15d-41a9-91ca-f4fdcd7b5219"), "Fast Food" },
                    { new Guid("5768088c-2b30-456a-974f-2ae91db5370f"), "Restaurant" },
                    { new Guid("93e36610-87d4-4dd5-aa75-c62b591e6bdf"), "Bistro" },
                    { new Guid("e7a8353d-3cb5-4edc-98c6-3a877e6ec165"), "Bakery" }
                });

            migrationBuilder.InsertData(
                table: "Cuisines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3224871d-306a-4ced-aed2-47c93cdd213b"), "Japanese" },
                    { new Guid("3d1390a6-f4f6-40ab-ae10-4fa4cc740ada"), "Mediteranean" },
                    { new Guid("3e11fef3-dec2-46a8-9626-90ecee2b40c7"), "Bulgarian" },
                    { new Guid("6e845001-ed0c-49cd-b3c4-9b4268b6e003"), "Only drinks" },
                    { new Guid("6f128966-f8fd-4aca-a8ec-297655c07232"), "French" },
                    { new Guid("8e234917-fac5-42f1-bee4-1585a370eaa4"), "Italian" },
                    { new Guid("bb984f6f-fd07-40f5-808c-29e2b62dde26"), "Chinease" },
                    { new Guid("f5aaef23-e1f1-4e90-846e-df9327ce2d03"), "Mexican" }
                });

            migrationBuilder.InsertData(
                table: "RecepiesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("321984a8-7c5f-4dc9-9be7-210341e7bb81"), "Lunch" },
                    { new Guid("64b375f9-3027-4e5d-b6b4-79ad31def9aa"), "Side dish" },
                    { new Guid("6e5ab054-0ac3-4a47-a1af-cc2e5c3855d2"), "Breakfast" },
                    { new Guid("b301a004-9548-4b59-a4e5-0054006c97be"), "Snack" },
                    { new Guid("dbe55f84-44db-485e-b44f-a7c53a6cba66"), "Starter" },
                    { new Guid("e8d3ad72-5f65-4130-9a6d-4315a88792a3"), "Dessert" },
                    { new Guid("f8f63f96-5b47-46e9-b8ed-685f028df269"), "Dinner" }
                });
        }
    }
}
