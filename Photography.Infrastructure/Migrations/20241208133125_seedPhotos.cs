using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedPhotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0128e2fb-6d23-4b7c-b4c3-32ba2d661bdc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("20dcc3ee-6f4f-441a-b302-e5ae45d3ff54"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("454eb44e-4f45-42c0-916d-0b7bcb645f09"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("66697fa2-d97a-4e5d-a393-7c150bb5c48c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("693a0085-52cd-43c0-bb3e-8184738510d8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9df7978a-92bb-4f4e-a10d-ab1bf3a61e67"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cb1a2127-a789-454e-b3bb-c02b44ad4ef8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e86850d7-5089-466c-bdaa-c6d5da242475"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ec00bc7a-7296-4d51-bca3-29fc2b5f0d85"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("eea53935-59b8-43f8-a9bf-07d47be3bfa7"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadedAt",
                table: "Photos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 8, 15, 31, 23, 817, DateTimeKind.Local).AddTicks(7126),
                comment: "Date of photo uploading",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date of photo uploading");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Photos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "Description of the photo",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "Description of the photo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 8, 15, 31, 23, 219, DateTimeKind.Local).AddTicks(4534),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 1, 20, 15, 39, 301, DateTimeKind.Local).AddTicks(2437),
                oldComment: "Date of user registration");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is user deleted");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("34282161-754b-4c2a-2ec6-08dd12303248"), null, "Admin", "ADMIN" },
                    { new Guid("8246f96f-bd49-4db2-69ae-08dd176d0f38"), null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3af3b00d-8dde-455a-8d74-3119c5c73783", new DateTime(2024, 12, 8, 15, 31, 23, 219, DateTimeKind.Local).AddTicks(6390), "AQAAAAIAAYagAAAAEGeGiqcnUCHE126TUV1lm+LH1JC7Sqpja0MH8kJ0/7BHfpwY5GTDj335SgIwhv4ApQ==", "1f7c996c-2603-4366-8330-445b2d43080f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12c70195-26bf-450e-9d70-8016a637f2a8", new DateTime(2024, 12, 8, 15, 31, 23, 219, DateTimeKind.Local).AddTicks(6371), "AQAAAAIAAYagAAAAENQJ8oFtQIeTYjUjwm3CuRRp3tIPZKIobsqWKgkZxlOyjWuY0U9Z0MdOUgzWpaCj5A==", "ad1c08a8-63b8-4d73-b187-5e136e46536d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abcf0aed-3741-4ad2-beb1-eb547237baea", new DateTime(2024, 12, 8, 15, 31, 23, 219, DateTimeKind.Local).AddTicks(6343), "AQAAAAIAAYagAAAAEGoAvONH87P/cL+BB8CGZsHrDLQbV/v8THmBemDrYFBgF7fMl2yJSUD/E2RsrVVBdg==", "e9faff98-446f-4ced-a0cf-f723633be0e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95d458a7-115a-4db5-9319-809c7763d841"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "849201dd-2432-487b-a6e7-f3e543f40a29", new DateTime(2024, 12, 8, 15, 31, 23, 219, DateTimeKind.Local).AddTicks(6409), "AQAAAAIAAYagAAAAEDT4hBUVG9KXMuw28i8c2UxMpviJ5fHKxxtdstt1JFlYz5rx/RzkKGxyjkouYJQYgw==", "6d70faf7-8160-4c1a-94d2-4095ecc2ba9b" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("13a08262-6477-40f9-8db7-d6ebd4178e47"), "Архитектура" },
                    { new Guid("5d56e870-0080-4609-b189-94282ae97f31"), "Животни" },
                    { new Guid("8e1654cf-f730-41c7-92c2-0e280a94e7ce"), "Спорт" },
                    { new Guid("a5b3d93c-96d1-41ab-8d07-4cbf7754656f"), "Други" },
                    { new Guid("aa25251b-6ddc-438b-b5f0-28b3341731e3"), "Семейна фотография" },
                    { new Guid("bcc254e8-2534-4791-90e2-d17c03122886"), "Храна и напитки" },
                    { new Guid("c1f05508-2b56-46d8-86f9-027f5aaee67a"), "Пейзажи" },
                    { new Guid("c7347c35-effb-4cd6-9334-1348ec5d635b"), "Черно-бяла фотография" },
                    { new Guid("c7e699d1-fc73-459b-8f0f-11b7c4e101b5"), "Мода" },
                    { new Guid("e5aedd38-0dc5-49e4-b51a-acf63fd991a8"), "Пътуваня и дестинации" },
                    { new Guid("e5fd2c2f-40a0-4a90-a89c-81ab099fa581"), "Природа" }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "DeletedAt", "Description", "ImageUrl", "IsPrivate", "TagUser", "UserOwnerId" },
                values: new object[,]
                {
                    { new Guid("1932884a-dfdc-4acb-9334-ac88c1585170"), null, null, "https://live.staticflickr.com/65535/54179235838_98b592402f_n.jpg", false, null, new Guid("95d458a7-115a-4db5-9319-809c7763d841") },
                    { new Guid("1d2c011f-8eba-452a-a180-67349167774f"), null, "Long way home", "https://live.staticflickr.com/65535/54179236228_d084cd37fb_n.jpg", true, "Микаел", new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846") },
                    { new Guid("1d86b8c1-424a-464b-8582-edc8d1287125"), null, "Началото на нов живот", "https://live.staticflickr.com/65535/54179405645_da2965d7af_n.jpg", false, null, new Guid("95d458a7-115a-4db5-9319-809c7763d841") },
                    { new Guid("2a4c4f88-6949-4b4a-bb4e-4227ec05a78e"), null, "Книгите са вълшебни врати, през които можем да се пренесем в различни светове и реалности - Джим Хенсън", "https://live.staticflickr.com/65535/54179235863_ef79e9cd79.jpg", false, null, new Guid("95d458a7-115a-4db5-9319-809c7763d841") },
                    { new Guid("2c9fbf60-4155-4777-a03f-3e7d5f01339b"), null, null, "https://live.staticflickr.com/65535/54178078662_c668a923ac_n.jpg", false, null, new Guid("95d458a7-115a-4db5-9319-809c7763d841") },
                    { new Guid("451bff33-d4fc-4217-bdda-a67251b1a427"), null, "Girlish", "https://live.staticflickr.com/65535/54190853033_3552742834_w.jpg", true, null, new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846") },
                    { new Guid("45bc9358-d7ec-41f8-9ea9-511e81306730"), null, "The Tree", "https://live.staticflickr.com/65535/54179405720_de0340c35d_n.jpg", false, null, new Guid("95d458a7-115a-4db5-9319-809c7763d841") },
                    { new Guid("8787347e-dc88-411d-9acd-fdd5937197ad"), null, null, "https://live.staticflickr.com/65535/54189701457_55e2a97488_w.jpg", true, "Мери", new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846") },
                    { new Guid("8a009518-bb4a-4443-9e75-da259a75430a"), null, null, "https://live.staticflickr.com/65535/54178078787_53fe24ea4a_n.jpg", false, null, new Guid("95d458a7-115a-4db5-9319-809c7763d841") },
                    { new Guid("92d706d4-5969-412b-a663-463c71865623"), null, null, "https://live.staticflickr.com/65535/54191040230_19726ab96d_w.jpg", true, null, new Guid("95d458a7-115a-4db5-9319-809c7763d841") },
                    { new Guid("938b99b9-25ff-4a6a-89b5-e9d625ab72b4"), null, "Home, sweet home", "https://live.staticflickr.com/65535/54178963106_6698d8a47b_n.jpg", true, "Елмаз", new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d") },
                    { new Guid("af7ef5d0-c362-43f7-8418-5c20ff360141"), null, "Всяко нещо крие своята красота", "https://live.staticflickr.com/65535/54191040245_7864be5ce1_w.jpg", false, null, new Guid("95d458a7-115a-4db5-9319-809c7763d841") },
                    { new Guid("b597a498-68d9-4883-b081-9f53d2237c2b"), null, "Времето се променя и ние с него", "https://live.staticflickr.com/65535/54189701467_958b69d5bc_w.jpg", false, null, new Guid("95d458a7-115a-4db5-9319-809c7763d841") },
                    { new Guid("cf01d099-9925-490d-b1b7-ef30e24167bb"), null, null, "https://live.staticflickr.com/65535/54179405980_f9fb480fb0_n.jpg", false, null, new Guid("95d458a7-115a-4db5-9319-809c7763d841") },
                    { new Guid("d8679b22-5cc2-4d0d-95e1-4f535dbdc56a"), null, "Благодат", "https://live.staticflickr.com/65535/54179261934_74b915c632_n.jpg", false, "Ниса", new Guid("95d458a7-115a-4db5-9319-809c7763d841") },
                    { new Guid("f06e0640-1421-4303-87c3-8a9d6d815f38"), null, null, "https://live.staticflickr.com/65535/54179262309_60ce92ee0b_n.jpg", true, "Микаел", new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846") },
                    { new Guid("f2f36f3c-44f2-433c-bc88-bda0af4a5b5c"), null, "Розите са цветя, които говорят на сърцето, без да използват думи", "https://live.staticflickr.com/65535/54179261839_b223eaf533_n.jpg", false, "Ниса", new Guid("95d458a7-115a-4db5-9319-809c7763d841") },
                    { new Guid("fba07170-9485-423b-93dd-6c9fc392fc71"), null, "River road", "https://live.staticflickr.com/65535/54179262259_781ec3326b_n.jpg", true, null, new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("34282161-754b-4c2a-2ec6-08dd12303248"), new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd") },
                    { new Guid("8246f96f-bd49-4db2-69ae-08dd176d0f38"), new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d") },
                    { new Guid("8246f96f-bd49-4db2-69ae-08dd176d0f38"), new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846") },
                    { new Guid("8246f96f-bd49-4db2-69ae-08dd176d0f38"), new Guid("95d458a7-115a-4db5-9319-809c7763d841") }
                });

            migrationBuilder.InsertData(
                table: "PhotosCategories",
                columns: new[] { "CategoryId", "PhotoId" },
                values: new object[,]
                {
                    { new Guid("13a08262-6477-40f9-8db7-d6ebd4178e47"), new Guid("b597a498-68d9-4883-b081-9f53d2237c2b") },
                    { new Guid("5d56e870-0080-4609-b189-94282ae97f31"), new Guid("1932884a-dfdc-4acb-9334-ac88c1585170") },
                    { new Guid("a5b3d93c-96d1-41ab-8d07-4cbf7754656f"), new Guid("f2f36f3c-44f2-433c-bc88-bda0af4a5b5c") },
                    { new Guid("aa25251b-6ddc-438b-b5f0-28b3341731e3"), new Guid("938b99b9-25ff-4a6a-89b5-e9d625ab72b4") },
                    { new Guid("aa25251b-6ddc-438b-b5f0-28b3341731e3"), new Guid("f06e0640-1421-4303-87c3-8a9d6d815f38") },
                    { new Guid("c1f05508-2b56-46d8-86f9-027f5aaee67a"), new Guid("45bc9358-d7ec-41f8-9ea9-511e81306730") },
                    { new Guid("c7e699d1-fc73-459b-8f0f-11b7c4e101b5"), new Guid("451bff33-d4fc-4217-bdda-a67251b1a427") },
                    { new Guid("c7e699d1-fc73-459b-8f0f-11b7c4e101b5"), new Guid("8787347e-dc88-411d-9acd-fdd5937197ad") },
                    { new Guid("e5aedd38-0dc5-49e4-b51a-acf63fd991a8"), new Guid("451bff33-d4fc-4217-bdda-a67251b1a427") },
                    { new Guid("e5aedd38-0dc5-49e4-b51a-acf63fd991a8"), new Guid("af7ef5d0-c362-43f7-8418-5c20ff360141") },
                    { new Guid("e5fd2c2f-40a0-4a90-a89c-81ab099fa581"), new Guid("1932884a-dfdc-4acb-9334-ac88c1585170") },
                    { new Guid("e5fd2c2f-40a0-4a90-a89c-81ab099fa581"), new Guid("1d86b8c1-424a-464b-8582-edc8d1287125") },
                    { new Guid("e5fd2c2f-40a0-4a90-a89c-81ab099fa581"), new Guid("2c9fbf60-4155-4777-a03f-3e7d5f01339b") },
                    { new Guid("e5fd2c2f-40a0-4a90-a89c-81ab099fa581"), new Guid("45bc9358-d7ec-41f8-9ea9-511e81306730") },
                    { new Guid("e5fd2c2f-40a0-4a90-a89c-81ab099fa581"), new Guid("8a009518-bb4a-4443-9e75-da259a75430a") },
                    { new Guid("e5fd2c2f-40a0-4a90-a89c-81ab099fa581"), new Guid("938b99b9-25ff-4a6a-89b5-e9d625ab72b4") },
                    { new Guid("e5fd2c2f-40a0-4a90-a89c-81ab099fa581"), new Guid("d8679b22-5cc2-4d0d-95e1-4f535dbdc56a") },
                    { new Guid("e5fd2c2f-40a0-4a90-a89c-81ab099fa581"), new Guid("f06e0640-1421-4303-87c3-8a9d6d815f38") },
                    { new Guid("e5fd2c2f-40a0-4a90-a89c-81ab099fa581"), new Guid("fba07170-9485-423b-93dd-6c9fc392fc71") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("34282161-754b-4c2a-2ec6-08dd12303248"), new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8246f96f-bd49-4db2-69ae-08dd176d0f38"), new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8246f96f-bd49-4db2-69ae-08dd176d0f38"), new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8246f96f-bd49-4db2-69ae-08dd176d0f38"), new Guid("95d458a7-115a-4db5-9319-809c7763d841") });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8e1654cf-f730-41c7-92c2-0e280a94e7ce"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bcc254e8-2534-4791-90e2-d17c03122886"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c7347c35-effb-4cd6-9334-1348ec5d635b"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1d2c011f-8eba-452a-a180-67349167774f"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2a4c4f88-6949-4b4a-bb4e-4227ec05a78e"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("92d706d4-5969-412b-a663-463c71865623"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("cf01d099-9925-490d-b1b7-ef30e24167bb"));

            migrationBuilder.DeleteData(
                table: "PhotosCategories",
                keyColumns: new[] { "CategoryId", "PhotoId" },
                keyValues: new object[] { new Guid("13a08262-6477-40f9-8db7-d6ebd4178e47"), new Guid("b597a498-68d9-4883-b081-9f53d2237c2b") });

            migrationBuilder.DeleteData(
                table: "PhotosCategories",
                keyColumns: new[] { "CategoryId", "PhotoId" },
                keyValues: new object[] { new Guid("5d56e870-0080-4609-b189-94282ae97f31"), new Guid("1932884a-dfdc-4acb-9334-ac88c1585170") });

            migrationBuilder.DeleteData(
                table: "PhotosCategories",
                keyColumns: new[] { "CategoryId", "PhotoId" },
                keyValues: new object[] { new Guid("a5b3d93c-96d1-41ab-8d07-4cbf7754656f"), new Guid("f2f36f3c-44f2-433c-bc88-bda0af4a5b5c") });

            migrationBuilder.DeleteData(
                table: "PhotosCategories",
                keyColumns: new[] { "CategoryId", "PhotoId" },
                keyValues: new object[] { new Guid("aa25251b-6ddc-438b-b5f0-28b3341731e3"), new Guid("938b99b9-25ff-4a6a-89b5-e9d625ab72b4") });

            migrationBuilder.DeleteData(
                table: "PhotosCategories",
                keyColumns: new[] { "CategoryId", "PhotoId" },
                keyValues: new object[] { new Guid("aa25251b-6ddc-438b-b5f0-28b3341731e3"), new Guid("f06e0640-1421-4303-87c3-8a9d6d815f38") });

            migrationBuilder.DeleteData(
                table: "PhotosCategories",
                keyColumns: new[] { "CategoryId", "PhotoId" },
                keyValues: new object[] { new Guid("c1f05508-2b56-46d8-86f9-027f5aaee67a"), new Guid("45bc9358-d7ec-41f8-9ea9-511e81306730") });

            migrationBuilder.DeleteData(
                table: "PhotosCategories",
                keyColumns: new[] { "CategoryId", "PhotoId" },
                keyValues: new object[] { new Guid("c7e699d1-fc73-459b-8f0f-11b7c4e101b5"), new Guid("451bff33-d4fc-4217-bdda-a67251b1a427") });

            migrationBuilder.DeleteData(
                table: "PhotosCategories",
                keyColumns: new[] { "CategoryId", "PhotoId" },
                keyValues: new object[] { new Guid("c7e699d1-fc73-459b-8f0f-11b7c4e101b5"), new Guid("8787347e-dc88-411d-9acd-fdd5937197ad") });

            migrationBuilder.DeleteData(
                table: "PhotosCategories",
                keyColumns: new[] { "CategoryId", "PhotoId" },
                keyValues: new object[] { new Guid("e5aedd38-0dc5-49e4-b51a-acf63fd991a8"), new Guid("451bff33-d4fc-4217-bdda-a67251b1a427") });

            migrationBuilder.DeleteData(
                table: "PhotosCategories",
                keyColumns: new[] { "CategoryId", "PhotoId" },
                keyValues: new object[] { new Guid("e5aedd38-0dc5-49e4-b51a-acf63fd991a8"), new Guid("af7ef5d0-c362-43f7-8418-5c20ff360141") });

            migrationBuilder.DeleteData(
                table: "PhotosCategories",
                keyColumns: new[] { "CategoryId", "PhotoId" },
                keyValues: new object[] { new Guid("e5fd2c2f-40a0-4a90-a89c-81ab099fa581"), new Guid("1932884a-dfdc-4acb-9334-ac88c1585170") });

            migrationBuilder.DeleteData(
                table: "PhotosCategories",
                keyColumns: new[] { "CategoryId", "PhotoId" },
                keyValues: new object[] { new Guid("e5fd2c2f-40a0-4a90-a89c-81ab099fa581"), new Guid("1d86b8c1-424a-464b-8582-edc8d1287125") });

            migrationBuilder.DeleteData(
                table: "PhotosCategories",
                keyColumns: new[] { "CategoryId", "PhotoId" },
                keyValues: new object[] { new Guid("e5fd2c2f-40a0-4a90-a89c-81ab099fa581"), new Guid("2c9fbf60-4155-4777-a03f-3e7d5f01339b") });

            migrationBuilder.DeleteData(
                table: "PhotosCategories",
                keyColumns: new[] { "CategoryId", "PhotoId" },
                keyValues: new object[] { new Guid("e5fd2c2f-40a0-4a90-a89c-81ab099fa581"), new Guid("45bc9358-d7ec-41f8-9ea9-511e81306730") });

            migrationBuilder.DeleteData(
                table: "PhotosCategories",
                keyColumns: new[] { "CategoryId", "PhotoId" },
                keyValues: new object[] { new Guid("e5fd2c2f-40a0-4a90-a89c-81ab099fa581"), new Guid("8a009518-bb4a-4443-9e75-da259a75430a") });

            migrationBuilder.DeleteData(
                table: "PhotosCategories",
                keyColumns: new[] { "CategoryId", "PhotoId" },
                keyValues: new object[] { new Guid("e5fd2c2f-40a0-4a90-a89c-81ab099fa581"), new Guid("938b99b9-25ff-4a6a-89b5-e9d625ab72b4") });

            migrationBuilder.DeleteData(
                table: "PhotosCategories",
                keyColumns: new[] { "CategoryId", "PhotoId" },
                keyValues: new object[] { new Guid("e5fd2c2f-40a0-4a90-a89c-81ab099fa581"), new Guid("d8679b22-5cc2-4d0d-95e1-4f535dbdc56a") });

            migrationBuilder.DeleteData(
                table: "PhotosCategories",
                keyColumns: new[] { "CategoryId", "PhotoId" },
                keyValues: new object[] { new Guid("e5fd2c2f-40a0-4a90-a89c-81ab099fa581"), new Guid("f06e0640-1421-4303-87c3-8a9d6d815f38") });

            migrationBuilder.DeleteData(
                table: "PhotosCategories",
                keyColumns: new[] { "CategoryId", "PhotoId" },
                keyValues: new object[] { new Guid("e5fd2c2f-40a0-4a90-a89c-81ab099fa581"), new Guid("fba07170-9485-423b-93dd-6c9fc392fc71") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("34282161-754b-4c2a-2ec6-08dd12303248"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8246f96f-bd49-4db2-69ae-08dd176d0f38"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("13a08262-6477-40f9-8db7-d6ebd4178e47"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5d56e870-0080-4609-b189-94282ae97f31"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a5b3d93c-96d1-41ab-8d07-4cbf7754656f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aa25251b-6ddc-438b-b5f0-28b3341731e3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c1f05508-2b56-46d8-86f9-027f5aaee67a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c7e699d1-fc73-459b-8f0f-11b7c4e101b5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e5aedd38-0dc5-49e4-b51a-acf63fd991a8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e5fd2c2f-40a0-4a90-a89c-81ab099fa581"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1932884a-dfdc-4acb-9334-ac88c1585170"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1d86b8c1-424a-464b-8582-edc8d1287125"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2c9fbf60-4155-4777-a03f-3e7d5f01339b"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("451bff33-d4fc-4217-bdda-a67251b1a427"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("45bc9358-d7ec-41f8-9ea9-511e81306730"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("8787347e-dc88-411d-9acd-fdd5937197ad"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("8a009518-bb4a-4443-9e75-da259a75430a"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("938b99b9-25ff-4a6a-89b5-e9d625ab72b4"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("af7ef5d0-c362-43f7-8418-5c20ff360141"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("b597a498-68d9-4883-b081-9f53d2237c2b"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("d8679b22-5cc2-4d0d-95e1-4f535dbdc56a"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f06e0640-1421-4303-87c3-8a9d6d815f38"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f2f36f3c-44f2-433c-bc88-bda0af4a5b5c"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("fba07170-9485-423b-93dd-6c9fc392fc71"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadedAt",
                table: "Photos",
                type: "datetime2",
                nullable: false,
                comment: "Date of photo uploading",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 8, 15, 31, 23, 817, DateTimeKind.Local).AddTicks(7126),
                oldComment: "Date of photo uploading");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Photos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Description of the photo",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true,
                oldComment: "Description of the photo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 1, 20, 15, 39, 301, DateTimeKind.Local).AddTicks(2437),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 8, 15, 31, 23, 219, DateTimeKind.Local).AddTicks(4534),
                oldComment: "Date of user registration");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27d649ee-03d9-4f4c-8917-1b9a2a06890c", new DateTime(2024, 12, 1, 20, 15, 39, 301, DateTimeKind.Local).AddTicks(3596), "AQAAAAIAAYagAAAAEII8rJJS27aS9ghbnwHheCZScxdLbgHef+5sbKWdxQaohPmi++qsNQXBlf2zI5benQ==", "73f0a8b9-7929-4ac2-9b8d-1e2954492a1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "733c374a-5bff-43b9-bda4-47bc4cd8ae02", new DateTime(2024, 12, 1, 20, 15, 39, 301, DateTimeKind.Local).AddTicks(3572), "AQAAAAIAAYagAAAAEBQGis9Ao2m8KGjLVYs9TItMLhGPMqjzabshi7vHNPSYzy9rR09VnHm61SeIYKS3vQ==", "d9e79d0d-03ac-4368-b822-72fbcd5769ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f05befaa-2c9c-4f4b-8a49-d765c6ac7bf7", new DateTime(2024, 12, 1, 20, 15, 39, 301, DateTimeKind.Local).AddTicks(3538), "AQAAAAIAAYagAAAAENWlhKiTAoCWoKdxiJhZznval6Wm9XcsG7JrsLm91VoVGFSaHjFvgyhnB4joXpt3lw==", "2966045a-d48f-41c7-b116-e6413673fbec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95d458a7-115a-4db5-9319-809c7763d841"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57ce5500-e886-4267-aaed-63a100fe6cb1", new DateTime(2024, 12, 1, 20, 15, 39, 301, DateTimeKind.Local).AddTicks(3617), "AQAAAAIAAYagAAAAEJFyjNtmcTm3kZhfsCOYJDTQVThVxSBJk+yo1qXhovyn8aOlFdPOTDVtvh2bjeX4lw==", "b640ac75-fe0d-4ec4-bd76-3d5f8ebb6a77" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0128e2fb-6d23-4b7c-b4c3-32ba2d661bdc"), "Архитектура" },
                    { new Guid("20dcc3ee-6f4f-441a-b302-e5ae45d3ff54"), "Мода" },
                    { new Guid("454eb44e-4f45-42c0-916d-0b7bcb645f09"), "Семейна фотография" },
                    { new Guid("66697fa2-d97a-4e5d-a393-7c150bb5c48c"), "Пейзажи" },
                    { new Guid("693a0085-52cd-43c0-bb3e-8184738510d8"), "Пътуваня и дестинации" },
                    { new Guid("9df7978a-92bb-4f4e-a10d-ab1bf3a61e67"), "Спорт" },
                    { new Guid("cb1a2127-a789-454e-b3bb-c02b44ad4ef8"), "Храна и напитки" },
                    { new Guid("e86850d7-5089-466c-bdaa-c6d5da242475"), "Черно-бяла фотография" },
                    { new Guid("ec00bc7a-7296-4d51-bca3-29fc2b5f0d85"), "Животни" },
                    { new Guid("eea53935-59b8-43f8-a9bf-07d47be3bfa7"), "Природа" }
                });
        }
    }
}
