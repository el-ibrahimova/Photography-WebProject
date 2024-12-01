using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addIcollectionOfPhotographers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2024, 12, 1, 19, 43, 5, 322, DateTimeKind.Local).AddTicks(332),
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2024, 12, 1, 19, 24, 6, 684, DateTimeKind.Local).AddTicks(472),
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
    }
}
