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
    [Migration("20241122203303_AddPhotoShootAndPhotoShootParticipantEntities")]
    partial class AddPhotoShootAndPhotoShootParticipantEntities
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
                        .HasDefaultValue(new DateTime(2024, 11, 22, 22, 32, 59, 698, DateTimeKind.Local).AddTicks(6456))
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
                            Id = new Guid("6fefd247-7336-442b-8c04-7becb4748543"),
                            IsDeleted = false,
                            Name = "Животни"
                        },
                        new
                        {
                            Id = new Guid("bacc437f-40e2-4596-ab24-d9348652b2b2"),
                            IsDeleted = false,
                            Name = "Природа"
                        },
                        new
                        {
                            Id = new Guid("80d1c776-b333-447d-9423-48d61f64e58c"),
                            IsDeleted = false,
                            Name = "Храна и напитки"
                        },
                        new
                        {
                            Id = new Guid("d493906d-1521-4c28-91ea-3b7cf26da8fe"),
                            IsDeleted = false,
                            Name = "Семейна фотография"
                        },
                        new
                        {
                            Id = new Guid("e7b51a58-491a-44f8-acd1-4d10dd335077"),
                            IsDeleted = false,
                            Name = "Спорт"
                        },
                        new
                        {
                            Id = new Guid("5b34f795-2e1b-4284-b135-cecce865c14d"),
                            IsDeleted = false,
                            Name = "Архитектура"
                        },
                        new
                        {
                            Id = new Guid("64e0e877-a0de-4ffe-a4a8-8996cefc9854"),
                            IsDeleted = false,
                            Name = "Пътуваня и дестинации"
                        },
                        new
                        {
                            Id = new Guid("8760ec5f-bb82-4122-ac8c-13d13ad2fa33"),
                            IsDeleted = false,
                            Name = "Черно-бяла фотография"
                        },
                        new
                        {
                            Id = new Guid("66633dae-13cd-4a0a-82c2-d65cb02ea03d"),
                            IsDeleted = false,
                            Name = "Мода"
                        },
                        new
                        {
                            Id = new Guid("c47c863e-40bc-4f49-bcf6-9bd1d3faeb85"),
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

                    b.Property<Guid?>("UserOwnerId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Is the user owner of photo");

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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Rate identifier");

                    b.Property<Guid>("PhotoId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Photo identifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("User identifier");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId");

                    b.HasIndex("UserId");

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

                    b.HasKey("Id");

                    b.ToTable("PhotoShoots", t =>
                        {
                            t.HasComment("PhotoShoot");
                        });
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.PhotoShootParticipant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Identifier");

                    b.Property<Guid>("PhotoShootId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("PhotoShoot identifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("User identifier");

                    b.HasKey("Id");

                    b.HasIndex("PhotoShootId");

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
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Photography.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Photo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.Photo", b =>
                {
                    b.HasOne("Photography.Infrastructure.Data.Models.ApplicationUser", "Owner")
                        .WithMany("Photos")
                        .HasForeignKey("UserOwnerId");

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
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Photography.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany("PhotosRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Photo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.PhotoShootParticipant", b =>
                {
                    b.HasOne("Photography.Infrastructure.Data.Models.PhotoShoot", "PhotoShoot")
                        .WithMany("Participants")
                        .HasForeignKey("PhotoShootId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Photography.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhotoShoot");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.Photographer", b =>
                {
                    b.HasOne("Photography.Infrastructure.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.ApplicationUser", b =>
                {
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
#pragma warning restore 612, 618
        }
    }
}
