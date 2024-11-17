using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addPhotographerDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 17, 18, 6, 42, 686, DateTimeKind.Local).AddTicks(161),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 17, 17, 38, 59, 673, DateTimeKind.Local).AddTicks(1740),
                oldComment: "Date of user registration");

            migrationBuilder.CreateTable(
                name: "Photographers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Photographer identifier"),
                    BrandName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Brand name of the photographer"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Photographer user identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photographers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photographers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Photographer");

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

            migrationBuilder.CreateIndex(
                name: "IX_Photographers_UserId",
                table: "Photographers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photographers");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 17, 17, 38, 59, 673, DateTimeKind.Local).AddTicks(1740),
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
    }
}
