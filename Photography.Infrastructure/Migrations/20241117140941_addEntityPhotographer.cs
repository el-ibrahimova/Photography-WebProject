using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addEntityPhotographer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("12bb2780-7894-49d0-a62c-003cf2f57bb9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("17436b90-b536-48b5-b0df-d9501687089f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("35979756-91c1-4ad8-985a-8e078a077db5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6eb17588-884c-4874-9adf-df54da20ad16"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("886e1930-df9b-4fe9-bb22-2268bf920065"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9f079124-5d71-4a4d-9e59-e8e49fd9cb09"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bcc288d1-dc27-48d7-8615-301dd8508ab3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c125c138-6659-4a06-9b25-9c1632e0a98c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cd11b5be-d4f5-4a61-b920-b8c4dd4da1c0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f3719d8c-2619-4c6d-8655-6c3f2805db87"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("7e9dd99b-ab3e-49b7-a609-06c713076a33"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("8784f6a9-7ec7-450e-ac1b-7efcf48ea1b3"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("be5b0995-c7bc-48c4-8fd6-e6db847c71f7"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("bf1eb655-30ab-4731-88d3-308dbfeb5339"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("d5b8c1ec-ea23-4cf4-b099-f9f21253d59b"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("da35988a-f4ab-4ed8-88e1-02c7976e450e"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 17, 16, 9, 40, 139, DateTimeKind.Local).AddTicks(7760),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 17, 12, 39, 5, 3, DateTimeKind.Local).AddTicks(439),
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 17, 12, 39, 5, 3, DateTimeKind.Local).AddTicks(439),
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
                    { new Guid("12bb2780-7894-49d0-a62c-003cf2f57bb9"), "Храна и напитки" },
                    { new Guid("17436b90-b536-48b5-b0df-d9501687089f"), "Животни" },
                    { new Guid("35979756-91c1-4ad8-985a-8e078a077db5"), "Природа" },
                    { new Guid("6eb17588-884c-4874-9adf-df54da20ad16"), "Пейзажи" },
                    { new Guid("886e1930-df9b-4fe9-bb22-2268bf920065"), "Черно-бяла фотография" },
                    { new Guid("9f079124-5d71-4a4d-9e59-e8e49fd9cb09"), "Мода" },
                    { new Guid("bcc288d1-dc27-48d7-8615-301dd8508ab3"), "Пътуваня и дестинации" },
                    { new Guid("c125c138-6659-4a06-9b25-9c1632e0a98c"), "Архитектура" },
                    { new Guid("cd11b5be-d4f5-4a61-b920-b8c4dd4da1c0"), "Спорт" },
                    { new Guid("f3719d8c-2619-4c6d-8655-6c3f2805db87"), "Семейна фотография" }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("7e9dd99b-ab3e-49b7-a609-06c713076a33"), null, "Печат на снимка в размер 10x15", 0.45m },
                    { new Guid("8784f6a9-7ec7-450e-ac1b-7efcf48ea1b3"), null, "Печат на снимка в размер 13x18", 1.20m },
                    { new Guid("be5b0995-c7bc-48c4-8fd6-e6db847c71f7"), null, "Печат на снимка в размер А4", 2.00m },
                    { new Guid("bf1eb655-30ab-4731-88d3-308dbfeb5339"), null, "Печат на снимка в размер 9х13", 0.40m },
                    { new Guid("d5b8c1ec-ea23-4cf4-b099-f9f21253d59b"), null, "Печат на снимка върху чаша", 12.00m },
                    { new Guid("da35988a-f4ab-4ed8-88e1-02c7976e450e"), "Възможни са различни размери", "Печат на снимка върху тениска", 18m }
                });
        }
    }
}
