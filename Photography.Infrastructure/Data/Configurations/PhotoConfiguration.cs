using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photography.Infrastructure.Data.Models;

namespace Photography.Infrastructure.Data.Configurations
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.Property(p => p.IsDeleted)
                .HasDefaultValue(false);
            builder.Property(p => p.Rating)
                .HasDefaultValue(0);
            builder.Property(u => u.UploadedAt)
                .HasDefaultValue(DateTime.Now);

            builder.HasData(SeedPhotos());
        }

        private IEnumerable<Photo> SeedPhotos()
        {
            IEnumerable<Photo> photos = new List<Photo>()
            {
                new Photo()
                {
                    TagUser = "Ниса",
                    Description = "Момичето с розата",
                    ImageUrl = "https://live.staticflickr.com/65535/54179261839_b223eaf533_n.jpg",
                    IsPrivate = false,
                    Id = Guid.Parse("95D458A7-115A-4DB5-9319-809C7763D841")
                },

                new Photo()
                {
                   Description = "Началото на нов живот",
                    ImageUrl = "https://live.staticflickr.com/65535/54179405645_da2965d7af_n.jpg",
                    IsPrivate = false,
                    Id = Guid.Parse("95D458A7-115A-4DB5-9319-809C7763D841"),
                    PhotosCategories = new List<PhotoCategory>() { new PhotoCategory()
                        {
                            CategoryId = Guid.Parse("E5FD2C2F-40A0-4A90-A89C-81AB099FA581")
                        }
                    }
                },

                new Photo()
                {
                    Description = "В началото бе словото",
                    ImageUrl = "https://live.staticflickr.com/65535/54179235863_ef79e9cd79.jpg",
                    IsPrivate = false,
                    Id = Guid.Parse("95D458A7-115A-4DB5-9319-809C7763D841"),
                },

                new Photo()
                {
                    Description = "The Tree",
                    ImageUrl = "https://live.staticflickr.com/65535/54179405720_de0340c35d_n.jpg",
                    IsPrivate = false,
                    Id = Guid.Parse("95D458A7-115A-4DB5-9319-809C7763D841"),
                    PhotosCategories = new List<PhotoCategory>()
                    {
                        new PhotoCategory() { CategoryId = Guid.Parse("E5FD2C2F-40A0-4A90-A89C-81AB099FA581") },
                        new PhotoCategory() { CategoryId = Guid.Parse("C1F05508-2B56-46D8-86F9-027F5AAEE67A") }
                    }
                },

                new Photo()
                {
                    TagUser = "Ниса",
                    Description = "Благодат",
                    ImageUrl = "https://live.staticflickr.com/65535/54179261934_74b915c632_n.jpg",
                    IsPrivate = false,
                    Id = Guid.Parse("95D458A7-115A-4DB5-9319-809C7763D841"),
                    PhotosCategories = new List<PhotoCategory>()
                    {
                        new PhotoCategory()  { CategoryId = Guid.Parse("5D56E870-0080-4609-B189-94282AE97F31") },
                        new PhotoCategory()  { CategoryId = Guid.Parse("E5FD2C2F-40A0-4A90-A89C-81AB099FA581") }
                    }
                },

                new Photo()
                {
                    ImageUrl = "https://live.staticflickr.com/65535/54179235838_98b592402f_n.jpg",
                    IsPrivate = false,
                    Id = Guid.Parse("95D458A7-115A-4DB5-9319-809C7763D841"),
                    PhotosCategories = new List<PhotoCategory>()
                    {
                        new PhotoCategory() { CategoryId = Guid.Parse("E5FD2C2F-40A0-4A90-A89C-81AB099FA581") },
                        new PhotoCategory() { CategoryId = Guid.Parse("5D56E870-0080-4609-B189-94282AE97F31") }
                    }
                },

                new Photo()
                {
                    ImageUrl = "https://live.staticflickr.com/65535/54178078662_c668a923ac_n.jpg",
                    IsPrivate = false,
                    Id = Guid.Parse("95D458A7-115A-4DB5-9319-809C7763D841"),
                    PhotosCategories = new List<PhotoCategory>()
                    {
                        new PhotoCategory() { CategoryId = Guid.Parse("E5FD2C2F-40A0-4A90-A89C-81AB099FA581") }
                    }
                },

                new Photo()
                {
                    ImageUrl = "https://live.staticflickr.com/65535/54179405980_f9fb480fb0_n.jpg",
                    IsPrivate = false,
                    Id = Guid.Parse("95D458A7-115A-4DB5-9319-809C7763D841"),
                    PhotosCategories = new List<PhotoCategory>()
                    {
                        new PhotoCategory()  { CategoryId = Guid.Parse("E5FD2C2F-40A0-4A90-A89C-81AB099FA581") }
                    }
                },

                new Photo()
                {
                    TagUser = "Елмаз",
                    Description = "Home, sweet home",
                    ImageUrl = "https://live.staticflickr.com/65535/54178963106_6698d8a47b_n.jpg",
                    IsPrivate = true,
                    UserOwnerId =Guid.Parse("0CEA6E1C-0655-4C21-A14B-5B5932332FFD"),
                    PhotosCategories = new List<PhotoCategory>()
                    {
                        new PhotoCategory()  { CategoryId = Guid.Parse("E5FD2C2F-40A0-4A90-A89C-81AB099FA581") },
                        new PhotoCategory()  { CategoryId = Guid.Parse("AA25251B-6DDC-438B-B5F0-28B3341731E3") },
                    }
                },

                new Photo()
                {
                    ImageUrl = "https://live.staticflickr.com/65535/54178078787_53fe24ea4a_n.jpg",
                    IsPrivate = false,
                    Id = Guid.Parse("95D458A7-115A-4DB5-9319-809C7763D841"),
                    PhotosCategories = new List<PhotoCategory>()
                    {
                        new PhotoCategory()  { CategoryId = Guid.Parse("E5FD2C2F-40A0-4A90-A89C-81AB099FA581") },
                        new PhotoCategory()  { CategoryId = Guid.Parse("AA25251B-6DDC-438B-B5F0-28B3341731E3") },
                    }
                },

            };   return photos;
        }
    }

}
