﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PhotoPhotographerNotRequired : Migration
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
                keyValue: new Guid("498c2594-5b1a-4d06-bacc-6b25792e5851"));

            migrationBuilder.DeleteData(
                table: "PhotoShoots",
                keyColumn: "Id",
                keyValue: new Guid("4e9eeddf-dc14-49d4-b5ed-6ab8927e52ac"));

            migrationBuilder.DeleteData(
                table: "PhotoShoots",
                keyColumn: "Id",
                keyValue: new Guid("7a94606b-9a96-4057-9179-672313472ada"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PhotoShoots",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 9, 11, 11, 22, 761, DateTimeKind.Local).AddTicks(9585),
                comment: "Date of PhotoShoot creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 9, 10, 19, 50, 657, DateTimeKind.Local).AddTicks(7777),
                oldComment: "Date of PhotoShoot creation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadedAt",
                table: "Photos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 9, 11, 11, 22, 758, DateTimeKind.Local).AddTicks(9842),
                comment: "Date of photo uploading",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 9, 10, 19, 50, 653, DateTimeKind.Local).AddTicks(3042),
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
                defaultValue: new DateTime(2024, 12, 9, 11, 11, 22, 207, DateTimeKind.Local).AddTicks(7544),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 9, 10, 19, 50, 27, DateTimeKind.Local).AddTicks(6968),
                oldComment: "Date of user registration");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e668c63-d717-48dd-b76c-27cff26a2213", new DateTime(2024, 12, 9, 11, 11, 22, 208, DateTimeKind.Local).AddTicks(395), "AQAAAAIAAYagAAAAECaC1lPkqGYCpOvZD4mdh/i1tTOuITELeJY5j1uOZFDosgfx7wrSRpB5d49eYyYAHQ==", "276bea7e-4383-4702-82dc-5a3554e40f9d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "951dbbe6-7b0f-4d45-8b6c-f56b6371c329", new DateTime(2024, 12, 9, 11, 11, 22, 208, DateTimeKind.Local).AddTicks(368), "AQAAAAIAAYagAAAAECnrhNHDMBHb5UMeV2MbUXfd1bmKLtyQQNaijQxMqmWVnpv5RKIQSm3/oYEOW3WJlQ==", "55ab94e5-ebd0-4b4a-ab1a-0792e9e6a587" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1c67b77-1941-4ace-b3d0-a3c8477d752c", new DateTime(2024, 12, 9, 11, 11, 22, 208, DateTimeKind.Local).AddTicks(339), "AQAAAAIAAYagAAAAEIbEaQH/tsqIODe3UVhgt3/9/4fOTytFxGuTl/6bInpN6Tuzgp8Vqy4pRwkcADl8wQ==", "7e10325e-5b47-43e7-85cc-a78d450588d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95d458a7-115a-4db5-9319-809c7763d841"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d8acb18-b95e-4ff5-87ea-0b4ef1f5f6f8", new DateTime(2024, 12, 9, 11, 11, 22, 208, DateTimeKind.Local).AddTicks(412), "AQAAAAIAAYagAAAAEGFPg3MLHYfXxdeSZFDhzVCrLBH7ej/Kx7uF+zx5PUQLPFigqVDGlPrYDOdNcR9Y0g==", "8bf54fa7-a4cf-4d6e-8f2c-195ab474b768" });

            migrationBuilder.InsertData(
                table: "PhotoShoots",
                columns: new[] { "Id", "Description", "ImageUrl1", "ImageUrl2", "ImageUrl3", "Name", "PhotographerId" },
                values: new object[,]
                {
                    { new Guid("2618c65a-c3c8-4103-8010-31225449ce33"), "Създай атмосфера, която впечатлява с минимализъм и съвършена хармония! Едноцветният декор е перфектният избор за всеки, който търси изтънченост и стил в детайлите.   Подходящ за всякакви събития:\n\n🎂 Рождени дни със стилна концепция.\n🥂 Романтични вечери, предложения за брак или годежи.\n📸 Професионални фотосесии, фокусирани върху елегантност и симетрия.\n🎉 Корпоративни събития с изискана атмосфера.\n✨ Защо да избереш едноцветен декор?\nЕдноцветната концепция носи усещане за изисканост и баланс, позволявайки на детайлите и емоциите да изпъкнат. 🎈 Направи събитието си незабравимо с простота, която говори сама за себе си!", "https://live.staticflickr.com/65535/54190601391_f3b0a45080_w.jpg", "https://live.staticflickr.com/65535/54190876344_a028421411_n.jpg", "https://live.staticflickr.com/65535/54190853588_78ffec8957_n.jpg", "Едноцветен декор – стил, елегантност и изчистена визия!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") },
                    { new Guid("c1674de4-64d9-439d-9cd3-2406819b4b34"), "Потопи се в свят на свежи цветове, изпълнен с радост и уют! Декорът с балони и маргаритки е перфектен избор за всяко събитие, носещо усмивки и пролетно настроение.\n\n✨ Как изглежда декорът?\n\n🎈 Балони в нежни пастелни тонове или ярки цветове, подредени в елегантни арки, букети или гирлянди.\n🌼 Красиви маргаритки – естествени или декоративни, вплетени между балоните, създавайки хармонична и весела атмосфера.\n🌿 Малки зелени акценти за още повече природна свежест.\n🌟 Възможност за добавяне на персонализирани елементи – имена, надписи или специални фигури.\n💡 За какви събития е подходящ?\n\n🎂 Рождени дни и празненства с пролетна или лятна тематика.\n👶 Бебешки фотосесии или кръщенета.\n🥂 Романтични събития като годежи или сватбени фотосесии.\n📸 Тематични фотосесии на открито или в уютна студийна атмосфера.\n✨ Създай празник, изпълнен с нежност и красота!\nДекорът с балони и маргаритки ще добави неповторима топлина и стил към твоето събитие.", "https://live.staticflickr.com/65535/54190601336_b62502c21a_w.jpg", "https://live.staticflickr.com/65535/54189701927_c384ca435f_n.jpg", null, "Декор с балони и маргаритки – свежест и радост в едно!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") },
                    { new Guid("e8b2aef1-ad03-4724-91ef-54b9771a0b8b"), "Потопи се в приказна атмосфера, изпълнена с ефирна нежност и радост! Декорът с балони и облаци е перфектният избор за създаване на незабравима фотосесия, парти или специално събитие.\n\n✨ Как изглежда декорът?\n\n🌥️ Нежни пухкави облаци, които създават усещане за лекота и безгрижие.\n🎈 Балони в пастелни или ярки цветове, красиво подредени в арки, букети или плаващи композиции.\n✨ Блясък и акценти – включваме светлинки или блестящи детайли за още повече магия.\n🌟 Персонализирани елементи – добавяме надписи, цифри или малки декорации, съобразени с темата на събитието.\n💡 За кого е подходящ този декор?\n\n👶 Бебешки фотосесии и рождени дни.\n💍 Романтични моменти като предложения за брак или годежи.\n🎉 Детски партита и тематични събития.\n📸 Уникални фотосесии за всеки, който иска да се почувства като в облаците.\nСъздай магия, която ще остави незабравими спомени! ✨\nПозволи на мечтите си да полетят с нашия декор от балони и облаци.", "https://live.staticflickr.com/65535/54190601381_ee8cc95269_w.jpg", "https://live.staticflickr.com/65535/54190601406_faae4a7942_w.jpg", null, "Декор с балони и облаци – магията на мечтите!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") }
                });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1932884a-dfdc-4acb-9334-ac88c1585170"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 11, 11, 22, 758, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1d2c011f-8eba-452a-a180-67349167774f"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 11, 11, 22, 758, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1d86b8c1-424a-464b-8582-edc8d1287125"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 11, 11, 22, 758, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2a4c4f88-6949-4b4a-bb4e-4227ec05a78e"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 11, 11, 22, 758, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2c9fbf60-4155-4777-a03f-3e7d5f01339b"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 11, 11, 22, 758, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("451bff33-d4fc-4217-bdda-a67251b1a427"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 11, 11, 22, 758, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("45bc9358-d7ec-41f8-9ea9-511e81306730"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 11, 11, 22, 758, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("8787347e-dc88-411d-9acd-fdd5937197ad"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 11, 11, 22, 758, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("8a009518-bb4a-4443-9e75-da259a75430a"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 11, 11, 22, 758, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("92d706d4-5969-412b-a663-463c71865623"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 11, 11, 22, 758, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("938b99b9-25ff-4a6a-89b5-e9d625ab72b4"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 11, 11, 22, 758, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("af7ef5d0-c362-43f7-8418-5c20ff360141"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 11, 11, 22, 758, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("b597a498-68d9-4883-b081-9f53d2237c2b"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 11, 11, 22, 758, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("cf01d099-9925-490d-b1b7-ef30e24167bb"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 11, 11, 22, 758, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("d8679b22-5cc2-4d0d-95e1-4f535dbdc56a"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 11, 11, 22, 758, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f06e0640-1421-4303-87c3-8a9d6d815f38"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 11, 11, 22, 758, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f2f36f3c-44f2-433c-bc88-bda0af4a5b5c"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 11, 11, 22, 758, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("fba07170-9485-423b-93dd-6c9fc392fc71"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 11, 11, 22, 758, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Photographers_PhotographerId",
                table: "Photos",
                column: "PhotographerId",
                principalTable: "Photographers",
                principalColumn: "Id");
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
                keyValue: new Guid("2618c65a-c3c8-4103-8010-31225449ce33"));

            migrationBuilder.DeleteData(
                table: "PhotoShoots",
                keyColumn: "Id",
                keyValue: new Guid("c1674de4-64d9-439d-9cd3-2406819b4b34"));

            migrationBuilder.DeleteData(
                table: "PhotoShoots",
                keyColumn: "Id",
                keyValue: new Guid("e8b2aef1-ad03-4724-91ef-54b9771a0b8b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PhotoShoots",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 9, 10, 19, 50, 657, DateTimeKind.Local).AddTicks(7777),
                comment: "Date of PhotoShoot creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 9, 11, 11, 22, 761, DateTimeKind.Local).AddTicks(9585),
                oldComment: "Date of PhotoShoot creation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UploadedAt",
                table: "Photos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 9, 10, 19, 50, 653, DateTimeKind.Local).AddTicks(3042),
                comment: "Date of photo uploading",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 9, 11, 11, 22, 758, DateTimeKind.Local).AddTicks(9842),
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
                defaultValue: new DateTime(2024, 12, 9, 10, 19, 50, 27, DateTimeKind.Local).AddTicks(6968),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 9, 11, 11, 22, 207, DateTimeKind.Local).AddTicks(7544),
                oldComment: "Date of user registration");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d65e87d9-8a01-4374-8330-2d72e0363957", new DateTime(2024, 12, 9, 10, 19, 50, 27, DateTimeKind.Local).AddTicks(9567), "AQAAAAIAAYagAAAAEOtAnsNZJH/PMfFxnWoaob8nO0fe2UNp8edafWeMr4+kH86fh78Rml9ta5MXQyWy8w==", "2bc0ff20-6cec-442d-8607-ad1119638e67" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ce83c22-120f-4f91-9abb-f2316d790aaa", new DateTime(2024, 12, 9, 10, 19, 50, 27, DateTimeKind.Local).AddTicks(9547), "AQAAAAIAAYagAAAAECPwqfLSTXvFWJG80ckmcHnP8EMObfrudYzOPfF30vfOqbx9BgOuv5fes4irj18VsQ==", "8e2d025f-092c-4d13-a2ee-678697e52d8e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea3b9fa4-ab95-495c-9596-84d3ae562463", new DateTime(2024, 12, 9, 10, 19, 50, 27, DateTimeKind.Local).AddTicks(9502), "AQAAAAIAAYagAAAAEAbZ0cLs+3UTIHksoTZlh6U8wT5NZdOaFlz/50D2glOKjBSFmlUidiyBEFm+STlNHw==", "e44570cd-d4a7-41de-8210-c7eefe4c2458" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95d458a7-115a-4db5-9319-809c7763d841"),
                columns: new[] { "ConcurrencyStamp", "JoinedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd90fbb9-8325-45bf-9d36-1bfe53f31b2a", new DateTime(2024, 12, 9, 10, 19, 50, 27, DateTimeKind.Local).AddTicks(9808), "AQAAAAIAAYagAAAAEI09D9WT2yD3iZDCHKrrc4cRodwEARS571DwrxsDQqRtiCvNDT94/8rKi0Cmq4+HCg==", "94a6f866-4b3c-412f-af44-e651c06c1705" });

            migrationBuilder.InsertData(
                table: "PhotoShoots",
                columns: new[] { "Id", "Description", "ImageUrl1", "ImageUrl2", "ImageUrl3", "Name", "PhotographerId" },
                values: new object[,]
                {
                    { new Guid("498c2594-5b1a-4d06-bacc-6b25792e5851"), "Създай атмосфера, която впечатлява с минимализъм и съвършена хармония! Едноцветният декор е перфектният избор за всеки, който търси изтънченост и стил в детайлите.   Подходящ за всякакви събития:\n\n🎂 Рождени дни със стилна концепция.\n🥂 Романтични вечери, предложения за брак или годежи.\n📸 Професионални фотосесии, фокусирани върху елегантност и симетрия.\n🎉 Корпоративни събития с изискана атмосфера.\n✨ Защо да избереш едноцветен декор?\nЕдноцветната концепция носи усещане за изисканост и баланс, позволявайки на детайлите и емоциите да изпъкнат. 🎈 Направи събитието си незабравимо с простота, която говори сама за себе си!", "https://live.staticflickr.com/65535/54190601391_f3b0a45080_w.jpg", "https://live.staticflickr.com/65535/54190876344_a028421411_n.jpg", "https://live.staticflickr.com/65535/54190853588_78ffec8957_n.jpg", "Едноцветен декор – стил, елегантност и изчистена визия!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") },
                    { new Guid("4e9eeddf-dc14-49d4-b5ed-6ab8927e52ac"), "Потопи се в приказна атмосфера, изпълнена с ефирна нежност и радост! Декорът с балони и облаци е перфектният избор за създаване на незабравима фотосесия, парти или специално събитие.\n\n✨ Как изглежда декорът?\n\n🌥️ Нежни пухкави облаци, които създават усещане за лекота и безгрижие.\n🎈 Балони в пастелни или ярки цветове, красиво подредени в арки, букети или плаващи композиции.\n✨ Блясък и акценти – включваме светлинки или блестящи детайли за още повече магия.\n🌟 Персонализирани елементи – добавяме надписи, цифри или малки декорации, съобразени с темата на събитието.\n💡 За кого е подходящ този декор?\n\n👶 Бебешки фотосесии и рождени дни.\n💍 Романтични моменти като предложения за брак или годежи.\n🎉 Детски партита и тематични събития.\n📸 Уникални фотосесии за всеки, който иска да се почувства като в облаците.\nСъздай магия, която ще остави незабравими спомени! ✨\nПозволи на мечтите си да полетят с нашия декор от балони и облаци.", "https://live.staticflickr.com/65535/54190601381_ee8cc95269_w.jpg", "https://live.staticflickr.com/65535/54190601406_faae4a7942_w.jpg", null, "Декор с балони и облаци – магията на мечтите!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") },
                    { new Guid("7a94606b-9a96-4057-9179-672313472ada"), "Потопи се в свят на свежи цветове, изпълнен с радост и уют! Декорът с балони и маргаритки е перфектен избор за всяко събитие, носещо усмивки и пролетно настроение.\n\n✨ Как изглежда декорът?\n\n🎈 Балони в нежни пастелни тонове или ярки цветове, подредени в елегантни арки, букети или гирлянди.\n🌼 Красиви маргаритки – естествени или декоративни, вплетени между балоните, създавайки хармонична и весела атмосфера.\n🌿 Малки зелени акценти за още повече природна свежест.\n🌟 Възможност за добавяне на персонализирани елементи – имена, надписи или специални фигури.\n💡 За какви събития е подходящ?\n\n🎂 Рождени дни и празненства с пролетна или лятна тематика.\n👶 Бебешки фотосесии или кръщенета.\n🥂 Романтични събития като годежи или сватбени фотосесии.\n📸 Тематични фотосесии на открито или в уютна студийна атмосфера.\n✨ Създай празник, изпълнен с нежност и красота!\nДекорът с балони и маргаритки ще добави неповторима топлина и стил към твоето събитие.", "https://live.staticflickr.com/65535/54190601336_b62502c21a_w.jpg", "https://live.staticflickr.com/65535/54189701927_c384ca435f_n.jpg", null, "Декор с балони и маргаритки – свежест и радост в едно!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") }
                });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1932884a-dfdc-4acb-9334-ac88c1585170"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 10, 19, 50, 653, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1d2c011f-8eba-452a-a180-67349167774f"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 10, 19, 50, 653, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1d86b8c1-424a-464b-8582-edc8d1287125"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 10, 19, 50, 653, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2a4c4f88-6949-4b4a-bb4e-4227ec05a78e"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 10, 19, 50, 653, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2c9fbf60-4155-4777-a03f-3e7d5f01339b"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 10, 19, 50, 653, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("451bff33-d4fc-4217-bdda-a67251b1a427"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 10, 19, 50, 653, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("45bc9358-d7ec-41f8-9ea9-511e81306730"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 10, 19, 50, 653, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("8787347e-dc88-411d-9acd-fdd5937197ad"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 10, 19, 50, 653, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("8a009518-bb4a-4443-9e75-da259a75430a"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 10, 19, 50, 653, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("92d706d4-5969-412b-a663-463c71865623"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 10, 19, 50, 653, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("938b99b9-25ff-4a6a-89b5-e9d625ab72b4"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 10, 19, 50, 653, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("af7ef5d0-c362-43f7-8418-5c20ff360141"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 10, 19, 50, 653, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("b597a498-68d9-4883-b081-9f53d2237c2b"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 10, 19, 50, 653, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("cf01d099-9925-490d-b1b7-ef30e24167bb"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 10, 19, 50, 653, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("d8679b22-5cc2-4d0d-95e1-4f535dbdc56a"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 10, 19, 50, 653, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f06e0640-1421-4303-87c3-8a9d6d815f38"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 10, 19, 50, 653, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f2f36f3c-44f2-433c-bc88-bda0af4a5b5c"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 10, 19, 50, 653, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("fba07170-9485-423b-93dd-6c9fc392fc71"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 9, 10, 19, 50, 653, DateTimeKind.Local).AddTicks(3042));

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Photographers_PhotographerId",
                table: "Photos",
                column: "PhotographerId",
                principalTable: "Photographers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}