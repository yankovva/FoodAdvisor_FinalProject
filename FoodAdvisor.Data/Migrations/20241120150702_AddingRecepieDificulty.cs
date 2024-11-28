using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAdvisor.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingRecepieDificulty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("289750e0-17cb-4681-a3ba-2057dc0e86d2"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("41213f4b-e9c9-45ee-ac37-6a47dc4dc8a0"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("4869320a-bb30-43fa-baf8-e71f013978ca"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("6da74f82-3448-4d7b-8457-816853e2b666"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("acdfab1e-9197-4c3a-a301-b8dcf4ce3e75"));

            //migrationBuilder.DeleteData(
            //    table: "Categories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("b61dd991-b59d-4173-b4c0-5adc4cf597d6"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("23bb004f-4f23-493c-9b0c-6dd69bcdae3f"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("2655a31f-33f8-4852-8694-83d158acd6e8"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("28c79765-468f-4be6-94f4-f85bf52fa725"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("298ff35e-a4a3-4f04-b9ca-777e8eb4a6d7"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("3ee613a2-d0f2-47e4-9abc-ce4d4be546d9"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("87801996-60f9-4ddc-9fe7-5e48cb10283d"));

            //migrationBuilder.DeleteData(
            //    table: "RecepiesCategories",
            //    keyColumn: "Id",
            //    keyValue: new Guid("ef806b71-2b9e-494d-a8ff-26df6fb7a8e5"));

            migrationBuilder.AddColumn<int>(
                name: "RecepieDificultyId",
                table: "Recepies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 20, 17, 7, 0, 846, DateTimeKind.Local).AddTicks(5704),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 19, 12, 2, 59, 868, DateTimeKind.Local).AddTicks(8488),
                oldComment: "Date of creation of the User.");

            migrationBuilder.CreateTable(
                name: "RecepiesDificulties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The idemtifier of the Recepie Dificulty.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DificultyName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The name of the Recepie dificulty level.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecepiesDificulties", x => x.Id);
                });

            //migrationBuilder.InsertData(
            //    table: "Categories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("43c7cd7f-d32c-452e-a932-78cc37cbdfcc"), "Bistro" },
            //        { new Guid("73083fb7-455d-41b7-9c34-8fe87b92aa3f"), "Fast Food" },
            //        { new Guid("7cc4a429-8997-4802-ba86-90d1c56ee771"), "Bar & Dinner" },
            //        { new Guid("ad0e24a5-94e7-4a26-9ab9-36c1c5069cd1"), "Restaurant" },
            //        { new Guid("f3cb1412-bc32-48a3-ac7e-2713120b103b"), "Cafe" },
            //        { new Guid("fecf9278-e9ed-449e-8f6e-9226a1ac7def"), "Bakery" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "RecepiesCategories",
            //    columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { new Guid("1c5356e9-42eb-448a-ae5a-b7ce030675cc"), "Lunch" },
            //        { new Guid("30fd10af-428a-424a-8a7e-89a4efe6ed75"), "Breakfast" },
            //        { new Guid("82c03683-306f-44b8-b931-260c50da0932"), "Snack" },
            //        { new Guid("b1e90944-8cbf-4041-8f93-eee9f74418c5"), "Side dish" },
            //        { new Guid("c18cf9b8-1aa4-4b9d-b625-be47e5d94b68"), "Dinner" },
            //        { new Guid("d0f083f1-1335-46f9-872c-c408edb4eb85"), "Starter" },
            //        { new Guid("d6e411a3-33d7-4e81-b654-ae53602fe238"), "Dessert" }
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_Recepies_RecepieDificultyId",
                table: "Recepies",
                column: "RecepieDificultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recepies_RecepiesDificulties_RecepieDificultyId",
                table: "Recepies",
                column: "RecepieDificultyId",
                principalTable: "RecepiesDificulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recepies_RecepiesDificulties_RecepieDificultyId",
                table: "Recepies");

            migrationBuilder.DropTable(
                name: "RecepiesDificulties");

            migrationBuilder.DropIndex(
                name: "IX_Recepies_RecepieDificultyId",
                table: "Recepies");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("43c7cd7f-d32c-452e-a932-78cc37cbdfcc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("73083fb7-455d-41b7-9c34-8fe87b92aa3f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7cc4a429-8997-4802-ba86-90d1c56ee771"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ad0e24a5-94e7-4a26-9ab9-36c1c5069cd1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f3cb1412-bc32-48a3-ac7e-2713120b103b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fecf9278-e9ed-449e-8f6e-9226a1ac7def"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("1c5356e9-42eb-448a-ae5a-b7ce030675cc"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("30fd10af-428a-424a-8a7e-89a4efe6ed75"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("82c03683-306f-44b8-b931-260c50da0932"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("b1e90944-8cbf-4041-8f93-eee9f74418c5"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("c18cf9b8-1aa4-4b9d-b625-be47e5d94b68"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("d0f083f1-1335-46f9-872c-c408edb4eb85"));

            migrationBuilder.DeleteData(
                table: "RecepiesCategories",
                keyColumn: "Id",
                keyValue: new Guid("d6e411a3-33d7-4e81-b654-ae53602fe238"));

            migrationBuilder.DropColumn(
                name: "RecepieDificultyId",
                table: "Recepies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Createdon",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 19, 12, 2, 59, 868, DateTimeKind.Local).AddTicks(8488),
                comment: "Date of creation of the User.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 20, 17, 7, 0, 846, DateTimeKind.Local).AddTicks(5704),
                oldComment: "Date of creation of the User.");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("289750e0-17cb-4681-a3ba-2057dc0e86d2"), "Restaurant" },
                    { new Guid("41213f4b-e9c9-45ee-ac37-6a47dc4dc8a0"), "Fast Food" },
                    { new Guid("4869320a-bb30-43fa-baf8-e71f013978ca"), "Bar & Dinner" },
                    { new Guid("6da74f82-3448-4d7b-8457-816853e2b666"), "Cafe" },
                    { new Guid("acdfab1e-9197-4c3a-a301-b8dcf4ce3e75"), "Bistro" },
                    { new Guid("b61dd991-b59d-4173-b4c0-5adc4cf597d6"), "Bakery" }
                });

            migrationBuilder.InsertData(
                table: "RecepiesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("23bb004f-4f23-493c-9b0c-6dd69bcdae3f"), "Dinner" },
                    { new Guid("2655a31f-33f8-4852-8694-83d158acd6e8"), "Snack" },
                    { new Guid("28c79765-468f-4be6-94f4-f85bf52fa725"), "Side dish" },
                    { new Guid("298ff35e-a4a3-4f04-b9ca-777e8eb4a6d7"), "Starter" },
                    { new Guid("3ee613a2-d0f2-47e4-9abc-ce4d4be546d9"), "Dessert" },
                    { new Guid("87801996-60f9-4ddc-9fe7-5e48cb10283d"), "Breakfast" },
                    { new Guid("ef806b71-2b9e-494d-a8ff-26df6fb7a8e5"), "Lunch" }
                });
        }
    }
}
