namespace Photography.Common
{
    public static class EntityConstants
    {
        public static class CategoryEntity
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 20;
        }

        public static class PhotoEntity
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 20;
            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 100;
        }

        public static class UserEntity
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 20;
            public const int LastNameMinLength = 3;
            public const int LastNameMaxLength = 20;

        }


    }
}
