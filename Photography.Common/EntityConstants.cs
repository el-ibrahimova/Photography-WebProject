namespace Photography.Common
{
    public static class EntityConstants
    {
        public static class Category
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 30;
        }

        public static class Photo
        {
            public const int TagUserMinLength = 3;
            public const int TagUserMaxLength = 20;
            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 200;
            public const int ImageUrlMinLength = 10;
            public const int ImageUrlMaxLength = 100;
            public const string DateRegexFormat = @"^(\d{2})\.(\d{4})\s\-\s(\d{2})\.(\d{4})$";
        }

        public static class User
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 20;
            public const int LastNameMinLength = 3;
            public const int LastNameMaxLength = 20;
            public const int UsernameMinLength = 5;
            public const int UsernameMaxLength = 30;
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 20;
            public const int EmailMinLength = 10;
            public const int EmailMaxLength = 25;
            public const int PhoneNumberMinLength = 8;
            public const int PhoneNumberMaxLength = 15;
        }
        public static class Photographer
        {
            public const int BrandNameMinLength = 2;
            public const int BrandNameMaxLength = 30;
        }

        public static class PhotoShoot
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 20;
            public const int ImageUrlMinLength = 10;
            public const int ImageUrlMaxLength = 100;
            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 100;
        }
    }
}
