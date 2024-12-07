﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Photography.Infrastructure.Data;

#nullable disable

namespace Photography.Infrastructure.Migrations
{
    [DbContext(typeof(PhotographyDbContext))]
    [Migration("20241201174308_addIcollectionOfPhotographers")]
    partial class addIcollectionOfPhotographers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("User First Name");

                    b.Property<DateTime>("JoinedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 12, 1, 19, 43, 5, 322, DateTimeKind.Local).AddTicks(332))
                        .HasComment("Date of user registration");

                    b.Property<string>("LastName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("User Last Name");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("58d5d0e4-2bd2-477d-b94c-ff91ec025846"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "700d6189-3d13-4a6d-863d-63ef933e406f",
                            Email = "client_one@gmail.com",
                            EmailConfirmed = false,
                            JoinedAt = new DateTime(2024, 12, 1, 19, 43, 5, 322, DateTimeKind.Local).AddTicks(1901),
                            LockoutEnabled = false,
                            NormalizedEmail = "CLIENT_ONE@GMAIL.COM",
                            NormalizedUserName = "CLIENTONE",
                            PasswordHash = "AQAAAAIAAYagAAAAEOGTZtR9zvWMvxCA06J5ciksz68fwObGyrkSjEi1goEqzTY5w90g/xz+FtoyOuxRdQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "cb30de8c-ec5d-493d-9ba5-01f4a619304f",
                            TwoFactorEnabled = false,
                            UserName = "ClientOne"
                        },
                        new
                        {
                            Id = new Guid("33386302-4eb2-4a2b-925c-819c1b92cc4d"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7fdefac4-c1c4-4109-a97c-4787c1359776",
                            Email = "client_two@gmail.com",
                            EmailConfirmed = false,
                            JoinedAt = new DateTime(2024, 12, 1, 19, 43, 5, 322, DateTimeKind.Local).AddTicks(1953),
                            LockoutEnabled = false,
                            NormalizedEmail = "CLIENT_TWO@GMAIL.COM",
                            NormalizedUserName = "CLIENTTWO",
                            PasswordHash = "AQAAAAIAAYagAAAAEI4Pb1JP/+lYPTfzkd+WnC+hWCAV6IBRS0P9sBmYlZNMysG+Anbetfac4t9WviFT3A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a09ba247-bf06-4aa8-9bac-862f68b3b530",
                            TwoFactorEnabled = false,
                            UserName = "ClientTwo"
                        },
                        new
                        {
                            Id = new Guid("0cea6e1c-0655-4c21-a14b-5b5932332ffd"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "efceb649-5403-49be-859e-482cac4fc156",
                            Email = "admin@photography.com",
                            EmailConfirmed = false,
                            JoinedAt = new DateTime(2024, 12, 1, 19, 43, 5, 322, DateTimeKind.Local).AddTicks(1980),
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@PHOTOGRAPHY.COM",
                            NormalizedUserName = "АDMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEJ6hHarbn320Gye9Pzn9t2OfdDMpnPJWx+I3FZaqmm5WezcaqZ9wKvA6BtM67T2z5Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9c95fd0e-e178-4e4a-bcdc-ef53175eb2a7",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = new Guid("95d458a7-115a-4db5-9319-809c7763d841"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "15db46a0-4674-4f7d-8ade-78537b09a72b",
                            Email = "photographer@gmail.com",
                            EmailConfirmed = false,
                            JoinedAt = new DateTime(2024, 12, 1, 19, 43, 5, 322, DateTimeKind.Local).AddTicks(2012),
                            LockoutEnabled = false,
                            NormalizedEmail = "PHOTOGRAPHER@GMAIL.COM",
                            NormalizedUserName = "PHOTOGRAPHER",
                            PasswordHash = "AQAAAAIAAYagAAAAEJBrW9YMyzCh1BxArNfFQSTDtX9E+mnbfZMYPsbEa65At+3h4dANDCVrVuNjEmKMtw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b2ce51a0-1c12-40e2-b00f-f0637a3af104",
                            TwoFactorEnabled = false,
                            UserName = "Photographer"
                        });
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Category identifier");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasComment("Is category deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Name of the category");

                    b.HasKey("Id");

                    b.ToTable("Categories", t =>
                        {
                            t.HasComment("Categories of photos");
                        });

                    b.HasData(
                        new
                        {
                            Id = new Guid("c709889b-612d-4cb7-be88-0df72607af4b"),
                            IsDeleted = false,
                            Name = "Животни"
                        },
                        new
                        {
                            Id = new Guid("b946c3d4-b96a-4663-ae25-5d35050efbc3"),
                            IsDeleted = false,
                            Name = "Природа"
                        },
                        new
                        {
                            Id = new Guid("c06971cc-10c6-4d39-8c06-a854bef9d09b"),
                            IsDeleted = false,
                            Name = "Храна и напитки"
                        },
                        new
                        {
                            Id = new Guid("0909a747-b398-4c15-9697-f94b2b540a40"),
                            IsDeleted = false,
                            Name = "Семейна фотография"
                        },
                        new
                        {
                            Id = new Guid("80ebd9c2-5766-44c8-bf27-62344e7dea28"),
                            IsDeleted = false,
                            Name = "Спорт"
                        },
                        new
                        {
                            Id = new Guid("01cbef24-396c-45ea-8758-9d6f37ef6c50"),
                            IsDeleted = false,
                            Name = "Архитектура"
                        },
                        new
                        {
                            Id = new Guid("79efbc84-64c8-401d-b016-15bc6ec248d2"),
                            IsDeleted = false,
                            Name = "Пътуваня и дестинации"
                        },
                        new
                        {
                            Id = new Guid("4d30f91f-745a-4791-a0be-701e407a55cb"),
                            IsDeleted = false,
                            Name = "Черно-бяла фотография"
                        },
                        new
                        {
                            Id = new Guid("b53943a4-9df8-4a94-8738-13b7c8038fc1"),
                            IsDeleted = false,
                            Name = "Мода"
                        },
                        new
                        {
                            Id = new Guid("00ca1d5e-f02c-400f-9fd8-2147dc8820d9"),
                            IsDeleted = false,
                            Name = "Пейзажи"
                        });
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.FavoritePhoto", b =>
                {
                    b.Property<Guid>("PhotoId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Photo identifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("User identifier");

                    b.HasKey("PhotoId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("FavoritePhotos", t =>
                        {
                            t.HasComment("Favorite photo");
                        });
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Photo identifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasComment("Date of photo uploading");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Description of the photo");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Photo URL");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasComment("Is the photo deleted or not");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("bit")
                        .HasComment("Is the photo private ot public");

                    b.Property<int>("Rating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasComment("Rating of the photo");

                    b.Property<string>("TagUser")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Tag user");

                    b.Property<DateTime>("UploadedAt")
                        .HasColumnType("datetime2")
                        .HasComment("Date of photo uploading");

                    b.Property<Guid>("UserOwnerId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Owner of photo");

                    b.HasKey("Id");

                    b.HasIndex("UserOwnerId");

                    b.ToTable("Photos", t =>
                        {
                            t.HasComment("Photo information");
                        });
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.PhotoCategory", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Category identifier");

                    b.Property<Guid>("PhotoId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Photo identifier");

                    b.HasKey("CategoryId", "PhotoId");

                    b.HasIndex("PhotoId");

                    b.ToTable("PhotosCategories", t =>
                        {
                            t.HasComment("Photo Categories");
                        });
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.PhotoRating", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("User identifier");

                    b.Property<Guid>("PhotoId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Photo identifier");

                    b.HasKey("UserId", "PhotoId");

                    b.HasIndex("PhotoId");

                    b.ToTable("PhotosRatings", t =>
                        {
                            t.HasComment("Rating for photo");
                        });
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.PhotoShoot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("PhotoShoot identifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasComment("Date of PhotoShoot creation");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Photo shoot description");

                    b.Property<string>("ImageUrl1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Image URL for first photo");

                    b.Property<string>("ImageUrl2")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Image URL for second photo");

                    b.Property<string>("ImageUrl3")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Image URL for third photo");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasComment("Is photo shoot deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("PhotoShoot Name");

                    b.Property<Guid>("PhotographerId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("PhotoShoot photographer identifier");

                    b.HasKey("Id");

                    b.HasIndex("PhotographerId");

                    b.ToTable("PhotoShoots", t =>
                        {
                            t.HasComment("PhotoShoot");
                        });
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.PhotoShootParticipant", b =>
                {
                    b.Property<Guid>("PhotoShootId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("PhotoShoot identifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("User identifier");

                    b.HasKey("PhotoShootId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("PhotoShootParticipants", t =>
                        {
                            t.HasComment("PhotoShoot Participant");
                        });
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.Photographer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Photographer identifier");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Brand name of the photographer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Photographer user identifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Photographers", t =>
                        {
                            t.HasComment("Photographer");
                        });

                    b.HasData(
                        new
                        {
                            Id = new Guid("d19b7253-a40e-4d28-8bd0-43410f6a3ca4"),
                            BrandName = "NIES",
                            UserId = new Guid("95d458a7-115a-4db5-9319-809c7763d841")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Photography.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Photography.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Photography.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Photography.Infrastructure.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.FavoritePhoto", b =>
                {
                    b.HasOne("Photography.Infrastructure.Data.Models.Photo", "Photo")
                        .WithMany("FavoritePhotos")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Photography.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany("FavoritePhotos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Photo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.Photo", b =>
                {
                    b.HasOne("Photography.Infrastructure.Data.Models.ApplicationUser", "Owner")
                        .WithMany("Photos")
                        .HasForeignKey("UserOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.PhotoCategory", b =>
                {
                    b.HasOne("Photography.Infrastructure.Data.Models.Category", "Category")
                        .WithMany("PhotosCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Photography.Infrastructure.Data.Models.Photo", "Photo")
                        .WithMany("PhotosCategories")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Photo");
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.PhotoRating", b =>
                {
                    b.HasOne("Photography.Infrastructure.Data.Models.Photo", "Photo")
                        .WithMany("PhotosRatings")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Photography.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany("PhotosRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Photo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.PhotoShoot", b =>
                {
                    b.HasOne("Photography.Infrastructure.Data.Models.Photographer", "Photographer")
                        .WithMany("PhotoShoots")
                        .HasForeignKey("PhotographerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Photographer");
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.PhotoShootParticipant", b =>
                {
                    b.HasOne("Photography.Infrastructure.Data.Models.PhotoShoot", "PhotoShoot")
                        .WithMany("Participants")
                        .HasForeignKey("PhotoShootId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Photography.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany("Participants")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("PhotoShoot");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.Photographer", b =>
                {
                    b.HasOne("Photography.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany("Photographers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("FavoritePhotos");

                    b.Navigation("Participants");

                    b.Navigation("Photographers");

                    b.Navigation("Photos");

                    b.Navigation("PhotosRatings");
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.Category", b =>
                {
                    b.Navigation("PhotosCategories");
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.Photo", b =>
                {
                    b.Navigation("FavoritePhotos");

                    b.Navigation("PhotosCategories");

                    b.Navigation("PhotosRatings");
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.PhotoShoot", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.Photographer", b =>
                {
                    b.Navigation("PhotoShoots");
                });
#pragma warning restore 612, 618
        }
    }
}