using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeConstructorInitializationForUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0371863c-bea0-4e75-939e-ebc016fcabf9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("175deaac-baa2-49b2-97f4-391fd95c457d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2f235d36-599c-4752-827d-a0d38170f641"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2f43aab4-979b-421b-9e4d-85284cd38cd2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("49a0f76e-6db0-4621-aa65-cce718e43232"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("503b7bc1-b1b6-46fa-a955-1f761aa924aa"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5b31304d-0dfe-4749-b10f-927a601354e5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7b620839-a792-48db-b328-7beb1dd6c491"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("87ab7874-e2a4-4a1d-920f-c2c45629186e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b0713c2a-3b1f-4d6f-acd4-c1678c4c9627"));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Orders",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OfferTypes",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 4, 23, 49, 14, 538, DateTimeKind.Local).AddTicks(3584),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 3, 21, 27, 47, 404, DateTimeKind.Local).AddTicks(2447),
                oldComment: "Date of user registration");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1892de6d-5bc1-46bc-8116-32446daa834b"), "Животни" },
                    { new Guid("18d67e42-d791-4ffe-85fc-17e2bc0519c7"), "Храна и напитки" },
                    { new Guid("4ed2e160-db4c-43b3-9e3c-83d4ee119c28"), "Мода" },
                    { new Guid("5d3b282c-48d4-451a-b92d-b940eb07e3ae"), "Пътуваня и дестинации" },
                    { new Guid("6b8ebeb6-fae1-4a0a-a3bb-146baae0564a"), "Пейзажи" },
                    { new Guid("93507439-9d0d-4b7d-b83b-e263bda85bad"), "Архитектура" },
                    { new Guid("c7aa4ba5-8f42-417b-ac20-e0f7dde67064"), "Семейна фотография" },
                    { new Guid("e2a74e6f-dd1b-46d0-b9ab-366cf7e72c01"), "Природа" },
                    { new Guid("e64ddfd4-26ad-42be-8fe8-6e76b124d380"), "Спорт" },
                    { new Guid("f0d1ce03-98a2-4281-955f-75125796e8de"), "Черно-бяла фотография" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1892de6d-5bc1-46bc-8116-32446daa834b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("18d67e42-d791-4ffe-85fc-17e2bc0519c7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4ed2e160-db4c-43b3-9e3c-83d4ee119c28"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5d3b282c-48d4-451a-b92d-b940eb07e3ae"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6b8ebeb6-fae1-4a0a-a3bb-146baae0564a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("93507439-9d0d-4b7d-b83b-e263bda85bad"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c7aa4ba5-8f42-417b-ac20-e0f7dde67064"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e2a74e6f-dd1b-46d0-b9ab-366cf7e72c01"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e64ddfd4-26ad-42be-8fe8-6e76b124d380"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f0d1ce03-98a2-4281-955f-75125796e8de"));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Orders",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OfferTypes",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 3, 21, 27, 47, 404, DateTimeKind.Local).AddTicks(2447),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 4, 23, 49, 14, 538, DateTimeKind.Local).AddTicks(3584),
                oldComment: "Date of user registration");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0371863c-bea0-4e75-939e-ebc016fcabf9"), "Животни" },
                    { new Guid("175deaac-baa2-49b2-97f4-391fd95c457d"), "Черно-бяла фотография" },
                    { new Guid("2f235d36-599c-4752-827d-a0d38170f641"), "Пътуваня и дестинации" },
                    { new Guid("2f43aab4-979b-421b-9e4d-85284cd38cd2"), "Пейзажи" },
                    { new Guid("49a0f76e-6db0-4621-aa65-cce718e43232"), "Храна и напитки" },
                    { new Guid("503b7bc1-b1b6-46fa-a955-1f761aa924aa"), "Природа" },
                    { new Guid("5b31304d-0dfe-4749-b10f-927a601354e5"), "Мода" },
                    { new Guid("7b620839-a792-48db-b328-7beb1dd6c491"), "Семейна фотография" },
                    { new Guid("87ab7874-e2a4-4a1d-920f-c2c45629186e"), "Спорт" },
                    { new Guid("b0713c2a-3b1f-4d6f-acd4-c1678c4c9627"), "Архитектура" }
                });
        }
    }
}
