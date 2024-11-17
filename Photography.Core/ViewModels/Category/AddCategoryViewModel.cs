using System.ComponentModel.DataAnnotations;

namespace Photography.Core.ViewModels.Category
{
    using static Common.EntityConstants.Category;
    using static Common.EntityValidationMessages;
    public class AddCategoryViewModel
    {
        public string Id { get; set; } = null!;

        [Required(ErrorMessage =CategoryNameRequiredMessage )]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;
    }
}
