using System.Data;

namespace MHome.Data.Models.Common
{
    public static class FurnitureValidationConstants
    {
        public const string NameIsRequiredError = "Furniture name is required!";
        public const string NameMinLengthError = "Furniture name must be at least 3 symbols!";
        public const string NameMaxLengthError = "Furniture name must no more than 50 symbols!";
        public const string DescriptionIsRequiredError = "Furniture description is required!";
        public const string DescriptionMinLengthError = "Furniture description must be at least 10 symbols!";
        public const string DescriptionMaxLengthError = "Furniture description must no more than 100 symbols!";
        public const string DimensionsAreRequiredError = "Furniture dimensions are required!";
        public const string DimensionsMinLengthError = "Furniture dimensions must be at least 5 symbols!";
        public const string DimensionsMaxLengthError = "Furniture dimensions must no more than 40 symbols!";

        public const int NameMaxLength = 50;
        public const int NameMinLength = 3;
        public const int DescriptionMinLength = 10;
        public const int DescriptionMaxLength = 100;
        public const int DimensionsMinLength = 5;
        public const int DimensionsMaxLength = 40;
        public const int StockQuantityMinValue = 0;
        public const int StockQuantityMaxValue = int.MaxValue;

        public const string PriceMinValue = "0";
        public const string PriceMaxValue = "79228162514264337593543950335";
    }
}