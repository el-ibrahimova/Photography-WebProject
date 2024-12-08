namespace Photography.Common
{
    public static class EntityValidationMessages
    {
        public const string RegisterUsernameFormatMessage =
            "Полето {0} трябва да съдържа от {2} до {1} символа.";

        public const string LengthMessage = "Полето {0} трябва да съдържа от {2} до {1} символа";
        public const string RequiredMessage = "Полето {0} е задължително";
        public const string PhoneNumberFormat = "Полето трябва да съдържа 10 цифри";

        public const string BrandNameExist = "Тази марка вече съществува";
    }
}
