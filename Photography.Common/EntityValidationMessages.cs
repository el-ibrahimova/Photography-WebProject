namespace Photography.Common
{
    public static class EntityValidationMessages
    {
        public static class Photo
        {
            public const string PhotoUploadedAtRequiredMessage = "Датата на качване на снимката е задължителна.";
            public const string PhotoImageUrlRequiredMessage = "URL адрес на снимката е задължителен.";
        }

        public static class Category
        {
            public const string CategoryNameRequiredMessage = "Името на категорията е задължително.";
        }

        public static class PhotoShoot
        {
            public const string PhotoShootNameRequiredMessage = "Името на фотосесията е задължително.";
            public const string PhotoShootImageUrlRequiredMessage = "URL адрес на снимката е задължително.";
            public const string PhotoShootDescriptionRequiredMessage = "Описанието на фотосесията е задължително.";

            public const string PhotoShootCreatedAtRequiredMessage =
                "Датата на създаване на фотосесията е задължителна.";
        }
    }
}
