namespace Photography.Common
{
    public static class EntityConstants
    {
        public static class CategoryEntity
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 30;
        }

        public static class PhotoEntity
        {
            public const int TagUserMinLength = 3;
            public const int TagUserMaxLength = 20;
            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 100;
            public const int ImageUrlMinLength = 10;
            public const int ImageUrlMaxLength = 100;
            public const int RatingMinValue = 0;
            public const int RatingMaxValue = 10;
        }

        public static class UserEntity
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
            public const int PhoneNumberMaxLength = 20;
        }

        public static class OfferEntity
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 30;
        }

        public static class OrderEntity
        {
            public const int NoteMinLength = 3;
            public const int NoteMaxLength = 200;
        }

        public static class Photographer
        {
            public const int BrandNameMinLength = 2;
            public const int BrandNameMaxLength = 30;
        }

    }
}
