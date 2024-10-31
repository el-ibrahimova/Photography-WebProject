using Photography.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Photography.Core.ViewModels.Photo
{
    using static Common.EntityConstants.PhotoEntity;
    using static Common.EntityValidationMessages;
    public class AddPhotoViewModel
    {
        public AddPhotoViewModel()
        {
            // in this way we set default value for UploadedAt
            this.UploadedAt = DateTime.UtcNow.ToString(Common.ApplicationConstants.EntityDateFormat);
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = PhotoTitleRequiredMessage)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string? Description { get; set; }


        [Required(ErrorMessage = PhotoUploadedAtRequiredMessage)]
        public string UploadedAt { get; set; }


        [Required(ErrorMessage = PhotoImageUrlRequiredMessage)]
        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength)]
        public string ImageUrl { get; set; } = null!;
        
        public ICollection<CategoryViewModel> Categories { get; set; } = new HashSet<CategoryViewModel>();


        [Required]
        public bool IsPrivate { get; set; }

        public Guid? UserOwnerId { get; set; }

        public ICollection<UserViewModel> UserPhotoOwners { get; set; } = new HashSet<UserViewModel>();

        public ICollection<int> SelectedCategoryIds { get; set; }= new HashSet<int>();
    }
}
