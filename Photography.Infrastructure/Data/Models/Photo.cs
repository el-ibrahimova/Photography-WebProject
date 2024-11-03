using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Photography.Infrastructure.Data.Enums;

namespace Photography.Infrastructure.Data.Models
{
    using static Common.EntityConstants.PhotoEntity;

    [Comment("Photo information")]
    public class Photo
    {
        [Key]
        [Comment("Photo identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("Title of the photo")]
        public string Title { get; set; } = null!;

        [MaxLength(DescriptionMaxLength)]
        [Comment("Description of the photo")]
        public string? Description { get; set; }

        [Comment("Rating of the photo")]
        public int Rating { get; set; }

        [Comment("Number of photo votes")]
        public int VoteCount { get; set; }

        [Required]
        [Comment("Date of photo uploading")]
        public DateTime UploadedAt { get; set; }

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        [Comment("Photo URL")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Comment("Is the photo deleted or not")]
        public bool IsDeleted { get; set; }

        [Required]
        [Comment("Is the photo selected as favorite")]
        public bool IsFavorite { get; set; }

        [Required]
        [Comment("Is the photo private ot public")]
        public bool IsPrivate { get; set; }

        [Comment("Is the user owner of photo")]
        public Guid? UserOwnerId { get; set; }


      //  public ICollection<Category> Categories { get; set; } = new HashSet<Category>();

        public ICollection<FavoritePhoto> FavoritePhotos { get; set; } = new HashSet<FavoritePhoto>();

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public ICollection<OrderPhoto> OrderPhotos { get; set; }= new HashSet<OrderPhoto>();

        public ICollection<User?> UserOwner { get; set; } = new HashSet<User?>();

        public ICollection<PhotoCategory> PhotosCategories { get; set; } = new HashSet<PhotoCategory>();
    }
}
