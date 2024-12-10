using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class photographerIsRequiredForPhotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Photographers_PhotographerId",
                table: "Photos");

            migrationBuilder.DeleteData(
                table: "PhotoShoots",
                keyColumn: "Id",
                keyValue: new Guid("0f71803c-c0db-4cb2-8c7e-a3a38679a176"));

            migrationBuilder.DeleteData(
                table: "PhotoShoots",
                keyColumn: "Id",
                keyValue: new Guid("29858981-86ee-4ab7-b569-9f1e88141421"));

            migrationBuilder.DeleteData(
                table: "PhotoShoots",
                keyColumn: "Id",
                keyValue: new Guid("2a15bddc-1dba-457c-b501-ecadd60f2ba7"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PhotoShoots",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 10, 20, 19, 12, 589, DateTimeKind.Local).AddTicks(1322),
                comment: "Date of PhotoShoot creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 9, 13, 18, 57, 276, DateTimeKind.Local).AddTicks(9258),
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
                oldDefaultValue: new DateTime(2024, 12, 9, 13, 18, 57, 273, DateTimeKind.Local).AddTicks(3034),
                oldComment: "Date of photo uploading");

            migrationBuilder.AlterColumn<Guid>(
                name: "PhotographerId",
                table: "Photos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Photographer",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "Photographer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 10, 20, 19, 12, 75, DateTimeKind.Local).AddTicks(6120),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 9, 13, 18, 56, 786, DateTimeKind.Local).AddTicks(6118),
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

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Photographers_PhotographerId",
                table: "Photos",
                column: "PhotographerId",
                principalTable: "Photographers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Photographers_PhotographerId",
                table: "Photos");

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
                defaultValue: new DateTime(2024, 12, 9, 13, 18, 57, 276, DateTimeKind.Local).AddTicks(9258),
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
                defaultValue: new DateTime(2024, 12, 9, 13, 18, 57, 273, DateTimeKind.Local).AddTicks(3034),
                comment: "Date of photo uploading",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 10, 20, 19, 12, 585, DateTimeKind.Local).AddTicks(6599),
                oldComment: "Date of photo uploading");

            migrationBuilder.AlterColumn<Guid>(
                name: "PhotographerId",
                table: "Photos",
                type: "uniqueidentifier",
                nullable: true,
                comment: "Photographer",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Photographer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 9, 13, 18, 56, 786, DateTimeKind.Local).AddTicks(6118),
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
                values: new object[] { "3e1e6c08-614d-4fd7-a4a7-e7bd8dbc8e7e", new DateTime(2024, 12, 9, 13, 18, 56, 786, DateTimeKind.Local).AddTicks(8585), "AQAAAAIAAYagAAAAEHX7aiedf1Y2WdaPPavNYpkpwc83jk95g3bnEvXtH7x9ldNtM5XVOHXx+iODwjy72w==", "3e32212a-f415-4db3-bff5-c25f4e8d9cff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c4ce12a-b7bb-41dd-b4e6-66b68de9fe10", new DateTime(2024, 12, 9, 13, 18, 56, 786, DateTimeKind.Local).AddTicks(8563), "AQAAAAIAAYagAAAAELd+5gSzbEEzDPbjT6fTEzjdiv6Bt8WBQL0+viHOsPMKstkZGUAGyPL2AAdypqFQhg==", "5fd1bc73-a3e0-49da-8f36-2de2b0af96c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff5eceef-470e-46cf-be40-37f30f2719d3", new DateTime(2024, 12, 9, 13, 18, 56, 786, DateTimeKind.Local).AddTicks(8539), "AQAAAAIAAYagAAAAEBfb5zBrgKYYyTIkgxuWGCpriPwiEMnQOviouEuzcJIJWQDhZOFKwgqxquWC9y8xrg==", "be9a148f-7d2a-45d7-86cc-87f0b4eeb965" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95d458a7-115a-4db5-9319-809c7763d841"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dca1b0c7-0879-445f-b662-7d7f9b67d618", new DateTime(2024, 12, 9, 13, 18, 56, 786, DateTimeKind.Local).AddTicks(8606), "AQAAAAIAAYagAAAAEIFGrkUhgg7kZgRkLxXI+sT5i+EOFS4O4C542CFzwiRrnrWzhu4vtmknIPHTLGZ4Xw==", "2ab86ce2-88f8-4c11-a756-d7ce7198c7ca" });

            migrationBuilder.InsertData(
                table: "PhotoShoots",
                columns: new[] { "Id", "Description", "ImageUrl1", "ImageUrl2", "ImageUrl3", "Name", "PhotographerId" },
                values: new object[,]
                {
                    { new Guid("0f71803c-c0db-4cb2-8c7e-a3a38679a176"), "Създай атмосфера, която впечатлява с минимализъм и съвършена хармония! Едноцветният декор е перфектният избор за всеки, който търси изтънченост и стил в детайлите.   Подходящ за всякакви събития:\n\n🎂 Рождени дни със стилна концепция.\n🥂 Романтични вечери, предложения за брак или годежи.\n📸 Професионални фотосесии, фокусирани върху елегантност и симетрия.\n🎉 Корпоративни събития с изискана атмосфера.\n✨ Защо да избереш едноцветен декор?\nЕдноцветната концепция носи усещане за изисканост и баланс, позволявайки на детайлите и емоциите да изпъкнат. 🎈 Направи събитието си незабравимо с простота, която говори сама за себе си!", "https://live.staticflickr.com/65535/54190601391_f3b0a45080_w.jpg", "https://live.staticflickr.com/65535/54190876344_a028421411_n.jpg", "https://live.staticflickr.com/65535/54190853588_78ffec8957_n.jpg", "Едноцветен декор – стил, елегантност и изчистена визия!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") },
                    { new Guid("29858981-86ee-4ab7-b569-9f1e88141421"), "Потопи се в свят на свежи цветове, изпълнен с радост и уют! Декорът с балони и маргаритки е перфектен избор за всяко събитие, носещо усмивки и пролетно настроение.\n\n✨ Как изглежда декорът?\n\n🎈 Балони в нежни пастелни тонове или ярки цветове, подредени в елегантни арки, букети или гирлянди.\n🌼 Красиви маргаритки – естествени или декоративни, вплетени между балоните, създавайки хармонична и весела атмосфера.\n🌿 Малки зелени акценти за още повече природна свежест.\n🌟 Възможност за добавяне на персонализирани елементи – имена, надписи или специални фигури.\n💡 За какви събития е подходящ?\n\n🎂 Рождени дни и празненства с пролетна или лятна тематика.\n👶 Бебешки фотосесии или кръщенета.\n🥂 Романтични събития като годежи или сватбени фотосесии.\n📸 Тематични фотосесии на открито или в уютна студийна атмосфера.\n✨ Създай празник, изпълнен с нежност и красота!\nДекорът с балони и маргаритки ще добави неповторима топлина и стил към твоето събитие.", "https://live.staticflickr.com/65535/54190601336_b62502c21a_w.jpg", "https://live.staticflickr.com/65535/54189701927_c384ca435f_n.jpg", null, "Декор с балони и маргаритки – свежест и радост в едно!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") },
                    { new Guid("2a15bddc-1dba-457c-b501-ecadd60f2ba7"), "Потопи се в приказна атмосфера, изпълнена с ефирна нежност и радост! Декорът с балони и облаци е перфектният избор за създаване на незабравима фотосесия, парти или специално събитие.\n\n✨ Как изглежда декорът?\n\n🌥️ Нежни пухкави облаци, които създават усещане за лекота и безгрижие.\n🎈 Балони в пастелни или ярки цветове, красиво подредени в арки, букети или плаващи композиции.\n✨ Блясък и акценти – включваме светлинки или блестящи детайли за още повече магия.\n🌟 Персонализирани елементи – добавяме надписи, цифри или малки декорации, съобразени с темата на събитието.\n💡 За кого е подходящ този декор?\n\n👶 Бебешки фотосесии и рождени дни.\n💍 Романтични моменти като предложения за брак или годежи.\n🎉 Детски партита и тематични събития.\n📸 Уникални фотосесии за всеки, който иска да се почувства като в облаците.\nСъздай магия, която ще остави незабравими спомени! ✨\nПозволи на мечтите си да полетят с нашия декор от балони и облаци.", "https://live.staticflickr.com/65535/54190601381_ee8cc95269_w.jpg", "https://live.staticflickr.com/65535/54190601406_faae4a7942_w.jpg", null, "Декор с балони и облаци – магията на мечтите!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") }
                });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1932884a-dfdc-4acb-9334-ac88c1585170"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 13, 18, 57, 273, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1d2c011f-8eba-452a-a180-67349167774f"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 13, 18, 57, 273, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1d86b8c1-424a-464b-8582-edc8d1287125"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 13, 18, 57, 273, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2a4c4f88-6949-4b4a-bb4e-4227ec05a78e"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 13, 18, 57, 273, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2c9fbf60-4155-4777-a03f-3e7d5f01339b"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 13, 18, 57, 273, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("451bff33-d4fc-4217-bdda-a67251b1a427"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 13, 18, 57, 273, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("45bc9358-d7ec-41f8-9ea9-511e81306730"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 13, 18, 57, 273, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("8787347e-dc88-411d-9acd-fdd5937197ad"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 13, 18, 57, 273, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("8a009518-bb4a-4443-9e75-da259a75430a"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 13, 18, 57, 273, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("92d706d4-5969-412b-a663-463c71865623"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 13, 18, 57, 273, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("938b99b9-25ff-4a6a-89b5-e9d625ab72b4"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 13, 18, 57, 273, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("af7ef5d0-c362-43f7-8418-5c20ff360141"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 13, 18, 57, 273, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("b597a498-68d9-4883-b081-9f53d2237c2b"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 13, 18, 57, 273, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("cf01d099-9925-490d-b1b7-ef30e24167bb"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 13, 18, 57, 273, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("d8679b22-5cc2-4d0d-95e1-4f535dbdc56a"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 13, 18, 57, 273, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f06e0640-1421-4303-87c3-8a9d6d815f38"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 13, 18, 57, 273, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f2f36f3c-44f2-433c-bc88-bda0af4a5b5c"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 13, 18, 57, 273, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("fba07170-9485-423b-93dd-6c9fc392fc71"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 13, 18, 57, 273, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Photographers_PhotographerId",
                table: "Photos",
                column: "PhotographerId",
                principalTable: "Photographers",
                principalColumn: "Id");
        }
    }
}
