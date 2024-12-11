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
                    Id = Guid.Parse("F2F36F3C-44F2-433C-BC88-BDA0AF4A5B5C"),
                    TagUser = "Ниса",
                    Description = "Розите са цветя, които говорят на сърцето, без да използват думи",
                    ImageUrl = "https://live.staticflickr.com/65535/54179261839_b223eaf533_n.jpg",
                    IsPrivate = false,
                    PhotographerId = Guid.Parse("D19B7253-A40E-4D28-8BD0-43410F6A3CA4")
                },

                new Photo()
                {
                    Id = Guid.Parse("1D86B8C1-424A-464B-8582-EDC8D1287125"),
                   Description = "Началото на нов живот",
                    ImageUrl = "https://live.staticflickr.com/65535/54179405645_da2965d7af_n.jpg",
                    IsPrivate = false,
                    PhotographerId = Guid.Parse("D19B7253-A40E-4D28-8BD0-43410F6A3CA4")
                },

                new Photo()
                {
                    Id = Guid.Parse("2A4C4F88-6949-4B4A-BB4E-4227EC05A78E"),
                    Description = "Книгите са вълшебни врати, през които можем да се пренесем в различни светове и реалности - Джим Хенсън",
                    ImageUrl = "https://live.staticflickr.com/65535/54179235863_ef79e9cd79.jpg",
                    IsPrivate = false,
                    PhotographerId = Guid.Parse("D19B7253-A40E-4D28-8BD0-43410F6A3CA4")
                },

                new Photo()
                {
                    Id = Guid.Parse("45BC9358-D7EC-41F8-9EA9-511E81306730"),
                    Description = "The Tree",
                    ImageUrl = "https://live.staticflickr.com/65535/54179405720_de0340c35d_n.jpg",
                    IsPrivate = false,
                    PhotographerId = Guid.Parse("D19B7253-A40E-4D28-8BD0-43410F6A3CA4")
                },

                new Photo()
                {
                    Id = Guid.Parse("D8679B22-5CC2-4D0D-95E1-4F535DBDC56A"),
                    TagUser = "Ниса",
                    Description = "Благодат",
                    ImageUrl = "https://live.staticflickr.com/65535/54179261934_74b915c632_n.jpg",
                    IsPrivate = false,
                    PhotographerId = Guid.Parse("D19B7253-A40E-4D28-8BD0-43410F6A3CA4")
                  },

                new Photo()
                {
                    Id = Guid.Parse("1932884A-DFDC-4ACB-9334-AC88C1585170"),
                    ImageUrl = "https://live.staticflickr.com/65535/54179235838_98b592402f_n.jpg",
                    IsPrivate = false,
                    PhotographerId = Guid.Parse("D19B7253-A40E-4D28-8BD0-43410F6A3CA4")
                },

                new Photo()
                {
                    Id = Guid.Parse("2C9FBF60-4155-4777-A03F-3E7D5F01339B"),
                    ImageUrl = "https://live.staticflickr.com/65535/54178078662_c668a923ac_n.jpg",
                    IsPrivate = false,
                    PhotographerId = Guid.Parse("D19B7253-A40E-4D28-8BD0-43410F6A3CA4")
                },

                new Photo()
                {
                    Id = Guid.Parse("CF01D099-9925-490D-B1B7-EF30E24167BB"),
                    ImageUrl = "https://live.staticflickr.com/65535/54179405980_f9fb480fb0_n.jpg",
                    IsPrivate = false,
                    PhotographerId = Guid.Parse("D19B7253-A40E-4D28-8BD0-43410F6A3CA4")
                },

                new Photo()
                {
                    Id = Guid.Parse("938B99B9-25FF-4A6A-89B5-E9D625AB72B4"),
                    TagUser = "Елмаз",
                    Description = "Home, sweet home",
                    ImageUrl = "https://live.staticflickr.com/65535/54178963106_6698d8a47b_n.jpg",
                    IsPrivate = true,
                    UserOwnerId =Guid.Parse("33386302-4EB2-4A2B-925C-819C1B92CC4D"),
                    PhotographerId = Guid.Parse("D19B7253-A40E-4D28-8BD0-43410F6A3CA4")
                },

                new Photo()
                {
                    Id = Guid.Parse("8A009518-BB4A-4443-9E75-DA259A75430A"),
                    ImageUrl = "https://live.staticflickr.com/65535/54178078787_53fe24ea4a_n.jpg",
                    IsPrivate = false,
                    PhotographerId = Guid.Parse("D19B7253-A40E-4D28-8BD0-43410F6A3CA4")
                },

                new Photo()
                {
                    Id = Guid.Parse("FBA07170-9485-423B-93DD-6C9FC392FC71"),
                    Description = "River road",
                    ImageUrl = "https://live.staticflickr.com/65535/54179262259_781ec3326b_n.jpg",
                    IsPrivate = true,
                    UserOwnerId = Guid.Parse("58D5D0E4-2BD2-477D-B94C-FF91EC025846"),
                    PhotographerId = Guid.Parse("D19B7253-A40E-4D28-8BD0-43410F6A3CA4")
                },

                new Photo()
                {
                    Id = Guid.Parse("F06E0640-1421-4303-87C3-8A9D6D815F38"),
                    TagUser = "Микаел",
                    ImageUrl = "https://live.staticflickr.com/65535/54179262309_60ce92ee0b_n.jpg",
                    IsPrivate = true,
                    UserOwnerId = Guid.Parse("58D5D0E4-2BD2-477D-B94C-FF91EC025846"),
                    PhotographerId = Guid.Parse("D19B7253-A40E-4D28-8BD0-43410F6A3CA4")
                },

                new Photo()
                {
                    Id = Guid.Parse("1D2C011F-8EBA-452A-A180-67349167774F"),
                    TagUser = "Микаел",
                    Description = "Long way home",
                    ImageUrl = "https://live.staticflickr.com/65535/54179236228_d084cd37fb_n.jpg",
                    IsPrivate = true,
                    UserOwnerId = Guid.Parse("58D5D0E4-2BD2-477D-B94C-FF91EC025846"),
                    PhotographerId = Guid.Parse("D19B7253-A40E-4D28-8BD0-43410F6A3CA4")
                },

                new Photo()
                {
                    Id = Guid.Parse("92D706D4-5969-412B-A663-463C71865623"),
                    ImageUrl = "https://live.staticflickr.com/65535/54191040230_19726ab96d_w.jpg",
                    IsPrivate = true,
                    UserOwnerId = Guid.Parse("95D458A7-115A-4DB5-9319-809C7763D841"),
                    PhotographerId = Guid.Parse("D19B7253-A40E-4D28-8BD0-43410F6A3CA4")
                },

                new Photo()
                {
                    Id = Guid.Parse("451BFF33-D4FC-4217-BDDA-A67251B1A427"),
                    Description = "Girlish",
                    ImageUrl = "https://live.staticflickr.com/65535/54190853033_3552742834_w.jpg",
                    IsPrivate = true,
                    UserOwnerId = Guid.Parse("58D5D0E4-2BD2-477D-B94C-FF91EC025846"),
                    PhotographerId = Guid.Parse("D19B7253-A40E-4D28-8BD0-43410F6A3CA4")
                },

                new Photo()
                {
                    Id = Guid.Parse("AF7EF5D0-C362-43F7-8418-5C20FF360141"),
                    Description = "Всяко нещо крие своята красота",
                    ImageUrl = "https://live.staticflickr.com/65535/54191040245_7864be5ce1_w.jpg",
                    IsPrivate = false,
                    PhotographerId = Guid.Parse("D19B7253-A40E-4D28-8BD0-43410F6A3CA4")
                 },

                new Photo()
                {
                    Id = Guid.Parse("8787347E-DC88-411D-9ACD-FDD5937197AD"),
                    TagUser = "Мери",
                    ImageUrl = "https://live.staticflickr.com/65535/54189701457_55e2a97488_w.jpg",
                    IsPrivate = true,
                    UserOwnerId = Guid.Parse("58D5D0E4-2BD2-477D-B94C-FF91EC025846"),
                    PhotographerId = Guid.Parse("D19B7253-A40E-4D28-8BD0-43410F6A3CA4")
                },

                new Photo()
                {
                    Id = Guid.Parse("B597A498-68D9-4883-B081-9F53D2237C2B"),
                    Description = "Времето се променя и ние с него",
                    ImageUrl = "https://live.staticflickr.com/65535/54189701467_958b69d5bc_w.jpg",
                    IsPrivate = false,
                    PhotographerId = Guid.Parse("D19B7253-A40E-4D28-8BD0-43410F6A3CA4")
                },

                new Photo()
                {
                    Id = Guid.Parse("9AE9BB85-BABE-43CA-8FF6-4EDE7DB51F96"),
                    ImageUrl = "https://live.staticflickr.com/65535/54197310938_28a21d712c_m.jpg",
                    IsPrivate = false,
                    PhotographerId = Guid.Parse("01A0E6F6-DA36-4634-9533-E6BD4E861C11")
                },

                new Photo()
                {
                    Id = Guid.Parse("A9FD9095-0C36-4E99-AFAB-467263EF2445"),
                    ImageUrl = "https://live.staticflickr.com/65535/54197075071_7a81a1ab99_m.jpg",
                    IsPrivate = false,
                    PhotographerId = Guid.Parse("01A0E6F6-DA36-4634-9533-E6BD4E861C11")
                },


            }; return photos;
        }
    }

}
