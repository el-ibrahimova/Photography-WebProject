using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class some : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2024, 10, 29, 20, 51, 26, 695, DateTimeKind.Local).AddTicks(7126),
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
                defaultValue: new DateTime(2024, 10, 29, 20, 51, 26, 695, DateTimeKind.Local).AddTicks(7126),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 29, 23, 19, 4, 840, DateTimeKind.Local).AddTicks(4170),
                oldComment: "Date of user registration");
        }
    }
}
