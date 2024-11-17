using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deleteCommentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Offers_OfferId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OfferId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0ef7c457-fec7-4c00-a334-762e6a84d3f9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1cdea3e7-0f92-4dab-92dc-1e3d6a37a1f8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5cc78c54-44f7-4895-8db0-d762968f1001"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7060b10c-0ce1-4c2e-87c9-c071c517b6c3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("75bdf241-2093-455c-b640-869f9b4bf52a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7e53213f-0951-437a-9613-a18db925bba9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8256a07f-e113-4f3c-8725-1c5368c7694d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9b627dc8-34fd-40fc-b615-ba1fb3a68e3e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a550a3d7-c39f-4506-bed6-2715b0970675"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a72a41b7-fa6c-4efc-bbef-ad4ffa07fd39"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("0f3e9895-7485-411c-a113-001e68455bab"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("14de24dc-e762-4ec8-801d-f101e811239f"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("a22e5e73-4ee9-4f2f-99e4-c5c168c16595"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("a5c2d5e5-3252-4e5e-b1c2-c77695b98140"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("d134ca62-15d6-4db3-9854-a093d8bb3160"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("eea06896-0a27-4fc8-9fcf-b7fc4be1077d"));

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 17, 12, 39, 5, 3, DateTimeKind.Local).AddTicks(439),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 17, 9, 39, 48, 266, DateTimeKind.Local).AddTicks(6108),
                oldComment: "Date of user registration");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("12bb2780-7894-49d0-a62c-003cf2f57bb9"), "Храна и напитки" },
                    { new Guid("17436b90-b536-48b5-b0df-d9501687089f"), "Животни" },
                    { new Guid("35979756-91c1-4ad8-985a-8e078a077db5"), "Природа" },
                    { new Guid("6eb17588-884c-4874-9adf-df54da20ad16"), "Пейзажи" },
                    { new Guid("886e1930-df9b-4fe9-bb22-2268bf920065"), "Черно-бяла фотография" },
                    { new Guid("9f079124-5d71-4a4d-9e59-e8e49fd9cb09"), "Мода" },
                    { new Guid("bcc288d1-dc27-48d7-8615-301dd8508ab3"), "Пътуваня и дестинации" },
                    { new Guid("c125c138-6659-4a06-9b25-9c1632e0a98c"), "Архитектура" },
                    { new Guid("cd11b5be-d4f5-4a61-b920-b8c4dd4da1c0"), "Спорт" },
                    { new Guid("f3719d8c-2619-4c6d-8655-6c3f2805db87"), "Семейна фотография" }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("7e9dd99b-ab3e-49b7-a609-06c713076a33"), null, "Печат на снимка в размер 10x15", 0.45m },
                    { new Guid("8784f6a9-7ec7-450e-ac1b-7efcf48ea1b3"), null, "Печат на снимка в размер 13x18", 1.20m },
                    { new Guid("be5b0995-c7bc-48c4-8fd6-e6db847c71f7"), null, "Печат на снимка в размер А4", 2.00m },
                    { new Guid("bf1eb655-30ab-4731-88d3-308dbfeb5339"), null, "Печат на снимка в размер 9х13", 0.40m },
                    { new Guid("d5b8c1ec-ea23-4cf4-b099-f9f21253d59b"), null, "Печат на снимка върху чаша", 12.00m },
                    { new Guid("da35988a-f4ab-4ed8-88e1-02c7976e450e"), "Възможни са различни размери", "Печат на снимка върху тениска", 18m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("12bb2780-7894-49d0-a62c-003cf2f57bb9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("17436b90-b536-48b5-b0df-d9501687089f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("35979756-91c1-4ad8-985a-8e078a077db5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6eb17588-884c-4874-9adf-df54da20ad16"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("886e1930-df9b-4fe9-bb22-2268bf920065"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9f079124-5d71-4a4d-9e59-e8e49fd9cb09"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bcc288d1-dc27-48d7-8615-301dd8508ab3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c125c138-6659-4a06-9b25-9c1632e0a98c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cd11b5be-d4f5-4a61-b920-b8c4dd4da1c0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f3719d8c-2619-4c6d-8655-6c3f2805db87"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("7e9dd99b-ab3e-49b7-a609-06c713076a33"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("8784f6a9-7ec7-450e-ac1b-7efcf48ea1b3"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("be5b0995-c7bc-48c4-8fd6-e6db847c71f7"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("bf1eb655-30ab-4731-88d3-308dbfeb5339"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("d5b8c1ec-ea23-4cf4-b099-f9f21253d59b"));

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("da35988a-f4ab-4ed8-88e1-02c7976e450e"));

            migrationBuilder.AddColumn<Guid>(
                name: "OfferId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Offer identifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 17, 9, 39, 48, 266, DateTimeKind.Local).AddTicks(6108),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 17, 12, 39, 5, 3, DateTimeKind.Local).AddTicks(439),
                oldComment: "Date of user registration");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Comment identifier"),
                    PhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Photo identifier"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "User identifier"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of post"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Is the comment deleted"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Name of the user")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Photo comments");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0ef7c457-fec7-4c00-a334-762e6a84d3f9"), "Пейзажи" },
                    { new Guid("1cdea3e7-0f92-4dab-92dc-1e3d6a37a1f8"), "Природа" },
                    { new Guid("5cc78c54-44f7-4895-8db0-d762968f1001"), "Семейна фотография" },
                    { new Guid("7060b10c-0ce1-4c2e-87c9-c071c517b6c3"), "Мода" },
                    { new Guid("75bdf241-2093-455c-b640-869f9b4bf52a"), "Черно-бяла фотография" },
                    { new Guid("7e53213f-0951-437a-9613-a18db925bba9"), "Храна и напитки" },
                    { new Guid("8256a07f-e113-4f3c-8725-1c5368c7694d"), "Спорт" },
                    { new Guid("9b627dc8-34fd-40fc-b615-ba1fb3a68e3e"), "Пътуваня и дестинации" },
                    { new Guid("a550a3d7-c39f-4506-bed6-2715b0970675"), "Архитектура" },
                    { new Guid("a72a41b7-fa6c-4efc-bbef-ad4ffa07fd39"), "Животни" }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0f3e9895-7485-411c-a113-001e68455bab"), null, "Печат на снимка в размер 9х13", 0.40m },
                    { new Guid("14de24dc-e762-4ec8-801d-f101e811239f"), null, "Печат на снимка в размер 13x18", 1.20m },
                    { new Guid("a22e5e73-4ee9-4f2f-99e4-c5c168c16595"), null, "Печат на снимка в размер 10x15", 0.45m },
                    { new Guid("a5c2d5e5-3252-4e5e-b1c2-c77695b98140"), "Възможни са различни размери", "Печат на снимка върху тениска", 18m },
                    { new Guid("d134ca62-15d6-4db3-9854-a093d8bb3160"), null, "Печат на снимка върху чаша", 12.00m },
                    { new Guid("eea06896-0a27-4fc8-9fcf-b7fc4be1077d"), null, "Печат на снимка в размер А4", 2.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OfferId",
                table: "Orders",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PhotoId",
                table: "Comments",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Offers_OfferId",
                table: "Orders",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
