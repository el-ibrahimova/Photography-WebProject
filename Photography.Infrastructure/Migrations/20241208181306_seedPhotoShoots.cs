using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedPhotoShoots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PhotoShoots",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                comment: "PhotoShoot Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "PhotoShoot Name");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PhotoShoots",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                comment: "Photo shoot description",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Photo shoot description");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PhotoShoots",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 8, 20, 13, 4, 266, DateTimeKind.Local).AddTicks(1950),
                comment: "Date of PhotoShoot creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date of PhotoShoot creation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadedAt",
                table: "Photos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 8, 20, 13, 4, 262, DateTimeKind.Local).AddTicks(9819),
                comment: "Date of photo uploading",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 8, 15, 47, 13, 312, DateTimeKind.Local).AddTicks(3646),
                oldComment: "Date of photo uploading");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 8, 20, 13, 3, 576, DateTimeKind.Local).AddTicks(6819),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 8, 15, 47, 12, 806, DateTimeKind.Local).AddTicks(6232),
                oldComment: "Date of user registration");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f46b68d2-3b77-4c39-98cd-763f31c5a1f5", new DateTime(2024, 12, 8, 20, 13, 3, 577, DateTimeKind.Local).AddTicks(598), "AQAAAAIAAYagAAAAEOPIFKy2viXKEZGO9yKK1wepeQ7XhcT3JFEn+bFYVTC9siOLeuXQgUIzZn5I1DEXMg==", "d96a5b61-2dd3-4d50-b77c-e4cf296d0af6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a53e648-9984-448f-9082-860f72273e24", new DateTime(2024, 12, 8, 20, 13, 3, 577, DateTimeKind.Local).AddTicks(508), "AQAAAAIAAYagAAAAELlRVMaoZPyxt4Zhzxm3Vy3JU67mvbhUxSwLm686R0+scutaNaIQ6ire6XefOpLwwA==", "a096f7e9-6f0a-42c4-b38b-30ae3bc7c54d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69f9e5df-8bc2-46b2-a1f4-e516226f3da4", new DateTime(2024, 12, 8, 20, 13, 3, 577, DateTimeKind.Local).AddTicks(472), "AQAAAAIAAYagAAAAEJubeglJ5zrS+qmVrtyKJ09tkUcF78D4hK759H/QfCMO8cRQpvj+9VUqQO3t/om2Ig==", "c604ba63-a4df-4110-8f06-67cf6dc3888e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95d458a7-115a-4db5-9319-809c7763d841"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b73bf48b-0083-43ad-a792-aae23e78e17c", new DateTime(2024, 12, 8, 20, 13, 3, 577, DateTimeKind.Local).AddTicks(630), "AQAAAAIAAYagAAAAEChaPrlYM4mPjSuY780x8aqoi2ZGvnxRiLABQNANG2/L+fELedH4FHML5PIPk3IZOQ==", "e95c43d1-83f9-4890-b957-6389ff04d016" });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1932884a-dfdc-4acb-9334-ac88c1585170"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 20, 13, 4, 262, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1d2c011f-8eba-452a-a180-67349167774f"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 20, 13, 4, 262, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1d86b8c1-424a-464b-8582-edc8d1287125"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 20, 13, 4, 262, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2a4c4f88-6949-4b4a-bb4e-4227ec05a78e"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 20, 13, 4, 262, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2c9fbf60-4155-4777-a03f-3e7d5f01339b"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 20, 13, 4, 262, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("451bff33-d4fc-4217-bdda-a67251b1a427"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 20, 13, 4, 262, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("45bc9358-d7ec-41f8-9ea9-511e81306730"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 20, 13, 4, 262, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("8787347e-dc88-411d-9acd-fdd5937197ad"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 20, 13, 4, 262, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("8a009518-bb4a-4443-9e75-da259a75430a"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 20, 13, 4, 262, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("92d706d4-5969-412b-a663-463c71865623"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 20, 13, 4, 262, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("938b99b9-25ff-4a6a-89b5-e9d625ab72b4"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 20, 13, 4, 262, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("af7ef5d0-c362-43f7-8418-5c20ff360141"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 20, 13, 4, 262, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("b597a498-68d9-4883-b081-9f53d2237c2b"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 20, 13, 4, 262, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("cf01d099-9925-490d-b1b7-ef30e24167bb"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 20, 13, 4, 262, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("d8679b22-5cc2-4d0d-95e1-4f535dbdc56a"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 20, 13, 4, 262, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f06e0640-1421-4303-87c3-8a9d6d815f38"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 20, 13, 4, 262, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f2f36f3c-44f2-433c-bc88-bda0af4a5b5c"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 20, 13, 4, 262, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("fba07170-9485-423b-93dd-6c9fc392fc71"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 20, 13, 4, 262, DateTimeKind.Local).AddTicks(9819));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PhotoShoots",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "PhotoShoot Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldComment: "PhotoShoot Name");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PhotoShoots",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Photo shoot description",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldComment: "Photo shoot description");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PhotoShoots",
                type: "datetime2",
                nullable: false,
                comment: "Date of PhotoShoot creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 8, 20, 13, 4, 266, DateTimeKind.Local).AddTicks(1950),
                oldComment: "Date of PhotoShoot creation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadedAt",
                table: "Photos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 8, 15, 47, 13, 312, DateTimeKind.Local).AddTicks(3646),
                comment: "Date of photo uploading",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 8, 20, 13, 4, 262, DateTimeKind.Local).AddTicks(9819),
                oldComment: "Date of photo uploading");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 8, 15, 47, 12, 806, DateTimeKind.Local).AddTicks(6232),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 8, 20, 13, 3, 576, DateTimeKind.Local).AddTicks(6819),
                oldComment: "Date of user registration");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd3de267-945f-4657-9397-5115d73dd28a", new DateTime(2024, 12, 8, 15, 47, 12, 806, DateTimeKind.Local).AddTicks(8033), "AQAAAAIAAYagAAAAEP2hnR2TDMFbT6+Rg9Z8UB5mTOC9rOBiN1ZGkpI6lTILA2XImdvKUW8527e6xCFTAw==", "06697f6f-1754-4e07-ba97-cb9ead738537" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "429f9ffb-3efa-4c6b-84a8-fdf3ff269263", new DateTime(2024, 12, 8, 15, 47, 12, 806, DateTimeKind.Local).AddTicks(8015), "AQAAAAIAAYagAAAAEMobsHHqhqPsj2aW4eZF9G6sq8id9HPOhH19G3NIPiHnglgdXXCGmQG7EIyRzeuD/w==", "fdfd9a9d-04ce-43c8-a561-dd927b390894" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a620c9b-3550-495b-bdb6-d37fe0b27fbe", new DateTime(2024, 12, 8, 15, 47, 12, 806, DateTimeKind.Local).AddTicks(7974), "AQAAAAIAAYagAAAAEEMgCmVfklhnWyPZbOto13JYm5laOzHx8/1Wwr6LT4fj8tIIuHXALYXuvUZYmNmDZg==", "52a40fb0-242f-4f16-9414-0794ab2c908f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95d458a7-115a-4db5-9319-809c7763d841"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72d38399-a6e2-4ce2-8836-ef796ccf3eb2", new DateTime(2024, 12, 8, 15, 47, 12, 806, DateTimeKind.Local).AddTicks(8058), "AQAAAAIAAYagAAAAEMqh2m/zNK0Vdi9e+YhFsP140UpXnMoujrbfJHpRfU8MlF26gmkVrry0epil/mmMOg==", "c3ff6c4d-bb5e-4af7-988d-ec7d9c6ef384" });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1932884a-dfdc-4acb-9334-ac88c1585170"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 15, 47, 13, 312, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1d2c011f-8eba-452a-a180-67349167774f"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 15, 47, 13, 312, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1d86b8c1-424a-464b-8582-edc8d1287125"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 15, 47, 13, 312, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2a4c4f88-6949-4b4a-bb4e-4227ec05a78e"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 15, 47, 13, 312, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2c9fbf60-4155-4777-a03f-3e7d5f01339b"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 15, 47, 13, 312, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("451bff33-d4fc-4217-bdda-a67251b1a427"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 15, 47, 13, 312, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("45bc9358-d7ec-41f8-9ea9-511e81306730"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 15, 47, 13, 312, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("8787347e-dc88-411d-9acd-fdd5937197ad"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 15, 47, 13, 312, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("8a009518-bb4a-4443-9e75-da259a75430a"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 15, 47, 13, 312, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("92d706d4-5969-412b-a663-463c71865623"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 15, 47, 13, 312, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("938b99b9-25ff-4a6a-89b5-e9d625ab72b4"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 15, 47, 13, 312, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("af7ef5d0-c362-43f7-8418-5c20ff360141"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 15, 47, 13, 312, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("b597a498-68d9-4883-b081-9f53d2237c2b"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 15, 47, 13, 312, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("cf01d099-9925-490d-b1b7-ef30e24167bb"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 15, 47, 13, 312, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("d8679b22-5cc2-4d0d-95e1-4f535dbdc56a"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 15, 47, 13, 312, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f06e0640-1421-4303-87c3-8a9d6d815f38"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 15, 47, 13, 312, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f2f36f3c-44f2-433c-bc88-bda0af4a5b5c"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 15, 47, 13, 312, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("fba07170-9485-423b-93dd-6c9fc392fc71"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 8, 15, 47, 13, 312, DateTimeKind.Local).AddTicks(3646));
        }
    }
}
