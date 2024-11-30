using Photography.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Photography.Core.ViewModels.PhotoShoot
{
    using static Common.ApplicationConstants;
    using static Common.EntityConstants.PhotoShoot;
    using static Common.EntityValidationMessages;
    public class AddPhotoShootViewModel
    {
        public AddPhotoShootViewModel()
        {
            this.CreatedAt = DateTime.UtcNow.ToString(EntityDateFormat);

        }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength,ErrorMessage = LengthMessage)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength, ErrorMessage = LengthMessage)]
        public string ImageUrl1 { get; set; } = null!;

        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength, ErrorMessage = LengthMessage)]
        public string? ImageUrl2 { get; set; }

        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength, ErrorMessage=LengthMessage)]
        public string? ImageUrl3 { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DescriptionMaxLength, MinimumLength=DescriptionMinLength, ErrorMessage = LengthMessage)]
        public string Description { get; set; } = null!;


        [Required(ErrorMessage = RequiredMessage)]
        public string CreatedAt { get; set; } 
    }
}
