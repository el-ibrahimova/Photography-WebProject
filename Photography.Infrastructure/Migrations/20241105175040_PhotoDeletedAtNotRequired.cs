using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PhotoDeletedAtNotRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("207e17cc-90ba-4a61-9bb9-a3366b97f595"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5256d5a3-6d45-4276-8ec1-2f509cfc6fc5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5a660017-e652-4aae-92c7-753f62727e44"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5ec2ed64-b891-49dd-b19e-f3ff8d04e681"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7b5d9a66-1c07-4471-b1f9-89cd8a51c028"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("94daa770-5a73-4e0a-a51a-23af08670eb3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c44026e0-d9b5-43e6-b7f5-ab4a4f57dcc0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ce0b7aff-da9d-4001-9168-ab79fe1bb776"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d5e6831e-920a-4d49-a60a-7c3e280bb47b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f23e2fc5-2c7e-4726-84fe-7396c9be58c6"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "Photos",
                type: "datetime2",
                nullable: true,
                comment: "Date of photo uploading",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date of photo uploading");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 5, 19, 50, 37, 820, DateTimeKind.Local).AddTicks(6939),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 5, 19, 27, 15, 537, DateTimeKind.Local).AddTicks(6902),
                oldComment: "Date of user registration");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("04ca5e9d-da73-42fd-baae-94fbd7f6584e"), "Мода" },
                    { new Guid("0936f0b3-62f4-43c7-b554-d8152b655304"), "Пътуваня и дестинации" },
                    { new Guid("277dfb7e-4e24-4ea7-a747-c7c5370a2330"), "Животни" },
                    { new Guid("353f6765-bd0c-4851-a398-a29748ba9dd3"), "Природа" },
                    { new Guid("4f4dc6d6-07e9-4be8-8c85-c1abe288396d"), "Храна и напитки" },
                    { new Guid("59008871-727c-4864-904b-0c2a844a55ea"), "Семейна фотография" },
                    { new Guid("7ea80550-73ca-41cc-8cae-216b4fd842b5"), "Пейзажи" },
                    { new Guid("b2163336-3326-46fb-b781-d4eef84d172d"), "Спорт" },
                    { new Guid("b28b6764-a8e5-4bc9-9d4b-4a3086dfd203"), "Черно-бяла фотография" },
                    { new Guid("d1185286-06e4-432e-9465-d1f08190f7ee"), "Архитектура" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("04ca5e9d-da73-42fd-baae-94fbd7f6584e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0936f0b3-62f4-43c7-b554-d8152b655304"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("277dfb7e-4e24-4ea7-a747-c7c5370a2330"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("353f6765-bd0c-4851-a398-a29748ba9dd3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4f4dc6d6-07e9-4be8-8c85-c1abe288396d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("59008871-727c-4864-904b-0c2a844a55ea"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7ea80550-73ca-41cc-8cae-216b4fd842b5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b2163336-3326-46fb-b781-d4eef84d172d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b28b6764-a8e5-4bc9-9d4b-4a3086dfd203"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d1185286-06e4-432e-9465-d1f08190f7ee"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "Photos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date of photo uploading",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Date of photo uploading");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 5, 19, 27, 15, 537, DateTimeKind.Local).AddTicks(6902),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 5, 19, 50, 37, 820, DateTimeKind.Local).AddTicks(6939),
                oldComment: "Date of user registration");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("207e17cc-90ba-4a61-9bb9-a3366b97f595"), "Мода" },
                    { new Guid("5256d5a3-6d45-4276-8ec1-2f509cfc6fc5"), "Пейзажи" },
                    { new Guid("5a660017-e652-4aae-92c7-753f62727e44"), "Животни" },
                    { new Guid("5ec2ed64-b891-49dd-b19e-f3ff8d04e681"), "Пътуваня и дестинации" },
                    { new Guid("7b5d9a66-1c07-4471-b1f9-89cd8a51c028"), "Черно-бяла фотография" },
                    { new Guid("94daa770-5a73-4e0a-a51a-23af08670eb3"), "Природа" },
                    { new Guid("c44026e0-d9b5-43e6-b7f5-ab4a4f57dcc0"), "Спорт" },
                    { new Guid("ce0b7aff-da9d-4001-9168-ab79fe1bb776"), "Храна и напитки" },
                    { new Guid("d5e6831e-920a-4d49-a60a-7c3e280bb47b"), "Семейна фотография" },
                    { new Guid("f23e2fc5-2c7e-4726-84fe-7396c9be58c6"), "Архитектура" }
                });
        }
    }
}
