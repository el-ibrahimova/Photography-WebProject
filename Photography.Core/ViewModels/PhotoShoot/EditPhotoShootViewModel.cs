using System.ComponentModel.DataAnnotations;

namespace Photography.Core.ViewModels.PhotoShoot
{
    using static Common.EntityConstants.PhotoShoot;
    using static Common.EntityValidationMessages;
    public class EditPhotoShootViewModel
    {
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength,ErrorMessage = LengthMessage)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength, ErrorMessage = LengthMessage)]
        public string ImageUrl1 { get; set; } = null!;

        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength, ErrorMessage = LengthMessage)]
        public string? ImageUrl2 { get; set; }

        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength, ErrorMessage = LengthMessage)]
        public string? ImageUrl3 { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = LengthMessage)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        public string PhotographerId { get; set; } = null!;
    }
}
