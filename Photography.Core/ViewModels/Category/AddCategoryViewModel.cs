using System.ComponentModel.DataAnnotations;

namespace Photography.Core.ViewModels.Category
{
    using static Common.EntityConstants.Category;
    using static Common.EntityValidationMessages.Category;

    public class AddCategoryViewModel
    {
        [Required(ErrorMessage =CategoryNameRequiredMessage )]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
