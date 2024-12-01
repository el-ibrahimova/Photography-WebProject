using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removePhotographerPropertyFromPhotoShoots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("00ca1d5e-f02c-400f-9fd8-2147dc8820d9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("01cbef24-396c-45ea-8758-9d6f37ef6c50"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0909a747-b398-4c15-9697-f94b2b540a40"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4d30f91f-745a-4791-a0be-701e407a55cb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("79efbc84-64c8-401d-b016-15bc6ec248d2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("80ebd9c2-5766-44c8-bf27-62344e7dea28"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b53943a4-9df8-4a94-8738-13b7c8038fc1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b946c3d4-b96a-4663-ae25-5d35050efbc3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c06971cc-10c6-4d39-8c06-a854bef9d09b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c709889b-612d-4cb7-be88-0df72607af4b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 20, 15, 39, 301, DateTimeKind.Local).AddTicks(2437),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 1, 19, 43, 5, 322, DateTimeKind.Local).AddTicks(332),
                oldComment: "Date of user registration");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27d649ee-03d9-4f4c-8917-1b9a2a06890c", new DateTime(2024, 12, 1, 20, 15, 39, 301, DateTimeKind.Local).AddTicks(3596), "AQAAAAIAAYagAAAAEII8rJJS27aS9ghbnwHheCZScxdLbgHef+5sbKWdxQaohPmi++qsNQXBlf2zI5benQ==", "73f0a8b9-7929-4ac2-9b8d-1e2954492a1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "733c374a-5bff-43b9-bda4-47bc4cd8ae02", new DateTime(2024, 12, 1, 20, 15, 39, 301, DateTimeKind.Local).AddTicks(3572), "AQAAAAIAAYagAAAAEBQGis9Ao2m8KGjLVYs9TItMLhGPMqjzabshi7vHNPSYzy9rR09VnHm61SeIYKS3vQ==", "d9e79d0d-03ac-4368-b822-72fbcd5769ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f05befaa-2c9c-4f4b-8a49-d765c6ac7bf7", new DateTime(2024, 12, 1, 20, 15, 39, 301, DateTimeKind.Local).AddTicks(3538), "AQAAAAIAAYagAAAAENWlhKiTAoCWoKdxiJhZznval6Wm9XcsG7JrsLm91VoVGFSaHjFvgyhnB4joXpt3lw==", "2966045a-d48f-41c7-b116-e6413673fbec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95d458a7-115a-4db5-9319-809c7763d841"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57ce5500-e886-4267-aaed-63a100fe6cb1", new DateTime(2024, 12, 1, 20, 15, 39, 301, DateTimeKind.Local).AddTicks(3617), "AQAAAAIAAYagAAAAEJFyjNtmcTm3kZhfsCOYJDTQVThVxSBJk+yo1qXhovyn8aOlFdPOTDVtvh2bjeX4lw==", "b640ac75-fe0d-4ec4-bd76-3d5f8ebb6a77" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0128e2fb-6d23-4b7c-b4c3-32ba2d661bdc"), "Архитектура" },
                    { new Guid("20dcc3ee-6f4f-441a-b302-e5ae45d3ff54"), "Мода" },
                    { new Guid("454eb44e-4f45-42c0-916d-0b7bcb645f09"), "Семейна фотография" },
                    { new Guid("66697fa2-d97a-4e5d-a393-7c150bb5c48c"), "Пейзажи" },
                    { new Guid("693a0085-52cd-43c0-bb3e-8184738510d8"), "Пътуваня и дестинации" },
                    { new Guid("9df7978a-92bb-4f4e-a10d-ab1bf3a61e67"), "Спорт" },
                    { new Guid("cb1a2127-a789-454e-b3bb-c02b44ad4ef8"), "Храна и напитки" },
                    { new Guid("e86850d7-5089-466c-bdaa-c6d5da242475"), "Черно-бяла фотография" },
                    { new Guid("ec00bc7a-7296-4d51-bca3-29fc2b5f0d85"), "Животни" },
                    { new Guid("eea53935-59b8-43f8-a9bf-07d47be3bfa7"), "Природа" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0128e2fb-6d23-4b7c-b4c3-32ba2d661bdc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("20dcc3ee-6f4f-441a-b302-e5ae45d3ff54"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("454eb44e-4f45-42c0-916d-0b7bcb645f09"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("66697fa2-d97a-4e5d-a393-7c150bb5c48c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("693a0085-52cd-43c0-bb3e-8184738510d8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9df7978a-92bb-4f4e-a10d-ab1bf3a61e67"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cb1a2127-a789-454e-b3bb-c02b44ad4ef8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e86850d7-5089-466c-bdaa-c6d5da242475"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ec00bc7a-7296-4d51-bca3-29fc2b5f0d85"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eea53935-59b8-43f8-a9bf-07d47be3bfa7"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 19, 43, 5, 322, DateTimeKind.Local).AddTicks(332),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 1, 20, 15, 39, 301, DateTimeKind.Local).AddTicks(2437),
                oldComment: "Date of user registration");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efceb649-5403-49be-859e-482cac4fc156", new DateTime(2024, 12, 1, 19, 43, 5, 322, DateTimeKind.Local).AddTicks(1980), "AQAAAAIAAYagAAAAEJ6hHarbn320Gye9Pzn9t2OfdDMpnPJWx+I3FZaqmm5WezcaqZ9wKvA6BtM67T2z5Q==", "9c95fd0e-e178-4e4a-bcdc-ef53175eb2a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fdefac4-c1c4-4109-a97c-4787c1359776", new DateTime(2024, 12, 1, 19, 43, 5, 322, DateTimeKind.Local).AddTicks(1953), "AQAAAAIAAYagAAAAEI4Pb1JP/+lYPTfzkd+WnC+hWCAV6IBRS0P9sBmYlZNMysG+Anbetfac4t9WviFT3A==", "a09ba247-bf06-4aa8-9bac-862f68b3b530" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "700d6189-3d13-4a6d-863d-63ef933e406f", new DateTime(2024, 12, 1, 19, 43, 5, 322, DateTimeKind.Local).AddTicks(1901), "AQAAAAIAAYagAAAAEOGTZtR9zvWMvxCA06J5ciksz68fwObGyrkSjEi1goEqzTY5w90g/xz+FtoyOuxRdQ==", "cb30de8c-ec5d-493d-9ba5-01f4a619304f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95d458a7-115a-4db5-9319-809c7763d841"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15db46a0-4674-4f7d-8ade-78537b09a72b", new DateTime(2024, 12, 1, 19, 43, 5, 322, DateTimeKind.Local).AddTicks(2012), "AQAAAAIAAYagAAAAEJBrW9YMyzCh1BxArNfFQSTDtX9E+mnbfZMYPsbEa65At+3h4dANDCVrVuNjEmKMtw==", "b2ce51a0-1c12-40e2-b00f-f0637a3af104" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00ca1d5e-f02c-400f-9fd8-2147dc8820d9"), "Пейзажи" },
                    { new Guid("01cbef24-396c-45ea-8758-9d6f37ef6c50"), "Архитектура" },
                    { new Guid("0909a747-b398-4c15-9697-f94b2b540a40"), "Семейна фотография" },
                    { new Guid("4d30f91f-745a-4791-a0be-701e407a55cb"), "Черно-бяла фотография" },
                    { new Guid("79efbc84-64c8-401d-b016-15bc6ec248d2"), "Пътуваня и дестинации" },
                    { new Guid("80ebd9c2-5766-44c8-bf27-62344e7dea28"), "Спорт" },
                    { new Guid("b53943a4-9df8-4a94-8738-13b7c8038fc1"), "Мода" },
                    { new Guid("b946c3d4-b96a-4663-ae25-5d35050efbc3"), "Природа" },
                    { new Guid("c06971cc-10c6-4d39-8c06-a854bef9d09b"), "Храна и напитки" },
                    { new Guid("c709889b-612d-4cb7-be88-0df72607af4b"), "Животни" }
                });
        }
    }
}
