using Photography.Infrastructure.Data.Models;

namespace Photography.Core.ViewModels.Photo
{
    public class DetailsViewModel
    {
        public string Id { get; set; } = null!;

        public string? TagUser { get; set; } 
        public string? Description { get; set; }

        public int Rating { get; set; }

        public string UploadedAt { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public bool IsDeleted { get; set; }


        public bool IsPrivate { get; set; }

        public Guid? UserOwnerId { get; set; }

        public ApplicationUser? Owner { get; set; }
        public string? PhotoOwner { get; set; }

        public ICollection<string> Categories { get; set; } = new HashSet<string>();


        //   public ICollection<FavoritePhoto> FavoritePhotos { get; set; } = new HashSet<FavoritePhoto>();

        //  public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        //   public ICollection<OrderPhoto> OrderPhotos { get; set; } = new HashSet<OrderPhoto>();

        //     public ICollection<PhotoRating> PhotosRatings { get; set; } = new HashSet<PhotoRating>();

    }
}
