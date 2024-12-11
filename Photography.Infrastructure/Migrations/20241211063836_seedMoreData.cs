using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedMoreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PhotoShoots",
                keyColumn: "Id",
                keyValue: new Guid("02ff112d-8f1c-42f1-90cc-2f4bd247a1aa"));

            migrationBuilder.DeleteData(
                table: "PhotoShoots",
                keyColumn: "Id",
                keyValue: new Guid("cb938183-7604-4106-842e-ded6d31f667a"));

            migrationBuilder.DeleteData(
                table: "PhotoShoots",
                keyColumn: "Id",
                keyValue: new Guid("e3594e46-6915-4a1c-8ecf-8a1fb9f814ad"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PhotoShoots",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 11, 8, 38, 30, 105, DateTimeKind.Local).AddTicks(1292),
                comment: "Date of PhotoShoot creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 10, 20, 19, 12, 589, DateTimeKind.Local).AddTicks(1322),
                oldComment: "Date of PhotoShoot creation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadedAt",
                table: "Photos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 11, 8, 38, 30, 96, DateTimeKind.Local).AddTicks(9577),
                comment: "Date of photo uploading",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 10, 20, 19, 12, 585, DateTimeKind.Local).AddTicks(6599),
                oldComment: "Date of photo uploading");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 11, 8, 38, 28, 517, DateTimeKind.Local).AddTicks(2501),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 10, 20, 19, 12, 75, DateTimeKind.Local).AddTicks(6120),
                oldComment: "Date of user registration");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d42d237b-bcb5-4e2c-9ba5-e961434b741a", new DateTime(2024, 12, 11, 8, 38, 28, 517, DateTimeKind.Local).AddTicks(5631), "AQAAAAIAAYagAAAAEPIoaT/Aum6ToOhhloRfSuJuutB6TRPed9hO5RB42WHQDObNGq1CGYNuL/aKtqBm3g==", "6d6eeb24-627e-4b04-a553-6c4de06ee54b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3cfaab8-067d-4ad1-b811-16abef3e9ade", new DateTime(2024, 12, 11, 8, 38, 28, 517, DateTimeKind.Local).AddTicks(5603), "AQAAAAIAAYagAAAAEBWjeMFSXefiWKyIK15QJ9Int0+jxjaDS4mBU0bk+l/xW9FJcGE0bpTd/O59zB+9Jg==", "18a0ac5e-6d82-4464-960f-704c94b2eff3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9dfdfcb4-86cb-4699-be56-6fec396a07db", new DateTime(2024, 12, 11, 8, 38, 28, 517, DateTimeKind.Local).AddTicks(5548), "AQAAAAIAAYagAAAAEGopl5hbzi2A5+ceIfSwpYcMKje4cL3bfj0C1jT7G7dYma/sytr28QHPykREflURZw==", "2a7e4409-1636-4c6f-9977-73cb6eafe981" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95d458a7-115a-4db5-9319-809c7763d841"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee71f933-9827-48be-9b85-b9d41b501b7f", new DateTime(2024, 12, 11, 8, 38, 28, 517, DateTimeKind.Local).AddTicks(5658), "AQAAAAIAAYagAAAAEPFRam/eiIssc9EYs/Z+Cu2oUo3ebmilAbY00CV9fXSC8B372YxVO287iFT8R20lbg==", "d84db06a-c01e-4398-991e-ffae57e9f4be" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "JoinedAt", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("5dbf7705-08fa-472d-bf9c-1faeaa220749"), 0, "dc062bb2-db65-4955-ad77-5b262d424b4f", "photographerMiki@gmail.com", false, null, new DateTime(2024, 12, 11, 8, 38, 28, 517, DateTimeKind.Local).AddTicks(5685), null, false, null, "PHOTOGRAPHERMIKI@GMAIL.COM", "PHOTOGRAPHERMIKI", "AQAAAAIAAYagAAAAEGeS4Uqm4Y665p0ubfZKH2BH4dKOq8D4W4NUDEO3kosE49yaSLTdIqEXaUYL4/+p6A==", null, false, "d3274b86-1590-431f-94b0-c5ec9ea2f773", false, "PhotographerMiki" });

            migrationBuilder.InsertData(
                table: "PhotoShoots",
                columns: new[] { "Id", "Description", "ImageUrl1", "ImageUrl2", "ImageUrl3", "Name", "PhotographerId" },
                values: new object[,]
                {
                    { new Guid("42086882-b380-438e-a3df-9f36234fa1b6"), "Потопи се в свят на свежи цветове, изпълнен с радост и уют! Декорът с балони и маргаритки е перфектен избор за всяко събитие, носещо усмивки и пролетно настроение.\n\n✨ Как изглежда декорът?\n\n🎈 Балони в нежни пастелни тонове или ярки цветове, подредени в елегантни арки, букети или гирлянди.\n🌼 Красиви маргаритки – естествени или декоративни, вплетени между балоните, създавайки хармонична и весела атмосфера.\n🌿 Малки зелени акценти за още повече природна свежест.\n🌟 Възможност за добавяне на персонализирани елементи – имена, надписи или специални фигури.\n💡 За какви събития е подходящ?\n\n🎂 Рождени дни и празненства с пролетна или лятна тематика.\n👶 Бебешки фотосесии или кръщенета.\n🥂 Романтични събития като годежи или сватбени фотосесии.\n📸 Тематични фотосесии на открито или в уютна студийна атмосфера.\n✨ Създай празник, изпълнен с нежност и красота!\nДекорът с балони и маргаритки ще добави неповторима топлина и стил към твоето събитие.", "https://live.staticflickr.com/65535/54190601336_b62502c21a_w.jpg", "https://live.staticflickr.com/65535/54189701927_c384ca435f_n.jpg", null, "Декор с балони и маргаритки – свежест и радост в едно!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") },
                    { new Guid("5456de68-3e58-472d-a97a-00c11e3b77d0"), "Потопи се в приказна атмосфера, изпълнена с ефирна нежност и радост! Декорът с балони и облаци е перфектният избор за създаване на незабравима фотосесия, парти или специално събитие.\n\n✨ Как изглежда декорът?\n\n🌥️ Нежни пухкави облаци, които създават усещане за лекота и безгрижие.\n🎈 Балони в пастелни или ярки цветове, красиво подредени в арки, букети или плаващи композиции.\n✨ Блясък и акценти – включваме светлинки или блестящи детайли за още повече магия.\n🌟 Персонализирани елементи – добавяме надписи, цифри или малки декорации, съобразени с темата на събитието.\n💡 За кого е подходящ този декор?\n\n👶 Бебешки фотосесии и рождени дни.\n💍 Романтични моменти като предложения за брак или годежи.\n🎉 Детски партита и тематични събития.\n📸 Уникални фотосесии за всеки, който иска да се почувства като в облаците.\nСъздай магия, която ще остави незабравими спомени! ✨\nПозволи на мечтите си да полетят с нашия декор от балони и облаци.", "https://live.staticflickr.com/65535/54190601381_ee8cc95269_w.jpg", "https://live.staticflickr.com/65535/54190601406_faae4a7942_w.jpg", null, "Декор с балони и облаци – магията на мечтите!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") }
                });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1932884a-dfdc-4acb-9334-ac88c1585170"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 8, 38, 30, 96, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1d2c011f-8eba-452a-a180-67349167774f"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 8, 38, 30, 96, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1d86b8c1-424a-464b-8582-edc8d1287125"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 8, 38, 30, 96, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2a4c4f88-6949-4b4a-bb4e-4227ec05a78e"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 8, 38, 30, 96, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2c9fbf60-4155-4777-a03f-3e7d5f01339b"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 8, 38, 30, 96, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("451bff33-d4fc-4217-bdda-a67251b1a427"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 8, 38, 30, 96, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("45bc9358-d7ec-41f8-9ea9-511e81306730"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 8, 38, 30, 96, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("8787347e-dc88-411d-9acd-fdd5937197ad"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 8, 38, 30, 96, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("8a009518-bb4a-4443-9e75-da259a75430a"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 8, 38, 30, 96, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("92d706d4-5969-412b-a663-463c71865623"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 8, 38, 30, 96, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("938b99b9-25ff-4a6a-89b5-e9d625ab72b4"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 8, 38, 30, 96, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("af7ef5d0-c362-43f7-8418-5c20ff360141"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 8, 38, 30, 96, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("b597a498-68d9-4883-b081-9f53d2237c2b"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 8, 38, 30, 96, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("cf01d099-9925-490d-b1b7-ef30e24167bb"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 8, 38, 30, 96, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("d8679b22-5cc2-4d0d-95e1-4f535dbdc56a"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 8, 38, 30, 96, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f06e0640-1421-4303-87c3-8a9d6d815f38"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 8, 38, 30, 96, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f2f36f3c-44f2-433c-bc88-bda0af4a5b5c"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 8, 38, 30, 96, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("fba07170-9485-423b-93dd-6c9fc392fc71"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 8, 38, 30, 96, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("8246f96f-bd49-4db2-69ae-08dd176d0f38"), new Guid("5dbf7705-08fa-472d-bf9c-1faeaa220749") });

            migrationBuilder.InsertData(
                table: "Photographers",
                columns: new[] { "Id", "BrandName", "UserId" },
                values: new object[] { new Guid("01a0e6f6-da36-4634-9533-e6bd4e861c11"), "MIKI", new Guid("5dbf7705-08fa-472d-bf9c-1faeaa220749") });

            migrationBuilder.InsertData(
                table: "PhotoShoots",
                columns: new[] { "Id", "Description", "ImageUrl1", "ImageUrl2", "ImageUrl3", "Name", "PhotographerId" },
                values: new object[] { new Guid("e52842d2-d0b3-4440-8ef1-654a0df5a7af"), "Създай атмосфера, която впечатлява с минимализъм и съвършена хармония! Едноцветният декор е перфектният избор за всеки, който търси изтънченост и стил в детайлите.   Подходящ за всякакви събития:\n\n🎂 Рождени дни със стилна концепция.\n🥂 Романтични вечери, предложения за брак или годежи.\n📸 Професионални фотосесии, фокусирани върху елегантност и симетрия.\n🎉 Корпоративни събития с изискана атмосфера.\n✨ Защо да избереш едноцветен декор?\nЕдноцветната концепция носи усещане за изисканост и баланс, позволявайки на детайлите и емоциите да изпъкнат. 🎈 Направи събитието си незабравимо с простота, която говори сама за себе си!", "https://live.staticflickr.com/65535/54190601391_f3b0a45080_w.jpg", "https://live.staticflickr.com/65535/54190876344_a028421411_n.jpg", "https://live.staticflickr.com/65535/54190853588_78ffec8957_n.jpg", "Едноцветен декор – стил, елегантност и изчистена визия!", new Guid("01a0e6f6-da36-4634-9533-e6bd4e861c11") });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "DeletedAt", "Description", "ImageUrl", "IsPrivate", "PhotographerId", "TagUser", "UserOwnerId" },
                values: new object[,]
                {
                    { new Guid("9ae9bb85-babe-43ca-8ff6-4ede7db51f96"), null, null, "https://live.staticflickr.com/65535/54197310938_28a21d712c_m.jpg", false, new Guid("01a0e6f6-da36-4634-9533-e6bd4e861c11"), null, null },
                    { new Guid("a9fd9095-0c36-4e99-afab-467263ef2445"), null, null, "https://live.staticflickr.com/65535/54197075071_7a81a1ab99_m.jpg", false, new Guid("01a0e6f6-da36-4634-9533-e6bd4e861c11"), null, null }
                });

            migrationBuilder.InsertData(
                table: "PhotosCategories",
                columns: new[] { "CategoryId", "PhotoId" },
                values: new object[] { new Guid("13a08262-6477-40f9-8db7-d6ebd4178e47"), new Guid("a9fd9095-0c36-4e99-afab-467263ef2445") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8246f96f-bd49-4db2-69ae-08dd176d0f38"), new Guid("5dbf7705-08fa-472d-bf9c-1faeaa220749") });

            migrationBuilder.DeleteData(
                table: "PhotoShoots",
                keyColumn: "Id",
                keyValue: new Guid("42086882-b380-438e-a3df-9f36234fa1b6"));

            migrationBuilder.DeleteData(
                table: "PhotoShoots",
                keyColumn: "Id",
                keyValue: new Guid("5456de68-3e58-472d-a97a-00c11e3b77d0"));

            migrationBuilder.DeleteData(
                table: "PhotoShoots",
                keyColumn: "Id",
                keyValue: new Guid("e52842d2-d0b3-4440-8ef1-654a0df5a7af"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("9ae9bb85-babe-43ca-8ff6-4ede7db51f96"));

            migrationBuilder.DeleteData(
                table: "PhotosCategories",
                keyColumns: new[] { "CategoryId", "PhotoId" },
                keyValues: new object[] { new Guid("13a08262-6477-40f9-8db7-d6ebd4178e47"), new Guid("a9fd9095-0c36-4e99-afab-467263ef2445") });

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("a9fd9095-0c36-4e99-afab-467263ef2445"));

            migrationBuilder.DeleteData(
                table: "Photographers",
                keyColumn: "Id",
                keyValue: new Guid("01a0e6f6-da36-4634-9533-e6bd4e861c11"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5dbf7705-08fa-472d-bf9c-1faeaa220749"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PhotoShoots",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 10, 20, 19, 12, 589, DateTimeKind.Local).AddTicks(1322),
                comment: "Date of PhotoShoot creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 11, 8, 38, 30, 105, DateTimeKind.Local).AddTicks(1292),
                oldComment: "Date of PhotoShoot creation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadedAt",
                table: "Photos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 10, 20, 19, 12, 585, DateTimeKind.Local).AddTicks(6599),
                comment: "Date of photo uploading",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 11, 8, 38, 30, 96, DateTimeKind.Local).AddTicks(9577),
                oldComment: "Date of photo uploading");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 10, 20, 19, 12, 75, DateTimeKind.Local).AddTicks(6120),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 11, 8, 38, 28, 517, DateTimeKind.Local).AddTicks(2501),
                oldComment: "Date of user registration");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc355fa2-e8ec-4a33-a609-5002e954c9c3", new DateTime(2024, 12, 10, 20, 19, 12, 75, DateTimeKind.Local).AddTicks(8074), "AQAAAAIAAYagAAAAEIXIekOVJgkTbmSZ1GGIm6lKCW8dzevY4DZbfeCsmvc39JRfK2pBpxhEiSsGgMACXA==", "698a8072-8f51-4e45-ada0-26da2ef0b581" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e86a22a8-2539-43a6-8bf1-5f19cddef64a", new DateTime(2024, 12, 10, 20, 19, 12, 75, DateTimeKind.Local).AddTicks(8051), "AQAAAAIAAYagAAAAEOipcIpVGNt8vM9Hjs9V/Bb54iiabr/qXkQqIdcEIYylNLNHRZ5TaCjNBO0ryoBzZA==", "68d99264-78f5-4608-b0ca-9508beef2d8b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f90fbce0-cbfb-45f8-ac5e-65b8282f3f20", new DateTime(2024, 12, 10, 20, 19, 12, 75, DateTimeKind.Local).AddTicks(8014), "AQAAAAIAAYagAAAAEA9iKpLI/D6QBMnB0NZqCAsobwIxxTiquEBm+innwCzpwczcVdSQLJuXkZ869VN2XA==", "87b777c9-f7e7-4c26-a9e9-5d3095cb948c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95d458a7-115a-4db5-9319-809c7763d841"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f70b127-08b9-4796-92b9-79b2d70c8aad", new DateTime(2024, 12, 10, 20, 19, 12, 75, DateTimeKind.Local).AddTicks(8162), "AQAAAAIAAYagAAAAEMKbz0oSUvJIOfNhy4+gjXdmoWH+fzqMJOSw56pOLa5BZMLXAhy0WgnUaPNERTsPQA==", "489951a0-5930-4451-9ff8-3bb4db0cf08a" });

            migrationBuilder.InsertData(
                table: "PhotoShoots",
                columns: new[] { "Id", "Description", "ImageUrl1", "ImageUrl2", "ImageUrl3", "Name", "PhotographerId" },
                values: new object[,]
                {
                    { new Guid("02ff112d-8f1c-42f1-90cc-2f4bd247a1aa"), "Потопи се в приказна атмосфера, изпълнена с ефирна нежност и радост! Декорът с балони и облаци е перфектният избор за създаване на незабравима фотосесия, парти или специално събитие.\n\n✨ Как изглежда декорът?\n\n🌥️ Нежни пухкави облаци, които създават усещане за лекота и безгрижие.\n🎈 Балони в пастелни или ярки цветове, красиво подредени в арки, букети или плаващи композиции.\n✨ Блясък и акценти – включваме светлинки или блестящи детайли за още повече магия.\n🌟 Персонализирани елементи – добавяме надписи, цифри или малки декорации, съобразени с темата на събитието.\n💡 За кого е подходящ този декор?\n\n👶 Бебешки фотосесии и рождени дни.\n💍 Романтични моменти като предложения за брак или годежи.\n🎉 Детски партита и тематични събития.\n📸 Уникални фотосесии за всеки, който иска да се почувства като в облаците.\nСъздай магия, която ще остави незабравими спомени! ✨\nПозволи на мечтите си да полетят с нашия декор от балони и облаци.", "https://live.staticflickr.com/65535/54190601381_ee8cc95269_w.jpg", "https://live.staticflickr.com/65535/54190601406_faae4a7942_w.jpg", null, "Декор с балони и облаци – магията на мечтите!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") },
                    { new Guid("cb938183-7604-4106-842e-ded6d31f667a"), "Потопи се в свят на свежи цветове, изпълнен с радост и уют! Декорът с балони и маргаритки е перфектен избор за всяко събитие, носещо усмивки и пролетно настроение.\n\n✨ Как изглежда декорът?\n\n🎈 Балони в нежни пастелни тонове или ярки цветове, подредени в елегантни арки, букети или гирлянди.\n🌼 Красиви маргаритки – естествени или декоративни, вплетени между балоните, създавайки хармонична и весела атмосфера.\n🌿 Малки зелени акценти за още повече природна свежест.\n🌟 Възможност за добавяне на персонализирани елементи – имена, надписи или специални фигури.\n💡 За какви събития е подходящ?\n\n🎂 Рождени дни и празненства с пролетна или лятна тематика.\n👶 Бебешки фотосесии или кръщенета.\n🥂 Романтични събития като годежи или сватбени фотосесии.\n📸 Тематични фотосесии на открито или в уютна студийна атмосфера.\n✨ Създай празник, изпълнен с нежност и красота!\nДекорът с балони и маргаритки ще добави неповторима топлина и стил към твоето събитие.", "https://live.staticflickr.com/65535/54190601336_b62502c21a_w.jpg", "https://live.staticflickr.com/65535/54189701927_c384ca435f_n.jpg", null, "Декор с балони и маргаритки – свежест и радост в едно!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") },
                    { new Guid("e3594e46-6915-4a1c-8ecf-8a1fb9f814ad"), "Създай атмосфера, която впечатлява с минимализъм и съвършена хармония! Едноцветният декор е перфектният избор за всеки, който търси изтънченост и стил в детайлите.   Подходящ за всякакви събития:\n\n🎂 Рождени дни със стилна концепция.\n🥂 Романтични вечери, предложения за брак или годежи.\n📸 Професионални фотосесии, фокусирани върху елегантност и симетрия.\n🎉 Корпоративни събития с изискана атмосфера.\n✨ Защо да избереш едноцветен декор?\nЕдноцветната концепция носи усещане за изисканост и баланс, позволявайки на детайлите и емоциите да изпъкнат. 🎈 Направи събитието си незабравимо с простота, която говори сама за себе си!", "https://live.staticflickr.com/65535/54190601391_f3b0a45080_w.jpg", "https://live.staticflickr.com/65535/54190876344_a028421411_n.jpg", "https://live.staticflickr.com/65535/54190853588_78ffec8957_n.jpg", "Едноцветен декор – стил, елегантност и изчистена визия!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") }
                });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1932884a-dfdc-4acb-9334-ac88c1585170"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 10, 20, 19, 12, 585, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1d2c011f-8eba-452a-a180-67349167774f"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 10, 20, 19, 12, 585, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1d86b8c1-424a-464b-8582-edc8d1287125"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 10, 20, 19, 12, 585, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2a4c4f88-6949-4b4a-bb4e-4227ec05a78e"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 10, 20, 19, 12, 585, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2c9fbf60-4155-4777-a03f-3e7d5f01339b"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 10, 20, 19, 12, 585, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("451bff33-d4fc-4217-bdda-a67251b1a427"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 10, 20, 19, 12, 585, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("45bc9358-d7ec-41f8-9ea9-511e81306730"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 10, 20, 19, 12, 585, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("8787347e-dc88-411d-9acd-fdd5937197ad"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 10, 20, 19, 12, 585, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("8a009518-bb4a-4443-9e75-da259a75430a"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 10, 20, 19, 12, 585, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("92d706d4-5969-412b-a663-463c71865623"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 10, 20, 19, 12, 585, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("938b99b9-25ff-4a6a-89b5-e9d625ab72b4"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 10, 20, 19, 12, 585, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("af7ef5d0-c362-43f7-8418-5c20ff360141"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 10, 20, 19, 12, 585, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("b597a498-68d9-4883-b081-9f53d2237c2b"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 10, 20, 19, 12, 585, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("cf01d099-9925-490d-b1b7-ef30e24167bb"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 10, 20, 19, 12, 585, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("d8679b22-5cc2-4d0d-95e1-4f535dbdc56a"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 10, 20, 19, 12, 585, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f06e0640-1421-4303-87c3-8a9d6d815f38"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 10, 20, 19, 12, 585, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f2f36f3c-44f2-433c-bc88-bda0af4a5b5c"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 10, 20, 19, 12, 585, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("fba07170-9485-423b-93dd-6c9fc392fc71"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 10, 20, 19, 12, 585, DateTimeKind.Local).AddTicks(6599));
        }
    }
}
