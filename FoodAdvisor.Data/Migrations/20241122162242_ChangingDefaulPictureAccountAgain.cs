using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangingDefaulPictureAccountAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("086f6c2c-e726-4753-83ae-9ce493607dfe"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("55a54e42-0215-4ff1-b320-333ddc164d0f"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("8e8acbb0-161b-43a5-9a62-af1e17c8a2e9"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("bf94d541-c0da-4c45-a8bb-2dab58b5dbc1"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("c4bbe80b-04ae-4fb8-a766-d88487055ba5"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("eaf354da-3f24-448b-bc63-44c1015bd7a1"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("0ccbd527-0248-49d4-aeb2-abd07bca9a41"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("13682688-2eeb-4c04-bdef-84cc500498c3"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("1b14b3ba-5dea-4738-8a20-0062431898bd"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("4d1cff44-c09f-4a04-8c3c-e98d2c5adc7c"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("8fa7149c-7805-47d5-b5bc-12c1e7704bd4"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("afc5adb1-4201-4e21-ada0-c05beec8860f"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("c9bb4f98-f4f0-450c-8684-475c101d9aa7"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("eaf3bc8a-8987-480d-9e98-69585ca01a9c"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("0123fef5-d679-4bac-84a0-69442117a920"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("7d8bd8ed-c42e-4c2d-b866-c7677ca7368b"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("aae9877b-8d34-43f4-9fdb-4e9bb90d0a35"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("bd91cd58-02d6-4c41-9f3b-b3e6a769ec12"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("c467002f-aaad-49e7-a1cf-17f99bd22482"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("de21ad46-c3b4-4def-b3df-8c1efbe034cc"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f5e4e699-8fe2-4e5b-9338-8faf1965780c"));

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePricturePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "assets/img/no-pfp.png",
                comment: "Path for the Profile picture of the User.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "/assets/img/no-pfp.png",
                oldComment: "Path for the Profile picture of the User.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 22, 18, 22, 40, 523, DateTimeKind.Local).AddTicks(8566),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 22, 17, 29, 3, 228, DateTimeKind.Local).AddTicks(6034),
                oldComment: "Date of creation of the User.");

            //migrationBuilder.InsertData(
            //    table: "Categories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("4a49f2a3-1c52-449d-9967-262f40fd7163"), "Bakery" },
            //        { new Guid("6cd241ef-f942-4d17-b298-77a183c1f6c9"), "Restaurant" },
            //        { new Guid("7d44f2f1-99f9-428c-ac6b-92e8161f921b"), "Bistro" },
            //        { new Guid("a070a259-a932-40d7-b0f6-92283ca78336"), "Cafe" },
            //        { new Guid("ce8723ac-34c9-42f5-81b6-ae8893093366"), "Fast Food" },
            //        { new Guid("d200d27b-2dac-4767-ba68-b4dfe518db3f"), "Bar & Dinner" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Cuisines",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("22ed1454-5f7b-40ef-9639-429c70a5a910"), "Mediteranean" },
            //        { new Guid("56f58d97-fc0f-418e-85fb-df46877817e8"), "Mexican" },
            //        { new Guid("65cf7813-9d3f-4f96-b2a1-a1e9b6060e09"), "Japanese" },
            //        { new Guid("8ceb2ede-5c13-43ac-bd91-1bc38c575e5c"), "Bulgarian" },
            //        { new Guid("8e5f4b2d-6643-4e5a-af35-ac097620b470"), "French" },
            //        { new Guid("938737e2-4e4d-470b-a3d6-3fcca86e4bea"), "Only drinks" },
            //        { new Guid("c790dd04-f306-493e-b774-3dbc5c272663"), "Chinease" },
            //        { new Guid("dd550d26-12c6-400a-b2e0-4b302ac690c5"), "Italian" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "RecepiesCategories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("19011b10-5315-4f82-a487-28bed8fe6e4b"), "Dinner" },
            //        { new Guid("3181a53a-2faa-4758-9b4d-b166189a48b4"), "Starter" },
            //        { new Guid("51e185d3-7c81-4188-8fbd-08e4fc552767"), "Dessert" },
            //        { new Guid("68bcd038-aef8-4618-be05-ea32309126a4"), "Breakfast" },
            //        { new Guid("7798f180-ffc4-4ee0-a649-15797318834e"), "Lunch" },
            //        { new Guid("7d08d52a-6e0c-4aa2-8131-bf3acc08ffd0"), "Side dish" },
            //        { new Guid("935e38b1-4af6-4ec2-ad5f-a505f59e5358"), "Snack" }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePricturePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "/assets/img/no-pfp.png",
                comment: "Path for the Profile picture of the User.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "assets/img/no-pfp.png",
                oldComment: "Path for the Profile picture of the User.");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 22, 17, 29, 3, 228, DateTimeKind.Local).AddTicks(6034),
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
                    { new Guid("086f6c2c-e726-4753-83ae-9ce493607dfe"), "Cafe" },
                    { new Guid("55a54e42-0215-4ff1-b320-333ddc164d0f"), "Restaurant" },
                    { new Guid("8e8acbb0-161b-43a5-9a62-af1e17c8a2e9"), "Bistro" },
                    { new Guid("bf94d541-c0da-4c45-a8bb-2dab58b5dbc1"), "Fast Food" },
                    { new Guid("c4bbe80b-04ae-4fb8-a766-d88487055ba5"), "Bakery" },
                    { new Guid("eaf354da-3f24-448b-bc63-44c1015bd7a1"), "Bar & Dinner" }
                });

            migrationBuilder.InsertData(
                table: "Cuisines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0ccbd527-0248-49d4-aeb2-abd07bca9a41"), "Chinease" },
                    { new Guid("13682688-2eeb-4c04-bdef-84cc500498c3"), "Bulgarian" },
                    { new Guid("1b14b3ba-5dea-4738-8a20-0062431898bd"), "Only drinks" },
                    { new Guid("4d1cff44-c09f-4a04-8c3c-e98d2c5adc7c"), "Italian" },
                    { new Guid("8fa7149c-7805-47d5-b5bc-12c1e7704bd4"), "Mediteranean" },
                    { new Guid("afc5adb1-4201-4e21-ada0-c05beec8860f"), "French" },
                    { new Guid("c9bb4f98-f4f0-450c-8684-475c101d9aa7"), "Japanese" },
                    { new Guid("eaf3bc8a-8987-480d-9e98-69585ca01a9c"), "Mexican" }
                });

            migrationBuilder.InsertData(
                table: "RecepiesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0123fef5-d679-4bac-84a0-69442117a920"), "Breakfast" },
                    { new Guid("7d8bd8ed-c42e-4c2d-b866-c7677ca7368b"), "Dessert" },
                    { new Guid("aae9877b-8d34-43f4-9fdb-4e9bb90d0a35"), "Side dish" },
                    { new Guid("bd91cd58-02d6-4c41-9f3b-b3e6a769ec12"), "Lunch" },
                    { new Guid("c467002f-aaad-49e7-a1cf-17f99bd22482"), "Dinner" },
                    { new Guid("de21ad46-c3b4-4def-b3df-8c1efbe034cc"), "Starter" },
                    { new Guid("f5e4e699-8fe2-4e5b-9338-8faf1965780c"), "Snack" }
                });
        }
    }
}
