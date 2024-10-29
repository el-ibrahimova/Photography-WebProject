using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addEntityPhotoCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 29, 20, 51, 26, 695, DateTimeKind.Local).AddTicks(7126),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 28, 20, 21, 19, 125, DateTimeKind.Local).AddTicks(5602),
                oldComment: "Date of user registration");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Rating of the photo",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Rating of the photo");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "Name of the category",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Name of the category");

            migrationBuilder.CreateTable(
                name: "PhotosCategories",
                columns: table => new
                {
                    PhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Photo identifier"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotosCategories", x => new { x.CategoryId, x.PhotoId });
                    table.ForeignKey(
                        name: "FK_PhotosCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhotosCategories_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id");
                },
                comment: "Photo Categories");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "PhotoId" },
                values: new object[,]
                {
                    { 1, "Животни", null },
                    { 2, "Природа", null },
                    { 3, "Храна и напитки", null },
                    { 4, "Семейна фотография", null },
                    { 5, "Спорт", null },
                    { 6, "Архитектура", null },
                    { 7, "Пътуваня и дестинации", null },
                    { 8, "Черно-бяла фотография", null },
                    { 9, "Мода", null },
                    { 10, "Пейзажи", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhotosCategories_PhotoId",
                table: "PhotosCategories",
                column: "PhotoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotosCategories");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 28, 20, 21, 19, 125, DateTimeKind.Local).AddTicks(5602),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 29, 20, 51, 26, 695, DateTimeKind.Local).AddTicks(7126),
                oldComment: "Date of user registration");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Photos",
                type: "int",
                nullable: false,
                comment: "Rating of the photo",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0,
                oldComment: "Rating of the photo");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Name of the category",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "Name of the category");
        }
    }
}
