namespace Photography.Core.ViewModels.Photographer
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationMessages;
    using static Common.EntityConstants.Photographer;

    public class AddPhotographerViewModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(BrandNameMaxLength, 
            MinimumLength = BrandNameMinLength, 
            ErrorMessage = LengthMessage)]
        [Display(Name = "Име на марката")]
        public string BrandName { get; set; } = null!;
    }
}
