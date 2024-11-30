using System.ComponentModel.DataAnnotations;
using static Photography.Common.EntityValidationMessages;
using static Photography.Common.EntityConstants.Photographer;

namespace Photography.Core.ViewModels.Photographer
{
    public class AddPhotographerViewModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(BrandNameMaxLength, MinimumLength = BrandNameMinLength, ErrorMessage = LengthMessage)]
        [Display(Name ="Име на марката")]
        public string BrandName { get; set; } = null!;
    }
}
