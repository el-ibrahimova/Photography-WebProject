﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Photography.Infrastructure.Data;

#nullable disable

namespace Photography.Infrastructure.Migrations
{
    [DbContext(typeof(PhotographyDbContext))]
    partial class PhotographyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasDefaultValue(new DateTime(2024, 11, 29, 16, 19, 1, 693, DateTimeKind.Local).AddTicks(9557))
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
                            Id = new Guid("e8e05209-b1ce-43e9-898b-885dd3ffc422"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "bbd19808-8f63-4d62-9fb1-6ff27b23b47e",
                            Email = "client_one@gmail.com",
                            EmailConfirmed = false,
                            JoinedAt = new DateTime(2024, 11, 29, 16, 19, 1, 694, DateTimeKind.Local).AddTicks(552),
                            LockoutEnabled = false,
                            NormalizedEmail = "CLIENT_ONE@GMAIL.COM",
                            NormalizedUserName = "CLIENTONE",
                            PasswordHash = "AQAAAAIAAYagAAAAEPLqWYAumcznPeIfIXT7z9ZlZL630PsrJJyCahf1sjkGDOqyqnJ51cNfLaeDae1lMg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b0d0559f-4532-4df0-8fa5-1942d01e47d8",
                            TwoFactorEnabled = false,
                            UserName = "ClientOne"
                        },
                        new
                        {
                            Id = new Guid("debacea0-5c7b-461d-a2fb-5af5284a7f9a"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0fcdb2d4-7625-4070-bc46-c2c628a4244c",
                            Email = "client_two@gmail.com",
                            EmailConfirmed = false,
                            JoinedAt = new DateTime(2024, 11, 29, 16, 19, 1, 694, DateTimeKind.Local).AddTicks(567),
                            LockoutEnabled = false,
                            NormalizedEmail = "CLIENT_TWO@GMAIL.COM",
                            NormalizedUserName = "CLIENTTWO",
                            PasswordHash = "AQAAAAIAAYagAAAAEEr3JWW9d7k3yvOUQ7cM/p16lgIhVP9X0ds8pgHX47uewKG1RoJW2zO0zlNPiP/tFA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3010d02a-1a03-4d9b-b31d-a970d3637208",
                            TwoFactorEnabled = false,
                            UserName = "ClientTwo"
                        },
                        new
                        {
                            Id = new Guid("a18bb94e-1a7c-4d44-b80c-fc984acf1b0d"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "332fa3c3-063f-4cd5-8865-dadf811c04e7",
                            Email = "admin@photography.com",
                            EmailConfirmed = false,
                            JoinedAt = new DateTime(2024, 11, 29, 16, 19, 1, 694, DateTimeKind.Local).AddTicks(590),
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@PHOTOGRAPHY.COM",
                            NormalizedUserName = "АDMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEEEOWdUr2R2G1MRyTOd/kOyRB5fXPmAPvJJuySMa4LECDaYUMNs9uchRdqhZ1PDyQQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "254e835b-f976-4577-ab05-7d30d23a63a1",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = new Guid("04c70e70-5cf9-4e8a-a694-5c7c8d730a8f"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "934c816c-a8ef-4556-b255-1882c6ecfb3e",
                            Email = "photographer@gmail.com",
                            EmailConfirmed = false,
                            JoinedAt = new DateTime(2024, 11, 29, 16, 19, 1, 694, DateTimeKind.Local).AddTicks(613),
                            LockoutEnabled = false,
                            NormalizedEmail = "PHOTOGRAPHER@GMAIL.COM",
                            NormalizedUserName = "PHOTOGRAPHER",
                            PasswordHash = "AQAAAAIAAYagAAAAEKFuEh2zvDZjltDzpaicAv/PEnmfMmsnXdayyZvf5X2cKLKQRpFwDcvJ/PG53xsD6g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "cbf8e444-86c2-4639-9ae4-e5ae286552e1",
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
                            Id = new Guid("1ed5b150-f99e-4157-9c72-716e43af7b64"),
                            IsDeleted = false,
                            Name = "Животни"
                        },
                        new
                        {
                            Id = new Guid("7c249e33-96a3-466a-b53c-3a9bd289b1da"),
                            IsDeleted = false,
                            Name = "Природа"
                        },
                        new
                        {
                            Id = new Guid("4edb59fd-4581-4b61-a155-4ab2cafe51ae"),
                            IsDeleted = false,
                            Name = "Храна и напитки"
                        },
                        new
                        {
                            Id = new Guid("d3094723-a92c-4580-a1de-aae8ba202e34"),
                            IsDeleted = false,
                            Name = "Семейна фотография"
                        },
                        new
                        {
                            Id = new Guid("a1982855-2b06-479d-8fd0-2426e1b5e173"),
                            IsDeleted = false,
                            Name = "Спорт"
                        },
                        new
                        {
                            Id = new Guid("d5521e08-210c-450b-9769-905f2ec62c85"),
                            IsDeleted = false,
                            Name = "Архитектура"
                        },
                        new
                        {
                            Id = new Guid("19ee311c-e14e-4381-bdb2-c6df5972a090"),
                            IsDeleted = false,
                            Name = "Пътуваня и дестинации"
                        },
                        new
                        {
                            Id = new Guid("b7e1cecb-e1e8-4d39-bed3-9d52e13b4f26"),
                            IsDeleted = false,
                            Name = "Черно-бяла фотография"
                        },
                        new
                        {
                            Id = new Guid("ea66fc21-abb8-4721-9172-7da707381536"),
                            IsDeleted = false,
                            Name = "Мода"
                        },
                        new
                        {
                            Id = new Guid("4236833d-6286-45a0-92c1-328a8fdfd1a5"),
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

                    b.HasKey("Id");

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
                            Id = new Guid("cd32306a-b068-4473-ae9d-6fd1bff6e8a2"),
                            BrandName = "NIES",
                            UserId = new Guid("04c70e70-5cf9-4e8a-a694-5c7c8d730a8f")
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
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Photography.Infrastructure.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Participants");

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
