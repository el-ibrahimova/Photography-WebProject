using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedMoreDataForUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PhotoShoots",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 11, 12, 23, 34, 567, DateTimeKind.Local).AddTicks(3662),
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
                defaultValue: new DateTime(2024, 12, 11, 12, 23, 34, 563, DateTimeKind.Local).AddTicks(9452),
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
                defaultValue: new DateTime(2024, 12, 11, 12, 23, 33, 806, DateTimeKind.Local).AddTicks(9358),
                comment: "Date of user registration",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 11, 8, 38, 28, 517, DateTimeKind.Local).AddTicks(2501),
                oldComment: "Date of user registration");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "JoinedAt", "LastName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "0212ced4-4415-4210-9165-926794ba15c0", "Администратор", new DateTime(2024, 12, 11, 12, 23, 33, 807, DateTimeKind.Local).AddTicks(1908), "Тодорова", "AQAAAAIAAYagAAAAEMzU0ZomKU6LDFdg0Q2mD+fUQvP5ZWJL2B0r6uGakXGTXDnl2m1q12cvxO7rRLK5IA==", "0889333333", "1242aa84-db44-4b02-a897-dd23d9214ed1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "JoinedAt", "LastName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "693eed44-6c0f-450d-9e89-24f96e60984a", "Милена", new DateTime(2024, 12, 11, 12, 23, 33, 807, DateTimeKind.Local).AddTicks(1866), "Иванова", "AQAAAAIAAYagAAAAEAZo8jUAF4FR6Os2MUYCsfZCYYzPXb8/N+LW9tfi4Rx8/Q2AXabAkNTV3MIODDvFmw==", "0889222222", "4be384cb-f36e-4475-8b47-54c42055f2af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "JoinedAt", "LastName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "bb12bdfa-9c3f-404d-9ae3-9f1fc1cda200", "Иво", new DateTime(2024, 12, 11, 12, 23, 33, 807, DateTimeKind.Local).AddTicks(1835), "Пенев", "AQAAAAIAAYagAAAAEHRpI3yC0EI1zT0+cOhfBBjzCLIb/1xjs5iopq6FQpCozCUt1zBusLBv5omIDTP8bA==", "0889111111", "d248851d-3756-4c07-a3a9-99f335959093" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5dbf7705-08fa-472d-bf9c-1faeaa220749"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "JoinedAt", "LastName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "f7a209a6-769b-4589-b487-4014d09e01b5", "Микаел", new DateTime(2024, 12, 11, 12, 23, 33, 807, DateTimeKind.Local).AddTicks(1941), "Хаджиев", "AQAAAAIAAYagAAAAEAK9B7aYwu0P96uu0eLe0Y7JczJ0mFSs+DFEa90RxmQqty0YGezDAtUhZ78vrwWGCQ==", "0889555555", "99885e49-b02a-4d03-8942-1d5eb00251c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95d458a7-115a-4db5-9319-809c7763d841"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "JoinedAt", "LastName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "eece184d-abb2-4b4b-a077-b8206d6f0bad", "Ниса", new DateTime(2024, 12, 11, 12, 23, 33, 807, DateTimeKind.Local).AddTicks(1926), "Кехайова", "AQAAAAIAAYagAAAAEO3KFQ8msnQR4ep7FifPJ8h/t0nRNksfHAX8nmmow54xYQIShY6umbPCKmDzSTSTEA==", "0889444444", "9bc0e399-5eb2-484d-9d12-990c16d6ec8c" });

            migrationBuilder.InsertData(
                table: "PhotoShoots",
                columns: new[] { "Id", "Description", "ImageUrl1", "ImageUrl2", "ImageUrl3", "Name", "PhotographerId" },
                values: new object[,]
                {
                    { new Guid("5556f751-817b-4c51-8e89-5c68ba355da2"), "Създай атмосфера, която впечатлява с минимализъм и съвършена хармония! Едноцветният декор е перфектният избор за всеки, който търси изтънченост и стил в детайлите.   Подходящ за всякакви събития:\n\n🎂 Рождени дни със стилна концепция.\n🥂 Романтични вечери, предложения за брак или годежи.\n📸 Професионални фотосесии, фокусирани върху елегантност и симетрия.\n🎉 Корпоративни събития с изискана атмосфера.\n✨ Защо да избереш едноцветен декор?\nЕдноцветната концепция носи усещане за изисканост и баланс, позволявайки на детайлите и емоциите да изпъкнат. 🎈 Направи събитието си незабравимо с простота, която говори сама за себе си!", "https://live.staticflickr.com/65535/54190601391_f3b0a45080_w.jpg", "https://live.staticflickr.com/65535/54190876344_a028421411_n.jpg", "https://live.staticflickr.com/65535/54190853588_78ffec8957_n.jpg", "Едноцветен декор – стил, елегантност и изчистена визия!", new Guid("01a0e6f6-da36-4634-9533-e6bd4e861c11") },
                    { new Guid("9a7ef32e-a4fe-4816-9c3d-b40e36eae9e8"), "Потопи се в свят на свежи цветове, изпълнен с радост и уют! Декорът с балони и маргаритки е перфектен избор за всяко събитие, носещо усмивки и пролетно настроение.\n\n✨ Как изглежда декорът?\n\n🎈 Балони в нежни пастелни тонове или ярки цветове, подредени в елегантни арки, букети или гирлянди.\n🌼 Красиви маргаритки – естествени или декоративни, вплетени между балоните, създавайки хармонична и весела атмосфера.\n🌿 Малки зелени акценти за още повече природна свежест.\n🌟 Възможност за добавяне на персонализирани елементи – имена, надписи или специални фигури.\n💡 За какви събития е подходящ?\n\n🎂 Рождени дни и празненства с пролетна или лятна тематика.\n👶 Бебешки фотосесии или кръщенета.\n🥂 Романтични събития като годежи или сватбени фотосесии.\n📸 Тематични фотосесии на открито или в уютна студийна атмосфера.\n✨ Създай празник, изпълнен с нежност и красота!\nДекорът с балони и маргаритки ще добави неповторима топлина и стил към твоето събитие.", "https://live.staticflickr.com/65535/54190601336_b62502c21a_w.jpg", "https://live.staticflickr.com/65535/54189701927_c384ca435f_n.jpg", null, "Декор с балони и маргаритки – свежест и радост в едно!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") },
                    { new Guid("a602ab3f-60c1-46f8-8790-66bb6ef97d63"), "Потопи се в приказна атмосфера, изпълнена с ефирна нежност и радост! Декорът с балони и облаци е перфектният избор за създаване на незабравима фотосесия, парти или специално събитие.\n\n✨ Как изглежда декорът?\n\n🌥️ Нежни пухкави облаци, които създават усещане за лекота и безгрижие.\n🎈 Балони в пастелни или ярки цветове, красиво подредени в арки, букети или плаващи композиции.\n✨ Блясък и акценти – включваме светлинки или блестящи детайли за още повече магия.\n🌟 Персонализирани елементи – добавяме надписи, цифри или малки декорации, съобразени с темата на събитието.\n💡 За кого е подходящ този декор?\n\n👶 Бебешки фотосесии и рождени дни.\n💍 Романтични моменти като предложения за брак или годежи.\n🎉 Детски партита и тематични събития.\n📸 Уникални фотосесии за всеки, който иска да се почувства като в облаците.\nСъздай магия, която ще остави незабравими спомени! ✨\nПозволи на мечтите си да полетят с нашия декор от балони и облаци.", "https://live.staticflickr.com/65535/54190601381_ee8cc95269_w.jpg", "https://live.staticflickr.com/65535/54190601406_faae4a7942_w.jpg", null, "Декор с балони и облаци – магията на мечтите!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") }
                });

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1932884a-dfdc-4acb-9334-ac88c1585170"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 12, 23, 34, 563, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1d2c011f-8eba-452a-a180-67349167774f"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 12, 23, 34, 563, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("1d86b8c1-424a-464b-8582-edc8d1287125"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 12, 23, 34, 563, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2a4c4f88-6949-4b4a-bb4e-4227ec05a78e"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 12, 23, 34, 563, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("2c9fbf60-4155-4777-a03f-3e7d5f01339b"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 12, 23, 34, 563, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("451bff33-d4fc-4217-bdda-a67251b1a427"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 12, 23, 34, 563, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("45bc9358-d7ec-41f8-9ea9-511e81306730"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 12, 23, 34, 563, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("8787347e-dc88-411d-9acd-fdd5937197ad"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 12, 23, 34, 563, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("8a009518-bb4a-4443-9e75-da259a75430a"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 12, 23, 34, 563, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("92d706d4-5969-412b-a663-463c71865623"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 12, 23, 34, 563, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("938b99b9-25ff-4a6a-89b5-e9d625ab72b4"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 12, 23, 34, 563, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("9ae9bb85-babe-43ca-8ff6-4ede7db51f96"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 12, 23, 34, 563, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("a9fd9095-0c36-4e99-afab-467263ef2445"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 12, 23, 34, 563, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("af7ef5d0-c362-43f7-8418-5c20ff360141"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 12, 23, 34, 563, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("b597a498-68d9-4883-b081-9f53d2237c2b"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 12, 23, 34, 563, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("cf01d099-9925-490d-b1b7-ef30e24167bb"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 12, 23, 34, 563, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("d8679b22-5cc2-4d0d-95e1-4f535dbdc56a"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 12, 23, 34, 563, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f06e0640-1421-4303-87c3-8a9d6d815f38"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 12, 23, 34, 563, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("f2f36f3c-44f2-433c-bc88-bda0af4a5b5c"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 12, 23, 34, 563, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("fba07170-9485-423b-93dd-6c9fc392fc71"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 12, 23, 34, 563, DateTimeKind.Local).AddTicks(9452));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PhotoShoots",
                keyColumn: "Id",
                keyValue: new Guid("5556f751-817b-4c51-8e89-5c68ba355da2"));

            migrationBuilder.DeleteData(
                table: "PhotoShoots",
                keyColumn: "Id",
                keyValue: new Guid("9a7ef32e-a4fe-4816-9c3d-b40e36eae9e8"));

            migrationBuilder.DeleteData(
                table: "PhotoShoots",
                keyColumn: "Id",
                keyValue: new Guid("a602ab3f-60c1-46f8-8790-66bb6ef97d63"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PhotoShoots",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 12, 11, 8, 38, 30, 105, DateTimeKind.Local).AddTicks(1292),
                comment: "Date of PhotoShoot creation",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 12, 11, 12, 23, 34, 567, DateTimeKind.Local).AddTicks(3662),
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
                oldDefaultValue: new DateTime(2024, 12, 11, 12, 23, 34, 563, DateTimeKind.Local).AddTicks(9452),
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
                oldDefaultValue: new DateTime(2024, 12, 11, 12, 23, 33, 806, DateTimeKind.Local).AddTicks(9358),
                oldComment: "Date of user registration");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "JoinedAt", "LastName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "d42d237b-bcb5-4e2c-9ba5-e961434b741a", null, new DateTime(2024, 12, 11, 8, 38, 28, 517, DateTimeKind.Local).AddTicks(5631), null, "AQAAAAIAAYagAAAAEPIoaT/Aum6ToOhhloRfSuJuutB6TRPed9hO5RB42WHQDObNGq1CGYNuL/aKtqBm3g==", null, "6d6eeb24-627e-4b04-a553-6c4de06ee54b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "JoinedAt", "LastName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "f3cfaab8-067d-4ad1-b811-16abef3e9ade", null, new DateTime(2024, 12, 11, 8, 38, 28, 517, DateTimeKind.Local).AddTicks(5603), null, "AQAAAAIAAYagAAAAEBWjeMFSXefiWKyIK15QJ9Int0+jxjaDS4mBU0bk+l/xW9FJcGE0bpTd/O59zB+9Jg==", null, "18a0ac5e-6d82-4464-960f-704c94b2eff3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "JoinedAt", "LastName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "9dfdfcb4-86cb-4699-be56-6fec396a07db", null, new DateTime(2024, 12, 11, 8, 38, 28, 517, DateTimeKind.Local).AddTicks(5548), null, "AQAAAAIAAYagAAAAEGopl5hbzi2A5+ceIfSwpYcMKje4cL3bfj0C1jT7G7dYma/sytr28QHPykREflURZw==", null, "2a7e4409-1636-4c6f-9977-73cb6eafe981" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5dbf7705-08fa-472d-bf9c-1faeaa220749"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "JoinedAt", "LastName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "dc062bb2-db65-4955-ad77-5b262d424b4f", null, new DateTime(2024, 12, 11, 8, 38, 28, 517, DateTimeKind.Local).AddTicks(5685), null, "AQAAAAIAAYagAAAAEGeS4Uqm4Y665p0ubfZKH2BH4dKOq8D4W4NUDEO3kosE49yaSLTdIqEXaUYL4/+p6A==", null, "d3274b86-1590-431f-94b0-c5ec9ea2f773" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("95d458a7-115a-4db5-9319-809c7763d841"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "JoinedAt", "LastName", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "ee71f933-9827-48be-9b85-b9d41b501b7f", null, new DateTime(2024, 12, 11, 8, 38, 28, 517, DateTimeKind.Local).AddTicks(5658), null, "AQAAAAIAAYagAAAAEPFRam/eiIssc9EYs/Z+Cu2oUo3ebmilAbY00CV9fXSC8B372YxVO287iFT8R20lbg==", null, "d84db06a-c01e-4398-991e-ffae57e9f4be" });

            migrationBuilder.InsertData(
                table: "PhotoShoots",
                columns: new[] { "Id", "Description", "ImageUrl1", "ImageUrl2", "ImageUrl3", "Name", "PhotographerId" },
                values: new object[,]
                {
                    { new Guid("42086882-b380-438e-a3df-9f36234fa1b6"), "Потопи се в свят на свежи цветове, изпълнен с радост и уют! Декорът с балони и маргаритки е перфектен избор за всяко събитие, носещо усмивки и пролетно настроение.\n\n✨ Как изглежда декорът?\n\n🎈 Балони в нежни пастелни тонове или ярки цветове, подредени в елегантни арки, букети или гирлянди.\n🌼 Красиви маргаритки – естествени или декоративни, вплетени между балоните, създавайки хармонична и весела атмосфера.\n🌿 Малки зелени акценти за още повече природна свежест.\n🌟 Възможност за добавяне на персонализирани елементи – имена, надписи или специални фигури.\n💡 За какви събития е подходящ?\n\n🎂 Рождени дни и празненства с пролетна или лятна тематика.\n👶 Бебешки фотосесии или кръщенета.\n🥂 Романтични събития като годежи или сватбени фотосесии.\n📸 Тематични фотосесии на открито или в уютна студийна атмосфера.\n✨ Създай празник, изпълнен с нежност и красота!\nДекорът с балони и маргаритки ще добави неповторима топлина и стил към твоето събитие.", "https://live.staticflickr.com/65535/54190601336_b62502c21a_w.jpg", "https://live.staticflickr.com/65535/54189701927_c384ca435f_n.jpg", null, "Декор с балони и маргаритки – свежест и радост в едно!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") },
                    { new Guid("5456de68-3e58-472d-a97a-00c11e3b77d0"), "Потопи се в приказна атмосфера, изпълнена с ефирна нежност и радост! Декорът с балони и облаци е перфектният избор за създаване на незабравима фотосесия, парти или специално събитие.\n\n✨ Как изглежда декорът?\n\n🌥️ Нежни пухкави облаци, които създават усещане за лекота и безгрижие.\n🎈 Балони в пастелни или ярки цветове, красиво подредени в арки, букети или плаващи композиции.\n✨ Блясък и акценти – включваме светлинки или блестящи детайли за още повече магия.\n🌟 Персонализирани елементи – добавяме надписи, цифри или малки декорации, съобразени с темата на събитието.\n💡 За кого е подходящ този декор?\n\n👶 Бебешки фотосесии и рождени дни.\n💍 Романтични моменти като предложения за брак или годежи.\n🎉 Детски партита и тематични събития.\n📸 Уникални фотосесии за всеки, който иска да се почувства като в облаците.\nСъздай магия, която ще остави незабравими спомени! ✨\nПозволи на мечтите си да полетят с нашия декор от балони и облаци.", "https://live.staticflickr.com/65535/54190601381_ee8cc95269_w.jpg", "https://live.staticflickr.com/65535/54190601406_faae4a7942_w.jpg", null, "Декор с балони и облаци – магията на мечтите!", new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4") },
                    { new Guid("e52842d2-d0b3-4440-8ef1-654a0df5a7af"), "Създай атмосфера, която впечатлява с минимализъм и съвършена хармония! Едноцветният декор е перфектният избор за всеки, който търси изтънченост и стил в детайлите.   Подходящ за всякакви събития:\n\n🎂 Рождени дни със стилна концепция.\n🥂 Романтични вечери, предложения за брак или годежи.\n📸 Професионални фотосесии, фокусирани върху елегантност и симетрия.\n🎉 Корпоративни събития с изискана атмосфера.\n✨ Защо да избереш едноцветен декор?\nЕдноцветната концепция носи усещане за изисканост и баланс, позволявайки на детайлите и емоциите да изпъкнат. 🎈 Направи събитието си незабравимо с простота, която говори сама за себе си!", "https://live.staticflickr.com/65535/54190601391_f3b0a45080_w.jpg", "https://live.staticflickr.com/65535/54190876344_a028421411_n.jpg", "https://live.staticflickr.com/65535/54190853588_78ffec8957_n.jpg", "Едноцветен декор – стил, елегантност и изчистена визия!", new Guid("01a0e6f6-da36-4634-9533-e6bd4e861c11") }
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
                keyValue: new Guid("9ae9bb85-babe-43ca-8ff6-4ede7db51f96"),
                column: "UploadedAt",
                value: new DateTime(2024, 12, 11, 8, 38, 30, 96, DateTimeKind.Local).AddTicks(9577));

            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: new Guid("a9fd9095-0c36-4e99-afab-467263ef2445"),
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
        }
    }
}
