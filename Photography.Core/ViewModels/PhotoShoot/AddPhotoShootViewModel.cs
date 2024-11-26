using Photography.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Photography.Core.ViewModels.PhotoShoot
{
    using static Common.ApplicationConstants;
    using static Common.EntityConstants.PhotoShoot;
    using static Common.EntityValidationMessages.PhotoShoot;
    public class AddPhotoShootViewModel
    {
        public AddPhotoShootViewModel()
        {
            this.CreatedAt = DateTime.UtcNow.ToString(EntityDateFormat);

        }
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = PhotoShootNameRequiredMessage)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = PhotoShootImageUrlRequiredMessage)]
        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength)]
        public string ImageUrl1 { get; set; } = null!;

        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength)]
        public string? ImageUrl2 { get; set; }

        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength)]
        public string? ImageUrl3 { get; set; }

        [Required(ErrorMessage = PhotoShootDescriptionRequiredMessage)]
        [StringLength(DescriptionMaxLength, MinimumLength=DescriptionMinLength)]
        public string Description { get; set; } = null!;

    
        [Required(ErrorMessage =PhotoShootCreatedAtRequiredMessage)]
        public string CreatedAt { get; set; }

        public ICollection<PhotoShootParticipant> Participants { get; set; } = new HashSet<PhotoShootParticipant>();
    }
}
