using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeIsRequiredForPrivatePhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UserOwnerId",
                table: "Photos",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Owner of photo",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Is the user owner of photo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 29, 16, 19, 1, 693, DateTimeKind.Local).AddTicks(9557),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 29, 14, 50, 8, 852, DateTimeKind.Local).AddTicks(5617),
                oldComment: "Date of user registration");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AlterColumn<Guid>(
                name: "UserOwnerId",
                table: "Photos",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Is the user owner of photo",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Owner of photo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 29, 14, 50, 8, 852, DateTimeKind.Local).AddTicks(5617),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 29, 16, 19, 1, 693, DateTimeKind.Local).AddTicks(9557),
                oldComment: "Date of user registration");
        }
    }
}
