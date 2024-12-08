using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesAndUserRolesAddIsDeletedToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2024, 12, 8, 13, 2, 40, 549, DateTimeKind.Local).AddTicks(3829),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 1, 20, 15, 39, 301, DateTimeKind.Local).AddTicks(2437),
                oldComment: "Date of user registration");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is user deleted");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("34282161-754b-4c2a-2ec6-08dd12303248"), null, "Admin", "ADMIN" },
                    { new Guid("8246f96f-bd49-4db2-69ae-08dd176d0f38"), null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc8d4638-ebb0-4019-8ee1-7a8a10633dbf", new DateTime(2024, 12, 8, 13, 2, 40, 549, DateTimeKind.Local).AddTicks(5771), "AQAAAAIAAYagAAAAEGWxx3BweTpT2cFMkNmHAHkWxYCmFSAQEX1zq01ByxiBybVlfgVgg4H54ViJdXxMpQ==", "ddd77044-33c7-4087-8d1e-8b57ccbed951" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f29eff44-5902-45ba-b1af-12e8a5021bf0", new DateTime(2024, 12, 8, 13, 2, 40, 549, DateTimeKind.Local).AddTicks(5753), "AQAAAAIAAYagAAAAEB8jAXXExdbNauwC3A+2hIhzKnm8vSskMSOLg9sldzEdrq0tBA6v107u0U1Rilt8Yw==", "d05cbb40-a9d6-4fb6-80e7-374d9253b9c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dcdca3b3-f8d2-4662-b3b5-4b5557034f4a", new DateTime(2024, 12, 8, 13, 2, 40, 549, DateTimeKind.Local).AddTicks(5728), "AQAAAAIAAYagAAAAECv0toR1PViIOtTIbjaVkplYHM0sLJhOqavPTFUOyGiSTvIJV6N/j0vhf+j1g0/rOQ==", "27c98b2b-fae1-4f1c-a107-fe41abe03918" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95d458a7-115a-4db5-9319-809c7763d841"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f8b8aa0-d472-4ab5-abb4-ef8224bc97bd", new DateTime(2024, 12, 8, 13, 2, 40, 549, DateTimeKind.Local).AddTicks(5792), "AQAAAAIAAYagAAAAELp22ufX0884WumsX//BOJevyCnUUt10x16/UQsxqSw9A5yAjl8zPvoXcQljUB5JHQ==", "d59862f2-6c21-47e0-834f-cceea2b7a638" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("13a08262-6477-40f9-8db7-d6ebd4178e47"), "Архитектура" },
                    { new Guid("5d56e870-0080-4609-b189-94282ae97f31"), "Животни" },
                    { new Guid("8e1654cf-f730-41c7-92c2-0e280a94e7ce"), "Спорт" },
                    { new Guid("aa25251b-6ddc-438b-b5f0-28b3341731e3"), "Семейна фотография" },
                    { new Guid("bcc254e8-2534-4791-90e2-d17c03122886"), "Храна и напитки" },
                    { new Guid("c1f05508-2b56-46d8-86f9-027f5aaee67a"), "Пейзажи" },
                    { new Guid("c7347c35-effb-4cd6-9334-1348ec5d635b"), "Черно-бяла фотография" },
                    { new Guid("c7e699d1-fc73-459b-8f0f-11b7c4e101b5"), "Мода" },
                    { new Guid("e5aedd38-0dc5-49e4-b51a-acf63fd991a8"), "Пътуваня и дестинации" },
                    { new Guid("e5fd2c2f-40a0-4a90-a89c-81ab099fa581"), "Природа" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("34282161-754b-4c2a-2ec6-08dd12303248"), new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd") },
                    { new Guid("8246f96f-bd49-4db2-69ae-08dd176d0f38"), new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d") },
                    { new Guid("8246f96f-bd49-4db2-69ae-08dd176d0f38"), new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846") },
                    { new Guid("8246f96f-bd49-4db2-69ae-08dd176d0f38"), new Guid("95d458a7-115a-4db5-9319-809c7763d841") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("34282161-754b-4c2a-2ec6-08dd12303248"), new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8246f96f-bd49-4db2-69ae-08dd176d0f38"), new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8246f96f-bd49-4db2-69ae-08dd176d0f38"), new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8246f96f-bd49-4db2-69ae-08dd176d0f38"), new Guid("95d458a7-115a-4db5-9319-809c7763d841") });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("13a08262-6477-40f9-8db7-d6ebd4178e47"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5d56e870-0080-4609-b189-94282ae97f31"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8e1654cf-f730-41c7-92c2-0e280a94e7ce"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aa25251b-6ddc-438b-b5f0-28b3341731e3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bcc254e8-2534-4791-90e2-d17c03122886"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c1f05508-2b56-46d8-86f9-027f5aaee67a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c7347c35-effb-4cd6-9334-1348ec5d635b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c7e699d1-fc73-459b-8f0f-11b7c4e101b5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e5aedd38-0dc5-49e4-b51a-acf63fd991a8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e5fd2c2f-40a0-4a90-a89c-81ab099fa581"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("34282161-754b-4c2a-2ec6-08dd12303248"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8246f96f-bd49-4db2-69ae-08dd176d0f38"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 20, 15, 39, 301, DateTimeKind.Local).AddTicks(2437),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 8, 13, 2, 40, 549, DateTimeKind.Local).AddTicks(3829),
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
    }
}
