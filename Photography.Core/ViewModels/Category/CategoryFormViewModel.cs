using System.ComponentModel.DataAnnotations;

namespace Photography.Core.ViewModels.Category
{
    using static Common.EntityConstants.Category;
    using static Common.EntityValidationMessages;

    public class CategoryFormViewModel
    {
        public string Id { get; set; } = null!;

        [Required(ErrorMessage =RequiredMessage )]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = LengthMessage)]
        public string Name { get; set; } = null!;
    }
}
