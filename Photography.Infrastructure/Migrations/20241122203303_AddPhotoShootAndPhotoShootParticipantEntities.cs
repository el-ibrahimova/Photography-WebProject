using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoShootAndPhotoShootParticipantEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2024, 11, 22, 22, 32, 59, 698, DateTimeKind.Local).AddTicks(6456),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 21, 21, 30, 31, 583, DateTimeKind.Local).AddTicks(6373),
                oldComment: "Date of user registration");

            migrationBuilder.CreateTable(
                name: "PhotoShoots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "PhotoShoot identifier"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "PhotoShoot Name"),
                    ImageUrl1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Image URL for first photo"),
                    ImageUrl2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Image URL for second photo"),
                    ImageUrl3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Image URL for third photo"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Photo shoot description"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Is photo shoot deleted"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of PhotoShoot creation")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoShoots", x => x.Id);
                },
                comment: "PhotoShoot");

            migrationBuilder.CreateTable(
                name: "PhotoShootParticipants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier"),
                    PhotoShootId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "PhotoShoot identifier"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "User identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoShootParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoShootParticipants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhotoShootParticipants_PhotoShoots_PhotoShootId",
                        column: x => x.PhotoShootId,
                        principalTable: "PhotoShoots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "PhotoShoot Participant");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5b34f795-2e1b-4284-b135-cecce865c14d"), "Архитектура" },
                    { new Guid("64e0e877-a0de-4ffe-a4a8-8996cefc9854"), "Пътуваня и дестинации" },
                    { new Guid("66633dae-13cd-4a0a-82c2-d65cb02ea03d"), "Мода" },
                    { new Guid("6fefd247-7336-442b-8c04-7becb4748543"), "Животни" },
                    { new Guid("80d1c776-b333-447d-9423-48d61f64e58c"), "Храна и напитки" },
                    { new Guid("8760ec5f-bb82-4122-ac8c-13d13ad2fa33"), "Черно-бяла фотография" },
                    { new Guid("bacc437f-40e2-4596-ab24-d9348652b2b2"), "Природа" },
                    { new Guid("c47c863e-40bc-4f49-bcf6-9bd1d3faeb85"), "Пейзажи" },
                    { new Guid("d493906d-1521-4c28-91ea-3b7cf26da8fe"), "Семейна фотография" },
                    { new Guid("e7b51a58-491a-44f8-acd1-4d10dd335077"), "Спорт" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhotoShootParticipants_PhotoShootId",
                table: "PhotoShootParticipants",
                column: "PhotoShootId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoShootParticipants_UserId",
                table: "PhotoShootParticipants",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotoShootParticipants");

            migrationBuilder.DropTable(
                name: "PhotoShoots");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5b34f795-2e1b-4284-b135-cecce865c14d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("64e0e877-a0de-4ffe-a4a8-8996cefc9854"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("66633dae-13cd-4a0a-82c2-d65cb02ea03d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6fefd247-7336-442b-8c04-7becb4748543"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("80d1c776-b333-447d-9423-48d61f64e58c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8760ec5f-bb82-4122-ac8c-13d13ad2fa33"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bacc437f-40e2-4596-ab24-d9348652b2b2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c47c863e-40bc-4f49-bcf6-9bd1d3faeb85"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d493906d-1521-4c28-91ea-3b7cf26da8fe"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e7b51a58-491a-44f8-acd1-4d10dd335077"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 21, 21, 30, 31, 583, DateTimeKind.Local).AddTicks(6373),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 22, 22, 32, 59, 698, DateTimeKind.Local).AddTicks(6456),
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
    }
}
