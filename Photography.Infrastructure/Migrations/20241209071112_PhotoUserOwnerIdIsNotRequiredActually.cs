﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PhotoUserOwnerIdIsNotRequiredActually : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_AspNetUsers_UserOwnerId",
                table: "Photos");

            migrationBuilder.DeleteData(
                table: "PhotoShoots",
                keyColumn: "Id",
                keyValue: new Guid("0ed63969-e514-4612-a33b-e8479cc977b8"));

            migrationBuilder.DeleteData(
                table: "PhotoShoots",
                keyColumn: "Id",
                keyValue: new Guid("e2473015-1863-4be1-94da-203dad0e4620"));

            migrationBuilder.DeleteData(
                table: "PhotoShoots",
                keyColumn: "Id",
                keyValue: new Guid("fcc268d5-7d84-4802-8b48-8db11ed2199d"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PhotoShoots",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 9, 9, 11, 8, 417, DateTimeKind.Local).AddTicks(132),
                comment: "Date of PhotoShoot creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 9, 9, 2, 48, 110, DateTimeKind.Local).AddTicks(1867),
                oldComment: "Date of PhotoShoot creation");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserOwnerId",
                table: "Photos",
                type: "uniqueidentifier",
                nullable: true,
                comment: "Owner of photo",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Owner of photo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadedAt",
                table: "Photos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 9, 9, 11, 8, 411, DateTimeKind.Local).AddTicks(5659),
                comment: "Date of photo uploading",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 9, 9, 2, 48, 105, DateTimeKind.Local).AddTicks(2414),
                oldComment: "Date of photo uploading");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 9, 9, 11, 7, 773, DateTimeKind.Local).AddTicks(9828),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 9, 9, 2, 47, 575, DateTimeKind.Local).AddTicks(8474),
                oldComment: "Date of user registration");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c639639-2647-4d9f-8d6f-b5f17771c3b9", new DateTime(2024, 12, 9, 9, 11, 7, 774, DateTimeKind.Local).AddTicks(2067), "AQAAAAIAAYagAAAAEKfq9sA0xTDy9amAHYRb+AT2JgUl1OUfTY41Nisx4Mz8PVf+ZAzLxV5t20wGylDCZQ==", "f44eef33-ad6c-4f70-ade5-a1c51fe0375a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6fbbd2a-7b54-433f-af73-4f93fb3ba911", new DateTime(2024, 12, 9, 9, 11, 7, 774, DateTimeKind.Local).AddTicks(2048), "AQAAAAIAAYagAAAAEKRwGflxhoOjxRF2d16oUHiaviV2XyudG0+qGF3mDy4yZciERlw5DDqPgWJ8NRmeYA==", "204cd404-a8f9-4eaf-b526-6694ea164fe8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9cb823a-6ae1-4ba9-a815-a71166ac3056", new DateTime(2024, 12, 9, 9, 11, 7, 774, DateTimeKind.Local).AddTicks(2011), "AQAAAAIAAYagAAAAEPxdPU51Y3Prh6ObGAm44ZVBtaM9tEE9jBtuFM3HiuzLO/ltarwIH/DS0J8fdrGO4Q==", "e6bc0c17-e87c-4ef0-bf0e-0456a66df318" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95d458a7-115a-4db5-9319-809c7763d841"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e6493db-d091-4935-8666-ea0c9f40c8cf", new DateTime(2024, 12, 9, 9, 11, 7, 774, DateTimeKind.Local).AddTicks(2087), "AQAAAAIAAYagAAAAEIDmE7zixII88h236HpJemIbOqCvQxVgNiExDmWMBJRr2YCXY3unH/VCw3A5XVGPnQ==", "12506a68-4caa-484e-bc01-624495c8856e" });

            migrationBuilder.InsertData(
                table: "PhotoShoots",
                columns: new[] { "Id", "Description", "ImageUrl1", "ImageUrl2", "ImageUrl3", "Name", "PhotographerId" },
                values: new object[,]
                {
                    { new Guid("bb5fcac3-b920-4952-b5f5-0881ae253038"), "Потопи се в свят на свежи цветове, изпълнен с радост и уют! Декорът с балони и маргаритки е перфектен избор за всяко събитие, носещо усмивки и пролетно настроение.\n\n✨ Как изглежда декорът?\n\n🎈 Балони в нежни пастелни тонове или ярки цветове, подредени в елегантни арки, букети или гирлянди.\n🌼 Красиви маргаритки – естествени или декоративни, вплетени между балоните, създавайки хармонична и весела атмосфера.\n🌿 Малки зелени акценти за още повече природна свежест.\n🌟 Възможност за добавяне на персонализирани елементи – имена, надписи или специални фигури.\n💡 За какви събития е подходящ?\n\n🎂 Рождени дни и празненства с пролетна или лятна тематика.\n👶 Бебешки фотосесии или кръщенета.\n🥂 Романтични събития като годежи или сватбени фотосесии.\n📸 Тематични фотосесии на открито или в уютна студийна атмосфера.\n✨ Създай празник, изпълнен с нежност и красота!\nДекорът с балони и маргаритки ще добави неповторима топлина и стил към твоето събитие.", "https://live.staticflickr.com/65535/54190601336_b62502c21a_w.jpg", "https://live.staticflickr.com/65535/54189701927_c384ca435f_n.jpg", null, "Декор с балони и маргаритки – свежест и радост в едно!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") },
                    { new Guid("e2f26603-8132-45d3-aade-be9dcee172e3"), "Потопи се в приказна атмосфера, изпълнена с ефирна нежност и радост! Декорът с балони и облаци е перфектният избор за създаване на незабравима фотосесия, парти или специално събитие.\n\n✨ Как изглежда декорът?\n\n🌥️ Нежни пухкави облаци, които създават усещане за лекота и безгрижие.\n🎈 Балони в пастелни или ярки цветове, красиво подредени в арки, букети или плаващи композиции.\n✨ Блясък и акценти – включваме светлинки или блестящи детайли за още повече магия.\n🌟 Персонализирани елементи – добавяме надписи, цифри или малки декорации, съобразени с темата на събитието.\n💡 За кого е подходящ този декор?\n\n👶 Бебешки фотосесии и рождени дни.\n💍 Романтични моменти като предложения за брак или годежи.\n🎉 Детски партита и тематични събития.\n📸 Уникални фотосесии за всеки, който иска да се почувства като в облаците.\nСъздай магия, която ще остави незабравими спомени! ✨\nПозволи на мечтите си да полетят с нашия декор от балони и облаци.", "https://live.staticflickr.com/65535/54190601381_ee8cc95269_w.jpg", "https://live.staticflickr.com/65535/54190601406_faae4a7942_w.jpg", null, "Декор с балони и облаци – магията на мечтите!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") },
                    { new Guid("e3b4365a-1ca2-4ffe-a3da-f7650ab2c7a0"), "Създай атмосфера, която впечатлява с минимализъм и съвършена хармония! Едноцветният декор е перфектният избор за всеки, който търси изтънченост и стил в детайлите.   Подходящ за всякакви събития:\n\n🎂 Рождени дни със стилна концепция.\n🥂 Романтични вечери, предложения за брак или годежи.\n📸 Професионални фотосесии, фокусирани върху елегантност и симетрия.\n🎉 Корпоративни събития с изискана атмосфера.\n✨ Защо да избереш едноцветен декор?\nЕдноцветната концепция носи усещане за изисканост и баланс, позволявайки на детайлите и емоциите да изпъкнат. 🎈 Направи събитието си незабравимо с простота, която говори сама за себе си!", "https://live.staticflickr.com/65535/54190601391_f3b0a45080_w.jpg", "https://live.staticflickr.com/65535/54190876344_a028421411_n.jpg", "https://live.staticflickr.com/65535/54190853588_78ffec8957_n.jpg", "Едноцветен декор – стил, елегантност и изчистена визия!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") }
                });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1932884a-dfdc-4acb-9334-ac88c1585170"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 11, 8, 411, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1d2c011f-8eba-452a-a180-67349167774f"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 11, 8, 411, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1d86b8c1-424a-464b-8582-edc8d1287125"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 11, 8, 411, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2a4c4f88-6949-4b4a-bb4e-4227ec05a78e"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 11, 8, 411, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2c9fbf60-4155-4777-a03f-3e7d5f01339b"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 11, 8, 411, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("451bff33-d4fc-4217-bdda-a67251b1a427"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 11, 8, 411, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("45bc9358-d7ec-41f8-9ea9-511e81306730"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 11, 8, 411, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("8787347e-dc88-411d-9acd-fdd5937197ad"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 11, 8, 411, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("8a009518-bb4a-4443-9e75-da259a75430a"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 11, 8, 411, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("92d706d4-5969-412b-a663-463c71865623"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 11, 8, 411, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("938b99b9-25ff-4a6a-89b5-e9d625ab72b4"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 11, 8, 411, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("af7ef5d0-c362-43f7-8418-5c20ff360141"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 11, 8, 411, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("b597a498-68d9-4883-b081-9f53d2237c2b"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 11, 8, 411, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("cf01d099-9925-490d-b1b7-ef30e24167bb"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 11, 8, 411, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("d8679b22-5cc2-4d0d-95e1-4f535dbdc56a"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 11, 8, 411, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f06e0640-1421-4303-87c3-8a9d6d815f38"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 11, 8, 411, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f2f36f3c-44f2-433c-bc88-bda0af4a5b5c"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 11, 8, 411, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("fba07170-9485-423b-93dd-6c9fc392fc71"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 11, 8, 411, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_AspNetUsers_UserOwnerId",
                table: "Photos",
                column: "UserOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_AspNetUsers_UserOwnerId",
                table: "Photos");

            migrationBuilder.DeleteData(
                table: "PhotoShoots",
                keyColumn: "Id",
                keyValue: new Guid("bb5fcac3-b920-4952-b5f5-0881ae253038"));

            migrationBuilder.DeleteData(
                table: "PhotoShoots",
                keyColumn: "Id",
                keyValue: new Guid("e2f26603-8132-45d3-aade-be9dcee172e3"));

            migrationBuilder.DeleteData(
                table: "PhotoShoots",
                keyColumn: "Id",
                keyValue: new Guid("e3b4365a-1ca2-4ffe-a3da-f7650ab2c7a0"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PhotoShoots",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 9, 9, 2, 48, 110, DateTimeKind.Local).AddTicks(1867),
                comment: "Date of PhotoShoot creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 9, 9, 11, 8, 417, DateTimeKind.Local).AddTicks(132),
                oldComment: "Date of PhotoShoot creation");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserOwnerId",
                table: "Photos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Owner of photo",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "Owner of photo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadedAt",
                table: "Photos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 9, 9, 2, 48, 105, DateTimeKind.Local).AddTicks(2414),
                comment: "Date of photo uploading",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 9, 9, 11, 8, 411, DateTimeKind.Local).AddTicks(5659),
                oldComment: "Date of photo uploading");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 9, 9, 2, 47, 575, DateTimeKind.Local).AddTicks(8474),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 9, 9, 11, 7, 773, DateTimeKind.Local).AddTicks(9828),
                oldComment: "Date of user registration");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd68dac4-76c2-4484-a4b1-e8617f01624d", new DateTime(2024, 12, 9, 9, 2, 47, 576, DateTimeKind.Local).AddTicks(312), "AQAAAAIAAYagAAAAEMMMLqNn43Q0VsrqQgLQaubKwA8kBK0UBfhgdhVi1FP0n3wJj4Ej7/T0D9qg088ZJw==", "013fae6b-4a58-423a-9fd3-d4e8fd34931c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76a66034-7892-4949-9e38-3c290476c0aa", new DateTime(2024, 12, 9, 9, 2, 47, 576, DateTimeKind.Local).AddTicks(291), "AQAAAAIAAYagAAAAEPCW2Ui9gP/heq7KvP7VUntDQn1Hz7zQ99Gua1QmkaEkURbmBBTR3RwI6J94ObjwDw==", "af4678ca-0a23-4813-9563-4270c9d5b6b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3cb103aa-cbbb-4564-afcf-839c6f64ddd2", new DateTime(2024, 12, 9, 9, 2, 47, 576, DateTimeKind.Local).AddTicks(257), "AQAAAAIAAYagAAAAEEhZjHoDHaUCIc+Usno+Wj4gGXIbIPb9fzt+UF0z4kxmMbAklpf45YwGFASgNt9RLw==", "86d2b15c-cfcf-489c-80ac-a6d3a1df6110" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95d458a7-115a-4db5-9319-809c7763d841"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "186e8ec6-d360-49be-a44d-61f6667001c5", new DateTime(2024, 12, 9, 9, 2, 47, 576, DateTimeKind.Local).AddTicks(336), "AQAAAAIAAYagAAAAELci9kCOaQ8NObkHl64gAf7NYAiMHVK+vOcMSI25TKT57pGYoeS4KwqwnMS94xe1NA==", "78fb7d14-9b0f-46c2-ac69-8e560ca10207" });

            migrationBuilder.InsertData(
                table: "PhotoShoots",
                columns: new[] { "Id", "Description", "ImageUrl1", "ImageUrl2", "ImageUrl3", "Name", "PhotographerId" },
                values: new object[,]
                {
                    { new Guid("0ed63969-e514-4612-a33b-e8479cc977b8"), "Потопи се в приказна атмосфера, изпълнена с ефирна нежност и радост! Декорът с балони и облаци е перфектният избор за създаване на незабравима фотосесия, парти или специално събитие.\n\n✨ Как изглежда декорът?\n\n🌥️ Нежни пухкави облаци, които създават усещане за лекота и безгрижие.\n🎈 Балони в пастелни или ярки цветове, красиво подредени в арки, букети или плаващи композиции.\n✨ Блясък и акценти – включваме светлинки или блестящи детайли за още повече магия.\n🌟 Персонализирани елементи – добавяме надписи, цифри или малки декорации, съобразени с темата на събитието.\n💡 За кого е подходящ този декор?\n\n👶 Бебешки фотосесии и рождени дни.\n💍 Романтични моменти като предложения за брак или годежи.\n🎉 Детски партита и тематични събития.\n📸 Уникални фотосесии за всеки, който иска да се почувства като в облаците.\nСъздай магия, която ще остави незабравими спомени! ✨\nПозволи на мечтите си да полетят с нашия декор от балони и облаци.", "https://live.staticflickr.com/65535/54190601381_ee8cc95269_w.jpg", "https://live.staticflickr.com/65535/54190601406_faae4a7942_w.jpg", null, "Декор с балони и облаци – магията на мечтите!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") },
                    { new Guid("e2473015-1863-4be1-94da-203dad0e4620"), "Създай атмосфера, която впечатлява с минимализъм и съвършена хармония! Едноцветният декор е перфектният избор за всеки, който търси изтънченост и стил в детайлите.   Подходящ за всякакви събития:\n\n🎂 Рождени дни със стилна концепция.\n🥂 Романтични вечери, предложения за брак или годежи.\n📸 Професионални фотосесии, фокусирани върху елегантност и симетрия.\n🎉 Корпоративни събития с изискана атмосфера.\n✨ Защо да избереш едноцветен декор?\nЕдноцветната концепция носи усещане за изисканост и баланс, позволявайки на детайлите и емоциите да изпъкнат. 🎈 Направи събитието си незабравимо с простота, която говори сама за себе си!", "https://live.staticflickr.com/65535/54190601391_f3b0a45080_w.jpg", "https://live.staticflickr.com/65535/54190876344_a028421411_n.jpg", "https://live.staticflickr.com/65535/54190853588_78ffec8957_n.jpg", "Едноцветен декор – стил, елегантност и изчистена визия!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") },
                    { new Guid("fcc268d5-7d84-4802-8b48-8db11ed2199d"), "Потопи се в свят на свежи цветове, изпълнен с радост и уют! Декорът с балони и маргаритки е перфектен избор за всяко събитие, носещо усмивки и пролетно настроение.\n\n✨ Как изглежда декорът?\n\n🎈 Балони в нежни пастелни тонове или ярки цветове, подредени в елегантни арки, букети или гирлянди.\n🌼 Красиви маргаритки – естествени или декоративни, вплетени между балоните, създавайки хармонична и весела атмосфера.\n🌿 Малки зелени акценти за още повече природна свежест.\n🌟 Възможност за добавяне на персонализирани елементи – имена, надписи или специални фигури.\n💡 За какви събития е подходящ?\n\n🎂 Рождени дни и празненства с пролетна или лятна тематика.\n👶 Бебешки фотосесии или кръщенета.\n🥂 Романтични събития като годежи или сватбени фотосесии.\n📸 Тематични фотосесии на открито или в уютна студийна атмосфера.\n✨ Създай празник, изпълнен с нежност и красота!\nДекорът с балони и маргаритки ще добави неповторима топлина и стил към твоето събитие.", "https://live.staticflickr.com/65535/54190601336_b62502c21a_w.jpg", "https://live.staticflickr.com/65535/54189701927_c384ca435f_n.jpg", null, "Декор с балони и маргаритки – свежест и радост в едно!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") }
                });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1932884a-dfdc-4acb-9334-ac88c1585170"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 2, 48, 105, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1d2c011f-8eba-452a-a180-67349167774f"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 2, 48, 105, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1d86b8c1-424a-464b-8582-edc8d1287125"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 2, 48, 105, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2a4c4f88-6949-4b4a-bb4e-4227ec05a78e"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 2, 48, 105, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2c9fbf60-4155-4777-a03f-3e7d5f01339b"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 2, 48, 105, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("451bff33-d4fc-4217-bdda-a67251b1a427"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 2, 48, 105, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("45bc9358-d7ec-41f8-9ea9-511e81306730"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 2, 48, 105, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("8787347e-dc88-411d-9acd-fdd5937197ad"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 2, 48, 105, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("8a009518-bb4a-4443-9e75-da259a75430a"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 2, 48, 105, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("92d706d4-5969-412b-a663-463c71865623"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 2, 48, 105, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("938b99b9-25ff-4a6a-89b5-e9d625ab72b4"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 2, 48, 105, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("af7ef5d0-c362-43f7-8418-5c20ff360141"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 2, 48, 105, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("b597a498-68d9-4883-b081-9f53d2237c2b"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 2, 48, 105, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("cf01d099-9925-490d-b1b7-ef30e24167bb"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 2, 48, 105, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("d8679b22-5cc2-4d0d-95e1-4f535dbdc56a"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 2, 48, 105, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f06e0640-1421-4303-87c3-8a9d6d815f38"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 2, 48, 105, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f2f36f3c-44f2-433c-bc88-bda0af4a5b5c"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 2, 48, 105, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("fba07170-9485-423b-93dd-6c9fc392fc71"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 9, 2, 48, 105, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_AspNetUsers_UserOwnerId",
                table: "Photos",
                column: "UserOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}