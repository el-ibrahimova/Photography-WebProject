using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRateProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "PhotosRatings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 9, 23, 31, 40, 831, DateTimeKind.Local).AddTicks(7730),
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
                    { new Guid("2761a9ec-938a-4cea-b60f-217eb2ef3696"), "Спорт" },
                    { new Guid("65a8bd1a-bbe4-4a9f-b6f5-5167f9dd1565"), "Храна и напитки" },
                    { new Guid("91f3be7b-28eb-475b-b248-f66d5f6a2a4a"), "Семейна фотография" },
                    { new Guid("966c40af-cb1e-4ea3-9207-6c3c124c0016"), "Пътуваня и дестинации" },
                    { new Guid("9787b954-0d13-4646-a87b-501312304345"), "Архитектура" },
                    { new Guid("c16fd6d5-bc85-4027-a67b-ffcb0c395260"), "Пейзажи" },
                    { new Guid("d51ce9f9-791d-4966-b5a2-791176bec956"), "Мода" },
                    { new Guid("dd66ce32-a56a-4dea-b853-da19806c907a"), "Черно-бяла фотография" },
                    { new Guid("e8428b5b-36da-4fe5-a83e-1bbe96eb0976"), "Животни" },
                    { new Guid("f9f9608b-3183-41da-a704-26070ab156f0"), "Природа" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2761a9ec-938a-4cea-b60f-217eb2ef3696"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("65a8bd1a-bbe4-4a9f-b6f5-5167f9dd1565"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("91f3be7b-28eb-475b-b248-f66d5f6a2a4a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("966c40af-cb1e-4ea3-9207-6c3c124c0016"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9787b954-0d13-4646-a87b-501312304345"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c16fd6d5-bc85-4027-a67b-ffcb0c395260"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d51ce9f9-791d-4966-b5a2-791176bec956"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dd66ce32-a56a-4dea-b853-da19806c907a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e8428b5b-36da-4fe5-a83e-1bbe96eb0976"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f9f9608b-3183-41da-a704-26070ab156f0"));

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "PhotosRatings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Rate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 5, 19, 50, 37, 820, DateTimeKind.Local).AddTicks(6939),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 9, 23, 31, 40, 831, DateTimeKind.Local).AddTicks(7730),
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
    }
}
