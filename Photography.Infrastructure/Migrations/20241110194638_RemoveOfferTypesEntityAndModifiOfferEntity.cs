using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOfferTypesEntityAndModifiOfferEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_OfferTypes_OfferTypeId",
                table: "Offers");

            migrationBuilder.DropTable(
                name: "OfferTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderPhotos",
                table: "OrderPhotos");

            migrationBuilder.DropIndex(
                name: "IX_OrderPhotos_OrderId",
                table: "OrderPhotos");

            migrationBuilder.DropIndex(
                name: "IX_Offers_OfferTypeId",
                table: "Offers");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2761a9ec-938a-4cea-b60f-217eb2ef3696"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("65a8bd1a-bbe4-4a9f-b6f5-5167f9dd1565"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("91f3be7b-28eb-475b-b248-f66d5f6a2a4a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("966c40af-cb1e-4ea3-9207-6c3c124c0016"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9787b954-0d13-4646-a87b-501312304345"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c16fd6d5-bc85-4027-a67b-ffcb0c395260"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d51ce9f9-791d-4966-b5a2-791176bec956"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dd66ce32-a56a-4dea-b853-da19806c907a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e8428b5b-36da-4fe5-a83e-1bbe96eb0976"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f9f9608b-3183-41da-a704-26070ab156f0"));

            migrationBuilder.DropColumn(
                name: "OrderPhotoId",
                table: "OrderPhotos");

            migrationBuilder.DropColumn(
                name: "OfferTypeId",
                table: "Offers");

            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "OrderPhotos",
                type: "int",
                nullable: false,
                defaultValue: 1,
                comment: "Count of ordered photos",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "OfferId",
                table: "OrderPhotos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Offers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "Offer description");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Offers",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                comment: "Offer price");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 10, 21, 46, 37, 383, DateTimeKind.Local).AddTicks(6397),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 9, 23, 31, 40, 831, DateTimeKind.Local).AddTicks(7730),
                oldComment: "Date of user registration");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderPhotos",
                table: "OrderPhotos",
                columns: new[] { "OrderId", "PhotoId", "OfferId" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("09dcd4f9-eeb9-4f9f-bdec-6adcabc76f34"), "Семейна фотография" },
                    { new Guid("3be16e03-fda1-49fa-9e67-078a4b84a9ba"), "Животни" },
                    { new Guid("47bacd1f-e3ae-4a8a-8aa7-c05f2e10a87f"), "Пейзажи" },
                    { new Guid("6cfb4730-8136-4354-b017-02ca3ac34a2b"), "Храна и напитки" },
                    { new Guid("80287d2e-c344-4861-be81-7e476d139d1d"), "Спорт" },
                    { new Guid("8800b3ba-4393-483a-8335-6002d7119bcc"), "Архитектура" },
                    { new Guid("916f85ed-c97f-40af-bc9c-053772cc73c3"), "Черно-бяла фотография" },
                    { new Guid("96a4cab3-a1d2-442d-a5f7-cf8f8e0c427f"), "Мода" },
                    { new Guid("ba54fedb-9caa-4e89-b11a-979fbeeb6541"), "Природа" },
                    { new Guid("eef882b4-fb25-4d8d-88a4-c70fd931611d"), "Пътуваня и дестинации" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderPhotos_OfferId",
                table: "OrderPhotos",
                column: "OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPhotos_Offers_OfferId",
                table: "OrderPhotos",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPhotos_Offers_OfferId",
                table: "OrderPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderPhotos",
                table: "OrderPhotos");

            migrationBuilder.DropIndex(
                name: "IX_OrderPhotos_OfferId",
                table: "OrderPhotos");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("09dcd4f9-eeb9-4f9f-bdec-6adcabc76f34"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3be16e03-fda1-49fa-9e67-078a4b84a9ba"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("47bacd1f-e3ae-4a8a-8aa7-c05f2e10a87f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6cfb4730-8136-4354-b017-02ca3ac34a2b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("80287d2e-c344-4861-be81-7e476d139d1d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8800b3ba-4393-483a-8335-6002d7119bcc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("916f85ed-c97f-40af-bc9c-053772cc73c3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("96a4cab3-a1d2-442d-a5f7-cf8f8e0c427f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ba54fedb-9caa-4e89-b11a-979fbeeb6541"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eef882b4-fb25-4d8d-88a4-c70fd931611d"));

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "OrderPhotos");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Offers");

            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "OrderPhotos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1,
                oldComment: "Count of ordered photos");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderPhotoId",
                table: "OrderPhotos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Order photo identifier");

            migrationBuilder.AddColumn<Guid>(
                name: "OfferTypeId",
                table: "Offers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Offer type identifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 9, 23, 31, 40, 831, DateTimeKind.Local).AddTicks(7730),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 10, 21, 46, 37, 383, DateTimeKind.Local).AddTicks(6397),
                oldComment: "Date of user registration");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderPhotos",
                table: "OrderPhotos",
                column: "OrderPhotoId");

            migrationBuilder.CreateTable(
                name: "OfferTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Type identifier"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Type description"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferTypes", x => x.Id);
                },
                comment: "Type of offer");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2761a9ec-938a-4cea-b60f-217eb2ef3696"), "Спорт" },
                    { new Guid("65a8bd1a-bbe4-4a9f-b6f5-5167f9dd1565"), "Храна и напитки" },
                    { new Guid("91f3be7b-28eb-475b-b248-f66d5f6a2a4a"), "Семейна фотография" },
                    { new Guid("966c40af-cb1e-4ea3-9207-6c3c124c0016"), "Пътуваня и дестинации" },
                    { new Guid("9787b954-0d13-4646-a87b-501312304345"), "Архитектура" },
                    { new Guid("c16fd6d5-bc85-4027-a67b-ffcb0c395260"), "Пейзажи" },
                    { new Guid("d51ce9f9-791d-4966-b5a2-791176bec956"), "Мода" },
                    { new Guid("dd66ce32-a56a-4dea-b853-da19806c907a"), "Черно-бяла фотография" },
                    { new Guid("e8428b5b-36da-4fe5-a83e-1bbe96eb0976"), "Животни" },
                    { new Guid("f9f9608b-3183-41da-a704-26070ab156f0"), "Природа" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderPhotos_OrderId",
                table: "OrderPhotos",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_OfferTypeId",
                table: "Offers",
                column: "OfferTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_OfferTypes_OfferTypeId",
                table: "Offers",
                column: "OfferTypeId",
                principalTable: "OfferTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
