using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addPhotoRatingEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Photos_PhotoId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_PhotoId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Categories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 31, 23, 3, 10, 472, DateTimeKind.Local).AddTicks(3513),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 29, 23, 53, 38, 155, DateTimeKind.Local).AddTicks(203),
                oldComment: "Date of user registration");

            migrationBuilder.AddColumn<int>(
                name: "VoteCount",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Number of photo votes");

            migrationBuilder.CreateTable(
                name: "PhotosRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Rate identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Photo identifier"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "User identifier"),
                    Rating = table.Column<int>(type: "int", nullable: false, comment: "Rate")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotosRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotosRatings_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhotosRatings_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Rating for photo");

            migrationBuilder.CreateIndex(
                name: "IX_PhotosRatings_PhotoId",
                table: "PhotosRatings",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotosRatings_UserId",
                table: "PhotosRatings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotosRatings");

            migrationBuilder.DropColumn(
                name: "VoteCount",
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
                oldDefaultValue: new DateTime(2024, 10, 31, 23, 3, 10, 472, DateTimeKind.Local).AddTicks(3513),
                oldComment: "Date of user registration");

            migrationBuilder.AddColumn<Guid>(
                name: "PhotoId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhotoId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "PhotoId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "PhotoId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "PhotoId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "PhotoId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "PhotoId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "PhotoId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "PhotoId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "PhotoId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_PhotoId",
                table: "Categories",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Photos_PhotoId",
                table: "Categories",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id");
        }
    }
}
