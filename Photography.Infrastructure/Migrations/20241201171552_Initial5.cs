using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "User First Name"),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "User Last Name"),
                    JoinedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 12, 1, 19, 15, 49, 747, DateTimeKind.Local).AddTicks(7855), comment: "Date of user registration"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Category identifier"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Name of the category"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Is category deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                },
                comment: "Categories of photos");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photographers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Photographer identifier"),
                    BrandName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Brand name of the photographer"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Photographer user identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photographers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photographers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Photographer");

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Photo identifier"),
                    TagUser = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Tag user"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Description of the photo"),
                    Rating = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "Rating of the photo"),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of photo uploading"),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of photo uploading"),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Photo URL"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Is the photo deleted or not"),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false, comment: "Is the photo private ot public"),
                    UserOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Owner of photo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_AspNetUsers_UserOwnerId",
                        column: x => x.UserOwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Photo information");

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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of PhotoShoot creation"),
                    PhotographerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "PhotoShoot photographer identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoShoots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoShoots_Photographers_PhotographerId",
                        column: x => x.PhotographerId,
                        principalTable: "Photographers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "PhotoShoot");

            migrationBuilder.CreateTable(
                name: "FavoritePhotos",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "User identifier"),
                    PhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Photo identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritePhotos", x => new { x.PhotoId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FavoritePhotos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavoritePhotos_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id");
                },
                comment: "Favorite photo");

            migrationBuilder.CreateTable(
                name: "PhotosCategories",
                columns: table => new
                {
                    PhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Photo identifier"),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Category identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotosCategories", x => new { x.CategoryId, x.PhotoId });
                    table.ForeignKey(
                        name: "FK_PhotosCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhotosCategories_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id");
                },
                comment: "Photo Categories");

            migrationBuilder.CreateTable(
                name: "PhotosRatings",
                columns: table => new
                {
                    PhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Photo identifier"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "User identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotosRatings", x => new { x.UserId, x.PhotoId });
                    table.ForeignKey(
                        name: "FK_PhotosRatings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhotosRatings_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id");
                },
                comment: "Rating for photo");

            migrationBuilder.CreateTable(
                name: "PhotoShootParticipants",
                columns: table => new
                {
                    PhotoShootId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "PhotoShoot identifier"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "User identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoShootParticipants", x => new { x.PhotoShootId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PhotoShootParticipants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhotoShootParticipants_PhotoShoots_PhotoShootId",
                        column: x => x.PhotoShootId,
                        principalTable: "PhotoShoots",
                        principalColumn: "Id");
                },
                comment: "PhotoShoot Participant");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "JoinedAt", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd"), 0, "4badbd30-e6aa-409f-acb6-42fbd6c8c6b2", "admin@photography.com", false, null, new DateTime(2024, 12, 1, 19, 15, 49, 747, DateTimeKind.Local).AddTicks(9417), null, false, null, "ADMIN@PHOTOGRAPHY.COM", "АDMIN", "AQAAAAIAAYagAAAAELNkhIWa7Z3+aWaI8LFAzXdKil0HcVKCRoQFYMM73anOk+75Tsb7DktrfSqjGX3BFQ==", null, false, "5af0fb0b-02fe-40d6-8990-044d9cbf049d", false, "Admin" },
                    { new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d"), 0, "a8379344-9886-4bca-8214-99d34ff7a969", "client_two@gmail.com", false, null, new DateTime(2024, 12, 1, 19, 15, 49, 747, DateTimeKind.Local).AddTicks(9380), null, false, null, "CLIENT_TWO@GMAIL.COM", "CLIENTTWO", "AQAAAAIAAYagAAAAEAFh+hqgkmOcwNGA2X1Ua5EDLHhQzqgRXpJNWHRfImE4ke6C933rc3sXT/jVMo68GA==", null, false, "7b029b7d-8db0-483b-8ac5-282f31985743", false, "ClientTwo" },
                    { new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846"), 0, "b3f803bc-cef4-4729-92cf-c07be6733e9d", "client_one@gmail.com", false, null, new DateTime(2024, 12, 1, 19, 15, 49, 747, DateTimeKind.Local).AddTicks(9235), null, false, null, "CLIENT_ONE@GMAIL.COM", "CLIENTONE", "AQAAAAIAAYagAAAAEMiqeq3dvyJxcyi8ES2iYbqu49OIuhsHBqq12oM9cAnVAtANPYoF/1Xq/y0+nQMH0g==", null, false, "eb22cef3-9dec-4645-952e-79aa26903655", false, "ClientOne" },
                    { new Guid("95d458a7-115a-4db5-9319-809c7763d841"), 0, "cac0e666-e9e6-492b-928a-573a5fa3d181", "photographer@gmail.com", false, null, new DateTime(2024, 12, 1, 19, 15, 49, 747, DateTimeKind.Local).AddTicks(9439), null, false, null, "PHOTOGRAPHER@GMAIL.COM", "PHOTOGRAPHER", "AQAAAAIAAYagAAAAEPX6LyXybxy4v+z8NEKPdmE0jP57K4CvOMo3KFEXTYvX7zbYUf7r4Fj3e7Myny6bkw==", null, false, "ba5f2c4c-60d0-44ce-96a8-a62f6edf73dc", false, "Photographer" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("18c787e0-1531-41b0-a56b-b926f2dceedc"), "Пейзажи" },
                    { new Guid("1a35751f-e6a3-4b8f-8562-3fc6105cefc4"), "Мода" },
                    { new Guid("1b643584-44e4-4d9f-8201-f5edfe44820a"), "Животни" },
                    { new Guid("8bd18449-776a-4d7e-8d7a-51263240e34b"), "Пътуваня и дестинации" },
                    { new Guid("b36e4c0d-a834-4175-86d9-a41296c6543c"), "Черно-бяла фотография" },
                    { new Guid("b9e23f30-ea51-457e-b7fd-fc30e8f3241e"), "Архитектура" },
                    { new Guid("c5481055-d571-43fc-80b7-d71edcb7d7e0"), "Семейна фотография" },
                    { new Guid("df24031c-6c7d-4cb9-8ddd-7c9a40d9292b"), "Природа" },
                    { new Guid("f83d4203-2e21-4308-a68d-b6f96ca47814"), "Спорт" },
                    { new Guid("f9df8a40-77fb-4dad-bfdd-f3d89a2c3b9c"), "Храна и напитки" }
                });

            migrationBuilder.InsertData(
                table: "Photographers",
                columns: new[] { "Id", "BrandName", "UserId" },
                values: new object[] { new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4"), "NIES", new Guid("95d458a7-115a-4db5-9319-809c7763d841") });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritePhotos_UserId",
                table: "FavoritePhotos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Photographers_UserId",
                table: "Photographers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserOwnerId",
                table: "Photos",
                column: "UserOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotosCategories_PhotoId",
                table: "PhotosCategories",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoShootParticipants_UserId",
                table: "PhotoShootParticipants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoShoots_PhotographerId",
                table: "PhotoShoots",
                column: "PhotographerId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotosRatings_PhotoId",
                table: "PhotosRatings",
                column: "PhotoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FavoritePhotos");

            migrationBuilder.DropTable(
                name: "PhotosCategories");

            migrationBuilder.DropTable(
                name: "PhotoShootParticipants");

            migrationBuilder.DropTable(
                name: "PhotosRatings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "PhotoShoots");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Photographers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
