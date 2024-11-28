using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangingDefaulPictureAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("091ff470-c970-41ef-b368-b16b0aa4c959"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("17b226b9-f4bc-4d8e-8b18-6bd9b2e7ab27"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("45d8cb81-0ab7-45f2-8227-3255ec39a28c"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("75220d4b-0e83-4815-bec2-4b5778b8dc86"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("bd7ca129-f37c-424a-85c2-8e0bc0858af1"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("ee0a65df-54ac-4be5-ba3e-724348f8d76c"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("2a935cc1-6ecb-4515-890c-bd13f5c2d1a8"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("364e6f4f-dcf4-49f0-a322-cbdba4758017"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("48dbdc79-02e1-402e-86e1-725a81edabd2"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("7baebda0-3bfe-48e3-8ea9-76defca6c512"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("a5bb0368-f449-4a06-9fc4-8f45f951185f"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("c70e3310-90ea-49e8-b2eb-75825ad99612"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("e1c21838-f415-42d3-8cdf-7ba6cbd2241e"));

            //migrationBuilder.DeleteData(
            //    table: "Cuisines",
            //    keyColumn: "Id",
            //    keyValue: new Guid("ee8bab9e-9b45-4d76-a13e-13384b988078"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("4b6a29e6-81aa-4578-b5a9-d270cd25fdba"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("5e1c73fd-fc63-4d88-9549-6aacf92e203c"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("730a7a36-ac02-49e6-ba00-064c16def614"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("9338faa0-5dc7-4485-ae6d-73bf53a7e839"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("a01e44e4-a3c4-4c9a-aab1-0e0a0bc3728b"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("bbf31729-851f-46e4-a29b-5fb9f40bd589"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("bf29ae9e-be81-4655-a829-0aab2bf7decf"));

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePricturePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "/assets/img/no-pfp.png",
                comment: "Path for the Profile picture of the User.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "/assets/img/no-image-account.jfif",
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
                oldDefaultValue: new DateTime(2024, 11, 22, 16, 0, 29, 869, DateTimeKind.Local).AddTicks(4214),
                oldComment: "Date of creation of the User.");

            //migrationBuilder.InsertData(
            //    table: "Categories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("086f6c2c-e726-4753-83ae-9ce493607dfe"), "Cafe" },
            //        { new Guid("55a54e42-0215-4ff1-b320-333ddc164d0f"), "Restaurant" },
            //        { new Guid("8e8acbb0-161b-43a5-9a62-af1e17c8a2e9"), "Bistro" },
            //        { new Guid("bf94d541-c0da-4c45-a8bb-2dab58b5dbc1"), "Fast Food" },
            //        { new Guid("c4bbe80b-04ae-4fb8-a766-d88487055ba5"), "Bakery" },
            //        { new Guid("eaf354da-3f24-448b-bc63-44c1015bd7a1"), "Bar & Dinner" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Cuisines",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("0ccbd527-0248-49d4-aeb2-abd07bca9a41"), "Chinease" },
            //        { new Guid("13682688-2eeb-4c04-bdef-84cc500498c3"), "Bulgarian" },
            //        { new Guid("1b14b3ba-5dea-4738-8a20-0062431898bd"), "Only drinks" },
            //        { new Guid("4d1cff44-c09f-4a04-8c3c-e98d2c5adc7c"), "Italian" },
            //        { new Guid("8fa7149c-7805-47d5-b5bc-12c1e7704bd4"), "Mediteranean" },
            //        { new Guid("afc5adb1-4201-4e21-ada0-c05beec8860f"), "French" },
            //        { new Guid("c9bb4f98-f4f0-450c-8684-475c101d9aa7"), "Japanese" },
            //        { new Guid("eaf3bc8a-8987-480d-9e98-69585ca01a9c"), "Mexican" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "RecepiesCategories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("0123fef5-d679-4bac-84a0-69442117a920"), "Breakfast" },
            //        { new Guid("7d8bd8ed-c42e-4c2d-b866-c7677ca7368b"), "Dessert" },
            //        { new Guid("aae9877b-8d34-43f4-9fdb-4e9bb90d0a35"), "Side dish" },
            //        { new Guid("bd91cd58-02d6-4c41-9f3b-b3e6a769ec12"), "Lunch" },
            //        { new Guid("c467002f-aaad-49e7-a1cf-17f99bd22482"), "Dinner" },
            //        { new Guid("de21ad46-c3b4-4def-b3df-8c1efbe034cc"), "Starter" },
            //        { new Guid("f5e4e699-8fe2-4e5b-9338-8faf1965780c"), "Snack" }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("086f6c2c-e726-4753-83ae-9ce493607dfe"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("55a54e42-0215-4ff1-b320-333ddc164d0f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8e8acbb0-161b-43a5-9a62-af1e17c8a2e9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bf94d541-c0da-4c45-a8bb-2dab58b5dbc1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c4bbe80b-04ae-4fb8-a766-d88487055ba5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eaf354da-3f24-448b-bc63-44c1015bd7a1"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("0ccbd527-0248-49d4-aeb2-abd07bca9a41"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("13682688-2eeb-4c04-bdef-84cc500498c3"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("1b14b3ba-5dea-4738-8a20-0062431898bd"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("4d1cff44-c09f-4a04-8c3c-e98d2c5adc7c"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("8fa7149c-7805-47d5-b5bc-12c1e7704bd4"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("afc5adb1-4201-4e21-ada0-c05beec8860f"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("c9bb4f98-f4f0-450c-8684-475c101d9aa7"));

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("eaf3bc8a-8987-480d-9e98-69585ca01a9c"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("0123fef5-d679-4bac-84a0-69442117a920"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("7d8bd8ed-c42e-4c2d-b866-c7677ca7368b"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("aae9877b-8d34-43f4-9fdb-4e9bb90d0a35"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("bd91cd58-02d6-4c41-9f3b-b3e6a769ec12"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("c467002f-aaad-49e7-a1cf-17f99bd22482"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("de21ad46-c3b4-4def-b3df-8c1efbe034cc"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("f5e4e699-8fe2-4e5b-9338-8faf1965780c"));

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePricturePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "/assets/img/no-image-account.jfif",
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
                defaultValue: new DateTime(2024, 11, 22, 16, 0, 29, 869, DateTimeKind.Local).AddTicks(4214),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 22, 17, 29, 3, 228, DateTimeKind.Local).AddTicks(6034),
                oldComment: "Date of creation of the User.");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("091ff470-c970-41ef-b368-b16b0aa4c959"), "Bistro" },
                    { new Guid("17b226b9-f4bc-4d8e-8b18-6bd9b2e7ab27"), "Bakery" },
                    { new Guid("45d8cb81-0ab7-45f2-8227-3255ec39a28c"), "Fast Food" },
                    { new Guid("75220d4b-0e83-4815-bec2-4b5778b8dc86"), "Bar & Dinner" },
                    { new Guid("bd7ca129-f37c-424a-85c2-8e0bc0858af1"), "Cafe" },
                    { new Guid("ee0a65df-54ac-4be5-ba3e-724348f8d76c"), "Restaurant" }
                });

            migrationBuilder.InsertData(
                table: "Cuisines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2a935cc1-6ecb-4515-890c-bd13f5c2d1a8"), "Mexican" },
                    { new Guid("364e6f4f-dcf4-49f0-a322-cbdba4758017"), "Japanese" },
                    { new Guid("48dbdc79-02e1-402e-86e1-725a81edabd2"), "Chinease" },
                    { new Guid("7baebda0-3bfe-48e3-8ea9-76defca6c512"), "Bulgarian" },
                    { new Guid("a5bb0368-f449-4a06-9fc4-8f45f951185f"), "Only drinks" },
                    { new Guid("c70e3310-90ea-49e8-b2eb-75825ad99612"), "Mediteranean" },
                    { new Guid("e1c21838-f415-42d3-8cdf-7ba6cbd2241e"), "Italian" },
                    { new Guid("ee8bab9e-9b45-4d76-a13e-13384b988078"), "French" }
                });

            migrationBuilder.InsertData(
                table: "RecepiesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4b6a29e6-81aa-4578-b5a9-d270cd25fdba"), "Side dish" },
                    { new Guid("5e1c73fd-fc63-4d88-9549-6aacf92e203c"), "Dinner" },
                    { new Guid("730a7a36-ac02-49e6-ba00-064c16def614"), "Snack" },
                    { new Guid("9338faa0-5dc7-4485-ae6d-73bf53a7e839"), "Starter" },
                    { new Guid("a01e44e4-a3c4-4c9a-aab1-0e0a0bc3728b"), "Breakfast" },
                    { new Guid("bbf31729-851f-46e4-a29b-5fb9f40bd589"), "Dessert" },
                    { new Guid("bf29ae9e-be81-4655-a829-0aab2bf7decf"), "Lunch" }
                });
        }
    }
}
