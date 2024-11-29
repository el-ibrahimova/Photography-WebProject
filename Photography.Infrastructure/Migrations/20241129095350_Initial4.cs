using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Photography.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial4 : Migration
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
                    JoinedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 11, 29, 11, 53, 49, 265, DateTimeKind.Local).AddTicks(9542), comment: "Date of user registration"),
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of PhotoShoot creation")
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
                    UserOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "Is the user owner of photo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_AspNetUsers_UserOwnerId",
                        column: x => x.UserOwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoritePhotos_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { new Guid("04c70e70-5cf9-4e8a-a694-5c7c8d730a8f"), 0, "3d10267a-8d59-423a-b85a-17b80171754b", "photographer@gmail.com", false, null, new DateTime(2024, 11, 29, 11, 53, 49, 266, DateTimeKind.Local).AddTicks(627), null, false, null, "PHOTOGRAPHER@GMAIL.COM", "PHOTOGRAPHER", "AQAAAAIAAYagAAAAEK+lSGwXWkv2OaaJq27/muNkREP4C7QrfCXAeEyqfF5Zm4Q63r7maZpkmVY3ZZTtDw==", null, false, "a2290c22-4a8e-4f2e-b0c4-8846966f13eb", false, "Photographer" },
                    { new Guid("a18bb94e-1a7c-4d44-b80c-fc984acf1b0d"), 0, "ae64946b-18ef-419a-9e6b-7a18603d0f7e", "admin@photography.com", false, null, new DateTime(2024, 11, 29, 11, 53, 49, 266, DateTimeKind.Local).AddTicks(493), null, false, null, "ADMIN@PHOTOGRAPHY.COM", "АDMIN", "AQAAAAIAAYagAAAAEAvuJAI0fwAKjnjnjfk5SzCcwENc0yQsKitcUk246nMgZaK3GDZW/vDUaJb3kEojuA==", null, false, "200ccbe6-6a76-4af3-a1e1-5ab7b9ac5cba", false, "Admin" },
                    { new Guid("debacea0-5c7b-461d-a2fb-5af5284a7f9a"), 0, "b409571a-e2ee-48a9-b4ff-8daa24f24369", "client_two@gmail.com", false, null, new DateTime(2024, 11, 29, 11, 53, 49, 266, DateTimeKind.Local).AddTicks(467), null, false, null, "CLIENT_TWO@GMAIL.COM", "CLIENTTWO", "AQAAAAIAAYagAAAAENx3kF4xorQudv/SeHt/DSX8U65smQ4A7obtsdDmfjngDktovSNxrUQKH5oZbXwqRg==", null, false, "14996aee-a058-4d8d-847a-0951f9d02da7", false, "ClientTwo" },
                    { new Guid("e8e05209-b1ce-43e9-898b-885dd3ffc422"), 0, "082f2800-7288-456f-9fa8-a117d69b92bd", "client_one@gmail.com", false, null, new DateTime(2024, 11, 29, 11, 53, 49, 266, DateTimeKind.Local).AddTicks(453), null, false, null, "CLIENT_ONE@GMAIL.COM", "CLIENTONE", "AQAAAAIAAYagAAAAEOYzVXutrowe2Oj63vfnAbuP1uNE1x+Ykk+stDi3hUFg2LuuxFV3TpE7/HnZGmlo9Q==", null, false, "0163f6c9-30ec-417a-a3a0-6cddf1fe3568", false, "ClientOne" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1e941d1e-6ed2-4c34-8717-79e8c008701e"), "Черно-бяла фотография" },
                    { new Guid("2ec56978-acee-48b6-bf54-446597d83ec7"), "Мода" },
                    { new Guid("677118c4-da24-4d95-8047-cd2013447a2e"), "Природа" },
                    { new Guid("6d324290-7af6-4e7c-b29e-5aff991d3d2f"), "Архитектура" },
                    { new Guid("88d1520a-f51f-4016-ab93-b170b1b640f4"), "Семейна фотография" },
                    { new Guid("8ba1a6b0-ad7e-4185-baad-3bae3105e4ba"), "Пейзажи" },
                    { new Guid("9964411b-04a6-4bc7-b5f4-b41d59537e40"), "Пътуваня и дестинации" },
                    { new Guid("ad694ea0-2845-48bd-85f4-ba5ebbce2df2"), "Животни" },
                    { new Guid("c1c2bd67-7157-48ee-90d3-09bb04c44aa6"), "Спорт" },
                    { new Guid("f93bf742-8828-4be6-8004-11208829b66c"), "Храна и напитки" }
                });

            migrationBuilder.InsertData(
                table: "Photographers",
                columns: new[] { "Id", "BrandName", "UserId" },
                values: new object[] { new Guid("cd32306a-b068-4473-ae9d-6fd1bff6e8a2"), "NIES", new Guid("04c70e70-5cf9-4e8a-a694-5c7c8d730a8f") });

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
