using System.ComponentModel.DataAnnotations;

namespace Photography.Core.ViewModels.UserProfile
{
    using static Common.EntityConstants.User;
    using static Common.EntityValidationMessages;
    public class UserProfileViewModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(FirstNameMaxLength, MinimumLength=FirstNameMinLength, ErrorMessage = LengthMessage)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = LengthMessage)]
        
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = LengthMessage)]
        public string Phone { get; set; } = null!;
    }
}
