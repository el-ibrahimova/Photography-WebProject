namespace Photography.Core.ViewModels.Category
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityConstants.Category;
    using static Common.EntityValidationMessages;

    public class CategoryFormViewModel
    {
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLength, 
            MinimumLength = NameMinLength, 
            ErrorMessage = LengthMessage)]
        [Display(Name = "Име")]
        public string Name { get; set; } = null!;
    }
}
