using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addPropertyParticipant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5b34f795-2e1b-4284-b135-cecce865c14d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("64e0e877-a0de-4ffe-a4a8-8996cefc9854"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("66633dae-13cd-4a0a-82c2-d65cb02ea03d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6fefd247-7336-442b-8c04-7becb4748543"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("80d1c776-b333-447d-9423-48d61f64e58c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8760ec5f-bb82-4122-ac8c-13d13ad2fa33"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bacc437f-40e2-4596-ab24-d9348652b2b2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c47c863e-40bc-4f49-bcf6-9bd1d3faeb85"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d493906d-1521-4c28-91ea-3b7cf26da8fe"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e7b51a58-491a-44f8-acd1-4d10dd335077"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 22, 22, 47, 40, 733, DateTimeKind.Local).AddTicks(3589),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 22, 22, 32, 59, 698, DateTimeKind.Local).AddTicks(6456),
                oldComment: "Date of user registration");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("347ded64-e13a-489f-b1af-336a9629e65c"), "Семейна фотография" },
                    { new Guid("3aaf0ab5-3a5e-4d63-8801-f550285c8c28"), "Спорт" },
                    { new Guid("4e7d6b48-4b27-44f7-b5c0-0364213dc44a"), "Мода" },
                    { new Guid("67a26e82-75e2-4f92-ac50-6c94f9bd6837"), "Черно-бяла фотография" },
                    { new Guid("6d05689d-c806-42ec-a2b2-fe743d1d8279"), "Природа" },
                    { new Guid("706a1af7-07ad-449e-92e0-bbec978af661"), "Пейзажи" },
                    { new Guid("8e56c3b3-4f23-4689-a41e-5a388dfa9b57"), "Пътуваня и дестинации" },
                    { new Guid("a347488e-0d3f-4902-ba3a-ee17b60ad377"), "Животни" },
                    { new Guid("a364cf37-0a61-4724-83a1-2326160ed1ca"), "Архитектура" },
                    { new Guid("df829c17-e955-40f9-aea7-0e51ef02b905"), "Храна и напитки" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("347ded64-e13a-489f-b1af-336a9629e65c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3aaf0ab5-3a5e-4d63-8801-f550285c8c28"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4e7d6b48-4b27-44f7-b5c0-0364213dc44a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("67a26e82-75e2-4f92-ac50-6c94f9bd6837"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6d05689d-c806-42ec-a2b2-fe743d1d8279"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("706a1af7-07ad-449e-92e0-bbec978af661"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8e56c3b3-4f23-4689-a41e-5a388dfa9b57"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a347488e-0d3f-4902-ba3a-ee17b60ad377"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a364cf37-0a61-4724-83a1-2326160ed1ca"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("df829c17-e955-40f9-aea7-0e51ef02b905"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 22, 22, 32, 59, 698, DateTimeKind.Local).AddTicks(6456),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 22, 22, 47, 40, 733, DateTimeKind.Local).AddTicks(3589),
                oldComment: "Date of user registration");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5b34f795-2e1b-4284-b135-cecce865c14d"), "Архитектура" },
                    { new Guid("64e0e877-a0de-4ffe-a4a8-8996cefc9854"), "Пътуваня и дестинации" },
                    { new Guid("66633dae-13cd-4a0a-82c2-d65cb02ea03d"), "Мода" },
                    { new Guid("6fefd247-7336-442b-8c04-7becb4748543"), "Животни" },
                    { new Guid("80d1c776-b333-447d-9423-48d61f64e58c"), "Храна и напитки" },
                    { new Guid("8760ec5f-bb82-4122-ac8c-13d13ad2fa33"), "Черно-бяла фотография" },
                    { new Guid("bacc437f-40e2-4596-ab24-d9348652b2b2"), "Природа" },
                    { new Guid("c47c863e-40bc-4f49-bcf6-9bd1d3faeb85"), "Пейзажи" },
                    { new Guid("d493906d-1521-4c28-91ea-3b7cf26da8fe"), "Семейна фотография" },
                    { new Guid("e7b51a58-491a-44f8-acd1-4d10dd335077"), "Спорт" }
                });
        }
    }
}
