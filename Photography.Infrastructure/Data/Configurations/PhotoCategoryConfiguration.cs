using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photography.Infrastructure.Data.Models;

namespace Photography.Infrastructure.Data.Configurations
{
    public class PhotoCategoryConfiguration:IEntityTypeConfiguration<PhotoCategory>
    {
        public void Configure(EntityTypeBuilder<PhotoCategory> builder)
        {
            builder.HasKey(pc => new { pc.CategoryId, pc.PhotoId });

            builder.HasOne(pc => pc.Photo).WithMany(p => p.PhotosCategories).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(pc => pc.Category).WithMany(c=> c.PhotosCategories).OnDelete(DeleteBehavior.NoAction);

            builder.HasData(SeedPhotosCategories());
        }

        private IEnumerable<PhotoCategory> SeedPhotosCategories()
        {
            IEnumerable<PhotoCategory> photoCategory = new List<PhotoCategory>()
            {
                new PhotoCategory()
                {
                    PhotoId = Guid.Parse("F2F36F3C-44F2-433C-BC88-BDA0AF4A5B5C"),
                    CategoryId = Guid.Parse("A5B3D93C-96D1-41AB-8D07-4CBF7754656F")
                },
                new PhotoCategory()
                {
                    PhotoId = Guid.Parse("1D86B8C1-424A-464B-8582-EDC8D1287125"),
                    CategoryId = Guid.Parse("E5FD2C2F-40A0-4A90-A89C-81AB099FA581")
                },
                new PhotoCategory()
                {
                    PhotoId = Guid.Parse("45BC9358-D7EC-41F8-9EA9-511E81306730"),
                    CategoryId = Guid.Parse("E5FD2C2F-40A0-4A90-A89C-81AB099FA581")
                },
                new PhotoCategory()
                {
                    PhotoId = Guid.Parse("45BC9358-D7EC-41F8-9EA9-511E81306730"),
                    CategoryId = Guid.Parse("C1F05508-2B56-46D8-86F9-027F5AAEE67A")
                },
                new PhotoCategory()
                {
                    PhotoId = Guid.Parse("D8679B22-5CC2-4D0D-95E1-4F535DBDC56A"),
                    CategoryId = Guid.Parse("E5FD2C2F-40A0-4A90-A89C-81AB099FA581")
                },
                new PhotoCategory()
                {
                    PhotoId = Guid.Parse("1932884A-DFDC-4ACB-9334-AC88C1585170"),
                    CategoryId = Guid.Parse("E5FD2C2F-40A0-4A90-A89C-81AB099FA581")
                }, 
                new PhotoCategory()
                {
                    PhotoId = Guid.Parse("1932884A-DFDC-4ACB-9334-AC88C1585170"),
                    CategoryId = Guid.Parse("5D56E870-0080-4609-B189-94282AE97F31")
                }, 
                new PhotoCategory()
                {
                    PhotoId = Guid.Parse("2C9FBF60-4155-4777-A03F-3E7D5F01339B"),
                    CategoryId = Guid.Parse("E5FD2C2F-40A0-4A90-A89C-81AB099FA581")
                }, 
                new PhotoCategory()
                {
                    PhotoId = Guid.Parse("938B99B9-25FF-4A6A-89B5-E9D625AB72B4"),
                    CategoryId = Guid.Parse("E5FD2C2F-40A0-4A90-A89C-81AB099FA581")
                }, 
                new PhotoCategory()
                {
                    PhotoId = Guid.Parse("938B99B9-25FF-4A6A-89B5-E9D625AB72B4"),
                    CategoryId = Guid.Parse("AA25251B-6DDC-438B-B5F0-28B3341731E3")
                }, 
                new PhotoCategory()
                {
                    PhotoId = Guid.Parse("8A009518-BB4A-4443-9E75-DA259A75430A"),
                    CategoryId = Guid.Parse("E5FD2C2F-40A0-4A90-A89C-81AB099FA581")
                },
                new PhotoCategory()
                {
                    PhotoId = Guid.Parse("FBA07170-9485-423B-93DD-6C9FC392FC71"),
                    CategoryId = Guid.Parse("E5FD2C2F-40A0-4A90-A89C-81AB099FA581")
                },
                new PhotoCategory()
                {
                    PhotoId = Guid.Parse("F06E0640-1421-4303-87C3-8A9D6D815F38"),
                    CategoryId = Guid.Parse("AA25251B-6DDC-438B-B5F0-28B3341731E3")
                },
                new PhotoCategory()
                {
                    PhotoId = Guid.Parse("F06E0640-1421-4303-87C3-8A9D6D815F38"),
                    CategoryId = Guid.Parse("E5FD2C2F-40A0-4A90-A89C-81AB099FA581")
                },
                new PhotoCategory()
                {
                    PhotoId = Guid.Parse("451BFF33-D4FC-4217-BDDA-A67251B1A427"),
                    CategoryId = Guid.Parse("C7E699D1-FC73-459B-8F0F-11B7C4E101B5")
                },
                new PhotoCategory()
                {
                    PhotoId = Guid.Parse("451BFF33-D4FC-4217-BDDA-A67251B1A427"),
                    CategoryId = Guid.Parse("E5AEDD38-0DC5-49E4-B51A-ACF63FD991A8")
                },
                new PhotoCategory()
                {
                    PhotoId = Guid.Parse("AF7EF5D0-C362-43F7-8418-5C20FF360141"),
                    CategoryId = Guid.Parse("E5AEDD38-0DC5-49E4-B51A-ACF63FD991A8")
                },
                new PhotoCategory()
                {
                    PhotoId = Guid.Parse("8787347E-DC88-411D-9ACD-FDD5937197AD"),
                    CategoryId = Guid.Parse("C7E699D1-FC73-459B-8F0F-11B7C4E101B5")
                },
                new PhotoCategory()
                {
                    PhotoId = Guid.Parse("B597A498-68D9-4883-B081-9F53D2237C2B"),
                    CategoryId = Guid.Parse("13A08262-6477-40F9-8DB7-D6EBD4178E47")
                },
                new PhotoCategory()
                {
                    PhotoId = Guid.Parse("A9FD9095-0C36-4E99-AFAB-467263EF2445"),
                    CategoryId = Guid.Parse("13A08262-6477-40F9-8DB7-D6EBD4178E47")
                },
            };
            
            return photoCategory;
        }
    }
}
