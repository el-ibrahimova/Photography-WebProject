using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedPropertyToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("05afc4d9-9f76-442d-867d-a289ff7f6af4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("38b699eb-77c4-4d83-8267-3c1699c44011"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3b7e844f-d46a-4130-bbfe-7898e687c275"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("67400629-8496-40b7-855c-21aa7e151581"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f5886d5-e7af-48ba-a92c-adc3860a352d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9d18eb2f-b3ad-404b-94da-b179521159b1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9d63db2b-590b-441c-8e69-bdcb83ca3f3e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("abaa7e56-f5d5-45da-aac9-97ff5e5ad4f6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c33b3b32-b793-4ed5-9378-d364b470037f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fc65fe79-3d5b-4ee1-b12f-f87fafef17bc"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("07c105c0-02d4-40e5-9b63-3ff4371251f5"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("2105fef6-33c3-4155-acc5-d1e6a637bfea"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("4244343c-ce8c-4ce2-8b1b-53dbd882005e"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("4a000f1c-39e7-4834-9d51-7a532f2fbe12"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("860dc8cb-cef3-4e70-aab9-48057030867d"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("f02de878-3ce2-4874-8f61-be0fb16222dc"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is category deleted");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 21, 21, 22, 50, 609, DateTimeKind.Local).AddTicks(8722),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 17, 18, 6, 42, 686, DateTimeKind.Local).AddTicks(161),
                oldComment: "Date of user registration");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("03f250e6-1272-4732-b10f-4985cf9c843c"), "Спорт" },
                    { new Guid("10c96751-327a-4eed-a39b-41d9a211350e"), "Животни" },
                    { new Guid("1217fb2a-44cb-440a-9df7-2402503d4aae"), "Семейна фотография" },
                    { new Guid("24c99397-b3c4-4806-82c1-202cceb2372e"), "Пътуваня и дестинации" },
                    { new Guid("281edede-954b-489a-ae09-10bd1483c58a"), "Архитектура" },
                    { new Guid("47625db2-1ec8-487d-99e7-11df716c37d4"), "Пейзажи" },
                    { new Guid("91ca8d2f-8c5b-47c4-97c5-30d13c84b3fa"), "Черно-бяла фотография" },
                    { new Guid("af9e6643-c65f-42e0-8b27-234b395d89c5"), "Мода" },
                    { new Guid("bb86eae1-1f00-47d1-be8d-f8039168c515"), "Природа" },
                    { new Guid("cd98984c-fbf9-4e6f-8e2c-1f3bf127ad9f"), "Храна и напитки" }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("462b6352-a38f-4b2f-860f-0763168e4644"), "Печат на снимка върху чаша", 12.00m },
                    { new Guid("48d2a5f7-82b3-48d6-8703-086b3964a173"), "Печат на снимка в размер А4", 2.00m },
                    { new Guid("7131e793-65ac-4906-9458-d9c3323a3376"), "Печат на снимка в размер 13x18", 1.20m },
                    { new Guid("bed1e592-cf09-46e7-94c4-e9cd4aaacd3e"), "Печат на снимка върху тениска", 18m },
                    { new Guid("d1b91f0e-990f-4a63-970f-1c495fd6c6e7"), "Печат на снимка в размер 9х13", 0.40m },
                    { new Guid("eeea71e4-e9ab-4c4d-821f-1e16e4e2e2f9"), "Печат на снимка в размер 10x15", 0.45m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("03f250e6-1272-4732-b10f-4985cf9c843c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10c96751-327a-4eed-a39b-41d9a211350e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1217fb2a-44cb-440a-9df7-2402503d4aae"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("24c99397-b3c4-4806-82c1-202cceb2372e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("281edede-954b-489a-ae09-10bd1483c58a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("47625db2-1ec8-487d-99e7-11df716c37d4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("91ca8d2f-8c5b-47c4-97c5-30d13c84b3fa"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("af9e6643-c65f-42e0-8b27-234b395d89c5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bb86eae1-1f00-47d1-be8d-f8039168c515"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cd98984c-fbf9-4e6f-8e2c-1f3bf127ad9f"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("462b6352-a38f-4b2f-860f-0763168e4644"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("48d2a5f7-82b3-48d6-8703-086b3964a173"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("7131e793-65ac-4906-9458-d9c3323a3376"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("bed1e592-cf09-46e7-94c4-e9cd4aaacd3e"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("d1b91f0e-990f-4a63-970f-1c495fd6c6e7"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("eeea71e4-e9ab-4c4d-821f-1e16e4e2e2f9"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 17, 18, 6, 42, 686, DateTimeKind.Local).AddTicks(161),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 21, 21, 22, 50, 609, DateTimeKind.Local).AddTicks(8722),
                oldComment: "Date of user registration");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("05afc4d9-9f76-442d-867d-a289ff7f6af4"), "Мода" },
                    { new Guid("38b699eb-77c4-4d83-8267-3c1699c44011"), "Черно-бяла фотография" },
                    { new Guid("3b7e844f-d46a-4130-bbfe-7898e687c275"), "Храна и напитки" },
                    { new Guid("67400629-8496-40b7-855c-21aa7e151581"), "Животни" },
                    { new Guid("6f5886d5-e7af-48ba-a92c-adc3860a352d"), "Семейна фотография" },
                    { new Guid("9d18eb2f-b3ad-404b-94da-b179521159b1"), "Архитектура" },
                    { new Guid("9d63db2b-590b-441c-8e69-bdcb83ca3f3e"), "Пътуваня и дестинации" },
                    { new Guid("abaa7e56-f5d5-45da-aac9-97ff5e5ad4f6"), "Спорт" },
                    { new Guid("c33b3b32-b793-4ed5-9378-d364b470037f"), "Пейзажи" },
                    { new Guid("fc65fe79-3d5b-4ee1-b12f-f87fafef17bc"), "Природа" }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("07c105c0-02d4-40e5-9b63-3ff4371251f5"), "Печат на снимка в размер 10x15", 0.45m },
                    { new Guid("2105fef6-33c3-4155-acc5-d1e6a637bfea"), "Печат на снимка върху чаша", 12.00m },
                    { new Guid("4244343c-ce8c-4ce2-8b1b-53dbd882005e"), "Печат на снимка върху тениска", 18m },
                    { new Guid("4a000f1c-39e7-4834-9d51-7a532f2fbe12"), "Печат на снимка в размер 9х13", 0.40m },
                    { new Guid("860dc8cb-cef3-4e70-aab9-48057030867d"), "Печат на снимка в размер А4", 2.00m },
                    { new Guid("f02de878-3ce2-4874-8f61-be0fb16222dc"), "Печат на снимка в размер 13x18", 1.20m }
                });
        }
    }
}
