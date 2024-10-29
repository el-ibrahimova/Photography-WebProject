using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeCategoryIdFromPhotoEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Categories_CategoryId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_CategoryId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Photos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 29, 23, 53, 38, 155, DateTimeKind.Local).AddTicks(203),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 29, 23, 19, 4, 840, DateTimeKind.Local).AddTicks(4170),
                oldComment: "Date of user registration");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 29, 23, 19, 4, 840, DateTimeKind.Local).AddTicks(4170),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 29, 23, 53, 38, 155, DateTimeKind.Local).AddTicks(203),
                oldComment: "Date of user registration");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Category identifier");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_CategoryId",
                table: "Photos",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Categories_CategoryId",
                table: "Photos",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
