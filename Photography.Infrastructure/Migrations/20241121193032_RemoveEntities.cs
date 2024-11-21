using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderPhotos");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Orders");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 21, 21, 30, 31, 583, DateTimeKind.Local).AddTicks(6373),
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
                    { new Guid("032f66c1-ca21-49c6-ae27-e5dcdc149879"), "Животни" },
                    { new Guid("243ed5dd-fa46-4510-bd19-8c22af08a3cc"), "Пейзажи" },
                    { new Guid("26d6c4df-6201-404e-8cda-c6c6cae1122d"), "Архитектура" },
                    { new Guid("cc652f85-ba78-47bf-a889-1563b9f720f8"), "Мода" },
                    { new Guid("d0b0b66a-e4e6-4192-86e8-0a1e2abc804b"), "Храна и напитки" },
                    { new Guid("d533d7b9-b12c-4e21-a0da-b6dc17a31272"), "Спорт" },
                    { new Guid("da592ebf-895c-4913-9a3d-0d095db87dc9"), "Пътуваня и дестинации" },
                    { new Guid("def1d6da-e599-4f6c-8803-3c19744b1145"), "Природа" },
                    { new Guid("effc6304-7efa-4b84-a5a0-5fe813521b6f"), "Семейна фотография" },
                    { new Guid("f4227f6c-8eff-47c5-88f9-2226aaa10a06"), "Черно-бяла фотография" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("032f66c1-ca21-49c6-ae27-e5dcdc149879"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("243ed5dd-fa46-4510-bd19-8c22af08a3cc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("26d6c4df-6201-404e-8cda-c6c6cae1122d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cc652f85-ba78-47bf-a889-1563b9f720f8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d0b0b66a-e4e6-4192-86e8-0a1e2abc804b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d533d7b9-b12c-4e21-a0da-b6dc17a31272"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("da592ebf-895c-4913-9a3d-0d095db87dc9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("def1d6da-e599-4f6c-8803-3c19744b1145"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("effc6304-7efa-4b84-a5a0-5fe813521b6f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f4227f6c-8eff-47c5-88f9-2226aaa10a06"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 21, 21, 22, 50, 609, DateTimeKind.Local).AddTicks(8722),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 21, 21, 30, 31, 583, DateTimeKind.Local).AddTicks(6373),
                oldComment: "Date of user registration");

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Offer identifier"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Offer name"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Offer price")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                },
                comment: "Offers");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Order identifier"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "User identifier"),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Order");

            migrationBuilder.CreateTable(
                name: "OrderPhotos",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Order identifier"),
                    PhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Photo identifier"),
                    OfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false, defaultValue: 1, comment: "Count of ordered photos")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPhotos", x => new { x.OrderId, x.PhotoId, x.OfferId });
                    table.ForeignKey(
                        name: "FK_OrderPhotos_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPhotos_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPhotos_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Order photo");

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

            migrationBuilder.CreateIndex(
                name: "IX_OrderPhotos_OfferId",
                table: "OrderPhotos",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPhotos_PhotoId",
                table: "OrderPhotos",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }
    }
}
