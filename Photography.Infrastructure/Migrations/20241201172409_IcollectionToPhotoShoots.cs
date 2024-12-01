using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IcollectionToPhotoShoots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("18c787e0-1531-41b0-a56b-b926f2dceedc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1a35751f-e6a3-4b8f-8562-3fc6105cefc4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1b643584-44e4-4d9f-8201-f5edfe44820a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8bd18449-776a-4d7e-8d7a-51263240e34b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b36e4c0d-a834-4175-86d9-a41296c6543c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b9e23f30-ea51-457e-b7fd-fc30e8f3241e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c5481055-d571-43fc-80b7-d71edcb7d7e0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("df24031c-6c7d-4cb9-8ddd-7c9a40d9292b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f83d4203-2e21-4308-a68d-b6f96ca47814"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f9df8a40-77fb-4dad-bfdd-f3d89a2c3b9c"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 19, 24, 6, 684, DateTimeKind.Local).AddTicks(472),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 1, 19, 15, 49, 747, DateTimeKind.Local).AddTicks(7855),
                oldComment: "Date of user registration");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e18a3367-441f-4269-874d-9ec5d2ca4be1", new DateTime(2024, 12, 1, 19, 24, 6, 684, DateTimeKind.Local).AddTicks(2012), "AQAAAAIAAYagAAAAEPGIQQnhuge9dheSEWeZkWtX1MK1QWTAQr+KwciTWgAePseUyeNURt+zY6nP8PxMpw==", "a8679b2c-bc2c-46bc-a251-0573862eb8c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8085102-684e-47a9-a806-3a4d463bcc81", new DateTime(2024, 12, 1, 19, 24, 6, 684, DateTimeKind.Local).AddTicks(1973), "AQAAAAIAAYagAAAAEHs6sHMV2aRD/cMNWReGRad3kwT5HeSYMW4wjpnTn7+1g6E0rqKqUitfgDOrqU9dYQ==", "d7f6247a-ae76-48e5-b6d9-3698230c5d45" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8959e448-d0c7-4e7e-ba93-da9ac146a8a7", new DateTime(2024, 12, 1, 19, 24, 6, 684, DateTimeKind.Local).AddTicks(1949), "AQAAAAIAAYagAAAAEBdsPeIfHfhtcR7VbmBSxMKP4WcOmoqBAfsCGBVWxjngtVW72ND38FWxvHd1SR/oTQ==", "a0578a31-b387-452c-ac75-79e96b3bd7ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95d458a7-115a-4db5-9319-809c7763d841"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "649a4541-bcef-477f-b531-a2d57f32c05d", new DateTime(2024, 12, 1, 19, 24, 6, 684, DateTimeKind.Local).AddTicks(2041), "AQAAAAIAAYagAAAAEHCDwUXYg1XkqTCVc0T9y3S/+jtQiKH6XjF6RRxIr5VEOuC9VShKfLwR2h1Asqw4dQ==", "38f3088b-cd04-4c33-b115-bf27384caed3" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("17c715a3-a810-4915-9048-2e5c9ec3fca4"), "Пътуваня и дестинации" },
                    { new Guid("2822f5d3-9981-46eb-b9f0-435f65fba600"), "Архитектура" },
                    { new Guid("357258d6-f22e-4787-b3c3-149b2dce8754"), "Животни" },
                    { new Guid("6b2febe6-2f17-4433-a42a-4715afa5e0f6"), "Мода" },
                    { new Guid("851eaddd-1b5e-4be0-8992-abae21a299af"), "Семейна фотография" },
                    { new Guid("89b3ea58-6b20-4788-aea9-9e6d4d23386f"), "Природа" },
                    { new Guid("910d5e91-40aa-4041-9291-c677d4ff1347"), "Спорт" },
                    { new Guid("b7ca2084-c987-49fa-88ce-d251c01ab9e1"), "Черно-бяла фотография" },
                    { new Guid("ce8cb41f-7f63-401f-8a2d-8270dadb5787"), "Храна и напитки" },
                    { new Guid("f6196ca1-76a9-4f06-b24d-b8441efc2674"), "Пейзажи" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("17c715a3-a810-4915-9048-2e5c9ec3fca4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2822f5d3-9981-46eb-b9f0-435f65fba600"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("357258d6-f22e-4787-b3c3-149b2dce8754"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6b2febe6-2f17-4433-a42a-4715afa5e0f6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("851eaddd-1b5e-4be0-8992-abae21a299af"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("89b3ea58-6b20-4788-aea9-9e6d4d23386f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("910d5e91-40aa-4041-9291-c677d4ff1347"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b7ca2084-c987-49fa-88ce-d251c01ab9e1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ce8cb41f-7f63-401f-8a2d-8270dadb5787"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f6196ca1-76a9-4f06-b24d-b8441efc2674"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 19, 15, 49, 747, DateTimeKind.Local).AddTicks(7855),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 1, 19, 24, 6, 684, DateTimeKind.Local).AddTicks(472),
                oldComment: "Date of user registration");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4badbd30-e6aa-409f-acb6-42fbd6c8c6b2", new DateTime(2024, 12, 1, 19, 15, 49, 747, DateTimeKind.Local).AddTicks(9417), "AQAAAAIAAYagAAAAELNkhIWa7Z3+aWaI8LFAzXdKil0HcVKCRoQFYMM73anOk+75Tsb7DktrfSqjGX3BFQ==", "5af0fb0b-02fe-40d6-8990-044d9cbf049d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8379344-9886-4bca-8214-99d34ff7a969", new DateTime(2024, 12, 1, 19, 15, 49, 747, DateTimeKind.Local).AddTicks(9380), "AQAAAAIAAYagAAAAEAFh+hqgkmOcwNGA2X1Ua5EDLHhQzqgRXpJNWHRfImE4ke6C933rc3sXT/jVMo68GA==", "7b029b7d-8db0-483b-8ac5-282f31985743" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3f803bc-cef4-4729-92cf-c07be6733e9d", new DateTime(2024, 12, 1, 19, 15, 49, 747, DateTimeKind.Local).AddTicks(9235), "AQAAAAIAAYagAAAAEMiqeq3dvyJxcyi8ES2iYbqu49OIuhsHBqq12oM9cAnVAtANPYoF/1Xq/y0+nQMH0g==", "eb22cef3-9dec-4645-952e-79aa26903655" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95d458a7-115a-4db5-9319-809c7763d841"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cac0e666-e9e6-492b-928a-573a5fa3d181", new DateTime(2024, 12, 1, 19, 15, 49, 747, DateTimeKind.Local).AddTicks(9439), "AQAAAAIAAYagAAAAEPX6LyXybxy4v+z8NEKPdmE0jP57K4CvOMo3KFEXTYvX7zbYUf7r4Fj3e7Myny6bkw==", "ba5f2c4c-60d0-44ce-96a8-a62f6edf73dc" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("18c787e0-1531-41b0-a56b-b926f2dceedc"), "Пейзажи" },
                    { new Guid("1a35751f-e6a3-4b8f-8562-3fc6105cefc4"), "Мода" },
                    { new Guid("1b643584-44e4-4d9f-8201-f5edfe44820a"), "Животни" },
                    { new Guid("8bd18449-776a-4d7e-8d7a-51263240e34b"), "Пътуваня и дестинации" },
                    { new Guid("b36e4c0d-a834-4175-86d9-a41296c6543c"), "Черно-бяла фотография" },
                    { new Guid("b9e23f30-ea51-457e-b7fd-fc30e8f3241e"), "Архитектура" },
                    { new Guid("c5481055-d571-43fc-80b7-d71edcb7d7e0"), "Семейна фотография" },
                    { new Guid("df24031c-6c7d-4cb9-8ddd-7c9a40d9292b"), "Природа" },
                    { new Guid("f83d4203-2e21-4308-a68d-b6f96ca47814"), "Спорт" },
                    { new Guid("f9df8a40-77fb-4dad-bfdd-f3d89a2c3b9c"), "Храна и напитки" }
                });
        }
    }
}
