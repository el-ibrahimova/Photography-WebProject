namespace Photography.Core.ViewModels.UserProfile
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityConstants.User;
    using static Common.EntityValidationMessages;

    public class UserProfileViewModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(FirstNameMaxLength,
            MinimumLength = FirstNameMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Първо име")]
        public string FirstName { get; set; } = null!;


        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(LastNameMaxLength,
            MinimumLength = LastNameMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } = null!;


        [Required(ErrorMessage = RequiredMessage)]
        [RegularExpression(PhoneNumberRegexFormat,ErrorMessage =PhoneNumberFormat)]
        [Display(Name = "Телефонен номер")]
        public string Phone { get; set; } = null!;
    }
}
