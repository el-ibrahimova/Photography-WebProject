using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
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
                    JoinedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 11, 30, 20, 17, 49, 934, DateTimeKind.Local).AddTicks(9147), comment: "Date of user registration"),
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
                },
                comment: "PhotoShoot");

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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "JoinedAt", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd"), 0, "1111d475-cdbb-4984-89fc-29832b90ae50", "admin@photography.com", false, null, new DateTime(2024, 11, 30, 20, 17, 49, 935, DateTimeKind.Local).AddTicks(1267), null, false, null, "ADMIN@PHOTOGRAPHY.COM", "АDMIN", "AQAAAAIAAYagAAAAEIoiOR/mxHl9qeaFMV/iawrJzvrcbGYCMOhcASHtIFNAgkIPTIlHa+dy+CQb4TckCA==", null, false, "113fe0a8-1e75-432c-83f1-46c9c039fb7c", false, "Admin" },
                    { new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d"), 0, "263ed5ee-dccb-45e1-8475-d90c9a9c76d1", "client_two@gmail.com", false, null, new DateTime(2024, 11, 30, 20, 17, 49, 935, DateTimeKind.Local).AddTicks(1218), null, false, null, "CLIENT_TWO@GMAIL.COM", "CLIENTTWO", "AQAAAAIAAYagAAAAEBnThCWBvFnsJGhVILRfVnPCqynLYSNEZ9WKQTumm6As8LMmENqdSEvIuBDMC+oc7w==", null, false, "c909d191-8de4-40e0-ad79-f58306af0535", false, "ClientTwo" },
                    { new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846"), 0, "fff8658e-d041-4e50-8746-9cdc8096d715", "client_one@gmail.com", false, null, new DateTime(2024, 11, 30, 20, 17, 49, 935, DateTimeKind.Local).AddTicks(872), null, false, null, "CLIENT_ONE@GMAIL.COM", "CLIENTONE", "AQAAAAIAAYagAAAAEH7ealSVaGavyPrS0YUZgwmuMN5fx6OU5zrO4nSbsF0jLuyvyyNkhu1vhECengpN0A==", null, false, "36523440-373d-4d1e-9c42-e2d3fb582917", false, "ClientOne" },
                    { new Guid("95d458a7-115a-4db5-9319-809c7763d841"), 0, "1ce74563-eb1f-4ddf-ab0b-b08287d7f39c", "photographer@gmail.com", false, null, new DateTime(2024, 11, 30, 20, 17, 49, 935, DateTimeKind.Local).AddTicks(1334), null, false, null, "PHOTOGRAPHER@GMAIL.COM", "PHOTOGRAPHER", "AQAAAAIAAYagAAAAEFbeUu/rDXlSnAQEs2BtklT/2wETc67AprlAFKH3UFC0hN86Jhf78NwVg0NG349CRA==", null, false, "9933c751-408d-4536-a368-9fa0a2c6a2e4", false, "Photographer" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("28f3ee06-3b31-44d2-a6e7-95bb7c0a387e"), "Храна и напитки" },
                    { new Guid("32218c94-93ec-4bf5-be8e-9d1d7b4e6048"), "Пейзажи" },
                    { new Guid("387253a3-6b29-4300-a5a8-f9fc291fc62a"), "Природа" },
                    { new Guid("4f3ead01-5f84-4522-9649-8971e196c062"), "Спорт" },
                    { new Guid("7944ae45-396f-48d8-b6c6-368b2a7fba41"), "Мода" },
                    { new Guid("8e38b8bd-1d71-4ba5-ab47-da801536b5e1"), "Архитектура" },
                    { new Guid("cc8d8279-95e3-412d-82db-d751a46aefb6"), "Черно-бяла фотография" },
                    { new Guid("eaed7ca1-b40c-4644-94d3-295786ac92cd"), "Семейна фотография" },
                    { new Guid("ebbf45c7-37c7-4df7-9ae0-b4e8503a21d3"), "Животни" },
                    { new Guid("f8ef36d1-fa74-4945-87bc-af7f6648bde6"), "Пътуваня и дестинации" }
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
                name: "Photographers");

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
                name: "AspNetUsers");
        }
    }
}
