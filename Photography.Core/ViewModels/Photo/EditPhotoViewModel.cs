using System.ComponentModel.DataAnnotations;

namespace Photography.Core.ViewModels.Photo
{
    using static Common.EntityConstants.Photo;
    using static Common.EntityValidationMessages.Photo;
    using static Common.ApplicationConstants;
    public class EditPhotoViewModel
    {
        public EditPhotoViewModel()
        {
            this.UploadedAt = DateTime.UtcNow.ToString(EntityDateFormat);
        }
        public Guid Id { get; set; }

        [StringLength(TagUserMaxLength, MinimumLength = TagUserMinLength)]
        public string? TagUser { get; set; } 

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

        public string UserOwnerId { get; set; }

        public ICollection<UserViewModel> UserPhotoOwners { get; set; } = new HashSet<UserViewModel>();

        public ICollection<Guid> SelectedCategoryIds { get; set; } = new HashSet<Guid>();
    }
}
