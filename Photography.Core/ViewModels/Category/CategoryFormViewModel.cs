using System.ComponentModel.DataAnnotations;

namespace Photography.Core.ViewModels.Category
{
    using static Common.EntityConstants.Category;
    using static Common.EntityValidationMessages.Category;

    public class CategoryFormViewModel
    {
        public string Id { get; set; } = null!;

        [Required(ErrorMessage =CategoryNameRequiredMessage )]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;
    }
}
