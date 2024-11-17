using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovePropertiDescriptionFromOffers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("16f69e39-6499-4280-8199-f04d3b9960d1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2ed91a7a-c4ee-40c8-b447-23a8f51f5904"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5a79f4bf-9f08-456f-a465-d32e99cba6a1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5bc4ddca-8668-4890-88b6-dffb8be3ad6b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("81ce99b6-7749-4ce0-a312-8dbd938a7051"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("adb051b4-3bdc-43f0-a50a-fbddc0f2a303"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b1284e8d-6406-4cb5-81df-f0e41fea1c11"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cdf6df2c-1b60-4ba0-9154-7aa00dc02260"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e2617e2e-f568-466b-8300-3b0a3890bb20"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f367660b-d42b-4380-873d-fb86e2ab0eb7"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("373fdbfe-5aa1-4eb5-8ab5-434fe146d8d4"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("4e66bc91-c9d0-485c-a7e9-fc5a1fc151d0"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("6221f9d8-1a11-4239-ada4-5649952c5fca"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("80833f31-b956-47f4-baa4-5e2ae2e92d9c"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("978238c8-da3b-407f-85ba-7ba0dd038932"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("d8c03bef-1015-4705-9a84-f3fa61f1b7b7"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Offers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 17, 17, 38, 59, 673, DateTimeKind.Local).AddTicks(1740),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 17, 16, 9, 40, 139, DateTimeKind.Local).AddTicks(7760),
                oldComment: "Date of user registration");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("18747b3c-3cc7-49fd-92bc-692df73bf454"), "Пътуваня и дестинации" },
                    { new Guid("237ce0e0-2e4e-4152-890d-3710e45eb6a7"), "Природа" },
                    { new Guid("36afbdb5-b8fa-44d4-846d-6eb855663ec7"), "Черно-бяла фотография" },
                    { new Guid("4e48afe5-ea7b-4326-98fe-aad942f8645e"), "Животни" },
                    { new Guid("69dbcbb8-8e36-4428-ab00-90d7b486354a"), "Пейзажи" },
                    { new Guid("708a1b71-0aab-4de5-af66-d24d28a1421b"), "Храна и напитки" },
                    { new Guid("913ad1fd-42e3-480b-be33-e6ea10246ce0"), "Мода" },
                    { new Guid("a1bec8fa-74eb-4c08-96d6-9ae81edcd681"), "Спорт" },
                    { new Guid("b81e73c3-3696-4766-b8db-58a184d878af"), "Архитектура" },
                    { new Guid("c75031cc-f57c-4772-96cf-d6732a05baac"), "Семейна фотография" }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("318b253a-1775-4d2b-b240-75b8e4d158cb"), "Печат на снимка в размер 10x15", 0.45m },
                    { new Guid("702c599e-b44a-4dfb-8c39-e6b438e293d9"), "Печат на снимка в размер 13x18", 1.20m },
                    { new Guid("7aa4d498-8ae3-4c67-b9e7-1331c262f9cd"), "Печат на снимка върху тениска", 18m },
                    { new Guid("a83b7742-389a-4e1a-9e52-34cea7b79831"), "Печат на снимка в размер 9х13", 0.40m },
                    { new Guid("cf26f078-f9f9-48bc-9a9d-daab57b2a481"), "Печат на снимка в размер А4", 2.00m },
                    { new Guid("f2fc7493-e05a-47ce-ade2-70f75aa00234"), "Печат на снимка върху чаша", 12.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("18747b3c-3cc7-49fd-92bc-692df73bf454"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("237ce0e0-2e4e-4152-890d-3710e45eb6a7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("36afbdb5-b8fa-44d4-846d-6eb855663ec7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4e48afe5-ea7b-4326-98fe-aad942f8645e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("69dbcbb8-8e36-4428-ab00-90d7b486354a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("708a1b71-0aab-4de5-af66-d24d28a1421b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("913ad1fd-42e3-480b-be33-e6ea10246ce0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a1bec8fa-74eb-4c08-96d6-9ae81edcd681"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b81e73c3-3696-4766-b8db-58a184d878af"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c75031cc-f57c-4772-96cf-d6732a05baac"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("318b253a-1775-4d2b-b240-75b8e4d158cb"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("702c599e-b44a-4dfb-8c39-e6b438e293d9"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("7aa4d498-8ae3-4c67-b9e7-1331c262f9cd"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("a83b7742-389a-4e1a-9e52-34cea7b79831"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("cf26f078-f9f9-48bc-9a9d-daab57b2a481"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("f2fc7493-e05a-47ce-ade2-70f75aa00234"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Offers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "Offer description");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 17, 16, 9, 40, 139, DateTimeKind.Local).AddTicks(7760),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 17, 17, 38, 59, 673, DateTimeKind.Local).AddTicks(1740),
                oldComment: "Date of user registration");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("16f69e39-6499-4280-8199-f04d3b9960d1"), "Пейзажи" },
                    { new Guid("2ed91a7a-c4ee-40c8-b447-23a8f51f5904"), "Семейна фотография" },
                    { new Guid("5a79f4bf-9f08-456f-a465-d32e99cba6a1"), "Пътуваня и дестинации" },
                    { new Guid("5bc4ddca-8668-4890-88b6-dffb8be3ad6b"), "Архитектура" },
                    { new Guid("81ce99b6-7749-4ce0-a312-8dbd938a7051"), "Животни" },
                    { new Guid("adb051b4-3bdc-43f0-a50a-fbddc0f2a303"), "Черно-бяла фотография" },
                    { new Guid("b1284e8d-6406-4cb5-81df-f0e41fea1c11"), "Природа" },
                    { new Guid("cdf6df2c-1b60-4ba0-9154-7aa00dc02260"), "Храна и напитки" },
                    { new Guid("e2617e2e-f568-466b-8300-3b0a3890bb20"), "Спорт" },
                    { new Guid("f367660b-d42b-4380-873d-fb86e2ab0eb7"), "Мода" }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("373fdbfe-5aa1-4eb5-8ab5-434fe146d8d4"), null, "Печат на снимка в размер 13x18", 1.20m },
                    { new Guid("4e66bc91-c9d0-485c-a7e9-fc5a1fc151d0"), null, "Печат на снимка в размер А4", 2.00m },
                    { new Guid("6221f9d8-1a11-4239-ada4-5649952c5fca"), "Възможни са различни размери", "Печат на снимка върху тениска", 18m },
                    { new Guid("80833f31-b956-47f4-baa4-5e2ae2e92d9c"), null, "Печат на снимка в размер 9х13", 0.40m },
                    { new Guid("978238c8-da3b-407f-85ba-7ba0dd038932"), null, "Печат на снимка в размер 10x15", 0.45m },
                    { new Guid("d8c03bef-1015-4705-9a84-f3fa61f1b7b7"), null, "Печат на снимка върху чаша", 12.00m }
                });
        }
    }
}
