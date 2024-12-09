namespace Photography.Core.ViewModels.Photo
{
    using System.ComponentModel.DataAnnotations;
    using static Common.ApplicationConstants;
    using static Common.EntityConstants.Photo;
    using static Common.EntityValidationMessages;
    public class AddPhotoViewModel
    {
        public AddPhotoViewModel()
        {
            // in this way we set default value for UploadedAt
            this.UploadedAt = DateTime.UtcNow.ToString(EntityDateFormat);
        }


        [StringLength(TagUserMaxLength, 
            MinimumLength = TagUserMinLength, 
            ErrorMessage = LengthMessage)]
        [Display(Name = "Отбелязване на потребител")]
        public string? TagUser { get; set; }


        [StringLength(DescriptionMaxLength, 
            MinimumLength = DescriptionMinLength, 
            ErrorMessage = LengthMessage)]
        [Display(Name = "Описание")]
        public string? Description { get; set; }


        [Required(ErrorMessage = RequiredMessage)]
        public string UploadedAt { get; set; }


        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ImageUrlMaxLength, 
            MinimumLength = ImageUrlMinLength, 
            ErrorMessage = LengthMessage)]
        [Display(Name = "URL на снимката")]
        public string ImageUrl { get; set; } = null!;

       public bool IsPrivate { get; set; }

        public string UserOwnerId { get; set; } 
        public string? PhotographerId { get; set; }

        public ICollection<UserViewModel> UserPhotoOwners { get; set; } = new HashSet<UserViewModel>();
        public ICollection<Guid> SelectedCategoryIds { get; set; } = new HashSet<Guid>(); 
        public ICollection<CategoryViewModel> Categories { get; set; } = new HashSet<CategoryViewModel>();
    }
}
