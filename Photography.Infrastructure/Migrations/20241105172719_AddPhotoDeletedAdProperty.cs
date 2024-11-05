using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoDeletedAdProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "VoteCount",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "PhotosRatings",
                newName: "Rate");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Photos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date of photo uploading");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 5, 19, 27, 15, 537, DateTimeKind.Local).AddTicks(6902),
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "PhotosRatings",
                newName: "Rating");

            migrationBuilder.AddColumn<int>(
                name: "VoteCount",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Number of photo votes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 4, 23, 49, 14, 538, DateTimeKind.Local).AddTicks(3584),
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
    }
}
