using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Countries_CityId",
                table: "Places");

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("6d25b351-7673-4bbb-b19d-28c1c598256b"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("9a57877e-7066-4107-802c-d82604d51257"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("a71ed52b-20c0-49ba-9dde-3078f439096b"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("b165837b-b714-468f-abd7-7c7c127efec4"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("cd97169f-1a58-43bb-94d4-545b916b26e2"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("dce529cd-6539-4581-ba9e-87a7836a34ad"));

            //migrationBuilder.InsertData(
            //    table: "Categories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("073d9d04-bbaf-4b28-a2b6-9a512c091103"), "Bakery" },
            //        { new Guid("74914725-016f-46e4-9125-028a9e2164e2"), "Bar & Dinner" },
            //        { new Guid("9807e338-d261-45bb-8259-c87defa289ab"), "Restaurant" },
            //        { new Guid("bdba7005-4063-4814-8279-7b1f767677e3"), "Bistro" },
            //        { new Guid("e5884382-4b5a-4abf-bf4e-c01ff88dedb2"), "Cafe" },
            //        { new Guid("f7997730-4fa6-49c5-8056-d7f6d8313c76"), "Fast Food" }
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_Places_ConutryId",
                table: "Places",
                column: "ConutryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Countries_ConutryId",
                table: "Places",
                column: "ConutryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Countries_ConutryId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_ConutryId",
                table: "Places");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("073d9d04-bbaf-4b28-a2b6-9a512c091103"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("74914725-016f-46e4-9125-028a9e2164e2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9807e338-d261-45bb-8259-c87defa289ab"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bdba7005-4063-4814-8279-7b1f767677e3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e5884382-4b5a-4abf-bf4e-c01ff88dedb2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f7997730-4fa6-49c5-8056-d7f6d8313c76"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6d25b351-7673-4bbb-b19d-28c1c598256b"), "Fast Food" },
                    { new Guid("9a57877e-7066-4107-802c-d82604d51257"), "Cafe" },
                    { new Guid("a71ed52b-20c0-49ba-9dde-3078f439096b"), "Bakery" },
                    { new Guid("b165837b-b714-468f-abd7-7c7c127efec4"), "Bar & Dinner" },
                    { new Guid("cd97169f-1a58-43bb-94d4-545b916b26e2"), "Bistro" },
                    { new Guid("dce529cd-6539-4581-ba9e-87a7836a34ad"), "Restaurant" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Countries_CityId",
                table: "Places",
                column: "CityId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
